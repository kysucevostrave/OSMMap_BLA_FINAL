using MapRendererLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMMapLib
{
    public class Map
    {



        public Layer[] Layer;

        private int zoom;
        private double lat;
        public double Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = (value + 90.0) % 180 - 90;
            }
        }

        private double lon;
        public double Lon
        {
            get { return this.lon; }
            set
            {
                this.lon = (value + 180.0) % 360 - 180;
            }
        }
        public int Zoom
        {
            get
            {
                int minimal_zoom = this.Layer[0].MaxZoom;
                for (int i = 1; i < this.Layer.Length; i++)
                {
                    if (minimal_zoom > this.Layer[i].MaxZoom)
                    {
                        minimal_zoom = this.Layer[i].MaxZoom;
                    }
                }
                if (zoom > minimal_zoom) {

                        return minimal_zoom;
                   }


                 if (zoom < 1) 
                        return 1;
                    
                       return zoom;
            }
            set
            {
                zoom = value;

            }
        }

        private int CenterTileX
        {
            get { return (int)((Lon + 180.0) / 360.0 * (1 << Zoom)); }

        }
        private int CenterTileY
        {
            get { return (int)((1.0 - Math.Log(Math.Tan(Lat * Math.PI / 180.0) + 1.0 / Math.Cos(Lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << Zoom)); }

        }
   

        public void Render()
        {
            MapRenderer mapRenderer = new MapRenderer(4, 4);

            for (int i = 0; i < Layer.Length; i++)
            {

            
           
            for (int x = -2; x < 2; x++)
            {
                for (int y = -2; y < 2; y++)
                {
                    Tile tile = this.Layer[i][this.CenterTileX + x, this.CenterTileY + y, this.Zoom];

                    Console.WriteLine(tile);

                    mapRenderer.Set(x + 2, y + 2, tile.Url,Layer[i].Opacity);
                }
            }
             mapRenderer.Flush();
            }
           
            mapRenderer.Render("Mapa.jpg");
        }


    }
}