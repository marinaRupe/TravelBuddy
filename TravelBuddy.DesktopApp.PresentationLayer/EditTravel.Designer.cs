﻿namespace TravelBuddy.DesktopApp.PresentationLayer
{
    partial class EditTravel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.travelNameInput = new System.Windows.Forms.TextBox();
            this.descriptionInput = new System.Windows.Forms.TextBox();
            this.dateStartPicker = new System.Windows.Forms.DateTimePicker();
            this.dateEndPicker = new System.Windows.Forms.DateTimePicker();
            this.budgetInput = new System.Windows.Forms.NumericUpDown();
            this.currencyListBox = new System.Windows.Forms.ListBox();
            this.saveTravelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.budgetInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Početak";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Završetak";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Budžet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Valuta";
            // 
            // travelNameInput
            // 
            this.travelNameInput.Location = new System.Drawing.Point(115, 9);
            this.travelNameInput.Name = "travelNameInput";
            this.travelNameInput.Size = new System.Drawing.Size(208, 20);
            this.travelNameInput.TabIndex = 14;
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(115, 35);
            this.descriptionInput.Multiline = true;
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.Size = new System.Drawing.Size(208, 47);
            this.descriptionInput.TabIndex = 15;
            // 
            // dateStartPicker
            // 
            this.dateStartPicker.Location = new System.Drawing.Point(114, 97);
            this.dateStartPicker.Name = "dateStartPicker";
            this.dateStartPicker.Size = new System.Drawing.Size(200, 20);
            this.dateStartPicker.TabIndex = 16;
            // 
            // dateEndPicker
            // 
            this.dateEndPicker.Location = new System.Drawing.Point(114, 133);
            this.dateEndPicker.Name = "dateEndPicker";
            this.dateEndPicker.Size = new System.Drawing.Size(200, 20);
            this.dateEndPicker.TabIndex = 17;
            // 
            // budgetInput
            // 
            this.budgetInput.Location = new System.Drawing.Point(114, 166);
            this.budgetInput.Name = "budgetInput";
            this.budgetInput.Size = new System.Drawing.Size(146, 20);
            this.budgetInput.TabIndex = 18;
            // 
            // currencyListBox
            // 
            this.currencyListBox.FormattingEnabled = true;
            this.currencyListBox.Location = new System.Drawing.Point(114, 204);
            this.currencyListBox.Name = "currencyListBox";
            this.currencyListBox.Size = new System.Drawing.Size(146, 43);
            this.currencyListBox.TabIndex = 19;
            // 
            // saveTravelBtn
            // 
            this.saveTravelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTravelBtn.Location = new System.Drawing.Point(227, 281);
            this.saveTravelBtn.Name = "saveTravelBtn";
            this.saveTravelBtn.Size = new System.Drawing.Size(157, 36);
            this.saveTravelBtn.TabIndex = 20;
            this.saveTravelBtn.Text = "Spremi promjene";
            this.saveTravelBtn.UseVisualStyleBackColor = true;
            this.saveTravelBtn.Click += new System.EventHandler(this.saveTravelBtn_Click);
            // 
            // EditTravel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 329);
            this.Controls.Add(this.saveTravelBtn);
            this.Controls.Add(this.currencyListBox);
            this.Controls.Add(this.budgetInput);
            this.Controls.Add(this.dateEndPicker);
            this.Controls.Add(this.dateStartPicker);
            this.Controls.Add(this.descriptionInput);
            this.Controls.Add(this.travelNameInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditTravel";
            this.Text = "TravelBuddy - Uredi putovanje";
            ((System.ComponentModel.ISupportInitialize)(this.budgetInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox travelNameInput;
        private System.Windows.Forms.TextBox descriptionInput;
        private System.Windows.Forms.DateTimePicker dateStartPicker;
        private System.Windows.Forms.DateTimePicker dateEndPicker;
        private System.Windows.Forms.NumericUpDown budgetInput;
        private System.Windows.Forms.ListBox currencyListBox;
        private System.Windows.Forms.Button saveTravelBtn;
    }
}