﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProjekt.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SletHistorik", ReplyAction="http://tempuri.org/IService1/SletHistorikResponse")]
        WCFServiceWebRole1.Models.Bevaegelser SletHistorik(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SletHistorik", ReplyAction="http://tempuri.org/IService1/SletHistorikResponse")]
        System.Threading.Tasks.Task<WCFServiceWebRole1.Models.Bevaegelser> SletHistorikAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OpretBruger", ReplyAction="http://tempuri.org/IService1/OpretBrugerResponse")]
        string OpretBruger(string brugernavn, string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OpretBruger", ReplyAction="http://tempuri.org/IService1/OpretBrugerResponse")]
        System.Threading.Tasks.Task<string> OpretBrugerAsync(string brugernavn, string password, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OpdaterPassword", ReplyAction="http://tempuri.org/IService1/OpdaterPasswordResponse")]
        string OpdaterPassword(string brugernavn, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OpdaterPassword", ReplyAction="http://tempuri.org/IService1/OpdaterPasswordResponse")]
        System.Threading.Tasks.Task<string> OpdaterPasswordAsync(string brugernavn, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OpdaterEmail", ReplyAction="http://tempuri.org/IService1/OpdaterEmailResponse")]
        string OpdaterEmail(string brugernavn, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/OpdaterEmail", ReplyAction="http://tempuri.org/IService1/OpdaterEmailResponse")]
        System.Threading.Tasks.Task<string> OpdaterEmailAsync(string brugernavn, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        string Login(string brugernavn, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string brugernavn, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HentBevaegelser", ReplyAction="http://tempuri.org/IService1/HentBevaegelserResponse")]
        WCFServiceWebRole1.Models.Bevaegelser[] HentBevaegelser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HentBevaegelser", ReplyAction="http://tempuri.org/IService1/HentBevaegelserResponse")]
        System.Threading.Tasks.Task<WCFServiceWebRole1.Models.Bevaegelser[]> HentBevaegelserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HentTemperatur", ReplyAction="http://tempuri.org/IService1/HentTemperaturResponse")]
        int HentTemperatur(int startInterval, int slutInterval);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HentTemperatur", ReplyAction="http://tempuri.org/IService1/HentTemperaturResponse")]
        System.Threading.Tasks.Task<int> HentTemperaturAsync(int startInterval, int slutInterval);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HentTidspunkt", ReplyAction="http://tempuri.org/IService1/HentTidspunktResponse")]
        int HentTidspunkt(int aarstal, int maaned, int slutdag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HentTidspunkt", ReplyAction="http://tempuri.org/IService1/HentTidspunktResponse")]
        System.Threading.Tasks.Task<int> HentTidspunktAsync(int aarstal, int maaned, int slutdag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GlemtPassword", ReplyAction="http://tempuri.org/IService1/GlemtPasswordResponse")]
        string GlemtPassword(string brugernavn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GlemtPassword", ReplyAction="http://tempuri.org/IService1/GlemtPasswordResponse")]
        System.Threading.Tasks.Task<string> GlemtPasswordAsync(string brugernavn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GlemtBrugernavn", ReplyAction="http://tempuri.org/IService1/GlemtBrugernavnResponse")]
        string GlemtBrugernavn(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GlemtBrugernavn", ReplyAction="http://tempuri.org/IService1/GlemtBrugernavnResponse")]
        System.Threading.Tasks.Task<string> GlemtBrugernavnAsync(string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TestProjekt.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TestProjekt.ServiceReference1.IService1>, TestProjekt.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCFServiceWebRole1.Models.Bevaegelser SletHistorik(int id) {
            return base.Channel.SletHistorik(id);
        }
        
        public System.Threading.Tasks.Task<WCFServiceWebRole1.Models.Bevaegelser> SletHistorikAsync(int id) {
            return base.Channel.SletHistorikAsync(id);
        }
        
        public string OpretBruger(string brugernavn, string password, string email) {
            return base.Channel.OpretBruger(brugernavn, password, email);
        }
        
        public System.Threading.Tasks.Task<string> OpretBrugerAsync(string brugernavn, string password, string email) {
            return base.Channel.OpretBrugerAsync(brugernavn, password, email);
        }
        
        public string OpdaterPassword(string brugernavn, string password) {
            return base.Channel.OpdaterPassword(brugernavn, password);
        }
        
        public System.Threading.Tasks.Task<string> OpdaterPasswordAsync(string brugernavn, string password) {
            return base.Channel.OpdaterPasswordAsync(brugernavn, password);
        }
        
        public string OpdaterEmail(string brugernavn, string email) {
            return base.Channel.OpdaterEmail(brugernavn, email);
        }
        
        public System.Threading.Tasks.Task<string> OpdaterEmailAsync(string brugernavn, string email) {
            return base.Channel.OpdaterEmailAsync(brugernavn, email);
        }
        
        public string Login(string brugernavn, string password) {
            return base.Channel.Login(brugernavn, password);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string brugernavn, string password) {
            return base.Channel.LoginAsync(brugernavn, password);
        }
        
        public WCFServiceWebRole1.Models.Bevaegelser[] HentBevaegelser() {
            return base.Channel.HentBevaegelser();
        }
        
        public System.Threading.Tasks.Task<WCFServiceWebRole1.Models.Bevaegelser[]> HentBevaegelserAsync() {
            return base.Channel.HentBevaegelserAsync();
        }
        
        public int HentTemperatur(int startInterval, int slutInterval) {
            return base.Channel.HentTemperatur(startInterval, slutInterval);
        }
        
        public System.Threading.Tasks.Task<int> HentTemperaturAsync(int startInterval, int slutInterval) {
            return base.Channel.HentTemperaturAsync(startInterval, slutInterval);
        }
        
        public int HentTidspunkt(int aarstal, int maaned, int slutdag) {
            return base.Channel.HentTidspunkt(aarstal, maaned, slutdag);
        }
        
        public System.Threading.Tasks.Task<int> HentTidspunktAsync(int aarstal, int maaned, int slutdag) {
            return base.Channel.HentTidspunktAsync(aarstal, maaned, slutdag);
        }
        
        public string GlemtPassword(string brugernavn) {
            return base.Channel.GlemtPassword(brugernavn);
        }
        
        public System.Threading.Tasks.Task<string> GlemtPasswordAsync(string brugernavn) {
            return base.Channel.GlemtPasswordAsync(brugernavn);
        }
        
        public string GlemtBrugernavn(string email) {
            return base.Channel.GlemtBrugernavn(email);
        }
        
        public System.Threading.Tasks.Task<string> GlemtBrugernavnAsync(string email) {
            return base.Channel.GlemtBrugernavnAsync(email);
        }
    }
}
