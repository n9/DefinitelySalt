using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    [ScriptNamespace("doT")]
    [ScriptName("Context")]
    public class DoTContext
    {
        [ScriptName("i")]
        public extern virtual string Interpolate(object value, string param);
        
        [ScriptName("c")]
        public extern virtual bool Condition(object value);
        
        [ScriptName("l")]
        public extern virtual string Loop(object value, DoTItemWriter itemWriter, DoTSeparatorWriter separatorWriter);

        [ScriptName("b")]
        public extern virtual string Block(string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

        [ScriptName("ib")]
        public extern virtual Func<object, Func<DoTContext, JsDictionary<string, DoTTemplate>>> InlineBlock(JsDictionary<string, DoTTemplate> defaultTemplateArguments);

        [ScriptName("bm")]
        public extern virtual object BlockMeta(string name, object jsArguments);

        public extern virtual string UnknownBlock(string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);
        public extern virtual object UnknownBlockMeta(string name, object jsArguments);
        public extern virtual DoTContext MayDerive(JsDictionary<string, DoTTemplate> blocks);

        public extern virtual DoTContext FullDerive();
    }

    [BindThisToFirstParameter]
    public delegate string DoTBlockFunc(DoTContext c, string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

    public delegate string DoTTemplate(DoTContext c, object data);

    public delegate string DoTItemWriter(DoTContext c, object item, int index, object[] collection);

    public delegate string DoTSeparatorWriter(DoTContext c);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("doT")]
    public static class DoT
    {
        public static DotTemplateSettings TemplateSettings;

        public static extern DoTTemplate Compile(string source, DotTemplateSettings settings = null);
        public static extern string Template(string source, DotTemplateSettings settings = null);

        public static extern string EncodeHTML(object value);
        public static extern Function ConstructorFromInstance(object instance);

        [InlineCode("{$DefinitelySalt.DoT}.loop.call({op}, {value}, {itemWriter}, {separatorWriter})")]
        public static extern string Loop(DoTContext op, object value, DoTItemWriter itemWriter, DoTSeparatorWriter separatorWriter);

        [InlineCode("{$DefinitelySalt.DoT}.blockSplatter.call({op}, {name}, {jsArguments}, {templateArguments}, {blockFunction})")]
        public static extern string BlockSplatter(DoTContext op, string name, object jsArguments,
            JsDictionary<string, DoTTemplate> templateArguments,
            DoTBlockFunc blockFunction);

    }

    [Imported]
    [Serializable]
    public class DotTemplateSettings
    {
    }
}
