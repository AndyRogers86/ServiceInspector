using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class TestApp : Form
    {
        private Core.ServiceInspector SI;
        private DataTable methodParamsTable = new DataTable();

        public TestApp()
        {
            InitializeComponent();

            methodParamsTable.Columns.Add("ParamName");
            methodParamsTable.Columns.Add("ParamType");
            methodParamsTable.Columns.Add("ParamValue");
        }
        
        private void btnGetMethods_Click(object sender, EventArgs e)
        {
            try
            {
                AddToOutput("Getting Methods...");

                SI = new Core.ServiceInspector(new Uri(txtServiceLocation.Text));

                List<MethodInfo> methods = SI.GetMethods();

                ddlMethods.Items.Clear();

                ddlMethods.Enabled = (methods.Count > 0 ? true : false);

                foreach (MethodInfo mi in methods)
                {
                    ddlMethods.Items.Add(mi.Name);
                }

                AddToOutput("Get Methods Sucessful");
            }
            catch (Exception _ex)
            {
                AddToOutput("Error Getting Methods - " + _ex.ToString());
            }
        }

        private void ddlMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddToOutput("Getting Parameters...");

                List<ParameterInfo> methodParams = SI.GetMethodParameters(ddlMethods.SelectedItem.ToString());

                methodParamsTable.Rows.Clear();

                foreach (ParameterInfo pi in methodParams)
                {
                    DataRow dr = methodParamsTable.NewRow();

                    dr["ParamName"] = pi.Name;
                    dr["ParamType"] = pi.ParameterType.ToString();
                    dr["ParamValue"] = string.Empty;

                    methodParamsTable.Rows.Add(dr);
                }

                grdParams.DataSource = methodParamsTable;

                AddToOutput("Geting Parameters Sucessful");
            }
            catch (Exception _ex)
            {
                AddToOutput("Error Getting Parameters - " + _ex.ToString());
            }
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                AddToOutput("Invoking Method '" + ddlMethods.SelectedItem.ToString() + "'...");

                List<object> methodParams = new List<object>();

                foreach (DataGridViewRow dgvr in grdParams.Rows)
                {
                    methodParams.Add(dgvr.Cells["ParamValue"].Value.ToString());
                }

                object result = SI.RunMethod(ddlMethods.SelectedItem.ToString(), methodParams);

                AddToOutput("Invoking Method '" + ddlMethods.SelectedItem.ToString() + "' Result = " + result.ToString());

                AddToOutput("Invoking Method '" + ddlMethods.SelectedItem.ToString() + "' Sucessful");
            }
            catch (Exception _ex)
            {
                AddToOutput("Error Invoking Method '" + ddlMethods.SelectedItem.ToString() + "' - " + _ex.ToString());
            }
        }

        private void AddToOutput(string value)
        {
            lbOutput.Items.Insert(0, value);

            if (lbOutput.Items.Count > 1000)
            {
                lbOutput.Items.RemoveAt(1001);
            }
        }
    }
}
