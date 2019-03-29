using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PPOL.MailObjects;

namespace PPOL
{
    public class ClassFactory : IDisposable
    {
        static ClassFactory _instance = new ClassFactory();
        public static ClassFactory Instance
        {
            get { return _instance; }
        }
        public IOutlookApplication Outlook { get; set; }
        public IOutlookWindowHost WindowHost { get; set; }
        EmailAttachProcessor processor;
        public void ConnectionProblem(Exception ex)
        {
            var message = "Cannot connect to the PlanPlus Online Application, please check if your account information is correct. If you continue to experience problems contact support at http://www.planplusonline.com/support.";
            message += Environment.NewLine+Environment.NewLine + ex.Message;
            Show( new Exception( message,ex));

        }
        public void Show(Exception ex)
        {
            IWin32Window currentWnd = null;
            if (WindowHost != null)
            {
                currentWnd = WindowHost.CurrentWindow;
            }
            if (currentWnd == null)
            {
                MessageBox.Show(ex.Message, "PlanPlus Online Outlook Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(currentWnd, ex.Message, "PlanPlus Online Outlook Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public EmailAttachProcessor EmailAttachProcessor
        {
            get
            {
                if (processor == null)
                {
                    if (Outlook == null)
                    {
                        throw new InvalidOperationException("Initialize Outlook property first");
                    }
                    processor = new EmailAttachProcessor(Outlook);
                }
                return processor;
            }
        }
        public void Dispose()
        {

        }
    }

    
}
