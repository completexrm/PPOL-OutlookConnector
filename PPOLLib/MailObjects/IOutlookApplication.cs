using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPOL.MailObjects
{
    public interface IOutlookApplication
    {
        IMailItem GetCurrentInspectorItem();
        IEnumerable<IContactItem> FindContactsByEmailDisplayName(string displayName);
        IEnumerable<string> GetPrimarySmtpAddresses();
        //IWin32Window CurrentWindow { get; }
    }

    public interface IOutlookWindowHost
    {
        IWin32Window CurrentWindow { get; }
    }
}
