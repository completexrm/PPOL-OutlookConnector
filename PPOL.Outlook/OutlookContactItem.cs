using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PPOL.MailObjects;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PPOL_Outlook
{
    sealed class OutlookContactItem : IContactItem
    {
        Outlook._ContactItem _contactItem;
        public OutlookContactItem(Outlook._ContactItem item)
        {
            _contactItem = item;
        }

        public IEnumerable<string> EmailAddresses
        {
            get 
            {
                if (_contactItem.Email1AddressType == "SMTP")
                {
                    yield return _contactItem.Email1Address;
                }

                if (_contactItem.Email2AddressType == "SMTP")
                {
                    yield return _contactItem.Email2Address;
                }

                if (_contactItem.Email3AddressType == "SMTP")
                {
                    yield return _contactItem.Email3Address;
                }
                
            }

        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(_contactItem);
        }
    }
}
