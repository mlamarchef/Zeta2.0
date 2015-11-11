﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.42.
// 
#pragma warning disable 1591

namespace ZetaHelpDesk.Main.ZetaHelpDeskUpdate {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GetZetaHelpDeskUpdateSoap", Namespace="http://zeta-software.de/zetahelpdesk/")]
    public partial class GetZetaHelpDeskUpdate : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback IsUpdatePresentOperationCompleted;
        
        private System.Threading.SendOrPostCallback DownloadUpdateOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GetZetaHelpDeskUpdate() {
            this.Url = global::ZetaHelpDesk.Main.Properties.Settings.Default.ZetaHelpDesk_Main_ZetaHelpDeskUpdate_GetZetaHelpDeskUpdate;
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
        public event IsUpdatePresentCompletedEventHandler IsUpdatePresentCompleted;
        
        /// <remarks/>
        public event DownloadUpdateCompletedEventHandler DownloadUpdateCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://zeta-software.de/zetahelpdesk/IsUpdatePresent", RequestNamespace="http://zeta-software.de/zetahelpdesk/", ResponseNamespace="http://zeta-software.de/zetahelpdesk/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsUpdatePresent(string currentVersionStringToCheckAgainst) {
            object[] results = this.Invoke("IsUpdatePresent", new object[] {
                        currentVersionStringToCheckAgainst});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsUpdatePresentAsync(string currentVersionStringToCheckAgainst) {
            this.IsUpdatePresentAsync(currentVersionStringToCheckAgainst, null);
        }
        
        /// <remarks/>
        public void IsUpdatePresentAsync(string currentVersionStringToCheckAgainst, object userState) {
            if ((this.IsUpdatePresentOperationCompleted == null)) {
                this.IsUpdatePresentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsUpdatePresentOperationCompleted);
            }
            this.InvokeAsync("IsUpdatePresent", new object[] {
                        currentVersionStringToCheckAgainst}, this.IsUpdatePresentOperationCompleted, userState);
        }
        
        private void OnIsUpdatePresentOperationCompleted(object arg) {
            if ((this.IsUpdatePresentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsUpdatePresentCompleted(this, new IsUpdatePresentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://zeta-software.de/zetahelpdesk/DownloadUpdate", RequestNamespace="http://zeta-software.de/zetahelpdesk/", ResponseNamespace="http://zeta-software.de/zetahelpdesk/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] DownloadUpdate() {
            object[] results = this.Invoke("DownloadUpdate", new object[0]);
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void DownloadUpdateAsync() {
            this.DownloadUpdateAsync(null);
        }
        
        /// <remarks/>
        public void DownloadUpdateAsync(object userState) {
            if ((this.DownloadUpdateOperationCompleted == null)) {
                this.DownloadUpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadUpdateOperationCompleted);
            }
            this.InvokeAsync("DownloadUpdate", new object[0], this.DownloadUpdateOperationCompleted, userState);
        }
        
        private void OnDownloadUpdateOperationCompleted(object arg) {
            if ((this.DownloadUpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadUpdateCompleted(this, new DownloadUpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void IsUpdatePresentCompletedEventHandler(object sender, IsUpdatePresentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsUpdatePresentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsUpdatePresentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void DownloadUpdateCompletedEventHandler(object sender, DownloadUpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadUpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DownloadUpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591