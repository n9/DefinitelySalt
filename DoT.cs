using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    public interface IDoTOp
    {
        [ScriptName("i")]
        string Interpolate(object value, string param);
        
        [ScriptName("c")]
        bool Condition(object value);
        
        [ScriptName("l")]
        string Loop(object value, Func<object, int, string> itemWriter, Func<string> separatorWriter);

        [ScriptName("b")]
        string Block(string name, IDoTOp op, object jsArguments, JsDictionary<string, Func<object, IDoTOp, string>> templateArguments);

        [ScriptName("bm")]
        object BlockMeta(string name, object jsArguments);
    }

    public delegate string DoTTemplate(object data, IDoTOp op);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("doT")]
    public static class DoT
    {
        public static DotTemplateSettings TemplateSettings;

        public static extern DoTTemplate Compile(string source, DotTemplateSettings settings = null);
        public static extern string Template(string source, DotTemplateSettings settings = null);

        public static extern string EncodeHTML(object value);
        public static extern string Loop(object value, Func<object, int, string> itemWriter, Func<string> separatorWriter);
        public static extern string BlockSplatter(string name, IDoTOp op, object jsArguments, 
            JsDictionary<string, Func<object, IDoTOp, string>> templateArguments, 
            Func<string, IDoTOp, object, JsDictionary<string, Func<object, IDoTOp, string>>, string> blockFunction);
    }

    [Imported]
    [Serializable]
    public class DotTemplateSettings
    {
    }
}
