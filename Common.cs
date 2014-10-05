using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    public class ArrayTuple<T1>
    {
        public T1 Item1 { [InlineCode("{this}[0]")] get; [InlineCode("{this}[0] = {value}")] set; }
    }

    public class ArrayTuple<T1, T2> : ArrayTuple<T1>
    {
        public T2 Item2 { [InlineCode("{this}[1]")] get; [InlineCode("{this}[1] = {value}")] set; }
    }

    public class ArrayTuple<T1, T2, T3> : ArrayTuple<T1, T2>
    {
        public T3 Item3 { [InlineCode("{this}[2]")] get; [InlineCode("{this}[2] = {value}")] set; }
    }
}
