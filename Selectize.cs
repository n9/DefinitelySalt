using jQueryApi;
using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Serializable]
    [Imported]
    public class SelectizeItem<T>
    {
        public string Text;
        public string Value;
        [ScriptName("$sort")]
        public double Sort;
        public T Item;
    }
    
    [Imported]
    public interface ISelectize<T>
    {
        Func<T, double> GetScoreFunction(string seach);
        void SetValue(string value);
        string GetValue();

        void AddOption(SelectizeItem<T> data);
        void UpdateOptions(string value, SelectizeItem<T> data);
        void RemoveOption(string value);
        void ClearOptions();
        jQueryObject GetOption();
        jQueryObject GetAdjacentOption(string value, int direction);
        void RefreshOptions(bool triggerDropdown);
    }

    [BindThisToFirstParameter]
    public delegate void SelectizeLoad<T>(ISelectize<T> selectize, string search, Action<SelectizeItem<T>[]> callback);

    [BindThisToFirstParameter]
    public delegate Func<T, double> SelectizeScore<T>(ISelectize<T> selectize, string search); 

    [Serializable]
    [Imported]
    public partial class SelectizeOptions<T>
    {
        public SelectizeLoad<T> Load;
        public SelectizeScore<T> Score;
        public SelectizeRender<T> Render;
        public string ValueField;
        public string LabelField;
        public string SearchField;
        public int? MaxItems;
        public bool? AllowEmptyOption;
        public SelectizeItem<T>[] Options;
        public TypeOption<bool, Func<string, SelectizeItem<T>>> Create;
    }

    [BindThisToFirstParameter]
    public delegate string SelectizeRenderItem<T>(ISelectize<T> selectize, SelectizeItem<T> item, Func<string, string> escape); 

    [Serializable]
    [Imported]
    public class SelectizeRender<T>
    {
        public SelectizeRenderItem<T> Option;
        public SelectizeRenderItem<T> Item;
    }

    public static partial class jQueryEx
    {
        [InstanceMethodOnFirstArgument]
        public static jQueryObject Selectize(this jQueryObject jQuery) { return null; }

        [InstanceMethodOnFirstArgument]
        public static jQueryObject Selectize(this jQueryObject jQuery, SelectizeOptions<object> options) { return null; }

        [InstanceMethodOnFirstArgument]
        public static jQueryObject Selectize<T>(this jQueryObject jQuery, SelectizeOptions<T> options) { return null; }
    }

    [Imported]
    public static class SelectizeEx
    {
        [InlineCode("{element}.selectize")]
        public extern static ISelectize<T> GetSelectize<T>(this Element element);

        [InlineCode("{jQ}[{index}].selectize")]
        public extern static ISelectize<T> GetSelectize<T>(this jQueryObject jQ, int index = 0);
    }
}
