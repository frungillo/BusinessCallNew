//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.34014
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RubricaNew.serviceSae {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebService1Soap", Namespace="http://tempuri.org/")]
    public partial class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public WebService1() {
            this.Url = "http://m.anm.it/SeviceCruscottoSae.asmx";
        }
        
        public WebService1(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/generaProgrammato", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public VDAPFS[] generaProgrammato(string dep, string linea) {
            object[] results = this.Invoke("generaProgrammato", new object[] {
                        dep,
                        linea});
            return ((VDAPFS[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingeneraProgrammato(string dep, string linea, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("generaProgrammato", new object[] {
                        dep,
                        linea}, callback, asyncState);
        }
        
        /// <remarks/>
        public VDAPFS[] EndgeneraProgrammato(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VDAPFS[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StatisticheSAE", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Statistiche StatisticheSAE(string dep, string lin) {
            object[] results = this.Invoke("StatisticheSAE", new object[] {
                        dep,
                        lin});
            return ((Statistiche)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginStatisticheSAE(string dep, string lin, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("StatisticheSAE", new object[] {
                        dep,
                        lin}, callback, asyncState);
        }
        
        /// <remarks/>
        public Statistiche EndStatisticheSAE(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Statistiche)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CaricaDepositi", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] CaricaDepositi() {
            object[] results = this.Invoke("CaricaDepositi", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCaricaDepositi(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaDepositi", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndCaricaDepositi(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LineePerDep", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] LineePerDep(string dep) {
            object[] results = this.Invoke("LineePerDep", new object[] {
                        dep});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLineePerDep(string dep, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("LineePerDep", new object[] {
                        dep}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndLineePerDep(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRubricaAll", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public RubricaCell[] GetRubricaAll(string IMEI) {
            object[] results = this.Invoke("GetRubricaAll", new object[] {
                        IMEI});
            return ((RubricaCell[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetRubricaAll(string IMEI, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetRubricaAll", new object[] {
                        IMEI}, callback, asyncState);
        }
        
        /// <remarks/>
        public RubricaCell[] EndGetRubricaAll(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((RubricaCell[])(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class VDAPFS {
        
        /// <remarks/>
        public string DATAPROG;
        
        /// <remarks/>
        public string RESIDENZATG;
        
        /// <remarks/>
        public string TG;
        
        /// <remarks/>
        public string TM;
        
        /// <remarks/>
        public string AUTISTA;
        
        /// <remarks/>
        public string COGNOME;
        
        /// <remarks/>
        public string NOME;
        
        /// <remarks/>
        public string STR;
        
        /// <remarks/>
        public string BUS;
        
        /// <remarks/>
        public string NOTE;
        
        /// <remarks/>
        public string TMI;
        
        /// <remarks/>
        public string TMF;
        
        /// <remarks/>
        public string TGI;
        
        /// <remarks/>
        public string TGF;
        
        /// <remarks/>
        public string CONVALIDATO;
        
        /// <remarks/>
        public int TURNOSAE;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RubricaCell {
        
        /// <remarks/>
        public string Matricola;
        
        /// <remarks/>
        public string Cognome;
        
        /// <remarks/>
        public string Nome;
        
        /// <remarks/>
        public string Utenza;
        
        /// <remarks/>
        public string Numero1;
        
        /// <remarks/>
        public string Numero2;
        
        /// <remarks/>
        public string Numero3;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamarinStudio", "4.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Statistiche {
        
        /// <remarks/>
        public int P;
        
        /// <remarks/>
        public int MP;
        
        /// <remarks/>
        public int MM;
        
        /// <remarks/>
        public int G;
        
        /// <remarks/>
        public int S;
        
        /// <remarks/>
        public int L;
        
        /// <remarks/>
        public int SAE;
        
        /// <remarks/>
        public int ALTRO;
    }
}