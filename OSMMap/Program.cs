
   
using OSMMapLib;
using System;

namespace OSMMap
{
    class Program
    {
        static void Main(string[] args)
        {
           
        Map map = new Map();
         map.Lat = 49.84335531583281;
            map.Lon = 18.173273993447488;
            map.Zoom = 17;  
            
            Layer layer1 = new Layer("https://cartodb-basemaps-{c}.global.ssl.fastly.net/dark_all/{z}/{x}/{y}.png", 15, 1.0f);
            Layer layer2 = new Layer("http://tile.memomaps.de/tilegen/{z}/{x}/{y}.png", 17, 0.2f);

            map.Layer = new Layer[2];
            map.Layer[0] = layer1;
            map.Layer[1] = layer2;
            
            

           

            map.Render();
        }
    }
}