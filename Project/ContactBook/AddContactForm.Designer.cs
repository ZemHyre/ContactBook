namespace ContactBook
{
    partial class AddContactForm
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
            this.components = new System.ComponentModel.Container();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.datePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.toolTipFullName = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipPhoneNumber = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBirthDate = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(26, 77);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(238, 22);
            this.textBoxFullName.TabIndex = 0;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(26, 155);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(238, 22);
            this.textBoxPhoneNumber.TabIndex = 2;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(23, 57);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(136, 16);
            this.labelFullName.TabIndex = 5;
            this.labelFullName.Text = "Enter Contact\'s Name";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(23, 135);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(189, 16);
            this.labelPhoneNumber.TabIndex = 7;
            this.labelPhoneNumber.Text = "Enter Contact\'s Phone Number";
            // 
            // labelBirthDate
            // 
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Location = new System.Drawing.Point(23, 207);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(157, 16);
            this.labelBirthDate.TabIndex = 8;
            this.labelBirthDate.Text = "Enter Contact\'s Birth Date";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(26, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 36);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 36);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // datePickerBirthDate
            // 
            this.datePickerBirthDate.Location = new System.Drawing.Point(26, 227);
            this.datePickerBirthDate.Name = "datePickerBirthDate";
            this.datePickerBirthDate.Size = new System.Drawing.Size(238, 22);
            this.datePickerBirthDate.TabIndex = 11;
            // 
            // AddContactForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 363);
            this.Controls.Add(this.datePickerBirthDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.labelBirthDate);
            this.Name = "AddContactForm";
            this.Text = "Add a New Contact";
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.DateTimePicker datePickerBirthDate;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTipFullName;
        private System.Windows.Forms.ToolTip toolTipPhoneNumber;
        private System.Windows.Forms.ToolTip toolTipBirthDate;
    }
}