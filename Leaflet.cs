using System;
using System.Collections.Generic;
using System.Html;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefinitelySalt
{
    [Imported]
    [IgnoreNamespace]
    [ScriptName("L")]
    public static class Leaflet
    {
        public static extern ILeafletMap Map(TypeOption<string, HtmlElement> elementOrId, LeafletMapOptions options = null);

        [ScriptName("CRS")]
        public static extern ILeafletCrsDefinitions Crs { get; }

        public static extern ILeafletPoint Point(double x, double y, bool round = false);
        public static extern ILeafletLatLng LatLng(double latitude, double longitude, double? altitude = null);
        public static extern ILeafletLatLngBounds LatLngBounds(ILeafletLatLng corner1, ILeafletLatLng corner2);

        public static extern ILeafletTileLayer TileLayer(string urlTemplate, LeafletTileLayerOptions options = null);
        public static extern ILeafletPopup Popup(LeafletPopupOptions options = null, ILeafletLayer source = null);
        public static extern ILeafletTooltip Popup(LeafletTooltipOptions options = null, ILeafletLayer source = null);

        public static extern ILeafletMarker Marker(ILeafletLatLng latLng, LeafletMarkerOptions options = null);
        public static extern ILeafletIcon Icon(LeafletIconOptions options);
        public static extern ILeafletDivIcon DivIcon(LeafletDivIconOptions options);

        public static extern ILeafletCircle Circle(ILeafletLatLng latLng, LeafletCircleOptions options = null);

        public static extern ILeafletMarkerClusterGroup MarkerClusterGroup(LeafletMarkerClusterGroupOptions options);

        [ScriptName("geoJSON")]
        public static extern ILeafletGeoJson GeoJson();

        [ScriptName("geoJSON")]
        public static extern ILeafletGeoJson GeoJson(object geoJson);
    }

    [Imported]
    [NamedValues]
    public enum LeafletPaneNames
    {
        MapPane, // auto - Pane that contains all other map panes
        TilePane, // 200 - Pane for GridLayers and TileLayers
        OverlayPane, // 400 - Pane for vectors (Paths, like Polylines and Polygons), ImageOverlays and VideoOverlays
        ShadowPane, // 500 - Pane for overlay shadows (e.g. Marker shadows)
        MarkerPane, // 600 - Pane for Icons of Markers
        TooltipPane, // 650 - Pane for Tooltips.
        PopupPane, // 700 - Pane for Popups.
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletCrsDefinitions
    {
        [ScriptName("Simple")]
        ILeafletCrs Simple { get; }

        [ScriptName("EPSG3857")]
        ILeafletCrs Epsg3857 { get; }
    }

    [Imported]
    [Serializable]
    public class LeafletMapOptions
    {
        public bool PreferCanvas;
        public bool AttributionControl = true;
        public bool ZoomControl = true;
        // ...

        [ScriptName("CRS")]
        public ILeafletCrs Crs;

        public ILeafletLatLng Center;
        public double Zoom;
        public double MinZoom;
        public double MaxZoom;
        public List<ILeafletLayer> Layers;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLatLng
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLatLngBounds
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLayerContainer
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLayerContainer<T> : ILeafletLayerContainer
    {
        T AddLayer(ILeafletLayer layer);
        T RemoveLayer(ILeafletLayer layer);

        bool HasLayer(ILeafletLayer layer);
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletMap : ILeafletLayerContainer<ILeafletMap>
    {
        ILeafletMap Remove();
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletCrs
    {

    }

    [Imported]
    [Serializable]
    public class LeafletLayerOptions
    {
        public TypeOption<LeafletPaneNames, string> Pane;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLayer
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLayer<T> : ILeafletLayer
    {
        T AddTo(ILeafletLayerContainer container);
        T RemoveFrom(ILeafletLayerContainer container);
        T Remove();

        T BindPopup(TypeOption<string, HtmlElement, Func<ILeafletLayer, TypeOption<string, HtmlElement>>, ILeafletPopup> content, LeafletPopupOptions options = null);
        T UnbindPopup();
        T SetPopupContent(TypeOption<string, HtmlElement, Func<ILeafletLayer, TypeOption<string, HtmlElement>>> content);

        T BindTooltip(TypeOption<string, HtmlElement, Func<ILeafletLayer, TypeOption<string, HtmlElement>>, ILeafletTooltip> content, LeafletTooltipOptions options = null);
        T UnbindTooltip();
        T SetTooltipContent(TypeOption<string, HtmlElement, Func<ILeafletLayer, TypeOption<string, HtmlElement>>> content);
    }

    [Imported]
    [Serializable]
    public class LeafletInterfactiveLayerOptions : LeafletLayerOptions
    {
        public bool? Interactive;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletDivOverlay<T> : ILeafletLayer<T>
    {
        T SetContent(TypeOption<string, HtmlElement, Func<ILeafletLayer, TypeOption<string, HtmlElement>>> content);
    }

    [Imported]
    [Serializable]
    public class LeafletPopupOptions
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletPopup : ILeafletDivOverlay<ILeafletPopup>
    {
    }

    [Imported]
    [Serializable]
    public class LeafletTooltipOptions
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletTooltip : ILeafletDivOverlay<LeafletTooltipOptions>
    {
    }

    [Imported]
    [Serializable]
    public class LeafletTileLayerOptions
    {
        public int TileSize;
        public double? MaxNativeZoom = null;
        public double MinZoom = 0;
        public double MaxZoom = 18;
        // ...

        public string Attribution;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletTileLayer : ILeafletLayer<ILeafletTileLayer>
    {

    }

    [Imported]
    [Serializable]
    public class LeafletMarkerOptions
    {
        public ILeafletIconBase Icon;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletMarker : ILeafletLayer<ILeafletMarker>
    {
        ILeafletMarker SetIcon(ILeafletIconBase icon);

        HtmlElement GetElement();
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletIconBase
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletIconBase<T> : ILeafletIconBase
    {

    }

    [Imported]
    [Serializable]
    public class LeafletIconOptions
    {
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletIcon : ILeafletIconBase<ILeafletIcon>
    {

    }

    [Imported]
    [Serializable]
    public class LeafletDivIconOptions
    {
        public ILeafletPoint IconSize;
        public ILeafletPoint IconAnchor;
        public string Html;
        public string ClassName;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletDivIcon : ILeafletIconBase<ILeafletDivIcon>
    {

    }

    [Imported]
    [Serializable]
    public class LeafletPathOptions : LeafletInterfactiveLayerOptions
    {
        public bool? Stroke;
        public string Color;
        public double? Width;
        public double? Opacity;
        public bool? Fill;
        public string FillColor;
        public double? FillOpacity;
        // TODO
        public string ClassName;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletPath<T, TOptions> : ILeafletLayer<T>
        where TOptions : LeafletPathOptions
    {
        T SetStyle(TOptions options);
    }

    [Imported]
    [Serializable]
    public class LeafletCircleOptions : LeafletPathOptions
    {
        public double Radius;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletCircle : ILeafletPath<ILeafletCircle, LeafletCircleOptions>
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletPoint
    {
        double X { [InlineCode("{this}[0]", GeneratedMethodName = "GetX")] get; }
        double Y { [InlineCode("{this}[1]", GeneratedMethodName = "GetY")] get; }
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletLayerGroup<T> : ILeafletLayer<T>, ILeafletLayerContainer<T>
    {

    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletFeatureGroup<T> : ILeafletLayerGroup<T>
    {

    }

    [Imported]
    [Serializable]
    public class LeafletMarkerClusterGroupOptions
    {
        public bool ShowCoverageOnHover = true;
        public int MaxClusterRadius = 80;

        public Func<ILeafletMarkerCluster, ILeafletIconBase> IconCreateFunction;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletMarkerClusterGroup : ILeafletLayer<ILeafletMarkerClusterGroup>, ILeafletFeatureGroup<ILeafletMarkerClusterGroup>
    {
        ILeafletMarkerClusterGroup AddLayers(List<ILeafletLayer> layers);
        ILeafletMarkerClusterGroup RemoveLayers(List<ILeafletLayer> layers);
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletMarkerCluster
    {
        List<ILeafletMarker> GetAllChildMarkers();
        int GetChildCount();
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletGeoJson : ILeafletLayer<ILeafletGeoJson>
    {
        ILeafletGeoJson AddData(object geoJson);
    }
}
