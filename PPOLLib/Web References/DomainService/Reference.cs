﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18444.
// 
#pragma warning disable 1591

namespace PPOL.DomainService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DomainLocationAPIServiceSoapBinding", Namespace="http://api.domains.cxrm.com/")]
    public partial class DomainLocationAPIService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback removeOperationCompleted;
        
        private System.Threading.SendOrPostCallback addOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateOperationCompleted;
        
        private System.Threading.SendOrPostCallback lookupServerURLOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DomainLocationAPIService() {
            this.Url = global::PPOL.Properties.Settings.Default.PPOL_Outlook_Plugin_DomainService_DomainLocationAPIService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event removeCompletedEventHandler removeCompleted;
        
        /// <remarks/>
        public event addCompletedEventHandler addCompleted;
        
        /// <remarks/>
        public event updateCompletedEventHandler updateCompleted;
        
        /// <remarks/>
        public event lookupServerURLCompletedEventHandler lookupServerURLCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://api.domains.cxrm.com/", ResponseNamespace="http://api.domains.cxrm.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string remove([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0) {
            object[] results = this.Invoke("remove", new object[] {
                        arg0});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void removeAsync(string arg0) {
            this.removeAsync(arg0, null);
        }
        
        /// <remarks/>
        public void removeAsync(string arg0, object userState) {
            if ((this.removeOperationCompleted == null)) {
                this.removeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnremoveOperationCompleted);
            }
            this.InvokeAsync("remove", new object[] {
                        arg0}, this.removeOperationCompleted, userState);
        }
        
        private void OnremoveOperationCompleted(object arg) {
            if ((this.removeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.removeCompleted(this, new removeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://api.domains.cxrm.com/", ResponseNamespace="http://api.domains.cxrm.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void add([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg2, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg3, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int arg4) {
            this.Invoke("add", new object[] {
                        arg0,
                        arg1,
                        arg2,
                        arg3,
                        arg4});
        }
        
        /// <remarks/>
        public void addAsync(string arg0, string arg1, string arg2, string arg3, int arg4) {
            this.addAsync(arg0, arg1, arg2, arg3, arg4, null);
        }
        
        /// <remarks/>
        public void addAsync(string arg0, string arg1, string arg2, string arg3, int arg4, object userState) {
            if ((this.addOperationCompleted == null)) {
                this.addOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddOperationCompleted);
            }
            this.InvokeAsync("add", new object[] {
                        arg0,
                        arg1,
                        arg2,
                        arg3,
                        arg4}, this.addOperationCompleted, userState);
        }
        
        private void OnaddOperationCompleted(object arg) {
            if ((this.addCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://api.domains.cxrm.com/", ResponseNamespace="http://api.domains.cxrm.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string update([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg2, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg3, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int arg4) {
            object[] results = this.Invoke("update", new object[] {
                        arg0,
                        arg1,
                        arg2,
                        arg3,
                        arg4});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void updateAsync(string arg0, string arg1, string arg2, string arg3, int arg4) {
            this.updateAsync(arg0, arg1, arg2, arg3, arg4, null);
        }
        
        /// <remarks/>
        public void updateAsync(string arg0, string arg1, string arg2, string arg3, int arg4, object userState) {
            if ((this.updateOperationCompleted == null)) {
                this.updateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateOperationCompleted);
            }
            this.InvokeAsync("update", new object[] {
                        arg0,
                        arg1,
                        arg2,
                        arg3,
                        arg4}, this.updateOperationCompleted, userState);
        }
        
        private void OnupdateOperationCompleted(object arg) {
            if ((this.updateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateCompleted(this, new updateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://api.domains.cxrm.com/", ResponseNamespace="http://api.domains.cxrm.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string lookupServerURL([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg2) {
            object[] results = this.Invoke("lookupServerURL", new object[] {
                        arg0,
                        arg1,
                        arg2});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void lookupServerURLAsync(string arg0, string arg1, string arg2) {
            this.lookupServerURLAsync(arg0, arg1, arg2, null);
        }
        
        /// <remarks/>
        public void lookupServerURLAsync(string arg0, string arg1, string arg2, object userState) {
            if ((this.lookupServerURLOperationCompleted == null)) {
                this.lookupServerURLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlookupServerURLOperationCompleted);
            }
            this.InvokeAsync("lookupServerURL", new object[] {
                        arg0,
                        arg1,
                        arg2}, this.lookupServerURLOperationCompleted, userState);
        }
        
        private void OnlookupServerURLOperationCompleted(object arg) {
            if ((this.lookupServerURLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.lookupServerURLCompleted(this, new lookupServerURLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void removeCompletedEventHandler(object sender, removeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class removeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal removeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void addCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void updateCompletedEventHandler(object sender, updateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void lookupServerURLCompletedEventHandler(object sender, lookupServerURLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class lookupServerURLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal lookupServerURLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591