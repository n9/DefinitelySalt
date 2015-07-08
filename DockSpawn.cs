using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Html;

namespace DefinitelySalt
{
    [Imported]
    [ScriptNamespace("dockspawn")]
    public class DockManager<T>
    {
        public extern DockManager(Element element, Func<T, PanelContainer<T>, Element> contentBuilder);

        public extern void Initialize();
        public extern void Resize(int width, int height);

        public readonly DockModel Model;
        public readonly Element Element;

        public extern DockNode DockLeft(DockNode reference, IDockContainer panel, double ratio);
        public extern DockNode DockRight(DockNode reference, IDockContainer panel, double ratio);
        public extern DockNode DockUp(DockNode reference, IDockContainer panel, double ratio);
        public extern DockNode DockDown(DockNode reference, IDockContainer panel, double ratio);
        public extern DockNode DockFill(DockNode reference, IDockContainer panel);

        public extern void AddLayoutListener(IDockLayoutListener<T> listener);
        public extern void RemoveLayoutListener(IDockLayoutListener<T> listener);

        public extern string SaveState();
        public extern void LoadState(string json);

        [ScriptName("_findNodeFromContainer")]
        public extern DockNode FindNodeFromContainer(IDockContainer container);
    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public interface IDockLayoutListener<T>
    {
        void OnSuspendLayout(DockManager<T> sender);
        void OnResumeLayout(DockManager<T> sender);
        void OnDock(DockManager<T> sender, DockNode node);
        void OnUnDock(DockManager<T> sender, DockNode node);
    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public class DockModel
    {
        public readonly DockNode RootNode;
        public readonly DockNode DocumentNode;
    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public class DockNode
    {
        public extern DockNode(IDockContainer container);

        public readonly IDockContainer Container;
        public readonly List<DockNode> Children;
    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public interface IDockContainer
    {

    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public class PanelContainer<T> : IDockContainer
    {
        public extern PanelContainer(T contentData, DockManager<T> manager, string title = null);

        [IntrinsicProperty]
        public extern string Title { get; [InlineCode("{this}.setTitle({value})")] set; }

        public Action OnCreated;
        public Action OnDestroyed;
    }
}
