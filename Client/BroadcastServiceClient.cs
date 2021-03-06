﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4013
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Broadcaster.Client
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.xpressive.com/broadcaster/2009/10", ConfigurationName="Broadcaster.Client.IBroadcastService", CallbackContract=typeof(Broadcaster.Client.IBroadcastServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IBroadcastService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/Subscribe", ReplyAction="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/SubscribeResponse")]
        System.Guid Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/Subscribe", ReplyAction="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/SubscribeResponse")]
        System.IAsyncResult BeginSubscribe(System.AsyncCallback callback, object asyncState);
        
        System.Guid EndSubscribe(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/Unsubscribe")]
        void Unsubscribe(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/Unsubscribe")]
        System.IAsyncResult BeginUnsubscribe(System.Guid guid, System.AsyncCallback callback, object asyncState);
        
        void EndUnsubscribe(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/Notify")]
        void Notify(System.Guid guid, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/Notify")]
        System.IAsyncResult BeginNotify(System.Guid guid, string message, System.AsyncCallback callback, object asyncState);
        
        void EndNotify(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IBroadcastServiceCallback
    {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/ReceiveMessage")]
        void ReceiveMessage(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://www.xpressive.com/broadcaster/2009/10/IBroadcastService/ReceiveMessage")]
        System.IAsyncResult BeginReceiveMessage(string message, System.AsyncCallback callback, object asyncState);
        
        void EndReceiveMessage(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IBroadcastServiceChannel : Broadcaster.Client.IBroadcastService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class BroadcastServiceClient : System.ServiceModel.DuplexClientBase<Broadcaster.Client.IBroadcastService>, Broadcaster.Client.IBroadcastService
    {
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance)
        {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName)
        {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }
        
        public BroadcastServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress)
        {
        }
        
        public System.Guid Subscribe()
        {
            return base.Channel.Subscribe();
        }
        
        public System.IAsyncResult BeginSubscribe(System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSubscribe(callback, asyncState);
        }
        
        public System.Guid EndSubscribe(System.IAsyncResult result)
        {
            return base.Channel.EndSubscribe(result);
        }
        
        public void Unsubscribe(System.Guid guid)
        {
            base.Channel.Unsubscribe(guid);
        }
        
        public System.IAsyncResult BeginUnsubscribe(System.Guid guid, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginUnsubscribe(guid, callback, asyncState);
        }
        
        public void EndUnsubscribe(System.IAsyncResult result)
        {
            base.Channel.EndUnsubscribe(result);
        }
        
        public void Notify(System.Guid guid, string message)
        {
            base.Channel.Notify(guid, message);
        }
        
        public System.IAsyncResult BeginNotify(System.Guid guid, string message, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginNotify(guid, message, callback, asyncState);
        }
        
        public void EndNotify(System.IAsyncResult result)
        {
            base.Channel.EndNotify(result);
        }
    }
}
