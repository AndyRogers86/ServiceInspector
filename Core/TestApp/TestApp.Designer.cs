namespace TestApp
{
    partial class TestApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServiceLocation = new System.Windows.Forms.TextBox();
            this.lblServiceLocation = new System.Windows.Forms.Label();
            this.btnGetMethods = new System.Windows.Forms.Button();
            this.ddlMethods = new System.Windows.Forms.ComboBox();
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.grdParams = new System.Windows.Forms.DataGridView();
            this.btnInvoke = new System.Windows.Forms.Button();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdParams)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServiceLocation
            // 
            this.txtServiceLocation.Location = new System.Drawing.Point(106, 10);
            this.txtServiceLocation.Name = "txtServiceLocation";
            this.txtServiceLocation.Size = new System.Drawing.Size(466, 20);
            this.txtServiceLocation.TabIndex = 0;
            this.txtServiceLocation.Text = "http://localhost:64216/TestService.asmx";
            // 
            // lblServiceLocation
            // 
            this.lblServiceLocation.AutoSize = true;
            this.lblServiceLocation.Location = new System.Drawing.Point(13, 13);
            this.lblServiceLocation.Name = "lblServiceLocation";
            this.lblServiceLocation.Size = new System.Drawing.Size(87, 13);
            this.lblServiceLocation.TabIndex = 1;
            this.lblServiceLocation.Text = "Service Location";
            // 
            // btnGetMethods
            // 
            this.btnGetMethods.Location = new System.Drawing.Point(16, 37);
            this.btnGetMethods.Name = "btnGetMethods";
            this.btnGetMethods.Size = new System.Drawing.Size(556, 23);
            this.btnGetMethods.TabIndex = 2;
            this.btnGetMethods.Text = "Get Service Methods";
            this.btnGetMethods.UseVisualStyleBackColor = true;
            this.btnGetMethods.Click += new System.EventHandler(this.btnGetMethods_Click);
            // 
            // ddlMethods
            // 
            this.ddlMethods.Enabled = false;
            this.ddlMethods.FormattingEnabled = true;
            this.ddlMethods.Location = new System.Drawing.Point(16, 67);
            this.ddlMethods.Name = "ddlMethods";
            this.ddlMethods.Size = new System.Drawing.Size(556, 21);
            this.ddlMethods.TabIndex = 3;
            this.ddlMethods.SelectedIndexChanged += new System.EventHandler(this.ddlMethods_SelectedIndexChanged);
            // 
            // lbOutput
            // 
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.Location = new System.Drawing.Point(16, 336);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(556, 173);
            this.lbOutput.TabIndex = 4;
            // 
            // grdParams
            // 
            this.grdParams.AllowUserToAddRows = false;
            this.grdParams.AllowUserToDeleteRows = false;
            this.grdParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.ParamType,
            this.ParamValue});
            this.grdParams.Location = new System.Drawing.Point(16, 94);
            this.grdParams.Name = "grdParams";
            this.grdParams.Size = new System.Drawing.Size(556, 207);
            this.grdParams.TabIndex = 5;
            // 
            // btnInvoke
            // 
            this.btnInvoke.Location = new System.Drawing.Point(16, 307);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(556, 23);
            this.btnInvoke.TabIndex = 6;
            this.btnInvoke.Text = "Invoke";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // ParamName
            // 
            this.ParamName.DataPropertyName = "ParamName";
            this.ParamName.HeaderText = "Name";
            this.ParamName.Name = "ParamName";
            this.ParamName.Width = 150;
            // 
            // ParamType
            // 
            this.ParamType.DataPropertyName = "ParamType";
            this.ParamType.HeaderText = "Type";
            this.ParamType.Name = "ParamType";
            this.ParamType.Width = 150;
            // 
            // ParamValue
            // 
            this.ParamValue.DataPropertyName = "ParamValue";
            this.ParamValue.HeaderText = "Value";
            this.ParamValue.Name = "ParamValue";
            this.ParamValue.Width = 210;
            // 
            // TestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 526);
            this.Controls.Add(this.btnInvoke);
            this.Controls.Add(this.grdParams);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.ddlMethods);
            this.Controls.Add(this.btnGetMethods);
            this.Controls.Add(this.lblServiceLocation);
            this.Controls.Add(this.txtServiceLocation);
            this.Name = "TestApp";
            this.Text = "TestApp";
            ((System.ComponentModel.ISupportInitialize)(this.grdParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceLocation;
        private System.Windows.Forms.Label lblServiceLocation;
        private System.Windows.Forms.Button btnGetMethods;
        private System.Windows.Forms.ComboBox ddlMethods;
        private System.Windows.Forms.ListBox lbOutput;
        private System.Windows.Forms.DataGridView grdParams;
        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamValue;
    }
}

