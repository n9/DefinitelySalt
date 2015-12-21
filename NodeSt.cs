using NodeJS.HttpModule;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ModuleName("st")]
    [ScriptName("")]
    public class NodeSt
    {
        [ScriptName("")]
        public static extern NodeStMount Create(TypeOption<string, NodeStOptions> pathOrOptions);
    }

    public delegate bool NodeStMount(ServerRequest request, ServerResponse response, Action notHandled = null);

    [Imported]
    [Serializable]
    public class NodeStOptions
    {
        public string Path;
        public string Url;
        public TypeOption<bool, string> Index;
        public TypeOption<bool, NodeStCacheOptions> Cache;
        
        [ScriptName("passthrough")]
        public bool PassThrough;
    }

    [Imported]
    [Serializable]
    public class NodeStCacheOptions
    {
        
    }
}
