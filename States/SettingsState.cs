using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lonernot.Controls;
using Lonernot.Engine;
using Lonernot;

namespace Lonernot.States
{
    public class SettingsState : State
    {
        private List<Button> _button;
        private Texture2D paper;
        private Texture2D background;
        public SpriteFont textFontTitle;

        public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
         : base(game, graphicsDevice, content)
        {
            background = _content.Load<Texture2D>("Controls/Background");
            paper = _content.Load<Texture2D>("Controls/Background3");
            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            var font = _content.Load<SpriteFont>("Fonts/Font");
            this.textFontTitle = _content.Load<SpriteFont>("Fonts/TextFont");

            var volumeUpButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(550, 460),
                Text = "+",
            };

            volumeUpButton.Click += volumeUpButton_Click;

            var volumeDownButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(550, 520),
                Text = "-",
            };

            volumeDownButton.Click += volumeDownButton_Click;

            var chooseBackButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(550, 760),
                Text = "Back",
            };

            chooseBackButton.Click += BackButton_Click;

            _button = new List<Button>()
            {
                volumeUpButton,
                volumeDownButton,
                chooseBackButton,
            };
          
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string tempStr = "Adjust the music volume";

            spriteBatch.Draw(background, new Vector2(0, 0), Color.Pink);
            spriteBatch.Draw(paper, new Vector2(0, 0), Color.Pink);

            spriteBatch.DrawString(textFontTitle, tempStr, new Vector2(285, 260), Color.Black);
            spriteBatch.DrawString(textFontTitle, "" + _game.GetVolume(), new Vector2(610, 380), Color.Black);


            foreach (var button in _button)
                button.Draw(gameTime, spriteBatch);

        }

     

        private void volumeDownButton_Click(object sender, EventArgs e)
        {
            _game.SetVolumeDown(sender, e);
        }

        private void volumeUpButton_Click(object sender, EventArgs e)
        {
            _game.SetVolumeUp(sender, e);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(_game.menuState);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in _button)
                button.Update(gameTime);
        }
    }
}
