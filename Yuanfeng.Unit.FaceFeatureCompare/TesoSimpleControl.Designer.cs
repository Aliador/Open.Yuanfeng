﻿namespace Yuanfeng.Unit.FaceFeatureCompare
{
    partial class TesoSimpleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesoSimpleControl));
            this.axstdfcectl1 = new AxcriterionLib.Axstdfcectl();
            ((System.ComponentModel.ISupportInitialize)(this.axstdfcectl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axstdfcectl1
            // 
            this.axstdfcectl1.Enabled = true;
            this.axstdfcectl1.Location = new System.Drawing.Point(0, 0);
            this.axstdfcectl1.Name = "axstdfcectl1";
            this.axstdfcectl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axstdfcectl1.OcxState")));
            this.axstdfcectl1.Size = new System.Drawing.Size(640, 480);
            this.axstdfcectl1.TabIndex = 0;
            // 
            // TesoSimpleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axstdfcectl1);
            this.Name = "TesoSimpleControl";
            this.Size = new System.Drawing.Size(640, 480);
            ((System.ComponentModel.ISupportInitialize)(this.axstdfcectl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxcriterionLib.Axstdfcectl axstdfcectl1;
    }
}
