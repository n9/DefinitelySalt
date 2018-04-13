using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;

namespace DefinitelySalt
{
    [Imported]
    [ScriptNamespace("")]
    public class Popper
    {
        public extern Popper(TypeOption<Element, IPopperReferenceObject> reference, Element popper, PopperOptions options);
        public extern void Destroy();
    }

    [Imported]
    public interface IPopperReferenceObject
    {
        DOMRect GetBoundingClientRect();
        int ClientWidth { get; }
        int ClientHeight { get; }
    }

    [Imported]
    [Serializable]
    public class PopperOptions
    {
        public string Placement;
        public bool? PositionFixed;
        public bool? EventsEnabled;
        public PopperModifiers Modifiers;
    }

    [Imported]
    [Serializable]
    public class PopperModifiers
    {
        public PopperFlipModifier Flip;
        public PopperPreventOverflowModifier PreventOverflow;
    }

    [Imported]
    [Serializable]
    public class PopperFlipModifier
    {
        public List<string> Behavior;
    }

    [Imported]
    [Serializable]
    public class PopperPreventOverflowModifier
    {
        public TypeOption<Element, string> BoundariesElement;
    }
}
