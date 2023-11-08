using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ContactBook
{
    public partial class MainForm : Form
    {
        private List<Contact> contactsList = new List<Contact>();
        private bool IsEditButtonShown = false;
        private bool IsDeleteButtonShown = false;

        public MainForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contactsGridView.DoubleBuffered(true); // anchor is used for contactsGridView (for resizing) which causes some screen tearing, Double Buffering makes the screen tearing less visible
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // DatabaseManager.FillData();
            contactsList = DatabaseManager.GetContacts();
            RefreshDataGridView();
        }

        private void contactsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (contactsGridView.SelectedRows.Count == 1)
            {
                btnEditContact.Enabled = true;
                toolTipEdit.SetToolTip(this.btnEditContact, "");
            }
            else if (contactsGridView.SelectedRows.Count == 0)
            {
                btnEditContact.Enabled = false;
                toolTipEdit.SetToolTip(this.btnEditContact, "Please select a contact you want to Edit.");
            }
            else
            {
                btnEditContact.Enabled = false;
                toolTipEdit.SetToolTip(this.btnEditContact, "You can only Edit one contact at a time.");
            }

            if (contactsGridView.SelectedRows.Count > 0)
            {
                btnDeleteContact.Enabled = true;
                toolTipDelete.SetToolTip(this.btnDeleteContact, "");
            }
            else
            {
                btnDeleteContact.Enabled = false;
                toolTipDelete.SetToolTip(this.btnDeleteContact, "Please select the contacts you want to Delete.");
            }
        }

        private void RefreshDataGridView()
        {
            contactsGridView.DataSource = typeof(List<>);
            contactsGridView.DataSource = contactsList.ToList();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContactForm addContactWindow = new AddContactForm();

            DialogResult result = addContactWindow.ShowDialog();

            if (result == DialogResult.OK)
            {
                Contact newContact = addContactWindow.GetNewContact();

                if (newContact != null)
                {
                    contactsList.Add(newContact);
                    RefreshDataGridView();
                }
            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            if (contactsGridView.SelectedRows.Count > 0)
            {
                Contact selectedContact = (Contact)contactsGridView.SelectedRows[0].DataBoundItem;

                AddContactForm editContactForm = new AddContactForm();
                editContactForm.SetContact(selectedContact);

                DialogResult result = editContactForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Contact updatedContact = editContactForm.GetEditedContact();
                    if (updatedContact != null)
                    {
                        int index = contactsList.FindIndex(c => c.ContactID == updatedContact.ContactID);
                        if (index != -1)
                        {
                            contactsList[index] = updatedContact;
                        }
                        RefreshDataGridView();
                    }
                }
            }
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            if (contactsGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected contact(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in contactsGridView.SelectedRows)
                    {
                        Contact selectedContact = row.DataBoundItem as Contact;
                        if (selectedContact != null)
                        {
                            DatabaseManager.DeleteContact(selectedContact.ContactID);
                            contactsList.Remove(selectedContact);
                        }
                    }

                    RefreshDataGridView();
                }
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            ShowToolTipOnHover(this.btnEditContact, this.toolTipEdit, ref IsEditButtonShown, e);
            ShowToolTipOnHover(this.btnDeleteContact, this.toolTipDelete, ref IsDeleteButtonShown, e);
        }

        private void ShowToolTipOnHover(Control control, ToolTip toolTip, ref bool isShown, MouseEventArgs e)
        {
            Control ctrl = this.GetChildAtPoint(e.Location);

            if (ctrl == control && !isShown)
            {
                string tipstring = toolTip.GetToolTip(control);
                toolTip.Show(tipstring, control, -70, -25);
                isShown = true;
            }
            else if (ctrl != control)
            {
                toolTip.Hide(control);
                isShown = false;
            }
        }
    }
}
