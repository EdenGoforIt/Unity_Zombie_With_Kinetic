using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingJsonEden
{
    public class PlaceOfInterest:IComparable<PlaceOfInterest>
    {
        public int UserID { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude  { get; set; }

        public PlaceOfInterest(int id, double lat, double lon, string des)
        {
            this.UserID = id;
            this.Latitude = lat;
            this.Longitude = lon;
            this.Description = des;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is PlaceOfInterest)
            {
                PlaceOfInterest poi = obj as PlaceOfInterest;
                return this.Latitude == poi.Latitude && this.Longitude == poi.Longitude && poi.UserID ==this.UserID && poi.Description == this.Description;

            }
            return false;
        }

  

        public int CompareTo(PlaceOfInterest other)
        {
            double com = this.Latitude.CompareTo(other.Latitude);

            if (com == 0)
            {
                //return this.Y.CompareTo(other.Y);
                return this.Longitude.CompareTo(other.Longitude);
            }
            return (int)com;
        }
    }
}
