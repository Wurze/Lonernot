using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lonernot.Controls;
using Lonernot.Engine;
using System.Threading.Tasks;

namespace Lonernot.States
{
    public class GameOverState : State
    {
        private List<Button> _button;
        private Texture2D paper;
        private Texture2D background;
        public SpriteFont textFontTitle;
        public SpriteFont font;

        public GameOverState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            background = _content.Load<Texture2D>("Controls/Background");
            paper = _content.Load<Texture2D>("Controls/Background3");
            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            this.font = _content.Load<SpriteFont>("Fonts/Font");
            this.textFontTitle = _content.Load<SpriteFont>("Fonts/TextFont");

            var chooseBackButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(550, 760),
                Text = "Back",
            };

            chooseBackButton.Click += BackButton_Click;

            _button = new List<Button>()
            {
                chooseBackButton,
            };

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.menuState);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string lost = "Unfortunately the monster was faster than you..";
            string won = "You got out! congrats";

            spriteBatch.Draw(background, new Vector2(0, 0), Color.Pink);
            spriteBatch.Draw(paper, new Vector2(0, 0), Color.Pink);

            if(_game.gameState.player.isCaught)
            {
                spriteBatch.DrawString(font, lost, new Vector2(285, 260), Color.Black);
            }
            else
            {
                spriteBatch.DrawString(font, won, new Vector2(285, 260), Color.Black);
            }
            
            foreach (var button in _button)
                button.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in _button)
                button.Update(gameTime);
        }
    }
}
