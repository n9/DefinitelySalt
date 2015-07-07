using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    [ScriptNamespace("")]
    public abstract class Ladda
    {
        public static extern Ladda Create(Element element);
        public static extern void StopAll();

        public extern Ladda Start();
        public extern Ladda StartAfter(int milis);
        public extern Ladda Stop();
        public extern Ladda Toggle();
        public extern bool IsLoading();

        public extern Ladda SetProgress(double progress);

        public extern void Remove();
    }
}
