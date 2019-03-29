using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PPOL.MailObjects;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PPOL_Outlook
{
    sealed class OutlookZippedAttachment : IAttachmentInfo
    {
        readonly Outlook.Attachment[] attachments;
        string zipFilePath;
        public OutlookZippedAttachment(Outlook.Attachment[] attachments)
        {
            this.attachments = attachments;
        }
        public string FileName
        {
            get { return "attachments.zip"; }
        }

        public System.IO.Stream OpenRead()
        {
            if (string.IsNullOrWhiteSpace(zipFilePath) && attachments!=null)
            {
                zipFilePath = System.IO.Path.GetTempFileName();
                var saveTo = System.IO.Path.GetTempFileName();
                System.IO.File.Delete(zipFilePath);
                using (var zip = new Ionic.Zip.ZipFile(zipFilePath))
                {
                    foreach(var a in attachments)
                    {
                        a.SaveAsFile(saveTo);
                        var fileName = a.FileName;
                        var buf = System.IO.File.ReadAllBytes(saveTo);
                        using (var ms = System.IO.File.Open(saveTo, System.IO.FileMode.Open))
                        {
                            zip.AddEntry(fileName, ms);
                            zip.Save();
                        }
                        System.IO.File.Delete(saveTo);
                    }
                }
            }
            return System.IO.File.Open(zipFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
        }

        public void Dispose()
        {
            if (attachments != null)
            {
                foreach (var a in attachments)
                {
                    Marshal.ReleaseComObject(a);
                }
            }
            if (!string.IsNullOrWhiteSpace(zipFilePath))
            {
                System.IO.File.Delete(zipFilePath);
                zipFilePath = null;
            }
            
        }
    }
}
