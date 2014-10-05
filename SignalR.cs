using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Threading.Tasks;

namespace DefinitelySalt
{
    [Imported]
    [ScriptNamespace("")]
    [ScriptName("$")]
    public class SignalR
    {
        public static SignalR Connection;
        
        [ScriptName("hubConnection")]
        public static HubConnection CreateHubConnection(string url = null) { return null; }


        public IjQueryPromise<object> Start() { return null; }
        public SignalR Stop(bool? async = null, bool? notifyServer = null) { return this; }
        
        //...

        public SignalR Received<T>(Action<T> handler) { return this; }
        public SignalR Error<T>(Action<T> handler) { return this; }

        public SignalR Send(string data) { return this; }

        public SignalR Error(Action<object, object> handler) { return this; }
        public SignalR StateChanged(Action<object> handler) { return this; }
        public SignalR Disconnected(Action handler) { return this; }

        // TODO
    }
    
    
    [Imported]
    public class HubConnection : SignalR
    {
        public HubProxy CreateHubProxy(string name) { return null; }

        
        // TODO
    }

    [Imported]
    public class HubProxy
    {
        public HubConnection Connection;

        public HubProxy On(string eventName, Delegate handler) { return this; }
        public HubProxy Off(string eventName, Delegate handler) { return this; }

        [ExpandParams]
        public IjQueryPromise<T> Invoke<T>(string methodName, params object[] args) { return null; }

        [ExpandParams]
        public IjQueryPromise<T, P> Invoke<T, P>(string methodName, params object[] args) { return null; }

        // TODO
    }
}
