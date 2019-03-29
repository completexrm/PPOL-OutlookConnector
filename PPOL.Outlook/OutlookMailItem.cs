using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PPOL.MailObjects;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace PPOL_Outlook
{
    sealed class OutlookMailItem : IMailItem
    {
        readonly Outlook._MailItem _mailItem;
        Outlook.Recipients recipients;
        public OutlookMailItem(Outlook._MailItem mailItem)
        {
            _mailItem = mailItem;
        }

        public string Subject
        {
            get { return _mailItem.Subject; }
        }
        public void Send()
        {
            _mailItem.Send();
        }
        public bool Sent
        {
            get { return _mailItem.Sent; }
        }
        public object ComObject
        {
            get { return _mailItem; }
        }
        public string Body
        {
            get { return _mailItem.Body; }
        }

        public string HTMLBody
        {
            get { return _mailItem.HTMLBody; }
        }

        public DateTime SentOn
        {
            get { return _mailItem.SentOn; }
        }

        public string SenderEmailAddress
        {
            get 
            {
                string address = "";
                try
                {
                    var addressEntry = (Outlook.AddressEntry)((dynamic)_mailItem).Sender;
                    if (addressEntry != null)
                    {
                        address = GetEmailAddress(addressEntry);
                        Marshal.ReleaseComObject(addressEntry);
                    }
                }
                catch { }
                return string.IsNullOrWhiteSpace(address) ? _mailItem.SenderEmailAddress : address;
            }
        }

        public string SenderName
        {
            get { return _mailItem.SenderName; }
        }
        Outlook.Recipients Recipients
        {
            get
            {
                if (this.recipients == null)
                {
                    this.recipients = _mailItem.Recipients;
                }
                return this.recipients;
            }
        }
        public void AddRecipient(string emailAddress, MailRecipientKind kind)
        {
            var recipients = Recipients;
            var r = recipients.Add(emailAddress);
            if (kind != MailRecipientKind.Unknown)
            {
                r.Type = (int)kind;
            }
            r.Resolve();
            Marshal.ReleaseComObject(r);
        }

        public void Dispose()
        {
            if (recipients != null)
            {
                Marshal.ReleaseComObject(recipients);
                recipients = null;
            }
            Marshal.ReleaseComObject(this._mailItem);
        }

        static string GetEmailAddress(Outlook.AddressEntry entry)
        {
            string emailAddress = "";
            switch (entry.AddressEntryUserType)
            {
                case Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry:
                case Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry:
                    try
                    {
                        var user = entry.GetExchangeUser();
                        if (user != null)
                        {
                            emailAddress = user.PrimarySmtpAddress;
                            Marshal.ReleaseComObject(user);
                        }
                    }
                    catch { }
                    break;
                case Outlook.OlAddressEntryUserType.olSmtpAddressEntry:
                    emailAddress = entry.Address;
                    break;

            }
            return emailAddress;
        }

        public IEnumerable<string> GetRecipientAddresses()
        {
            for (var idx = 1; idx <= Recipients.Count; idx++)
            {
                var r = Recipients[idx];
                var addressEntry = r.AddressEntry;
                string emailAddress="";
                if (addressEntry != null)
                {
                    emailAddress = GetEmailAddress(addressEntry);
                    Marshal.ReleaseComObject(addressEntry);
                }
                if (string.IsNullOrEmpty(emailAddress))
                {
                    emailAddress = r.Address;
                }
                Marshal.ReleaseComObject(r);
                if (!string.IsNullOrEmpty(emailAddress) && emailAddress.Contains('@'))
                {
                    yield return emailAddress;
                }
                
            }
        }

        public IAttachmentInfo GetSingleAttachment()
        {
            var comAttachments = _mailItem.Attachments;
            var attachments = new List<Outlook.Attachment>();
            for (var idx = 1; idx <= comAttachments.Count; idx++)
            {
                var a = comAttachments[idx];
                if (IsAttachment(a))
                {
                    attachments.Add(a);
                }
                else
                {
                    Marshal.ReleaseComObject(a);
                }
            }
            Marshal.ReleaseComObject(comAttachments);
            IAttachmentInfo attachInfo;
            switch (attachments.Count)
            {
                case 0:
                    attachInfo = null;
                    break;
                case 1:
                    attachInfo = new OutlookAttachment(comAttachments[0]);
                    break;
                default:
                    attachInfo = new OutlookZippedAttachment(attachments.ToArray());
                    break;
            }
            return attachInfo;
        }
        
        static bool IsAttachment(Outlook.Attachment a)
        {
            var propertyAccessor = a.PropertyAccessor;
            if (propertyAccessor != null)
            {
                try
                {
                    // PR_ATTACH_CONTENT_ID_A
                    var propValue = propertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E") as string;
                    return string.IsNullOrEmpty(propValue);
                }
                catch { }
                finally
                {
                    Marshal.ReleaseComObject(propertyAccessor);
                }
            }
            return a.Type == Outlook.OlAttachmentType.olByValue;
        }
        public IEnumerable<IAttachmentInfo> GetAttachments()
        {
            var attachments = _mailItem.Attachments;
            for (var idx = 1; idx <= attachments.Count; idx++)
            {
                var a = attachments[idx];
                if (IsAttachment(a))
                {
                    yield return new OutlookAttachment(a);
                }
                else
                {
                    Marshal.ReleaseComObject(a);
                }
            }
            Marshal.ReleaseComObject(attachments);
        }
    }

}
