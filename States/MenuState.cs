using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Lonernot.Controls;
using Lonernot.Engine;

namespace Lonernot.States
{
    public class MenuState : State
    {

        private Texture2D Background;
        private List<Button> _button;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            //Background = _content.Load<Texture2D>("Controls/Background");
            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 400),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;;

            var settingsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 500),
                Text = "Settings",
            };

            settingsButton.Click += SettingsButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 550),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _button = new List<Button>()
            {
                newGameButton,
                settingsButton,
                quitGameButton,
            };
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.gameState);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.settingsState);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
