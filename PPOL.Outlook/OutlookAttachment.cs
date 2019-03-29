using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PPOL.MailObjects;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PPOL_Outlook
{
    sealed class OutlookAttachment : IAttachmentInfo
    {
        readonly Outlook.Attachment _attachment;
        string tempAttachmentPath;
        public OutlookAttachment(Outlook.Attachment attachment)
        {
            _attachment = attachment;
        }

        public string FileName
        {
            get 
            {
                return _attachment.FileName;
            }
        }

        public System.IO.Stream OpenRead()
        {
            if (string.IsNullOrEmpty(tempAttachmentPath))
            {
                tempAttachmentPath = System.IO.Path.GetTempFileName();
                _attachment.SaveAsFile(tempAttachmentPath);
            }
            return System.IO.File.Open(tempAttachmentPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
        }

        public void Dispose()
        {
            Marshal.ReleaseComObject(_attachment);
            if (!string.IsNullOrEmpty(tempAttachmentPath))
            {
                System.IO.File.Delete(tempAttachmentPath);
            }
        }
    }
}
