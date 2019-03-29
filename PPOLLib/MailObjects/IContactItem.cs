using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPOL.MailObjects
{
    public interface IContactItem : IDisposable
    {
        IEnumerable<string> EmailAddresses { get; }
    }
}
