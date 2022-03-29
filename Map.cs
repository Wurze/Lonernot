﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TiledSharp;
using System.Text;
using System.Threading.Tasks;

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
            //DrawLayer(1, spritebatch);
        }

     



        public void AddCollisionPath()
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



        public Queue<Vector2> GetPath()
        {
            int points = Convert.ToInt32(map.ObjectGroups["Objects"].Properties["Points"]);

            Queue<Vector2> path = new Queue<Vector2>();

            for (int i = 1; i <= points; i++)
            {
                path.Enqueue(new Vector2((float)map.ObjectGroups["Objects"].Objects["Point" + i].X, (float)map.ObjectGroups["Objects"].Objects["Point" + i].Y));
            }

            path.Enqueue(new Vector2((float)map.ObjectGroups["Objects"].Objects["End"].X, (float)map.ObjectGroups["Objects"].Objects["End"].Y));

            return path;
        }

        public Vector2 GetStartingPoint()
        {
            return new Vector2((float)map.ObjectGroups["Objects"].Objects["Start"].X, (float)map.ObjectGroups["Objects"].Objects["Start"].Y);
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
