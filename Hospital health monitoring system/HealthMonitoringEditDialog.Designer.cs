namespace HospitalHealthMonitoringSystem
{
    partial class HealthMonitoringEditDialog
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
            this.tcParameters = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOxygenConcentration = new System.Windows.Forms.Label();
            this.txtBreathingDuration = new HospitalHealthMonitoringSystem.NumericTextBox();
            this.txtBPM = new HospitalHealthMonitoringSystem.NumericTextBox();
            this.txtAirPressure = new HospitalHealthMonitoringSystem.NumericTextBox();
            this.txtBedId = new HospitalHealthMonitoringSystem.NumericTextBox();
            this.txtOxygenConcentration = new HospitalHealthMonitoringSystem.NumericTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcParameters.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcParameters
            // 
            this.tcParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcParameters.Controls.Add(this.tabPage1);
            this.tcParameters.Location = new System.Drawing.Point(9, 8);
            this.tcParameters.Name = "tcParameters";
            this.tcParameters.SelectedIndex = 0;
            this.tcParameters.Size = new System.Drawing.Size(635, 207);
            this.tcParameters.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblOxygenConcentration);
            this.tabPage1.Controls.Add(this.txtBreathingDuration);
            this.tabPage1.Controls.Add(this.txtBPM);
            this.tabPage1.Controls.Add(this.txtAirPressure);
            this.tabPage1.Controls.Add(this.txtBedId);
            this.tabPage1.Controls.Add(this.txtOxygenConcentration);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ventilator device parameters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Breathing duration (miliseconds):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Breaths per minute:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Air pressure:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bed ID:";
            // 
            // lblOxygenConcentration
            // 
            this.lblOxygenConcentration.AutoSize = true;
            this.lblOxygenConcentration.Location = new System.Drawing.Point(37, 74);
            this.lblOxygenConcentration.Name = "lblOxygenConcentration";
            this.lblOxygenConcentration.Size = new System.Drawing.Size(131, 13);
            this.lblOxygenConcentration.TabIndex = 10;
            this.lblOxygenConcentration.Text = "Oxygen concentration (%):";
            // 
            // txtBreathingDuration
            // 
            this.txtBreathingDuration.AllowDecimalNotation = true;
            this.txtBreathingDuration.Location = new System.Drawing.Point(473, 71);
            this.txtBreathingDuration.Name = "txtBreathingDuration";
            this.txtBreathingDuration.Size = new System.Drawing.Size(100, 20);
            this.txtBreathingDuration.TabIndex = 4;
            // 
            // txtBPM
            // 
            this.txtBPM.Location = new System.Drawing.Point(473, 111);
            this.txtBPM.Name = "txtBPM";
            this.txtBPM.Size = new System.Drawing.Size(100, 20);
            this.txtBPM.TabIndex = 3;
            // 
            // txtAirPressure
            // 
            this.txtAirPressure.AllowDecimalNotation = true;
            this.txtAirPressure.Location = new System.Drawing.Point(174, 108);
            this.txtAirPressure.Name = "txtAirPressure";
            this.txtAirPressure.Size = new System.Drawing.Size(100, 20);
            this.txtAirPressure.TabIndex = 2;
            // 
            // txtBedId
            // 
            this.txtBedId.Location = new System.Drawing.Point(174, 30);
            this.txtBedId.Name = "txtBedId";
            this.txtBedId.ReadOnly = true;
            this.txtBedId.Size = new System.Drawing.Size(100, 20);
            this.txtBedId.TabIndex = 0;
            // 
            // txtOxygenConcentration
            // 
            this.txtOxygenConcentration.AllowDecimalNotation = true;
            this.txtOxygenConcentration.Location = new System.Drawing.Point(174, 71);
            this.txtOxygenConcentration.Name = "txtOxygenConcentration";
            this.txtOxygenConcentration.Size = new System.Drawing.Size(100, 20);
            this.txtOxygenConcentration.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(567, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(486, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // HealthMonitoringEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 253);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcParameters);
            this.Name = "HealthMonitoringEditDialog";
            this.ShowIcon = false;
            this.Text = "Edit parameters";
            this.tcParameters.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcParameters;
        private System.Windows.Forms.TabPage tabPage1;
        private NumericTextBox txtOxygenConcentration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOxygenConcentration;
        private NumericTextBox txtBreathingDuration;
        private NumericTextBox txtBPM;
        private NumericTextBox txtAirPressure;
        private NumericTextBox txtBedId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}