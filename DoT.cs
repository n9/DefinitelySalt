﻿using System;
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
        public readonly JsDictionary<string, DoTBlock> Blocks;

        public extern DoTContext(JsDictionary<string, DoTBlock> blocks = null);

        [ScriptName("i")]
        public extern virtual string Interpolate(object value, string param);
        
        [ScriptName("c")]
        public extern virtual bool Condition(object value, Action<object> action);

        [ScriptName("ic")]
        public extern virtual bool InterpolateCondition(object value);
        
        [ScriptName("l")]
        public extern virtual string Loop(object value, DoTItemWriter itemWriter, DoTSeparatorWriter separatorWriter);

        [ScriptName("b")]
        public extern virtual string Block(string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

        [ScriptName("ib")]
        public extern virtual Func<object, Func<DoTContext, JsDictionary<string, DoTTemplate>, object>> InlineBlock(JsDictionary<string, DoTTemplate> defaultTemplateArguments);

        [ScriptName("bm")]
        public extern virtual object BlockMeta(string name, object jsArguments);

        [ScriptName("bd")]
        public extern virtual object BlockDef(string name, JsDictionary<string, DoTTemplate> templateArguments);

        public extern virtual object WrapInlineBlock(string result);
        public extern virtual string UnknownBlock(string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);
        public extern virtual object UnknownBlockMeta(string name, object jsArguments);

        public extern virtual DoTContext Clone(JsDictionary<string, DoTTemplate> newBlocks);
        public extern virtual DoTContext FullDerive();
    }

    [BindThisToFirstParameter]
    public delegate string DoTBlockFunc(DoTContext c, string name, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

    public delegate string DoTTemplate(DoTContext c, object data);

    public delegate string DoTBlock(DoTContext c, object jsArguments, JsDictionary<string, DoTTemplate> templateArguments);

    public delegate string DoTItemWriter(DoTContext c, object item, int index, object[] collection);

    public delegate string DoTSeparatorWriter(DoTContext c);

    [Imported]
    [IgnoreNamespace]
    [ScriptName("doT")]
    public static class DoT
    {
        public static DoTTemplateSettings TemplateSettings;

        public static extern DoTTemplate Compile(string source, DoTTemplateSettings settings = null);
        public static extern string Template(string source, DoTTemplateSettings settings = null);

        public static extern string EncodeHTML(object value);
        public static extern string ExtractText(string html);

        [InlineCode("{$DefinitelySalt.DoT}.loop.call({op}, {value}, {itemWriter}, {separatorWriter})")]
        public static extern string Loop(DoTContext op, object value, DoTItemWriter itemWriter, DoTSeparatorWriter separatorWriter);
    }

    [Imported]
    [Serializable]
    public class DoTTemplateSettings
    {
    }

    [Imported]
    [ScriptNamespace("doT")]
    [ScriptName("Literal")]
    public class DoTLiteral 
    {
        public string Html;

        public extern DoTLiteral(string html);
    }
}
