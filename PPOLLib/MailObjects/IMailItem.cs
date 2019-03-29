using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPOL.MailObjects
{
    public interface IMailItem : IDisposable
    {
        string Subject { get; }
        string Body { get; }
        string HTMLBody { get; }
        bool Sent { get; }
        DateTime SentOn { get; }
        string SenderEmailAddress { get; }
        string SenderName { get; }
        void AddRecipient(string emailAddress, MailRecipientKind kind);
        IEnumerable<string> GetRecipientAddresses();
        void Send();
        object ComObject { get; }
        IEnumerable<IAttachmentInfo> GetAttachments();
        IAttachmentInfo GetSingleAttachment();
    }
    public interface IAttachmentInfo : IDisposable
    {
        string FileName { get; }
        System.IO.Stream OpenRead();
    }
    
    public enum MailRecipientKind
    {
        Unknown=0,
        To=1,
        Cc=2,
        Bcc=3
    }
}
