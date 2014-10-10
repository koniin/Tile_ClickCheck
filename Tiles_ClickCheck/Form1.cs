using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tiles_ClickCheck {
    public partial class Form1 : Form {
        private TileMap tileMap;
        private ContentManager contentManager;

        public Form1() {
            InitializeComponent();
            
            contentManager = new ContentManager();
            contentManager.Load("base");
            contentManager.Load("level1");
            tileMap = new TileMap(".\\Grid.txt");
        }

        ~Form1() {
            contentManager.UnloadAll();
        }

        protected override void OnPaint(PaintEventArgs e) {
            DrawGrid(tileMap.Grid);
            base.OnPaint(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            Point tilePosition = GetTilePosition(e);
            Graphics graphics = this.CreateGraphics();
            graphics.DrawImage(contentManager.Get<Image>(3), tilePosition);
        }

        private Point GetTilePosition(MouseEventArgs mouseEventArgs) {
            return new Point(mouseEventArgs.X - (mouseEventArgs.X % tileMap.TileSizeX), mouseEventArgs.Y - (mouseEventArgs.Y % tileMap.TileSizeY));
        }

        private void DrawGrid(int[,] grid) {
            Graphics graphics = this.CreateGraphics();

            for (int y = 0; y < tileMap.SizeY; y++) {
                for (int x = 0; x < tileMap.SizeX; x++) {
                    Point p = new Point {X = x * tileMap.TileSizeX, Y = y * tileMap.TileSizeY};
                    DrawTile(grid, graphics, x, y, p);
                }
            }
            /*
            var rectangle = new Rectangle(
                50, 100, 150, 150);
            graphics.DrawEllipse(Pens.Black, rectangle);
            graphics.DrawRectangle(Pens.Red, rectangle);
            
            Image tile = new Bitmap(".\\lightblue.png");
            
            */
        }

        private void DrawTile(int[,] grid, Graphics graphics, int x, int y, Point p) {
            graphics.DrawImage(contentManager.Get<Image>(grid[x, y]), p);
        }
    }
}
