using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ContactBook
{
    public partial class AddContactForm : Form
    {
        private Contact contactToEdit;
        private Contact newContact;

        public Contact GetNewContact()
        {
            return newContact;
        }
        public Contact GetEditedContact()
        {
            return contactToEdit;
        }

        public AddContactForm()
        {
            InitializeComponent();
        }

        public void SetContact(Contact contact)
        {
            this.contactToEdit = contact;

            textBoxFullName.Text = contact.FullName;
            textBoxPhoneNumber.Text = contact.PhoneNumber;
            datePickerBirthDate.Value = contact.BirthDate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                if (contactToEdit == null)
                {
                    int newContactId = DatabaseManager.InsertContact(textBoxFullName.Text, textBoxPhoneNumber.Text, datePickerBirthDate.Value);

                    newContact = new Contact
                    {
                        ContactID = newContactId,
                        FullName = textBoxFullName.Text,
                        PhoneNumber = textBoxPhoneNumber.Text,
                        BirthDate = datePickerBirthDate.Value.Date
                    };
                }
                else
                {
                    DatabaseManager.EditContact(contactToEdit.ContactID, textBoxFullName.Text, textBoxPhoneNumber.Text, datePickerBirthDate.Value);

                    contactToEdit.FullName = textBoxFullName.Text;
                    contactToEdit.PhoneNumber = textBoxPhoneNumber.Text;
                    contactToEdit.BirthDate = datePickerBirthDate.Value.Date;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool IsValidInput()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBoxFullName.Text))
            {
                toolTipFullName.Show("This field is required", textBoxFullName, 0, 20);
                isValid = false;
            }
            else
            {
                toolTipFullName.Hide(textBoxFullName);
            }

            if (string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text))
            {
                toolTipPhoneNumber.Show("This field is required", textBoxPhoneNumber, 0, 20);
                isValid = false;
            }
            else
            {
                toolTipPhoneNumber.Hide(textBoxPhoneNumber);

                if (!IsNumeric(textBoxPhoneNumber.Text))
                {
                    toolTipPhoneNumber.Show("Phone number must contain only numeric digits", textBoxPhoneNumber, 0, 20);
                    isValid = false;
                }
            }

            if (datePickerBirthDate.Value == DateTime.MinValue)
            {
                isValid = false;
            }

            return isValid;
        }

        private bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[0-9+\(\)\s]+$");
        }
    }
}
