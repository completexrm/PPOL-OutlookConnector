using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPOL
{
    public partial class OrgCreateFrm : Form
    {

        String mailSubject = "";
        String mailBody = "";
        ServicesUtil serviceUtil = null;
        MiscService.customerOptions customerOptions = null;
        MiscService.customerCategory[] customerCategory = null;
        MiscService.customerPhoneType[] customerPhoneType = null;
        MiscService.customerAddressType[] customerAddressType = null;
        MiscService.customerBusinessline[] customerBusinessline = null;
        MiscService.baseMessage[] notes = null;

        public OrgCreateFrm()
        {
            InitializeComponent();
            serviceUtil = new ServicesUtil();
            loadComboData();
        }

        private void OrgCreateFrm_Load(object sender, EventArgs e)
        {

        }
        
        public void setCustomerNotes(String mailSubject, String mailBody, String emailAddress)
        {
            this.mailBody = mailBody;
            this.mailSubject = mailSubject;
            this.txtEmail.Text = emailAddress;

        }

        private void loadComboData()
        {
            try
            {

                MiscService.MiscAPIService local = new MiscService.MiscAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/MiscAPI";

                customerOptions = local.getCustomerOptions(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                if (customerOptions != null)
                {
                    customerCategory = customerOptions.categoryList;
                    customerPhoneType = customerOptions.phoneTypeList;
                    customerAddressType = customerOptions.addressTypeList;
                    customerBusinessline = customerOptions.businesslineList;


                    if (customerCategory != null)
                    {

                        for (int i = 0; i < customerCategory.Length; i++)
                        {
                            MiscService.customerCategory category = customerCategory[i];
                            this.cbClassification.Items.Add(category.name);
                        }
                        cbClassification.SelectedIndex = 0;
                    }
                    if (customerBusinessline != null)
                    {

                        for (int i = 0; i < customerBusinessline.Length; i++)
                        {
                            MiscService.customerBusinessline businessline = customerBusinessline[i];
                            this.cbBusiness.Items.Add(businessline.name);
                        }
                        cbBusiness.SelectedIndex = 0;
                    }
                    if (customerPhoneType != null)
                    {

                        for (int i = 0; i < customerPhoneType.Length; i++)
                        {
                            MiscService.customerPhoneType phone = customerPhoneType[i];
                            this.cbPhone1.Items.Add(phone.name);
                            this.cbPhone2.Items.Add(phone.name);
                            this.cbPhone3.Items.Add(phone.name);
                        }
                        cbPhone1.SelectedIndex = 0;
                        cbPhone2.SelectedIndex = 0;
                        cbPhone3.SelectedIndex = 0;
                    }
                    if (customerAddressType != null)
                    {

                        for (int i = 0; i < customerAddressType.Length; i++)
                        {
                            MiscService.customerAddressType address = customerAddressType[i];
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
                
                if (this.txtCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Customer name is a required field.");
                    this.txtCustomer.Focus();
                }
                
                else if (this.txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("Email is a required field.");
                    this.txtEmail.Focus();
                }
                else
                {
                    MiscService.organization org = new MiscService.organization();

                    org.displayName =  txtCustomer.Text;
                    

                    if (txtEmail.Text.Trim() != "")
                    {
                        MiscService.cpEmail[] emailList = new MiscService.cpEmail[1];
                        MiscService.cpEmail email = new MiscService.cpEmail();

                        email.emailAddr = txtEmail.Text;
                        email.olLastUpdateDate = new DateTime();
                       
                        emailList[0] = email;
                        
                        org.emails = emailList;
                        
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
                            MiscService.customerPhoneType PhoneType = null;
                            if (i == 0)
                            {
                                PhoneType = customerPhoneType[phone1Index];
                                phone.phoneNumber = txtPhone1.Text;
                                phone.phoneExtension = txtExt1.Text;
                            }
                            else if (i == 1)
                            {
                                PhoneType = customerPhoneType[phone2Index];
                                phone.phoneNumber = txtPhone2.Text;
                                phone.phoneExtension = txtExt2.Text;
                            }
                            else if (i == 2)
                            {
                                PhoneType = customerPhoneType[phone3Index];
                                phone.phoneNumber = txtPhone3.Text;
                                phone.phoneExtension = txtExt3.Text;
                            }
                            phone.phoneLineType = PhoneType.key;
                            phone.olLastUpdateDate = new DateTime();
                            phoneList[i] = phone;
                        }
                        if (phoneCount > 0)
                        {
                            org.phones = phoneList;
                        }

                        if (txtAddress1.Text.Trim() != "")
                        {
                            MiscService.cpAddress[] addressList = new MiscService.cpAddress[1];
                            int addressIndex = cbAddress.SelectedIndex;
                            MiscService.customerAddressType addressType = customerAddressType[addressIndex];
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
                            org.addresses = addressList;
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
                        org.notes = notes;
                    }

                    int categoryIndex = this.cbClassification.SelectedIndex;
                    if (categoryIndex >= 0)
                    {
                        MiscService.customerCategory cat = customerCategory[categoryIndex];
                        org.customerCategory = cat.key;
                    }

                    int businesslineIndex = this.cbBusiness.SelectedIndex;
                    if (businesslineIndex >= 0)
                    {
                        MiscService.customerBusinessline businessline = customerBusinessline[businesslineIndex];
                        org.businessLine = businessline.key;
                    }

                    if (txtWebsite.Text.Trim() != "http://")
                        org.url = txtWebsite.Text.Trim();

                    MiscService.organization org1 = local.createOrganization(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), org);

                    MessageBox.Show("Organization was created successfully.");

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
