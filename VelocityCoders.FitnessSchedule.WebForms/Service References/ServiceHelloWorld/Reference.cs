﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VelocityCoders.FitnessSchedule.WebForms.ServiceHelloWorld {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceHelloWorld.IHelloWorld")]
    public interface IHelloWorld {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHelloWorld/GetHelloWorld", ReplyAction="http://tempuri.org/IHelloWorld/GetHelloWorldResponse")]
        string GetHelloWorld(string firstName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHelloWorld/GetHelloWorld", ReplyAction="http://tempuri.org/IHelloWorld/GetHelloWorldResponse")]
        System.Threading.Tasks.Task<string> GetHelloWorldAsync(string firstName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHelloWorldChannel : VelocityCoders.FitnessSchedule.WebForms.ServiceHelloWorld.IHelloWorld, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HelloWorldClient : System.ServiceModel.ClientBase<VelocityCoders.FitnessSchedule.WebForms.ServiceHelloWorld.IHelloWorld>, VelocityCoders.FitnessSchedule.WebForms.ServiceHelloWorld.IHelloWorld {
        
        public HelloWorldClient() {
        }
        
        public HelloWorldClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HelloWorldClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HelloWorldClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HelloWorldClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetHelloWorld(string firstName) {
            return base.Channel.GetHelloWorld(firstName);
        }
        
        public System.Threading.Tasks.Task<string> GetHelloWorldAsync(string firstName) {
            return base.Channel.GetHelloWorldAsync(firstName);
        }
    }
}
