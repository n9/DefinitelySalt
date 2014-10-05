using jQueryApi;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [NamedValues]
    public enum Select2Width
    {
        Copy, Element, Resolve
    }

    [Serializable]
    [Imported]
    public class Select2Item
    {
        public string Id;
        public string Text;
        public Select2Item[] Children;
    }

    [Serializable]
    [Imported]
    public class Select2Result<T>
    {
        public T[] Results;
        public bool? More;
        public object Context;
    }

    [Imported]
    public class Select2Query<T>
    {
        public jQueryObject Element;
        public string Term;
        public int Page;
        public object Context;
        public void Callback(Select2Result<T> data) { }
    }

    [Serializable]
    [Imported]
    public class Select2AjaxBase<TData>
    {
        public Delegate Transport;
        public TypeOption<string, Func<string>> Url;
        public string DataType;
        public int? QuietMillis;
        public bool? Cache;
        public TypeOption<string, Func<string>> JsonpCallback;
        public Func<string, int, object, JsDictionary<string, string>> Data;
        public TypeOption<JsDictionary<string, string>, Func<JsDictionary<string, string>>> Params;
    }

    [Serializable]
    [Imported]
    public class Select2Ajax<TData> : Select2AjaxBase<TData>
    {
        public Func<TData[], int, object, Select2Result<TData>> Results;
    }

    [Serializable]
    [Imported]
    public class Select2Ajax<TData, TResult> : Select2AjaxBase<TResult>
    {
        public Func<TData[], int, object, Select2Result<TResult>> Results;
    }

    public delegate bool Select2Matcher(string term, string text, jQueryObject option);
    public delegate object Select2SortResults(object results, jQueryObject container, object query);
    public delegate string Select2FormatSelection<T>(T obj, jQueryObject container, Func<string, string> escapeMarkup);
    public delegate string Select2FormatResult<T>(T obj, jQueryObject container, Select2Query<T> query, Func<string, string> escapeMarkup);
    public delegate string Select2FormatInputTooShort(string term, int minLength);
    public delegate string Select2FormatSelectionTooBig(int maxSize);
    public delegate void Select2InitSelection<T>(jQueryObject element, Action<TypeOption<T, T[]>> callback);
    public delegate string Select2Tokenizer<T>(string input, object[] selection, Action<object> selectCallback, Select2Options<T> options);

    [Serializable]
    [Imported]
    public class Select2Options<T>
    {
        public TypeOption<Select2Width, string, Func<TypeOption<Select2Width, string>>> Width;
        public int? MinimumInputLength;
        public int? MaximumInputLength;
        public int? MinimumResultsForSearch;
        public TypeOption<int, Func<int>> MaximumSelectionSize;
        public string Placeholder;
        public TypeOption<string, Func<string>> PlaceholderOption;
        public string Separator;
        public bool? AllowClear;
        public bool? Multiple;
        public bool? CloseOnSelect;
        public bool? OpenOnEnter;
        public bool? SelectOnBlur;
        public bool? DropdownAutoWidth;
        public int? LoadMorePadding;
        public Func<T, string> Id;
        public Select2Matcher Matcher;
        public Select2SortResults SortResults;
        public Select2FormatSelection<T> FormatSelection;
        public Select2FormatResult<T> FormatResult;
        public Func<T, string> FormatResultCssClass;
        public Func<string, string> FormatNoMatches;
        public Func<string> FormatSearching;
        public Select2FormatInputTooShort FormatInputTooShort;
        public Select2FormatSelectionTooBig FormatSelectionTooBig;
        public Func<string, object> CreateSearchChoice;
        public Select2InitSelection<T> InitSelection;
        public Select2Tokenizer<T> Tokenizer;
        public string[] TokenSeparators;
        public Action<Select2Query<T>> Query;
        public Select2AjaxBase<T> Ajax;
        public TypeOption<T, Select2Item[]> Data; // ...
        public TypeOption<Select2Item[], Func<Select2Item[]>> Tags; // ...
        public TypeOption<JsDictionary<string, object>, Func<JsDictionary<string, object>>> ContainerCss;
        public TypeOption<string, Func<string>> ContainerCssClass;
        public TypeOption<JsDictionary<string, object>, Func<JsDictionary<string, object>>> DropdownCss;
        public TypeOption<string, Func<string>> DropdownCssClass;
        public Func<string, string> AdaptContainerCssClass;
        public Func<string, string> AdaptDropdownCssClass;
        public Func<string, string> EscapeMarkup;
        public Delegate NextSearchTerm; // ?

        // undoc
        public Func<string, int, string> FormatInputTooLong;
        public Func<int, string> FormatLoadMore;
    }

    [Serializable]
    [Imported]
    public class Select2Options : Select2Options<Select2Item>
    {

    }

    public static class Select2Events
    {
        public readonly static jQueryEventName Changed = "change.select2";
    }

    public static partial class jQueryEx
    {
        [InstanceMethodOnFirstArgument]
        public static jQueryObject Select2(this jQueryObject jQuery) { return null; }

        [InstanceMethodOnFirstArgument]
        public static jQueryObject Select2(this jQueryObject jQuery, Select2Options options) { return null; }

        [InstanceMethodOnFirstArgument]
        public static jQueryObject Select2<T>(this jQueryObject jQuery, Select2Options<T> options) { return null; }

        [InlineCode("{jQuery}.select2('val')")]
        public static string Select2GetValue(this jQueryObject jQuery) { return null; }

        [InlineCode("{jQuery}.select2('val', {value})")]
        public static jQueryObject Select2SetValue(this jQueryObject jQuery, object value) { return null; }
    }
}
