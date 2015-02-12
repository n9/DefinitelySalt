using jQueryApi;
using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    public delegate string[] TypeaheadHighlightFunc(string query, string[] suggestions);

    [Serializable]
    [Imported]
    public class TypeaheadOptions
    {
        public bool Autoselect;
        public TypeOption<bool, TypeaheadHighlightFunc> Highlight;
        public bool Hint = true;
        public int MinLength = 1;
    }

    [Serializable]
    public class TypeaheadDatasetSourceItem
    {
        public string Value;
    }

    public delegate void TypeaheadDatasetSource<T>(string query, Action<T[]> callback);

    [Serializable]
    [Imported]
    public interface ITypeaheadQueryContext
    {
        string Query { get; }
    }

    [Serializable]
    [Imported]
    public interface ITypeaheadQueryWithEmptyContext : ITypeaheadQueryContext
    {
        bool IsEmpty { get; }
    }

    [Serializable]
    public class TypeaheadTemplates<T>
    {
        public Func<T, string> Suggestion { get; set; }
        public TypeOption<string, Func<ITypeaheadQueryContext, string>> Empty { get; set; }
        public TypeOption<string, Func<ITypeaheadQueryWithEmptyContext, string>> Header { get; set; }
        public TypeOption<string, Func<ITypeaheadQueryWithEmptyContext, string>> Footer { get; set; }
    }

    [Serializable]
    [Imported]
    public interface ITypeaheadDataset { }

    [Serializable]
    public class TypeaheadDataset<T> : ITypeaheadDataset
    {
        public TypeaheadDatasetSource<T> Source { get; set; }
        public string Name { get; set; }
        public Func<T, string> DisplayKey { get; set; }
        public TypeaheadTemplates<T> Templates { get; set; }
    }

    public static class Typeahead2Events
    {
        public static readonly jQueryEventName Opened = "typeahead:opened";
        public static readonly jQueryEventName Closed = "typeahead:closed";
    }

    public static class Typeahead2Events<T>
    {
        public static readonly jQueryEventName<TypeaheadEventHandlerWithContext<T>> CursorChanged = "typeahead:cursorchanged";
        public static readonly jQueryEventName<TypeaheadEventHandlerWithContext<T>> Selected = "typeahead:selected";
        public static readonly jQueryEventName<TypeaheadEventHandlerWithContext<T>> AutoCompleted = "typeahead:autocompleted";
    }

    [BindThisToFirstParameter]
    public delegate void TypeaheadEventHandlerWithContext<T>(Element element, jQueryEvent evt, T suggestion, string datasetName);

    [NamedValues]
    [Imported]
    public enum BloodhoundRateLimitBy
    {
        Debounce, Throttle
    }

    [Serializable]
    [Imported]
    public class BloodhoundRemoteOptions<T>
    {
        public string Url;
        public string Wildcard;
        public Func<string, string, string> Replace;
        public BloodhoundRateLimitBy RateLimitBy;
        public int RateLimitWait = 300;
        public Func<object, T[]> Filter;
        public jQueryAjaxOptions<object> Ajax;
    }

    [Serializable]
    [Imported]
    public class BloodhoundOptions<T>
    {
        public string Name;

        public Func<T, string[]> DatumTokenizer;
        public Func<string, string[]> QueryTokenizer;

        public TypeOption<string, BloodhoundRemoteOptions<T>> Remote;
        public T[] Local;
        // TODO
    }

    [Imported]
    [IgnoreNamespace]
    public class Bloodhound<T>
    {
        public Bloodhound(BloodhoundOptions<T> options) { }

        public void Initialize(bool force = false) { }

        public void Add(params T[] array) { }
        public void Get(string query, Action<T[]> suggestions) { }

        public TypeaheadDatasetSource<T> TtAdapter() { return null; }
    }

    [Imported]
    [ScriptNamespace("Bloodhound")]
    [ScriptName("tokenizers")]
    public static class BloodhoundTokenizers
    {
        public static Func<string, string[]> Whitespace;
        [ScriptName("nonword")]
        public static Func<string, string[]> NonWord;

        // ... Obj;
    }

    public static partial class jQueryEx
    {
        [InstanceMethodOnFirstArgument]
        public static jQueryObject Typeahead(this jQueryObject jQuery, TypeaheadOptions options, params ITypeaheadDataset[] datasets) { return null; }

        [InlineCode("{jQuery}.typeahead('destroy')")]
        public static jQueryObject TypeaheadDestroy(this jQueryObject jQuery) { return null; }

        [InlineCode("{jQuery}.typeahead('open')")]
        public static jQueryObject TypeaheadOpen(this jQueryObject jQuery) { return null; }

        [InlineCode("{jQuery}.typeahead('close')")]
        public static jQueryObject TypeaheadClose(this jQueryObject jQuery) { return null; }

        [InlineCode("{jQuery}.typeahead('val')")]
        public static string TypeaheadGetValue(this jQueryObject jQuery) { return null; }

        [InlineCode("{jQuery}.typeahead('val', {value})")]
        public static jQueryObject TypeaheadValue(this jQueryObject jQuery, string value) { return null; }

        [InlineCode("{jQuery}.typeahead('typeahead:opened', {value})")]
        public static jQueryObject OnTypeaheadOpened(this jQueryObject jQuery, string value) { return null; }
    }
}
