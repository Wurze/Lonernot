using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Lonernot.Controls;

namespace Lonernot.States
{
    public class MenuState : State
    {
        private Texture2D background;
        private Texture2D papirus;
        private List<Button> _button;
        public SpriteFont textFontTitle;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            background = _content.Load<Texture2D>("Controls/background");
            papirus = _content.Load<Texture2D>("Controls/papirus");
            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            this.textFontTitle = _content.Load<SpriteFont>("Fonts/TextFont");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 400),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;;

            var instructionsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 460),
                Text = "Instructions",
            };

            instructionsButton.Click += IntructionsButton_Click;

            var settingsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 520),
                Text = "Settings",
            };

            settingsButton.Click += SettingsButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(570, 580),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _button = new List<Button>()
            {
                newGameButton,
                instructionsButton,
                settingsButton,
                quitGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string tempStr = "Loner not";
            spriteBatch.Draw(background, new Vector2(0, 0), Color.Pink);
            spriteBatch.Draw(papirus, new Vector2(400, 50), Color.Pink);
            spriteBatch.DrawString(textFontTitle, tempStr, new Vector2(530, 250), Color.Black);
            foreach (var button in _button)
                button.Draw(gameTime, spriteBatch);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.gameState);
        }

        private void IntructionsButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.instructionsState);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.settingsState);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in _button)
                button.Update(gameTime);
        }
    }
}
