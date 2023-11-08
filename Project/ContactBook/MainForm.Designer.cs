using System.Windows.Forms;

namespace ContactBook
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
            this.components = new System.ComponentModel.Container();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.contactsGridView = new System.Windows.Forms.DataGridView();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.toolTipEdit = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDelete = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.contactsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contactsGridView
            // 
            this.contactsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.contactsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactsGridView.Location = new System.Drawing.Point(12, 12);
            this.contactsGridView.Name = "contactsGridView";
            this.contactsGridView.RowHeadersWidth = 51;
            this.contactsGridView.RowTemplate.Height = 24;
            this.contactsGridView.Size = new System.Drawing.Size(776, 353);
            this.contactsGridView.TabIndex = 1;
            this.contactsGridView.ReadOnly = true;
            this.contactsGridView.SelectionChanged += new System.EventHandler(this.contactsGridView_SelectionChanged);
            this.contactsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.contactsGridView.AllowUserToOrderColumns = true;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(190, 392);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(119, 46);
            this.btnAddContact.TabIndex = 0;
            this.btnAddContact.Text = "Add";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            this.btnAddContact.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom));
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(327, 392);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(120, 46);
            this.btnEditContact.TabIndex = 2;
            this.btnEditContact.Text = "Edit";
            this.btnEditContact.UseVisualStyleBackColor = true;
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            this.btnEditContact.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom));
            this.btnEditContact.Enabled = false;
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Location = new System.Drawing.Point(464, 392);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(120, 46);
            this.btnDeleteContact.TabIndex = 3;
            this.btnDeleteContact.Text = "Delete";
            this.btnDeleteContact.UseVisualStyleBackColor = true;
            this.btnDeleteContact.Click += new System.EventHandler(this.btnDeleteContact_Click);
            this.btnDeleteContact.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom));
            this.btnDeleteContact.Enabled = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteContact);
            this.Controls.Add(this.btnEditContact);
            this.Controls.Add(this.contactsGridView);
            this.Controls.Add(this.btnAddContact);
            this.Name = "MainForm";
            this.Text = "Contact Book";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.contactsGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.DataGridView contactsGridView;
        private Button btnEditContact;
        private Button btnDeleteContact;
        private ToolTip toolTipEdit;
        private ToolTip toolTipDelete;
    }
}

