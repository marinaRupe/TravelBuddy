﻿namespace TravelBuddy.DesktopApp.PresentationLayer
{
    partial class TravelList
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
            this.travelListBox = new System.Windows.Forms.ListBox();
            this.addTravelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // travelListBox
            // 
            this.travelListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.travelListBox.FormattingEnabled = true;
            this.travelListBox.ItemHeight = 20;
            this.travelListBox.Location = new System.Drawing.Point(39, 119);
            this.travelListBox.Name = "travelListBox";
            this.travelListBox.Size = new System.Drawing.Size(289, 144);
            this.travelListBox.TabIndex = 0;
            // 
            // addTravelBtn
            // 
            this.addTravelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTravelBtn.Location = new System.Drawing.Point(329, 23);
            this.addTravelBtn.Name = "addTravelBtn";
            this.addTravelBtn.Size = new System.Drawing.Size(137, 39);
            this.addTravelBtn.TabIndex = 2;
            this.addTravelBtn.Text = "Dodaj putovanje";
            this.addTravelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista putovanja";
            // 
            // TravelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addTravelBtn);
            this.Controls.Add(this.travelListBox);
            this.Name = "TravelList";
            this.Text = "TravelList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox travelListBox;
        private System.Windows.Forms.Button addTravelBtn;
        private System.Windows.Forms.Label label1;
    }
}