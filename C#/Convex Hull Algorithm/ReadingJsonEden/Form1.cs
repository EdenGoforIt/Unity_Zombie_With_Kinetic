using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;


namespace ReadingJsonEden
{
    public partial class Form1 : Form
    {
        List<PlaceOfInterest> locationList = new List<PlaceOfInterest>();
        HashSet<PlaceOfInterest> initialHashset = new HashSet<PlaceOfInterest>();
        GMapOverlay encircleMarkers;
        GMapOverlay polygons;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private List<PlaceOfInterest> GetLocationData()
        {
            string url = @"http://developer.kensnz.com/getlocdata";
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(url);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var jsonArray = ser.Deserialize<Dictionary<string, string>[]>(json);
                richTextBox1.AppendText(json);
                foreach (Dictionary<string, string> map in jsonArray)
                {

                    int userid = int.Parse(map["userid"]);
                    int id = int.Parse(map["id"]);
                    double latittude = double.Parse(map["latitude"]);
                    double longitude = double.Parse(map["longitude"]);
                    string description = map["description"];
                    if (latittude > -47 && latittude < -45 && longitude > 164 && longitude < 170)
                    {
                        PlaceOfInterest poi = new PlaceOfInterest(userid, latittude, longitude, description);
                        if (CheckDuplicacy(poi, initialHashset))
                        {
                            break;
                        }
                        else
                        {
                            initialHashset.Add(poi);
                        }
                      
                    }

                }
            }


            locationList = initialHashset.ToList();
            return locationList;
        }

        private bool CheckDuplicacy(PlaceOfInterest poi, HashSet<PlaceOfInterest> initialHashset)
        {
            bool duplicate = false;
            foreach (PlaceOfInterest p in initialHashset)
            {

                if (p.Equals(poi))
                {
                    duplicate = true;
                }
 
            }
            return duplicate;
        }

        private void GMapController_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            MessageBox.Show(string.Format("{0} lat:{1} lon:{2}", item.ToolTipText, item.Position.Lat, item.Position.Lng));

        }

 
        private void ButtonEncircle_Click(object sender, EventArgs e)
        {
            List<PlaceOfInterest> hull = ConvexHull.GrahmConvexHull(locationList);

            SEC.SmallestEnclosingCircle(hull);
            List<PointLatLng> circleList = new List<PointLatLng>();
            textBox1.Text = "Center Point : Lat " + SEC.centerPoint.Latitude.ToString() + "  Lon: " + SEC.centerPoint.Longitude.ToString();
            textBox2.Text = "Radius :  " + SEC.radius.ToString();
            int segments = 1000;
            //PlaceOfInterest testCenterPoint = new PlaceOfInterest(0,SEC.centerPoint.Latitude, 168.38,"");
            double seg = Math.PI * 2 / segments;
            double aspect = 0.70;
            double radius = SEC.radius;

            for (int i = 0; i < segments; i++)
            {

                double theta = seg * i;
           
                double a = SEC.centerPoint.Latitude + Math.Cos(theta) * radius;
                double b = SEC.centerPoint.Longitude + Math.Sin(theta) * radius ;

                PointLatLng gpoi = new PointLatLng(a, b);
                circleList.Add(gpoi);
            }

            encircleMarkers = new GMapOverlay("SEC");
            GMapPolygon gpol = new GMapPolygon(circleList, "circle");
            gMapController.Overlays.Add(encircleMarkers);
            encircleMarkers.Polygons.Add(gpol);


            GMapOverlay centerArray = new GMapOverlay("center");
            GMarkerGoogle centerMarker = new GMarkerGoogle(new PointLatLng(SEC.centerPoint.Latitude, SEC.centerPoint.Longitude),
              GMarkerGoogleType.green);
            centerArray.Markers.Add(centerMarker);
            gMapController.Overlays.Add(centerArray);



        }

        private void ButtonConvex_Click(object sender, EventArgs e)
        {
            //gMapController.Overlays.Clear();

            List<PlaceOfInterest> hullList = ConvexHull.GrahmConvexHull(locationList);
           // noDuplicateList = ConvexHull.MonoStoneConvexHull(noDuplicateList);
            List<PointLatLng> hull = new List<PointLatLng>();
            foreach (PlaceOfInterest poi in hullList)
            {
                hull.Add(new PointLatLng(poi.Latitude, poi.Longitude));
            }
            polygons = new GMapOverlay("polygons");
            GMapPolygon polygon = new GMapPolygon(hull, "hull");
            gMapController.Overlays.Add(polygons);
            polygons.Polygons.Add(polygon);
        }

        private void GMapController_Load(object sender, EventArgs e)
        {
            //locationList = GetLocationTestDat();
            gMapController.Position = new PointLatLng(1, 1);
            locationList = GetLocationData();
            gMapController.MapProvider = GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapController.Position = new PointLatLng(-46.4139136, 168.355639);
            gMapController.Zoom = 12;
            gMapController.ShowCenter = false;

            foreach (PlaceOfInterest poi in locationList)
            {
                GMapOverlay markers = new GMapOverlay("markers");
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(poi.Latitude, poi.Longitude), GMarkerGoogleType.blue_pushpin);

                marker.ToolTipText = string.Format("{0} : {1}", poi.UserID.ToString(), poi.Description);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                markers.Markers.Add(marker);
                gMapController.Overlays.Add(markers);
            }
        }

        private List<PlaceOfInterest> GetLocationTestDat()
        {
            PlaceOfInterest p1 = new PlaceOfInterest(1, 1, 1, "");
            PlaceOfInterest p2 = new PlaceOfInterest(1, 1, -1, "");
            PlaceOfInterest p3 = new PlaceOfInterest(1, -1, 1, "");
            PlaceOfInterest p4 = new PlaceOfInterest(1, -1, -1, "");
            PlaceOfInterest p5 = new PlaceOfInterest(1, 0, 0, "");

            PlaceOfInterest p6 = new PlaceOfInterest(1, 2, 2, "");
            List<PlaceOfInterest> list = new List<PlaceOfInterest>();
            locationList.Add(p1);
            locationList.Add(p2);
            locationList.Add(p3);
            locationList.Add(p4);
            locationList.Add(p5);
            locationList.Add(p6);
            return locationList;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            gMapController.Overlays.Remove(polygons);
            gMapController.Overlays.Remove(encircleMarkers);
            gMapController.Position = new PointLatLng(-46.4139137, 168.355638);
        }

    }
}

