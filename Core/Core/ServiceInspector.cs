using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Takes a WSDL file and allowes dynamic interaction with the service without a need for a web referance
    /// </summary>
    public class ServiceInspector
    {
        #region Varibles
        private Uri _serviceLocation;
        private List<MethodInfo> _methodInfo = new List<MethodInfo>();
        private Type _service;
        #endregion

        #region Contructor
        /// <summary>
        /// Creates a new Service Inspector from a given Uri of a WSDL
        /// </summary>
        /// <param name="serviceLocation">The location of the services WSDL file</param>
        public ServiceInspector(Uri serviceLocation)
        {
            if (serviceLocation.Query == string.Empty)
            {
                UriBuilder uriB = new UriBuilder(serviceLocation);

                uriB.Query = "WSDL";

                serviceLocation = uriB.Uri;
            }

            _serviceLocation = serviceLocation;

            WebRequest wsdlWebRequest = WebRequest.Create(serviceLocation);
            Stream wsdlRequestStream = wsdlWebRequest.GetResponse().GetResponseStream();

            //Get the ServiceDescription from the WSDL file
            ServiceDescription sd = ServiceDescription.Read(wsdlRequestStream);
            string sdName = sd.Services[0].Name;

            ServiceDescriptionImporter sdImport = new ServiceDescriptionImporter();
            sdImport.AddServiceDescription(sd, String.Empty, String.Empty);
            sdImport.ProtocolName = "Soap";
            sdImport.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

            CodeNamespace codeNameSpace = new CodeNamespace();
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
            codeCompileUnit.Namespaces.Add(codeNameSpace);

            ServiceDescriptionImportWarnings warnings = sdImport.Import(codeNameSpace, codeCompileUnit);

            if (warnings == 0)
            {
                StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
                Microsoft.CSharp.CSharpCodeProvider prov = new Microsoft.CSharp.CSharpCodeProvider();

                prov.GenerateCodeFromNamespace(codeNameSpace, stringWriter, new CodeGeneratorOptions());

                //Compile the assembly
                string[] assemblyReferences = new string[2] { "System.Web.Services.dll", "System.Xml.dll" };
                CompilerParameters param = new CompilerParameters(assemblyReferences);

                param.GenerateExecutable = false;
                param.GenerateInMemory = true;
                param.TreatWarningsAsErrors = false;
                param.WarningLevel = 4;

                CompilerResults results = new CompilerResults(new TempFileCollection());
                results = prov.CompileAssemblyFromDom(param, codeCompileUnit);

                Assembly assembly = results.CompiledAssembly;
                _service = assembly.GetType(sdName);

                _methodInfo.Clear();

                foreach (MethodInfo mi in _service.GetMethods())
                {
                    if (mi.Name == "Discover")
                    {
                        break;
                    }

                    _methodInfo.Add(mi);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a list of all of the methods on the service
        /// </summary>
        /// <returns>A list of all the methods</returns>
        public List<MethodInfo> GetMethods()
        {
            return _methodInfo;
        }

        /// <summary>
        /// Checks if the service has a specific method
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <param name="method">The MethodInfo of the method</param>
        /// <returns>True = Service contains method, False = Service does not contain method</returns>
        public bool HasMethod(string methodName, out MethodInfo method)
        {
            bool foundMethod = false;

            method = null;

            foreach (MethodInfo mi in _methodInfo)
            {
                if (mi.Name == methodName)
                {
                    method = mi;
                    foundMethod = true;

                    break;
                }
            }

            return foundMethod;
        }

        /// <summary>
        /// Gets a list of the parameters of a give method
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <returns>A list of parameters for the given method</returns>
        public List<ParameterInfo> GetMethodParameters(string methodName)
        {
            MethodInfo method;

            if (HasMethod(methodName, out method))
            {
                return method.GetParameters().ToList();
            }

            return new List<ParameterInfo>();
        }

        /// <summary>
        /// Runs a given method on the web service
        /// </summary>
        /// <param name="methodName">The name of the method</param>
        /// <param name="methodParameters">The parameters for the method</param>
        /// <returns>The object returned by the method</returns>
        public object RunMethod(string methodName, List<object> methodParameters)
        {
            object result = null;

            MethodInfo method;

            if (HasMethod(methodName, out method))
            {
                List<ParameterInfo> paramList = method.GetParameters().ToList();

                if (methodParameters.Count != paramList.Count)
                {
                    throw new Exception("No method '" + methodName + "' which takes " + methodParameters.Count.ToString() + " parameters");
                }

                List<object> paramsToPass = new List<object>();
                int index = 0;

                foreach(ParameterInfo pi in paramList)
                {
                    paramsToPass.Add(Convert.ChangeType(methodParameters[index], pi.ParameterType));

                    index++;
                }

                Object serviceInstance = Activator.CreateInstance(_service);

                return method.Invoke(serviceInstance, paramsToPass.ToArray());
            }

            return result;
        }
        #endregion
    }
}
