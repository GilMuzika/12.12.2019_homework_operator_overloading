namespace _12._12._2019_homework_operator_overloading
{
    partial class MainForm
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
            this.btnAddCamp = new System.Windows.Forms.Button();
            this.cmbCamps1 = new System.Windows.Forms.ComboBox();
            this.cmbCamps2 = new System.Windows.Forms.ComboBox();
            this.pnlCampsHolder = new System.Windows.Forms.Panel();
            this.lblMouseLocation = new System.Windows.Forms.Label();
            this.btnEnableIntersect = new System.Windows.Forms.Button();
            this.btnTreatCamps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCamp
            // 
            this.btnAddCamp.Location = new System.Drawing.Point(12, 10);
            this.btnAddCamp.Name = "btnAddCamp";
            this.btnAddCamp.Size = new System.Drawing.Size(90, 23);
            this.btnAddCamp.TabIndex = 0;
            this.btnAddCamp.Text = "Add new camp";
            this.btnAddCamp.UseVisualStyleBackColor = true;
            this.btnAddCamp.Click += new System.EventHandler(this.btnAddCamp_Click);
            // 
            // cmbCamps1
            // 
            this.cmbCamps1.FormattingEnabled = true;
            this.cmbCamps1.Location = new System.Drawing.Point(558, 12);
            this.cmbCamps1.Name = "cmbCamps1";
            this.cmbCamps1.Size = new System.Drawing.Size(150, 21);
            this.cmbCamps1.TabIndex = 1;
            this.cmbCamps1.Tag = "cmb1";
            // 
            // cmbCamps2
            // 
            this.cmbCamps2.FormattingEnabled = true;
            this.cmbCamps2.Location = new System.Drawing.Point(714, 12);
            this.cmbCamps2.Name = "cmbCamps2";
            this.cmbCamps2.Size = new System.Drawing.Size(150, 21);
            this.cmbCamps2.TabIndex = 2;
            this.cmbCamps2.Tag = "cmb2";
            // 
            // pnlCampsHolder
            // 
            this.pnlCampsHolder.Location = new System.Drawing.Point(12, 39);
            this.pnlCampsHolder.Name = "pnlCampsHolder";
            this.pnlCampsHolder.Size = new System.Drawing.Size(990, 399);
            this.pnlCampsHolder.TabIndex = 3;
            // 
            // lblMouseLocation
            // 
            this.lblMouseLocation.AutoSize = true;
            this.lblMouseLocation.Location = new System.Drawing.Point(280, 15);
            this.lblMouseLocation.Name = "lblMouseLocation";
            this.lblMouseLocation.Size = new System.Drawing.Size(35, 13);
            this.lblMouseLocation.TabIndex = 4;
            this.lblMouseLocation.Text = "label1";
            // 
            // btnEnableIntersect
            // 
            this.btnEnableIntersect.Location = new System.Drawing.Point(108, 10);
            this.btnEnableIntersect.Name = "btnEnableIntersect";
            this.btnEnableIntersect.Size = new System.Drawing.Size(94, 23);
            this.btnEnableIntersect.TabIndex = 5;
            this.btnEnableIntersect.Text = "Clear all camps";
            this.btnEnableIntersect.UseVisualStyleBackColor = true;
            // 
            // btnTreatCamps
            // 
            this.btnTreatCamps.Location = new System.Drawing.Point(870, 11);
            this.btnTreatCamps.Name = "btnTreatCamps";
            this.btnTreatCamps.Size = new System.Drawing.Size(49, 23);
            this.btnTreatCamps.TabIndex = 6;
            this.btnTreatCamps.Text = "השווה";
            this.btnTreatCamps.UseVisualStyleBackColor = true;
            this.btnTreatCamps.Click += new System.EventHandler(this.btnTreatCamps_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 450);
            this.Controls.Add(this.btnTreatCamps);
            this.Controls.Add(this.btnEnableIntersect);
            this.Controls.Add(this.lblMouseLocation);
            this.Controls.Add(this.pnlCampsHolder);
            this.Controls.Add(this.cmbCamps2);
            this.Controls.Add(this.cmbCamps1);
            this.Controls.Add(this.btnAddCamp);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddCamp;
        private System.Windows.Forms.ComboBox cmbCamps1;
        private System.Windows.Forms.ComboBox cmbCamps2;
        private System.Windows.Forms.Panel pnlCampsHolder;
        private System.Windows.Forms.Label lblMouseLocation;
        private System.Windows.Forms.Button btnEnableIntersect;
        private System.Windows.Forms.Button btnTreatCamps;
    }
}

