using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tiles_ClickCheck
{
    public class TileMap
    {
        private struct MapDescriptor {
            public int SizeX;
            public int SizeY;
            public int TileSizeX;
            public int TileSizeY;
        }

        public int[,] Grid { get; private set; }
        private MapDescriptor Descriptor;
        public int SizeX { get { return Descriptor.SizeX; } }
        public int SizeY { get { return Descriptor.SizeY; } }
        public int TileSizeX { get { return Descriptor.TileSizeX; } }
        public int TileSizeY { get { return Descriptor.TileSizeY; } }

        public TileMap(string fileName) {
            string[] gridLines = File.ReadAllLines(fileName);
            Descriptor = CreateMapDescriptor(gridLines[0]);
            Grid = new int[Descriptor.SizeX, Descriptor.SizeY];
            for (int y = 0; y < Descriptor.SizeY; y++) {
                int[] row = GetRow(gridLines[y + 1]);
                for (int x = 0; x < Descriptor.SizeX; x++) {
                    Grid[y, x] = row[x];
                }
            }
        }

        public Point GetTilePosition(int xActual, int yActual) {
            return new Point(xActual - (xActual % TileSizeX), yActual - (yActual % TileSizeY));
        }

        private int[] GetRow(string row) {
            string[] values = row.Split(',');
            return values.Select(int.Parse).ToArray();
        }

        private MapDescriptor CreateMapDescriptor(string descriptor) {
            string[] values = descriptor.Split(',');
            return new MapDescriptor {
                SizeX = int.Parse(values[0]), 
                SizeY = int.Parse(values[1]),
                TileSizeX = int.Parse(values[2]),
                TileSizeY = int.Parse(values[3]), 
            };
        }
    }
}
