using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    public enum SpinnerDirection
    {
        Clockwise = 1,
        Counterclockwise = -1
    }

    [Imported]
    [Serializable]
    public class SpinnerOptions
    {
        public int Lines;
        public double Length;
        public double Width;
        public double Radius;
        public double Corners;
        public double Rotate;
        public SpinnerDirection Direction;
        public string Color;
        public double Speed;
        public double Trail;
        public bool Shadow;
        public bool HwAccel;
        public string ClassName;
        public double ZIndex;
        public TypeOption<string, double> Top;
        public TypeOption<string, double> Left;
    }

    [Imported]
    [IgnoreNamespace]
    public class Spinner
    {
        public extern Spinner(SpinnerOptions options = null);
        public extern Spinner Spin(Element target = null);
        public extern Spinner Stop();
        
        [ScriptName("el")]
        public readonly Element Element;
    }
}
