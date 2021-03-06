using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TiledSharp;

namespace Lonernot
{
    public class Map
    {
        protected TmxMap map;
        //protected TmxTileset tileSet;
        protected Texture2D tileTexture;
        protected int tileWidth;
        protected int tileHeight;
        protected int tilesetTilesWide;
        protected int tilesetTilesHigh;
        public Queue<Vector2> path;
        public List<Rectangle> pathList;
        public Vector2 startPoint;
        public Rectangle endPoint;
        public List<Rectangle> portals;

        public object Tilesets { get; internal set; }
        public object Position { get; private set; }

        public Map(ContentManager content, string mapPath)
        {
            pathList = new List<Rectangle>();
            map = new TmxMap(mapPath);
            tileTexture = content.Load<Texture2D>(map.Tilesets[0].Name.ToString());
            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;
            tilesetTilesWide = tileTexture.Width / tileWidth;
            tilesetTilesHigh = tileTexture.Height / tileHeight;

            path = new Queue<Vector2>();
            portals = new List<Rectangle>();
        }

        public void DrawLayer(int index, SpriteBatch batch)
        {
            for (var i = 0; i < map.Layers[index].Tiles.Count; i++)
            {
                //Get the identification of the tile
                int gid = map.Layers[index].Tiles[i].Gid;

                // Empty tile, do nothing
                if (gid == 0) { }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                    //Put all the data together in a new rectangle
                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                    //Draw the tile that is within the tilesetRec
                    batch.Draw(tileTexture, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                }
            }
        }

        public void DrawMapLayer(SpriteBatch spritebatch)
        {
            DrawLayer(0, spritebatch);
        }

        public void AddCollision()
        {
            foreach (var point in map.ObjectGroups["Collision"].Objects)
            {
                pathList.Add(new Rectangle((int)point.X, (int)point.Y, (int)point.Width, (int)point.Height));
            }
        }

        public List<Rectangle> GetCollisionPath()
        {
            return pathList;
        }

        public bool IsCollision(Rectangle target)
        {
            foreach (Rectangle rec in pathList)
                if (rec.Intersects(target))
                {
                    return true;
                }
            return false;
        }

        public Vector2 GetStartingPoint()
        {
            return new Vector2((float)map.ObjectGroups["Objects"].Objects["Start"].X, (float)map.ObjectGroups["Objects"].Objects["Start"].Y);
        }

        public Rectangle GetEndingPoint()
        {
            return new Rectangle((int)map.ObjectGroups["Objects"].Objects["End"].X, (int)map.ObjectGroups["Objects"].Objects["End"].Y, (int)map.ObjectGroups["Objects"].Objects["End"].Width, (int)map.ObjectGroups["Objects"].Objects["End"].Height);
        }


        public List<Rectangle> GetPortals()
        {
            return portals;
        }

        public void AddPortals()
        {

            for (int i = 1; i <= 5; i++)
            {
                portals.Add(new Rectangle((int)map.ObjectGroups["Portals"].Objects["Portal" + i].X, (int)map.ObjectGroups["Portals"].Objects["Portal" + i].Y, (int)map.ObjectGroups["Portals"].Objects["Portal" + i].Width, (int)map.ObjectGroups["Portals"].Objects["Portal" + i].Height));
            }
        }

        // get and set methods
        public void SetTmxMap(TmxMap map)
        {
            this.map = map;
        }

        public TmxMap GetMap()
        {
            return map;
        }

        public void SetTexture(Texture2D tileTexture)
        {
            this.tileTexture = tileTexture;
        }

        public Texture2D GetTexture()
        {
            return tileTexture;
        }

        public void SetTileWidth(int tileWidth)
        {
            this.tileWidth = tileWidth;
        }

        public int GetTileWidth()
        {
            return tileWidth;
        }

        public void SetTileHeight(int tileHeight)
        {
            this.tileHeight = tileHeight;
        }

        public int GetTileHeight()
        {
            return tileHeight;
        }

        public void SetTilesetTilesWidth(int tilesetTilesWide)
        {
            this.tilesetTilesWide = tilesetTilesWide;
        }

        public int GetTilesetTilesWidth()
        {
            return tilesetTilesWide;
        }

        public void SetTilesetTilesHeight(int tilesetTilesHigh)
        {
            this.tilesetTilesHigh = tilesetTilesHigh;
        }

        public int GetTilesetTilesHeight()
        {
            return tilesetTilesHigh;
        }
    }
}
