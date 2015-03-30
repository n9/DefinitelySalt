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
        public static ID3Selection<object> Select(string selector) { return null; }
        public static ID3Selection<object> Select(XmlElement element) { return null; }
        public static ID3Selection<object> SelectAll(string selector) { return null; }
        public static ID3Selection<object> SelectAll(XmlElement[] element) { return null; }
        public static ID3Selection<object> Selection() { return null; }
        public static ID3Transition<object> Transition() { return null; }

        [IntrinsicProperty]
        public static Event Event { get { return null; } }
        public static ID3Point Mouse(XmlElement container) { return null; }
        public static ID3Point[] Touches(XmlElement container) { return null; }
        public static ID3Point[] Touches(XmlElement container, TouchList touches) { return null; }

        public static T[] Extent<T>(T[] array) { return null; }
        public static TO[] Extent<TI, TO>(TI[] array, Func<TI, TO> accessor) { return null; }
        public static TO[] Extent<TI, TO>(TI[] array, Func<TI, int, TO> accessor) { return null; }
        public static T Min<T>(T[] array) { return default(T); }
        public static TO Min<TI, TO>(TI[] array, Func<TI, TO> accessor) { return default(TO); }
        public static TO Min<TI, TO>(TI[] array, Func<TI, int, TO> accessor) { return default(TO); }
        public static T Max<T>(T[] array) { return default(T); }
        public static TO Max<TI, TO>(TI[] array, Func<TI, TO> accessor) { return default(TO); }
        public static TO Max<TI, TO>(TI[] array, Func<TI, int, TO> accessor) { return default(TO); }
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
        ID3Selection<TD> Classed(D3Source<TD, string> value);
        ID3Selection<TD> Classed(D3Source<TD, bool> value);
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
        public static D3TimeFormat Format(string specifier) { return null; }
        public static ID3TimeScale Scale() { return null; }
        [InlineCode("{$DefinitelySalt.D3Time}.scale.utc()")]
        public static ID3TimeScale ScaleUtc() { return null; }
    }

    [Imported]
    [ScriptNamespace("d3.time")]
    [ScriptName("format")]
    public class D3TimeFormat
    {
        [InlineCode("{this}({date})")]
        public string Format(DateTime date) { return null; }
        public DateTime? Parse(string text) { return null; }

        // TODO multi, utc, iso
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
        public string Apply(ID3Selection data) { return null; }

        [ScriptSkip]
        public static implicit operator Action<ID3Selection<TD>>(D3SvgAxis<TD> area) { return null; }

        public D3SvgAxis<TD> Scale(ID3Scale<TD> scale) { return null; }
        
        [ScriptName("scale")]
        public ID3Scale<TD> GetScale() { return null; }

        public D3SvgAxis<TD> Orient(D3SvgAxisOrient orient) { return null; }

        [ScriptName("orient")]
        public D3SvgAxisOrient GetOrient() { return default(D3SvgAxisOrient); }
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
}
