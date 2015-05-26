using System;
using System.Collections.Generic;
using Framework.Core;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    [ScriptNamespace("dockspawn")]
    public class DockManager
    {
        public extern DockManager(Element element);

        public extern void Initialize();
        public extern void Resize(int width, int height);

        [IntrinsicProperty]
        public extern IDockContext Context { get; }

        [IntrinsicProperty]
        public extern Element Element { get; }

        public extern IDockNode DockLeft(IDockNode container, IDockNode child, double percentage);
        public extern IDockNode DockRight(IDockNode container, IDockNode child, double percentage);
        public extern IDockNode DockUp(IDockNode container, IDockNode child, double percentage);
        public extern IDockNode DockDown(IDockNode container, IDockNode child, double percentage);
        public extern IDockNode dockFill(IDockNode container, IDockNode child);
    }

    [Imported]
    [IgnoreNamespace]
    [Serializable]
    public interface IDockContext
    {
        IDockModel Model { get; }
    }

    [Imported]
    [IgnoreNamespace]
    [Serializable]
    public interface IDockModel
    {
        IDockNode DocumentManagerNode { get; }
    }

    [Imported]
    [IgnoreNamespace]
    [Serializable]
    public interface IDockNode
    {

    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public class PanelContainer
    {
        public extern PanelContainer(Element element, DockManager manager);
    }
}
