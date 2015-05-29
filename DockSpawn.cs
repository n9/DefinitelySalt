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

        public extern IDockNode DockLeft(IDockNode reference, PanelContainer panel, double ratio);
        public extern IDockNode DockRight(IDockNode reference, PanelContainer panel, double ratio);
        public extern IDockNode DockUp(IDockNode reference, PanelContainer panel, double ratio);
        public extern IDockNode DockDown(IDockNode reference, PanelContainer panel, double ratio);
        public extern IDockNode DockFill(IDockNode reference, PanelContainer panel);

        public extern void AddLayoutListener(IDockLayoutListener listener);
        public extern void RemoveLayoutListener(IDockLayoutListener listener);
    }

    [Imported]
    [IgnoreNamespace]
    public interface IDockLayoutListener
    {
        void OnSuspendLayout(DockManager sender);
        void OnResumeLayout(DockManager sender);
        void OnDock(DockManager sender, IDockNode node);
        void OnUnDock(DockManager sender, IDockNode node);
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
