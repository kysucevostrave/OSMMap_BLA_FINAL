using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMMapLib
{
    public class Layer
    {
        public Layer(string _urlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png")
        {
            this.UrlTemplate = _urlTemplate;
            this.MaxZoom = 10;
            
        }
        public Layer(int _maxZoom)
        {
            this.UrlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png";
            this.MaxZoom = _maxZoom;
            
        }
        public Layer(string _urlTemplate, int _maxZoom = 10) : this(_urlTemplate)
        {
            this.MaxZoom = _maxZoom;
            this.opacity = 0.0f;
        }
        public Layer(string _urlTemplate, int _maxZoom , float _opacity) : this(_urlTemplate, _maxZoom)
        {
            
            this.opacity = _opacity;
        }

        private float opacity;
        public float Opacity { get { return opacity; } set {


                if (value > 1.0f) {

                    opacity = 1.0f;
                    return;
                }
                 

                if ( value < 0.0f)
                {

                    opacity = 0.0f;
                    return;
                }

                opacity = value;

            } }

        private string urlTemplate;
        private int maxZoom;

        public string UrlTemplate { get { return urlTemplate; } private set { urlTemplate = value; } }
        public int MaxZoom { get { return maxZoom; } private set { maxZoom = value; } }

        public Tile this[int _x, int _y, int _zoom]
        {

            get
            {
                Tile tile = new Tile(_x, _y, _zoom, this.FormatUrl(_x, _y, _zoom));
                return tile;
            }
            set { }
        }

        public string FormatUrl(int _x, int _y, int _zoom)
        {
            StringBuilder sb = new StringBuilder(this.UrlTemplate);

            sb.Replace("{x}", _x.ToString());
            sb.Replace("{y}", _y.ToString());
            sb.Replace("{z}", _zoom.ToString());

            Random rnd = new Random();
            int cislo = rnd.Next(0, 3);
            char pismeno = (char)(97 + cislo);
            sb.Replace("{c}", pismeno.ToString());

            return sb.ToString();
        }

    }
}