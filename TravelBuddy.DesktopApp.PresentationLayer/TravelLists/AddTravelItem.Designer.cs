namespace TravelBuddy.DesktopApp.PresentationLayer.TravelLists
{
    partial class AddTravelItem
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.descriptionInput = new System.Windows.Forms.TextBox();
            this.isTakenInput = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opis";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(85, 19);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(208, 20);
            this.nameInput.TabIndex = 4;
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(85, 45);
            this.descriptionInput.Multiline = true;
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.Size = new System.Drawing.Size(208, 47);
            this.descriptionInput.TabIndex = 5;
            // 
            // isTakenInput
            // 
            this.isTakenInput.AutoSize = true;
            this.isTakenInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isTakenInput.Location = new System.Drawing.Point(24, 129);
            this.isTakenInput.Name = "isTakenInput";
            this.isTakenInput.Size = new System.Drawing.Size(108, 21);
            this.isTakenInput.TabIndex = 7;
            this.isTakenInput.Text = "Uzeto na put";
            this.isTakenInput.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(235, 201);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(157, 36);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Dodaj na popis";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddTravelItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 261);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.isTakenInput);
            this.Controls.Add(this.descriptionInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddTravelItem";
            this.Text = "TravelBuddy - Dodaj na popis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox descriptionInput;
        private System.Windows.Forms.CheckBox isTakenInput;
        private System.Windows.Forms.Button addButton;
    }
}