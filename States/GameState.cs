using Lonernot.Engine;
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
        public Player player;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            map = new Map(content, "Content/Lonernot.tmx");
            var playerAnimations = new Dictionary<string, Animation>()
            {
                {"Walking_up", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_up"),4,1) },
                {"Walking_down", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_down"),4,1) },
                {"Walking_right", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_right"),4,1) },
                {"Walking_left", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_left"),4,1) }
            };
            player = new Player(playerAnimations);
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
