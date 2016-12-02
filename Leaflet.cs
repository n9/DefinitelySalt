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
        public static extern ILeafletMarker Marker(ILeafletLatLng latLng, LeafletMarkerOptions options = null);
        public static extern ILeafletIcon Icon(LeafletIconOptions options);
        public static extern ILeafletDivIcon DivIcon(LeafletDivIconOptions options);

        public static extern ILeafletMarkerClusterGroup MarkerClusterGroup(LeafletMarkerClusterGroupOptions options);
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
        public string Html;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletDivIcon : ILeafletIconBase<ILeafletDivIcon>
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
        public int MaxClusterRadius = 80;
    }

    [Imported]
    [IgnoreNamespace]
    public interface ILeafletMarkerClusterGroup : ILeafletLayer<ILeafletMarkerClusterGroup>, ILeafletFeatureGroup<ILeafletMarkerClusterGroup>
    {
        ILeafletMarkerClusterGroup AddLayers(List<ILeafletLayer> layers);
        ILeafletMarkerClusterGroup RemoveLayers(List<ILeafletLayer> layers);
    }
}
