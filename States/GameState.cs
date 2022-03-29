using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.States
{
    public class GameState:State
    {
        public Map map;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            map = new Map(content, "Content/Lonernot.tmx");

            // Buttons Creation
            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            
                map.DrawMapLayer(spriteBatch);
                
            
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawMap(spriteBatch);
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
