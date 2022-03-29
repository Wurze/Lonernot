using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lonernot.Controls;
using Lonernot.Engine;

namespace Lonernot.States
{
    public class InstructionsState : State
    {
        private List<Button> _button;
       
        public SpriteFont font;

        public Texture2D paper;
        public Texture2D background;
        public Texture2D wasd;
        public SpriteFont textFontTitle;

        public InstructionsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            background = _content.Load<Texture2D>("Controls/Background");
            paper = _content.Load<Texture2D>("Controls/Background3");
            wasd = _content.Load<Texture2D>("Controls/wasd");

            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            font = _content.Load<SpriteFont>("Fonts/Font");
            this.textFontTitle = _content.Load<SpriteFont>("Fonts/TextFont");
            /*this.firstSlide = _content.Load<Texture2D>("Controls/firstSlide");
            this.secondSlide = _content.Load<Texture2D>("Controls/secondSlide2");
            this.thirdSlide = _content.Load<Texture2D>("Controls/thirdSlide");
            this.fourthSlide = _content.Load<Texture2D>("Controls/fourthSlide");
            this.debugColor = _content.Load<Texture2D>("Controls/textBg");
*/

            var chooseBackButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(550, 760),
                Text = "Got it!",
            };

            chooseBackButton.Click += BackButton_Click;

            _button = new List<Button>()
            {
            chooseBackButton,
            };

        }

       

        /*public Rectangle bgCoordinates(int X, int Y)
        {
            textBox = new Rectangle(X, Y, 480, 170);
            return textBox;
        }
        */
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string tempStr = "Use W, A, S, D to move!";
            string tip1 = "Find your way out of the maze ;)";
            string tip2 = "Stay away from the monster!";
            spriteBatch.Draw(background, new Vector2(0, 0), Color.Pink);
            spriteBatch.Draw(paper, new Vector2(0, 0), Color.Pink);
            spriteBatch.Draw(wasd, new Vector2(470, 200), Color.Pink);
            spriteBatch.DrawString(textFontTitle, tempStr, new Vector2(260, 410), Color.Black);
            spriteBatch.DrawString(textFontTitle, tip1, new Vector2(260, 460), Color.Black);
            spriteBatch.DrawString(textFontTitle, tip2, new Vector2(260, 510), Color.Black);

            foreach (var button in _button)
                button.Draw(gameTime, spriteBatch);

            
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

