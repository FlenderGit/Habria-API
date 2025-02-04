using System.Drawing;
using BruTile.Predefined;
using BruTile.Web;
using BruTile.Wms;
using GeoAPI.Geometries;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using SharpMap;
using SharpMap.Layers;
using Application.Common.Interfaces.Services;

namespace Infrastructure.Services;
internal class MapService: IMapService
{

    public Image GetImageAtLocation((double latitude, double longitude) coordinates, Size size, int zoom = 2000, string urlFormatter = null)
    {
        Coordinate coordMercator = ConvertWgs84ToWebMercator(coordinates.latitude, coordinates.longitude);

        var map = new Map(size)
        {
            Center = coordMercator,
            Zoom = zoom,
        };

        urlFormatter ??= "https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}";

        var osmTileSource = new HttpTileSource(
            new GlobalSphericalMercator(),
            urlFormatter,
            new[] { "a", "b", "c" },
            name: "OpenStreetMap"
        );

        var osmLayer = new TileLayer(osmTileSource, "OSM")
        {
            Enabled = true,
        };

        map.Layers.Add(osmLayer);

        var layer = new VectorLayer("MyLayer")
        {
            DataSource = new SharpMap.Data.Providers.GeometryProvider(new NetTopologySuite.Geometries.Point(coordMercator.X, coordMercator.Y)),
            Style = new SharpMap.Styles.VectorStyle
            {
                Fill = Brushes.Red,
                Outline = Pens.Black
            }
        };

        map.Layers.Add(layer);
        return map.GetMap();
    }

    private Coordinate ConvertWgs84ToWebMercator(double latitude, double longitude)
    {
        GeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;
        ProjectedCoordinateSystem webMercator = ProjectedCoordinateSystem.WebMercator;
        var ctFactory = new CoordinateTransformationFactory();
        ICoordinateTransformation transformation = ctFactory.CreateFromCoordinateSystems(wgs84, webMercator);
        (double lat, double lng) = transformation.MathTransform.Transform(longitude, latitude);
        return new Coordinate(lat, lng);
    }

}
