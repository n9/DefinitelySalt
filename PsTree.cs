using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [IgnoreNamespace]
    [Imported]
    public static class PsTree
    {
        [InlineCode("require('ps-tree')({pid}, {action})")]
        public static extern void For(int pid, Action<Error, List<PsTreeProcessInfo>> action);
    }

    [Imported]
    [Serializable]
    public class PsTreeProcessInfo
    {
        [ScriptName("PID")]
        public string Pid;

        // ...
    }
}
