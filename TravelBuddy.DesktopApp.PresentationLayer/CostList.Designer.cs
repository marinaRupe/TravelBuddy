﻿namespace TravelBuddy.DesktopApp.PresentationLayer
{
    partial class CostList
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
            this.addButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(25, 218);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(103, 38);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Troškovi";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(25, 58);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(394, 134);
            this.listBox.TabIndex = 3;
            // 
            // CostList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 280);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Name = "CostList";
            this.Text = "TravelBuddy - Troškovi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox;
    }
}