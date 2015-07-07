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

        [IntrinsicProperty]
        public extern IDockModel Model { get; }

        [IntrinsicProperty]
        public extern Element Element { get; }

        public extern IDockNode DockLeft(IDockNode reference, PanelContainer<T> panel, double ratio);
        public extern IDockNode DockRight(IDockNode reference, PanelContainer<T> panel, double ratio);
        public extern IDockNode DockUp(IDockNode reference, PanelContainer<T> panel, double ratio);
        public extern IDockNode DockDown(IDockNode reference, PanelContainer<T> panel, double ratio);
        public extern IDockNode DockFill(IDockNode reference, PanelContainer<T> panel);

        public extern void AddLayoutListener(IDockLayoutListener<T> listener);
        public extern void RemoveLayoutListener(IDockLayoutListener<T> listener);

        public extern string SaveState();
        public extern void LoadState(string json);
    }

    [Imported]
    [IgnoreNamespace]
    public interface IDockLayoutListener<T>
    {
        void OnSuspendLayout(DockManager<T> sender);
        void OnResumeLayout(DockManager<T> sender);
        void OnDock(DockManager<T> sender, IDockNode node);
        void OnUnDock(DockManager<T> sender, IDockNode node);
    }

    [Imported]
    [IgnoreNamespace]
    [Serializable]
    public interface IDockModel
    {
        IDockNode RootNode { get; }
        IDockNode DocumentNode { get; }
    }

    [Imported]
    [IgnoreNamespace]
    [Serializable]
    public interface IDockNode
    {

    }

    [Imported]
    [ScriptNamespace("dockspawn")]
    public class PanelContainer<T>
    {
        public extern PanelContainer(T contentData, DockManager<T> manager, string title = null);

        [IntrinsicProperty]
        public extern string Title { get; [InlineCode("{this}.setTitle({value})")] set; }

        public Action OnCreated;
        public Action OnDestroyed;
    }
}
