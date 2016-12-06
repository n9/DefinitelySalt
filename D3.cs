using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Html;

namespace DefinitelySalt
{
    public delegate T D3Func<TD, T>(TD datum, int index);
    public delegate void D3Action<TD, T>(TD datum, int index);

    [BindThisToFirstParameter]
    public delegate T D3ElementFunc<TD, T>(XmlElement element, TD datum, int index);

    [BindThisToFirstParameter]
    public delegate void D3ElementAction<TD>(TD datum, int index);

    [Imported]
    public class D3Source<TD, T>
    {
        [ScriptSkip]
        public static implicit operator D3Source<TD, T>(T value) { return null; }
        [ScriptSkip]
        public static implicit operator D3Source<TD, T>(D3ElementFunc<TD, T> func) { return null; }
        [ScriptSkip]
        public static implicit operator D3Source<TD, T>(Func<TD, int, T> func) { return null; }
        [ScriptSkip]
        public static implicit operator D3Source<TD, T>(Func<TD, T> func) { return null; }
    }

    [Imported]
    public interface ID3Point
    {
        int X { [InlineCode("{this}[0]", GeneratedMethodName = "x")] get; }
        int Y { [InlineCode("{this}[1]", GeneratedMethodName = "y")] get; }
    }

    [Imported]
    [IgnoreNamespace]
    [ScriptName("d3")]
    public static class D3
    {
        public static extern ID3Selection<object> Select(string selector);
        public static extern ID3Selection<object> Select(XmlElement element);
        public static extern ID3Selection<object> SelectAll(string selector);
        public static extern ID3Selection<object> SelectAll(XmlElement[] element);
        public static extern ID3Selection<object> Selection();
        public static extern ID3Transition<object> Transition();

        [IntrinsicProperty]
        public static extern Event Event { get; }
        public static extern ID3Point Mouse(XmlElement container);
        public static extern ID3Point[] Touches(XmlElement container);
        public static extern ID3Point[] Touches(XmlElement container, TouchList touches);

        public static extern T[] Extent<T>(T[] array);
        public static extern TO[] Extent<TI, TO>(TI[] array, Func<TI, TO> accessor);
        public static extern TO[] Extent<TI, TO>(TI[] array, Func<TI, int, TO> accessor);
        public static extern T Min<T>(T[] array);
        public static extern TO Min<TI, TO>(TI[] array, Func<TI, TO> accessor);
        public static extern TO Min<TI, TO>(TI[] array, Func<TI, int, TO> accessor);
        public static extern T Max<T>(T[] array);
        public static extern TO Max<TI, TO>(TI[] array, Func<TI, TO> accessor);
        public static extern TO Max<TI, TO>(TI[] array, Func<TI, int, TO> accessor);

        public extern static D3NumberFormatter Format(string specifier);
        [InlineCode("{$DefinitelySalt.D3}.format = {format}")]
        public extern static void SetFormat(ID3NumberFormatConstructor format);

        public static extern D3Locale Locale(D3LocaleDefinition definition);

        public static extern ID3RgbColor Rgb(byte r, byte g, byte b);
        public static extern ID3RgbColor Rgb(string text);

        public static extern ID3HslColor Hsl(double h, double s, double l);
        public static extern ID3HslColor Hsl(string text);

        public static extern ID3HclColor Hcl(double h, double c, double l);
        public static extern ID3HclColor Hcl(string text);

        public static extern ID3LabColor Lab(double l, double a, double b);
        public static extern ID3LabColor Lab(string text);
    }

    public delegate string D3NumberFormatter(double value);

    [Imported]
    public interface ID3NumberFormatConstructor { }

    [Imported]
    public interface ID3TimeFormatConstructor { }

    [Imported]
    [Serializable]
    public class D3Locale
    {
        public ID3NumberFormatConstructor NumberFormat;
        public ID3TimeFormatConstructor TimeFormat;
    }

    [Imported]
    [Serializable]
    public class D3LocaleDefinition
    {
        public string Decimal;
        public string Thousands;
        public int[] Grouping;
        public string[] Currency;
        public string DateTime;
        public string Date;
        public string Time;
        public string[] Periods;
        public string[] Days;
        public string[] ShortDays;
        public string[] Months;
        public string[] ShortMonths;
    }

    [Imported]
    public static partial class D3Static
    {
        [InstanceMethodOnFirstArgument]
        public extern static TS Call<TS, TI>(this TS selection, Action<TI> action)
            where TS : TI
            where TI : ID3Selection;

        [InstanceMethodOnFirstArgument]
        public extern static TS Call<TS, TI, T1>(this TS selection, Action<TI, T1> action, T1 a1)
            where TS : TI
            where TI : ID3Selection;

        // TODO ...

        [InstanceMethodOnFirstArgument]
        public extern static TS Call<TS>(this TS selection, ID3Function action)
            where TS : ID3Selection;

        [InstanceMethodOnFirstArgument]
        public extern static TS Text<TS>(this TS selection, string value)
            where TS : ID3Selection;

        [InstanceMethodOnFirstArgument]
        public extern static ID3Selection<TD> Text<TD>(this ID3Selection<TD> selection, Func<TD, string> value);

        [InstanceMethodOnFirstArgument]
        public extern static ID3UpdateSelection<TD> Text<TD>(this ID3UpdateSelection<TD> selection, Func<TD, string> value);

        [InstanceMethodOnFirstArgument]
        public extern static TS Text<TS, TD>(this TS selection, D3Source<TD, string> value)
            where TS : ID3Selection<TD>;
    }

    [Imported]
    public interface ID3CreatorSeletion<TD>
    {
        ID3Selection<TD> Append(D3Source<TD, string> tagName);
        ID3Selection<TD> Append(D3Source<TD, XmlElement> element);
        ID3Selection<TD> Insert(D3Source<TD, string> tagName);
        ID3Selection<TD> Insert(D3Source<TD, XmlElement> element);
        ID3Selection<TD> Insert(D3Source<TD, string> tagName, D3Source<TD, string> beforeSelector);
        ID3Selection<TD> Insert(D3Source<TD, string> tagName, D3Source<TD, XmlElement> beforeElement);
        ID3Selection<TD> Insert(D3Source<TD, XmlElement> element, D3Source<TD, string> beforeSelector);
        ID3Selection<TD> Insert(D3Source<TD, XmlElement> element, D3Source<TD, XmlElement> beforeElement);
    }

    [Imported]
    public interface ID3RemoverSeletion<TD>
    {
        ID3Selection<TD> Remove();
    }
    
    [Imported]
    public interface ID3Selection { }

    [Imported]
    public interface ID3Selection<TD> : ID3CreatorSeletion<TD>, ID3RemoverSeletion<TD>, ID3Selection
    {
        [ScriptName("attr")]
        ID3Selection<TD> Attribute(string name, D3Source<TD, object> value);
        [ScriptName("attr")]
        ID3Selection<TD> Attribute<T>(string name, T value);
        [ScriptName("attr")]
        ID3Selection<TD> Attribute<T>(string name, Func<TD, T> value);
        [ScriptName("attr")]
        ID3Selection<TD> Attribute<T>(string name, D3Source<TD, T> value);
        [ScriptName("attr")]
        ID3Selection<TD> Attribute(D3Source<TD, JsDictionary<string, bool>> value);

        [ScriptName("classed")]
        bool IsClassed(string name);
        ID3Selection<TD> Classed(D3Source<TD, string> name, D3Source<TD, bool> value);
        ID3Selection<TD> Classed(D3Source<TD, JsDictionary<string, bool>> value);

        [ScriptName("style")]
        object GetStyle(string name);
        [ScriptName("style")]
        T GetStyle<T>(string name);
        ID3Selection<TD> Style(string name, D3Source<TD, object> value);
        ID3Selection<TD> Style<T>(string name, D3Source<TD, T> value);
        ID3Selection<TD> Style(D3Source<TD, JsDictionary<string, object>> value);

        [ScriptName("property")]
        object GetProperty(string name);
        [ScriptName("property")]
        T GetProperty<T>(string name);
        ID3Selection<TD> Property(string name, D3Source<TD, object> value);
        ID3Selection<TD> Property<T>(string name, D3Source<TD, T> value);
        ID3Selection<TD> Property(D3Source<TD, JsDictionary<string, object>> value);

        [ScriptName("text")]
        string GetText();

        [ScriptName("html")]
        string GetHtml();
        ID3Selection<TD> Html(D3Source<TD, string> value);

        ID3UpdateSelection<TR[]> Data<TR>(TR[] data);
        ID3UpdateSelection<TR> Data<TR>(D3Source<TD, TR> data);
        ID3UpdateSelection<TR> Data<TR, TI>(D3Source<TD, TI> data, Func<TI, TR> selector);

        [ScriptName("datum")]
        TD GetDatum();
        ID3UpdateSelection<TR> Datum<TR>(TR data);
        ID3UpdateSelection<TR> Datum<TR>(D3Source<TD, TR> data);

        ID3Selection<TD> Filter(string selector);
        ID3Selection<TD> Filter(D3ElementFunc<TD, bool> filter);

        ID3Selection<TD> Sort(Comparison<TD> selector);
        ID3Selection<TD> Order();

        ID3Selection<TD> Transition();
        ID3Selection<TD> Interrupt();

        ID3Selection<TD> Select(string selector);
        ID3Selection<TD> Select(D3ElementFunc<TD, XmlElement> selector);
        ID3Selection<TD> SelectAll(string selector);
        ID3Selection<TD> SelectAll(D3ElementFunc<TD, XmlElement[]> selector); // OR XmlNodeList

        XmlElement this[int index] { get; }

        ID3Selection<TD> Each(D3ElementAction<TD> action);

        [ScriptName("empty")]
        bool IsEmpty();

        [ScriptName("node")]
        XmlElement First();

        int Size();

        [ScriptName("on")]
        Delegate GetOn(string eventType);
        ID3Selection<TD> On(string eventType, D3ElementAction<TD> listener);
        ID3Selection<TD> On(string eventType, D3ElementAction<TD> listener, bool useCapture);
    }

    [Imported]
    public interface ID3Transition<TD>
    {

    }

    [Imported]
    public interface ID3UpdateSelection<TD> : ID3Selection<TD>
    {
        ID3EnterSelection<TD> Enter();
        ID3ExitSelection<TD> Exit();
    }

    [Imported]
    public interface ID3EnterSelection<TD> : ID3CreatorSeletion<TD>
    {

    }

    [Imported]
    public interface ID3ExitSelection<TD> : ID3RemoverSeletion<TD>
    {

    }

    [Imported]
    public interface ID3Scale<T>
    {
        [InlineCode("{this}({x})", GeneratedMethodName = "apply")]
        double Apply(T x);

        ID3Scale<T> Domain(params T[] values);
        ID3Scale<T> Range(params double[] values);
    }

    [Imported]
    public interface ID3LinearScale<T> : ID3Scale<T>
    {

    }

    [Imported]
    [ScriptNamespace("d3")]
    [ScriptName("scale")]
    public static class D3Scale
    {
        public static ID3LinearScale<T> Linear<T>() { return null; }
    }

    [Imported]
    [ScriptNamespace("d3")]
    [ScriptName("time")]
    public static class D3Time
    {
        [Imported]
        public interface IMultiFormats { }

        public extern static D3TimeFormat Format(string specifier);
        [InlineCode("{$DefinitelySalt.D3Time}.format = {format}")]
        public extern static void SetFormat(ID3TimeFormatConstructor format);
        [InlineCode("{$DefinitelySalt.D3Time}.format.multi({formats})")]
        public extern static D3TimeFormat FormatMulti(IMultiFormats formats);

        public extern static ID3TimeScale Scale();
        [InlineCode("{$DefinitelySalt.D3Time}.scale.utc()")]
        public extern static ID3TimeScale ScaleUtc();
    }


    [Imported]
    [ScriptNamespace("d3.time")]
    [ScriptName("format")]
    public class D3TimeFormat
    {
        [InlineCode("{this}({date})")]
        public string Format(DateTime date) { return null; }
        public DateTime? Parse(string text) { return null; }

        [ScriptSkip]
        public extern static implicit operator Func<DateTime, string>(D3TimeFormat format);
    }

    [Imported]
    public interface ID3TimeScale : ID3LinearScale<DateTime>
    {

    }

    [Imported]
    [ScriptNamespace("d3")]
    [ScriptName("svg")]
    public static class D3Svg
    {
        public static D3SvgAxis<T> Axis<T>() { return null; }
        public static D3SvgArea<T> Area<T>() { return null; }
    }

    [Imported]
    [NamedValues]
    public enum D3SvgAxisOrient
    {
        Top, Bottom, Left, Right
    }

    [Imported]
    public interface ID3Function
    {
        string Apply(ID3Selection data);
    }

    [Imported]
    public abstract class D3SvgAxis<TD> : ID3Function
    {
        [InlineCode("{this}({data})", GeneratedMethodName = "apply")]
        public extern string Apply(ID3Selection data);

        [ScriptSkip]
        public extern static implicit operator Action<ID3Selection<TD>>(D3SvgAxis<TD> area);

        [ScriptName("scale")]
        public extern ID3Scale<TD> GetScale();
        public extern D3SvgAxis<TD> Scale(ID3Scale<TD> scale);

        [ScriptName("orient")]
        public extern D3SvgAxisOrient GetOrient();
        public extern D3SvgAxis<TD> Orient(D3SvgAxisOrient orient);

        [ScriptName("tickFormat")]
        public extern Func<TD, string> GetTickFormat();
        public extern D3SvgAxis<TD> TickFormat(Func<TD, string> value);

        public extern D3SvgAxis<TD> TickSize(double inner, double outer);

        [ScriptName("innerTickSize")]
        public extern double GetInnerTickSize();
        public extern D3SvgAxis<TD> InnerTickSize(double value);

        [ScriptName("outerTickSize")]
        public extern double GetOuterTickSize();
        public extern D3SvgAxis<TD> OuterTickSize(double value);

        [ScriptName("tickPadding")]
        public extern double GetTickPadding();
        public extern D3SvgAxis<TD> TickPadding(double value);
    }

    [Imported]
    public abstract class D3SvgArea<TD>
    {
        [InlineCode("{this}({data})", GeneratedMethodName = "apply")]
        public string Apply(TD[] data) { return null; }

        [ScriptSkip]
        public static implicit operator Func<string, TD>(D3SvgArea<TD> area) { return null; }

        public D3SvgArea<TD> X(double constant) { return null; }
        public D3SvgArea<TD> X(Func<TD, double> accessor) { return null; }
        public D3SvgArea<TD> X(Func<TD, int, double> accessor) { return null; }
        public D3SvgArea<TD> X0(double constant) { return null; }
        public D3SvgArea<TD> X0(Func<TD, double> accessor) { return null; }
        public D3SvgArea<TD> X0(Func<TD, int, double> accessor) { return null; }
        public D3SvgArea<TD> X1(double constant) { return null; }
        public D3SvgArea<TD> X1(Func<TD, double> accessor) { return null; }
        public D3SvgArea<TD> X1(Func<TD, int, double> accessor) { return null; }

        public D3SvgArea<TD> Y(double constant) { return null; }
        public D3SvgArea<TD> Y(Func<TD, double> accessor) { return null; }
        public D3SvgArea<TD> Y(Func<TD, int, double> accessor) { return null; }
        public D3SvgArea<TD> Y0(double constant) { return null; }
        public D3SvgArea<TD> Y0(Func<TD, double> accessor) { return null; }
        public D3SvgArea<TD> Y0(Func<TD, int, double> accessor) { return null; }
        public D3SvgArea<TD> Y1(double constant) { return null; }
        public D3SvgArea<TD> Y1(Func<TD, double> accessor) { return null; }
        public D3SvgArea<TD> Y1(Func<TD, int, double> accessor) { return null; }
    }

    [Imported]
    [IgnoreNamespace]
    public interface ID3ColorBase<T>
    {
        T Brighter(double k);
        T Darker(double k);
    }

    [Imported]
    [IgnoreNamespace]
    public interface ID3NonRgbColorBase<T> : ID3ColorBase<T>
    {
        ID3RgbColor Rgb();
    }

    [Imported]
    [IgnoreNamespace]
    public interface ID3RgbColor : ID3ColorBase<ID3RgbColor>
    {
        ID3HslColor Hsl();
    }

    [Imported]
    [IgnoreNamespace]
    public interface ID3HslColor : ID3NonRgbColorBase<ID3HslColor> { }

    [Imported]
    [IgnoreNamespace]
    public interface ID3HclColor : ID3NonRgbColorBase<ID3HclColor> { }

    [Imported]
    [IgnoreNamespace]
    public interface ID3LabColor : ID3NonRgbColorBase<ID3LabColor> { }
}
