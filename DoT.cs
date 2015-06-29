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
        string Loop(object value, DoTItemWriter itemWriter, DoTSeparatorWriter separatorWriter);

        [ScriptName("b")]
        string Block(string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

        [ScriptName("bm")]
        object BlockMeta(string name, object jsArguments);
    }

    [BindThisToFirstParameter]
    public delegate string DoTBlockFunc(IDoTOp op, string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

    public delegate string DoTTemplate(IDoTOp op, object data);

    public delegate string DoTItemWriter(IDoTOp op, object item, int index, object[] collection);

    public delegate string DoTSeparatorWriter(IDoTOp op);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("doT")]
    public static class DoT
    {
        public static DotTemplateSettings TemplateSettings;

        public static extern DoTTemplate Compile(string source, DotTemplateSettings settings = null);
        public static extern string Template(string source, DotTemplateSettings settings = null);

        public static extern string EncodeHTML(object value);

        [InlineCode("{$DefinitelySalt.DoT}.loop.call({op}, {value}, {itemWriter}, {separatorWriter})")]
        public static extern string Loop(IDoTOp op, object value, DoTItemWriter itemWriter, DoTSeparatorWriter separatorWriter);
        
        [InlineCode("{$DefinitelySalt.DoT}.blockSplatter.call({op}, {name}, {jsArguments}, {templateArguments}, {blockFunction})")]
        public static extern string BlockSplatter(IDoTOp op, string name, object jsArguments,
            JsDictionary<string, DoTTemplate> templateArguments,
            DoTBlockFunc blockFunction);
    }

    [Imported]
    [Serializable]
    public class DotTemplateSettings
    {
    }
}
