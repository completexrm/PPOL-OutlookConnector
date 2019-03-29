using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using System.Windows.Forms;

namespace PPOL
{
    public partial class ContactCreateFrm : Form
    {
        ServicesUtil serviceUtil = null;
        MiscService.contactOptions contactOptions = null;
        MiscService.contactCategory[] contactCategory = null;
        MiscService.contactPhoneType[] contactPhoneType = null;
        MiscService.contactAddressType[] contactAddressType = null;
        MiscService.baseMessage[] notes = null;
        String mailSubject = "";
        String mailBody = "";

        public ContactCreateFrm()
        {
            InitializeComponent();
            serviceUtil = new ServicesUtil();
            loadComboData();
        }

        public void setContactNotes(String mailSubject, String mailBody,String emailAddress)
        {
            this.mailBody = mailBody;
            this.mailSubject = mailSubject;
            this.txtEmail.Text = emailAddress;
            
        }

        private void ContactCreateFrm_Load(object sender, EventArgs e)
        {

        }

        private void loadComboData()
        {
            try
            {

                MiscService.MiscAPIService local = new MiscService.MiscAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/MiscAPI";

                contactOptions = local.getContactOptions(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                if (contactOptions != null)
                {
                    contactCategory = contactOptions.categoryList;
                    contactPhoneType = contactOptions.phoneTypeList;
                    contactAddressType = contactOptions.addressTypeList;



                    if (contactCategory != null)
                    {
                        
                        for (int i = 0; i < contactCategory.Length; i++)
                        {
                            MiscService.contactCategory category = contactCategory[i];
                            this.cbClassification.Items.Add(category.name);
                        }
                        cbClassification.SelectedIndex = 0;
                    }
                    if (contactPhoneType != null)
                    {
                       
                        for (int i = 0; i < contactPhoneType.Length; i++)
                        {
                            MiscService.contactPhoneType phone = contactPhoneType[i];
                            this.cbPhone1.Items.Add(phone.name);
                            this.cbPhone2.Items.Add(phone.name);
                            this.cbPhone3.Items.Add(phone.name);
                        }
                        cbPhone1.SelectedIndex = 0;
                        cbPhone2.SelectedIndex = 0;
                        cbPhone3.SelectedIndex = 0;
                    }
                    if (contactAddressType != null)
                    {
                        
                        for (int i = 0; i < contactAddressType.Length; i++)
                        {
                            MiscService.contactAddressType address = contactAddressType[i];
                            this.cbAddress.Items.Add(address.name);
                        }
                        cbAddress.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                MiscService.MiscAPIService local = new MiscService.MiscAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/MiscAPI";

                if (this.txtFirstName.Text.Trim() == "")
                {
                    MessageBox.Show("First name is a required field.");
                    this.txtFirstName.Focus();
                }
                else if (this.txtLastName.Text.Trim() == "")
                {
                    MessageBox.Show("Last name is a required field.");
                    this.txtLastName.Focus();
                }
                else if (this.txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("Email is a required field.");
                    this.txtEmail.Focus();
                }
                else
                {
                    MiscService.contact psn = new MiscService.contact();

                    psn.firstName = txtFirstName.Text;
                    psn.lastName = txtLastName.Text;

                    if (txtEmail.Text.Trim() != "")
                    {
                        MiscService.cpEmail[] emailList = new MiscService.cpEmail[1];
                        MiscService.cpEmail email = new MiscService.cpEmail();

                        email.emailAddr = txtEmail.Text;
                        email.olLastUpdateDate = new DateTime();

                        emailList[0] = email;

                        psn.emails = emailList;

                    }

                    if (txtPhone1.Text.Trim() != "" || txtPhone2.Text.Trim() != "" || txtPhone3.Text.Trim() != null)
                    {
                        int phoneCount = 0;
                        int phone1Index = 0;
                        int phone2Index = 0;
                        int phone3Index = 0;

                        if (txtPhone1.Text.Trim() != "")
                        {
                            phoneCount = phoneCount + 1;
                            phone1Index = cbPhone1.SelectedIndex;
                        }
                        if (txtPhone2.Text.Trim() != "")
                        {
                            phoneCount = phoneCount + 1;
                            phone2Index = cbPhone2.SelectedIndex;
                        }
                        if (txtPhone3.Text.Trim() != "")
                        {
                            phoneCount = phoneCount + 1;
                            phone3Index = cbPhone3.SelectedIndex;
                        }
                        MiscService.cpPhone[] phoneList = new MiscService.cpPhone[phoneCount];
                        for (int i = 0; i < phoneCount; i++)
                        {
                            MiscService.cpPhone phone = new MiscService.cpPhone();

                            MiscService.contactPhoneType PhoneType = null;
                            if (i == 0)
                            {
                                PhoneType = contactPhoneType[phone1Index];
                                phone.phoneNumber = txtPhone1.Text;
                                phone.phoneExtension = txtExt1.Text;
                            }
                            else if (i == 1)
                            {
                                PhoneType = contactPhoneType[phone2Index];
                                phone.phoneNumber = txtPhone2.Text;
                                phone.phoneExtension = txtExt2.Text;
                            }
                            else if (i == 2)
                            {
                                PhoneType = contactPhoneType[phone3Index];
                                phone.phoneNumber = txtPhone3.Text;
                                phone.phoneExtension = txtExt3.Text;
                            }
                            phone.phoneLineType = PhoneType.key;
                            phone.olLastUpdateDate = new DateTime();
                            phoneList[i] = phone;
                        }
                        if (phoneCount > 0)
                        {
                            psn.phones = phoneList;
                        }

                        if (txtAddress1.Text.Trim() != "")
                        {
                            MiscService.cpAddress[] addressList = new MiscService.cpAddress[1];
                            int addressIndex = cbAddress.SelectedIndex;
                            MiscService.contactAddressType addressType = contactAddressType[addressIndex];
                            MiscService.cpAddress address = new MiscService.cpAddress();
                            address.addressType = addressType.key;
                            address.addrLine1 = txtAddress1.Text;
                            address.addrLine2 = txtAddress2.Text;
                            address.city = txtCity.Text;
                            address.state = txtState.Text;
                            address.postalCode = txtZip.Text;
                            address.country = txtCountry.Text;
                            address.olLastUpdateDate = new DateTime();
                            addressList[0] = address;
                            psn.addresses = addressList;
                        }

                    }
                    if (mailBody != "")
                    {
                        notes = new MiscService.baseMessage[1];
                        MiscService.baseMessage note = new MiscService.baseMessage();
                        note.msgTitle = mailSubject;
                        note.msgTxt = mailBody;
                        note.olLastUpdateDate = new DateTime();
                        notes[0] = note;
                        psn.notes = notes;
                    }

                    int categoryIndex = this.cbClassification.SelectedIndex;
                    if (categoryIndex >= 0)
                    {
                        MiscService.contactCategory cat = contactCategory[categoryIndex];
                        psn.contactClassification = cat.key;
                    }


                    MiscService.contact psn1 = local.createContact(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), psn, true);
                    MessageBox.Show("Contact was created successfully.");


                    this.Close();
                }

            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }
    }
}
