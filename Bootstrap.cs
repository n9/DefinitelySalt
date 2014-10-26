using System;
using System.Collections.Generic;
using System.Text;
using jQueryApi;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    public static class Bootstrap
    {

    }

    // https://github.com/eternicode/bootstrap-datepicker
    [Imported]
    [ScriptNamespace("$.fn")]
    [ScriptName("datepicker")]
    public static class BootstrapDatePicker
    {
        [InlineCode("$(document).off('.datepicker.data-api')")]
        public static void DisableDataApi() { return; }

        [InlineCode("{$DefinitelySalt.BootstrapDatePicker}.DPGlobal.formatDate({$System.Script}.fromUTC({date}), {format}, {language})")]
        public static string FormatDate(DateTime? date, string format, string language) { return null; }

        [InlineCode("{$System.Script}.toUTC({$DefinitelySalt.BootstrapDatePicker}.DPGlobal.parseDate({text}, {format}, {language}))")]
        public static DateTime? ParseDate(string text, string format, string language) { return null; }
    }

    [Imported]
    public static class BootstrapDatePickerEx
    {
        [InstanceMethodOnFirstArgument]
        [ScriptName("datepicker")]
        public static jQueryObject BootstrapDatePicker(this jQueryObject jq, BootstrapDatePickerOptions options = null) { return null; }

        [InlineCode("{jq}.datepicker('show')")]
        public static jQueryObject BootstrapDatePickerShow(this jQueryObject jq) { return null; }

        [InlineCode("{jq}.datepicker('hide')")]
        public static jQueryObject BootstrapDatePickerHide(this jQueryObject jq) { return null; }

        [InlineCode("{jq}.datepicker('place')")]
        public static jQueryObject BootstrapDatePickerPlace(this jQueryObject jq) { return null; }

        [InlineCode("{jq}.datepicker('setValue', {value})")]
        public static jQueryObject BootstrapDatePickerSetValue(this jQueryObject jq, TypeOption<string, JsDate, DateTime> value) { return null; }

        public const string Disabled = "disabled";
    }

    [Imported]
    [NamedValues]
    public enum BootstrapDatePickerStartView
    {
        Month,
        Year,
        Decade,
    }

    [Imported]
    [NamedValues]
    public enum BootstrapDatePickerMinViewMode
    {
        Days,
        Months,
        Years,
    }

    [Imported]
    [NamedValues]
    public enum BootstrapDatePickerTodayButton
    {
        True,
        Linked
    }

    [Serializable]
    [IgnoreNamespace]
    [Imported]
    public class BootstrapDatePickerOptions
    {
        public bool ForceParse = true;
        public string Format;
        public string Language;
        [ScriptName("autoclose")]
        public bool AutoClose;
        [ScriptName("clearBtn")]
        public bool ClearButton;
        public DateTime StartDate;
        public DateTime EndDate;
        public DayOfWeek WeekStart;
        public BootstrapDatePickerStartView StartView;
        public BootstrapDatePickerMinViewMode MinViewMode;
        public Func<DateTime, BootstrapDatePickerBeforeShowDay> BeforeShowDay;
        [ScriptName("todayBtn")]
        public BootstrapDatePickerTodayButton? TodayButton;
        public bool TodayHighlight;
    }

    [Imported]
    [Serializable]
    public class BootstrapDatePickerBeforeShowDay
    {
        public bool Enabled;
        public string Classes;
        public string Tooltip;
    }

    
    public delegate string BootstrapDatePickerEventFormat(int? index = null, string format = null);

    [Imported]
    public abstract class BootstrapDatePickerEvent// : jQueryEvent https://github.com/erik-kallen/SaltarelleCompiler/issues/285
    {
        public DateTime Date;
        public DateTime Dates;
        public BootstrapDatePickerEventFormat Format; 
    }

    [BindThisToFirstParameter]
    public delegate void BootstrapDatePickerEventHandlerWithContext(Element element, BootstrapDatePickerEvent evt);

    public static class BootstrapDatePickerEvents
    {
        public static readonly jQueryEventName<BootstrapDatePickerEventHandlerWithContext> Show = "show";
        public static readonly jQueryEventName<BootstrapDatePickerEventHandlerWithContext> Hide = "hide";
        public static readonly jQueryEventName<BootstrapDatePickerEventHandlerWithContext> ClearDate = "clearDate";
        public static readonly jQueryEventName<BootstrapDatePickerEventHandlerWithContext> ChangeDate = "changeDate";
        public static readonly jQueryEventName<BootstrapDatePickerEventHandlerWithContext> ChangeYear = "changeYear";
        public static readonly jQueryEventName<BootstrapDatePickerEventHandlerWithContext> ChangeMonth = "changeMonth";
    }
}
