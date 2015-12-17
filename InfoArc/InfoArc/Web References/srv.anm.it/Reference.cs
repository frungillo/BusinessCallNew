// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace InfoArc.srv.anm.it {
    
    
    /// <remarks/>
    [System.Web.Services.WebServiceBinding(Name="ServiceInfoAnmLineeClasseSoap", Namespace="http://m.anm.it/srv/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServiceInfoAnmLineeClasse : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CaricaPosizioneVeicoloOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaElencoLineeOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaElencoComuniOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaElencoPalineOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaPrevisioniOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaTransitiOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaPercorsoLineaOperationCompleted;
        
        private System.Threading.SendOrPostCallback RilevaEsistenzaFermataOperationCompleted;
        
        private System.Threading.SendOrPostCallback CaricaFermateStradaOperationCompleted;
        
        private System.Threading.SendOrPostCallback RilevaAnomalieLineaOperationCompleted;
        
        public ServiceInfoAnmLineeClasse() {
            this.Url = "http://srv.anm.it/ServiceInfoAnmLinee.asmx";
        }
        
        public ServiceInfoAnmLineeClasse(string url) {
            this.Url = url;
        }
        
        public event CaricaPosizioneVeicoloCompletedEventHandler CaricaPosizioneVeicoloCompleted;
        
        public event CaricaElencoLineeCompletedEventHandler CaricaElencoLineeCompleted;
        
        public event CaricaElencoComuniCompletedEventHandler CaricaElencoComuniCompleted;
        
        public event CaricaElencoPalineCompletedEventHandler CaricaElencoPalineCompleted;
        
        public event CaricaPrevisioniCompletedEventHandler CaricaPrevisioniCompleted;
        
        public event CaricaTransitiCompletedEventHandler CaricaTransitiCompleted;
        
        public event CaricaPercorsoLineaCompletedEventHandler CaricaPercorsoLineaCompleted;
        
        public event RilevaEsistenzaFermataCompletedEventHandler RilevaEsistenzaFermataCompleted;
        
        public event CaricaFermateStradaCompletedEventHandler CaricaFermateStradaCompleted;
        
        public event RilevaAnomalieLineaCompletedEventHandler RilevaAnomalieLineaCompleted;
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaPosizioneVeicolo", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public PosizioneVeicolo[] CaricaPosizioneVeicolo(string linea) {
            object[] results = this.Invoke("CaricaPosizioneVeicolo", new object[] {
                        linea});
            return ((PosizioneVeicolo[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaPosizioneVeicolo(string linea, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaPosizioneVeicolo", new object[] {
                        linea}, callback, asyncState);
        }
        
        public PosizioneVeicolo[] EndCaricaPosizioneVeicolo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((PosizioneVeicolo[])(results[0]));
        }
        
        public void CaricaPosizioneVeicoloAsync(string linea) {
            this.CaricaPosizioneVeicoloAsync(linea, null);
        }
        
        public void CaricaPosizioneVeicoloAsync(string linea, object userState) {
            if ((this.CaricaPosizioneVeicoloOperationCompleted == null)) {
                this.CaricaPosizioneVeicoloOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaPosizioneVeicoloCompleted);
            }
            this.InvokeAsync("CaricaPosizioneVeicolo", new object[] {
                        linea}, this.CaricaPosizioneVeicoloOperationCompleted, userState);
        }
        
        private void OnCaricaPosizioneVeicoloCompleted(object arg) {
            if ((this.CaricaPosizioneVeicoloCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaPosizioneVeicoloCompleted(this, new CaricaPosizioneVeicoloCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaElencoLinee", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Linea[] CaricaElencoLinee() {
            object[] results = this.Invoke("CaricaElencoLinee", new object[0]);
            return ((Linea[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaElencoLinee(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaElencoLinee", new object[0], callback, asyncState);
        }
        
        public Linea[] EndCaricaElencoLinee(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Linea[])(results[0]));
        }
        
        public void CaricaElencoLineeAsync() {
            this.CaricaElencoLineeAsync(null);
        }
        
        public void CaricaElencoLineeAsync(object userState) {
            if ((this.CaricaElencoLineeOperationCompleted == null)) {
                this.CaricaElencoLineeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaElencoLineeCompleted);
            }
            this.InvokeAsync("CaricaElencoLinee", new object[0], this.CaricaElencoLineeOperationCompleted, userState);
        }
        
        private void OnCaricaElencoLineeCompleted(object arg) {
            if ((this.CaricaElencoLineeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaElencoLineeCompleted(this, new CaricaElencoLineeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaElencoComuni", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Comune[] CaricaElencoComuni() {
            object[] results = this.Invoke("CaricaElencoComuni", new object[0]);
            return ((Comune[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaElencoComuni(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaElencoComuni", new object[0], callback, asyncState);
        }
        
        public Comune[] EndCaricaElencoComuni(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Comune[])(results[0]));
        }
        
        public void CaricaElencoComuniAsync() {
            this.CaricaElencoComuniAsync(null);
        }
        
        public void CaricaElencoComuniAsync(object userState) {
            if ((this.CaricaElencoComuniOperationCompleted == null)) {
                this.CaricaElencoComuniOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaElencoComuniCompleted);
            }
            this.InvokeAsync("CaricaElencoComuni", new object[0], this.CaricaElencoComuniOperationCompleted, userState);
        }
        
        private void OnCaricaElencoComuniCompleted(object arg) {
            if ((this.CaricaElencoComuniCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaElencoComuniCompleted(this, new CaricaElencoComuniCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaElencoPaline", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Palina[] CaricaElencoPaline() {
            object[] results = this.Invoke("CaricaElencoPaline", new object[0]);
            return ((Palina[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaElencoPaline(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaElencoPaline", new object[0], callback, asyncState);
        }
        
        public Palina[] EndCaricaElencoPaline(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Palina[])(results[0]));
        }
        
        public void CaricaElencoPalineAsync() {
            this.CaricaElencoPalineAsync(null);
        }
        
        public void CaricaElencoPalineAsync(object userState) {
            if ((this.CaricaElencoPalineOperationCompleted == null)) {
                this.CaricaElencoPalineOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaElencoPalineCompleted);
            }
            this.InvokeAsync("CaricaElencoPaline", new object[0], this.CaricaElencoPalineOperationCompleted, userState);
        }
        
        private void OnCaricaElencoPalineCompleted(object arg) {
            if ((this.CaricaElencoPalineCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaElencoPalineCompleted(this, new CaricaElencoPalineCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaPrevisioni", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Previsione[] CaricaPrevisioni(string Palina) {
            object[] results = this.Invoke("CaricaPrevisioni", new object[] {
                        Palina});
            return ((Previsione[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaPrevisioni(string Palina, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaPrevisioni", new object[] {
                        Palina}, callback, asyncState);
        }
        
        public Previsione[] EndCaricaPrevisioni(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Previsione[])(results[0]));
        }
        
        public void CaricaPrevisioniAsync(string Palina) {
            this.CaricaPrevisioniAsync(Palina, null);
        }
        
        public void CaricaPrevisioniAsync(string Palina, object userState) {
            if ((this.CaricaPrevisioniOperationCompleted == null)) {
                this.CaricaPrevisioniOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaPrevisioniCompleted);
            }
            this.InvokeAsync("CaricaPrevisioni", new object[] {
                        Palina}, this.CaricaPrevisioniOperationCompleted, userState);
        }
        
        private void OnCaricaPrevisioniCompleted(object arg) {
            if ((this.CaricaPrevisioniCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaPrevisioniCompleted(this, new CaricaPrevisioniCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaTransiti", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Linea[] CaricaTransiti(string Palina) {
            object[] results = this.Invoke("CaricaTransiti", new object[] {
                        Palina});
            return ((Linea[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaTransiti(string Palina, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaTransiti", new object[] {
                        Palina}, callback, asyncState);
        }
        
        public Linea[] EndCaricaTransiti(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Linea[])(results[0]));
        }
        
        public void CaricaTransitiAsync(string Palina) {
            this.CaricaTransitiAsync(Palina, null);
        }
        
        public void CaricaTransitiAsync(string Palina, object userState) {
            if ((this.CaricaTransitiOperationCompleted == null)) {
                this.CaricaTransitiOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaTransitiCompleted);
            }
            this.InvokeAsync("CaricaTransiti", new object[] {
                        Palina}, this.CaricaTransitiOperationCompleted, userState);
        }
        
        private void OnCaricaTransitiCompleted(object arg) {
            if ((this.CaricaTransitiCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaTransitiCompleted(this, new CaricaTransitiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaPercorsoLinea", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Percorso[] CaricaPercorsoLinea(string linea) {
            object[] results = this.Invoke("CaricaPercorsoLinea", new object[] {
                        linea});
            return ((Percorso[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaPercorsoLinea(string linea, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaPercorsoLinea", new object[] {
                        linea}, callback, asyncState);
        }
        
        public Percorso[] EndCaricaPercorsoLinea(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Percorso[])(results[0]));
        }
        
        public void CaricaPercorsoLineaAsync(string linea) {
            this.CaricaPercorsoLineaAsync(linea, null);
        }
        
        public void CaricaPercorsoLineaAsync(string linea, object userState) {
            if ((this.CaricaPercorsoLineaOperationCompleted == null)) {
                this.CaricaPercorsoLineaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaPercorsoLineaCompleted);
            }
            this.InvokeAsync("CaricaPercorsoLinea", new object[] {
                        linea}, this.CaricaPercorsoLineaOperationCompleted, userState);
        }
        
        private void OnCaricaPercorsoLineaCompleted(object arg) {
            if ((this.CaricaPercorsoLineaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaPercorsoLineaCompleted(this, new CaricaPercorsoLineaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/RilevaEsistenzaFermata", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Percorso[] RilevaEsistenzaFermata(string fermata) {
            object[] results = this.Invoke("RilevaEsistenzaFermata", new object[] {
                        fermata});
            return ((Percorso[])(results[0]));
        }
        
        public System.IAsyncResult BeginRilevaEsistenzaFermata(string fermata, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RilevaEsistenzaFermata", new object[] {
                        fermata}, callback, asyncState);
        }
        
        public Percorso[] EndRilevaEsistenzaFermata(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Percorso[])(results[0]));
        }
        
        public void RilevaEsistenzaFermataAsync(string fermata) {
            this.RilevaEsistenzaFermataAsync(fermata, null);
        }
        
        public void RilevaEsistenzaFermataAsync(string fermata, object userState) {
            if ((this.RilevaEsistenzaFermataOperationCompleted == null)) {
                this.RilevaEsistenzaFermataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRilevaEsistenzaFermataCompleted);
            }
            this.InvokeAsync("RilevaEsistenzaFermata", new object[] {
                        fermata}, this.RilevaEsistenzaFermataOperationCompleted, userState);
        }
        
        private void OnRilevaEsistenzaFermataCompleted(object arg) {
            if ((this.RilevaEsistenzaFermataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RilevaEsistenzaFermataCompleted(this, new RilevaEsistenzaFermataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/CaricaFermateStrada", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Percorso[] CaricaFermateStrada(string strada, string citta) {
            object[] results = this.Invoke("CaricaFermateStrada", new object[] {
                        strada,
                        citta});
            return ((Percorso[])(results[0]));
        }
        
        public System.IAsyncResult BeginCaricaFermateStrada(string strada, string citta, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CaricaFermateStrada", new object[] {
                        strada,
                        citta}, callback, asyncState);
        }
        
        public Percorso[] EndCaricaFermateStrada(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Percorso[])(results[0]));
        }
        
        public void CaricaFermateStradaAsync(string strada, string citta) {
            this.CaricaFermateStradaAsync(strada, citta, null);
        }
        
        public void CaricaFermateStradaAsync(string strada, string citta, object userState) {
            if ((this.CaricaFermateStradaOperationCompleted == null)) {
                this.CaricaFermateStradaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCaricaFermateStradaCompleted);
            }
            this.InvokeAsync("CaricaFermateStrada", new object[] {
                        strada,
                        citta}, this.CaricaFermateStradaOperationCompleted, userState);
        }
        
        private void OnCaricaFermateStradaCompleted(object arg) {
            if ((this.CaricaFermateStradaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CaricaFermateStradaCompleted(this, new CaricaFermateStradaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://m.anm.it/srv/RilevaAnomalieLinea", RequestNamespace="http://m.anm.it/srv/", ResponseNamespace="http://m.anm.it/srv/", ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped, Use=System.Web.Services.Description.SoapBindingUse.Literal)]
        [return: System.Xml.Serialization.XmlArrayItem(IsNullable=false)]
        public Linea[] RilevaAnomalieLinea(string linea) {
            object[] results = this.Invoke("RilevaAnomalieLinea", new object[] {
                        linea});
            return ((Linea[])(results[0]));
        }
        
        public System.IAsyncResult BeginRilevaAnomalieLinea(string linea, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RilevaAnomalieLinea", new object[] {
                        linea}, callback, asyncState);
        }
        
        public Linea[] EndRilevaAnomalieLinea(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Linea[])(results[0]));
        }
        
        public void RilevaAnomalieLineaAsync(string linea) {
            this.RilevaAnomalieLineaAsync(linea, null);
        }
        
        public void RilevaAnomalieLineaAsync(string linea, object userState) {
            if ((this.RilevaAnomalieLineaOperationCompleted == null)) {
                this.RilevaAnomalieLineaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRilevaAnomalieLineaCompleted);
            }
            this.InvokeAsync("RilevaAnomalieLinea", new object[] {
                        linea}, this.RilevaAnomalieLineaOperationCompleted, userState);
        }
        
        private void OnRilevaAnomalieLineaCompleted(object arg) {
            if ((this.RilevaAnomalieLineaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RilevaAnomalieLineaCompleted(this, new RilevaAnomalieLineaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://m.anm.it/srv/")]
    public partial class PosizioneVeicolo {
        
        /// <remarks/>
        public string veicolo;
        
        /// <remarks/>
        public string linea;
        
        /// <remarks/>
        public string lat;
        
        /// <remarks/>
        public string lon;
        
        /// <remarks/>
        public string nodor;
        
        /// <remarks/>
        public string noddes;
        
        /// <remarks/>
        public string capDst;
        
        /// <remarks/>
        public string time;
        
        /// <remarks/>
        public string stato;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://m.anm.it/srv/")]
    public partial class Linea {
        
        /// <remarks/>
        public string linea;
        
        /// <remarks/>
        public string treno;
        
        /// <remarks/>
        public string dateFrom;
        
        /// <remarks/>
        public string timeFrom;
        
        /// <remarks/>
        public string dateTo;
        
        /// <remarks/>
        public string timeTo;
        
        /// <remarks/>
        public string tipoEvento;
        
        /// <remarks/>
        public string locEvento;
        
        /// <remarks/>
        public string stato;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://m.anm.it/srv/")]
    public partial class Comune {
        
        /// <remarks/>
        public string comune;
        
        /// <remarks/>
        public string stato;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://m.anm.it/srv/")]
    public partial class Palina {
        
        /// <remarks/>
        public string id;
        
        /// <remarks/>
        public string nome;
        
        /// <remarks/>
        public string stato;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://m.anm.it/srv/")]
    public partial class Previsione {
        
        /// <remarks/>
        public string id;
        
        /// <remarks/>
        public string nome;
        
        /// <remarks/>
        public string time;
        
        /// <remarks/>
        public string linea;
        
        /// <remarks/>
        public string timeMin;
        
        /// <remarks/>
        public string stato;
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://m.anm.it/srv/")]
    public partial class Percorso {
        
        /// <remarks/>
        public string id;
        
        /// <remarks/>
        public string nome;
        
        /// <remarks/>
        public string lat;
        
        /// <remarks/>
        public string lon;
        
        /// <remarks/>
        public string verso;
        
        /// <remarks/>
        public string ord;
        
        /// <remarks/>
        public string stato;
    }
    
    public partial class CaricaPosizioneVeicoloCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaPosizioneVeicoloCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public PosizioneVeicolo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PosizioneVeicolo[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaPosizioneVeicoloCompletedEventHandler(object sender, CaricaPosizioneVeicoloCompletedEventArgs args);
    
    public partial class CaricaElencoLineeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaElencoLineeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Linea[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Linea[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaElencoLineeCompletedEventHandler(object sender, CaricaElencoLineeCompletedEventArgs args);
    
    public partial class CaricaElencoComuniCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaElencoComuniCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Comune[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Comune[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaElencoComuniCompletedEventHandler(object sender, CaricaElencoComuniCompletedEventArgs args);
    
    public partial class CaricaElencoPalineCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaElencoPalineCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Palina[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Palina[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaElencoPalineCompletedEventHandler(object sender, CaricaElencoPalineCompletedEventArgs args);
    
    public partial class CaricaPrevisioniCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaPrevisioniCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Previsione[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Previsione[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaPrevisioniCompletedEventHandler(object sender, CaricaPrevisioniCompletedEventArgs args);
    
    public partial class CaricaTransitiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaTransitiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Linea[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Linea[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaTransitiCompletedEventHandler(object sender, CaricaTransitiCompletedEventArgs args);
    
    public partial class CaricaPercorsoLineaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaPercorsoLineaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Percorso[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Percorso[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaPercorsoLineaCompletedEventHandler(object sender, CaricaPercorsoLineaCompletedEventArgs args);
    
    public partial class RilevaEsistenzaFermataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RilevaEsistenzaFermataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Percorso[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Percorso[])(this.results[0]));
            }
        }
    }
    
    public delegate void RilevaEsistenzaFermataCompletedEventHandler(object sender, RilevaEsistenzaFermataCompletedEventArgs args);
    
    public partial class CaricaFermateStradaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CaricaFermateStradaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Percorso[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Percorso[])(this.results[0]));
            }
        }
    }
    
    public delegate void CaricaFermateStradaCompletedEventHandler(object sender, CaricaFermateStradaCompletedEventArgs args);
    
    public partial class RilevaAnomalieLineaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RilevaAnomalieLineaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public Linea[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Linea[])(this.results[0]));
            }
        }
    }
    
    public delegate void RilevaAnomalieLineaCompletedEventHandler(object sender, RilevaAnomalieLineaCompletedEventArgs args);
}
