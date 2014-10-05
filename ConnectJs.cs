using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodeJS;
using System.Runtime.CompilerServices;
using NodeJS.HttpModule;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ModuleName("connect")]
    [ScriptName("")]
    public class Connect
    {
        [ScriptName("")]
        [ExpandParams]
        public static Connect Create(params Action<ServerRequest, ServerResponse, Action<object>>[] middlewares) { return null; }
        
        public Connect Use(Action<ServerRequest, ServerResponse, Action<object>> middleware) { return null; }

        public static Action<ServerRequest, ServerResponse, Action<object>> Static(string root, ConnectStaticOptions options = null) { return null; }

        [ScriptSkip]
        public static implicit operator Action<ServerRequest, ServerResponse>(Connect connect) { return null; } 
    }

    public static class ConnectEx
    {
        public static void Apply(this Connect connect, ServerRequest request, ServerResponse response)
        {
            ((Action<ServerRequest, ServerResponse>)connect)(request, response);
        }
    }

    [Serializable]
    public class ConnectStaticOptions
    {
        public int MaxAge;
        public bool Hidden;
        public bool Redirect;
        public string Index;
    }
}