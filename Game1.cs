using Lonernot.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelDefense.States;

namespace Lonernot
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public GameState gameState;
        public MenuState menuState;
        public InstructionsState instructionsState;
        public SettingsState settingsState;
        public GameOverState gameOverState;
        public MouseState mouseState;

        private State _currentState;
        private State _nextState;
        private int defaultWidth = 1280;
        private int defaultHeight = 830;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = defaultWidth,
                PreferredBackBufferHeight = defaultHeight
            };
            Content.RootDirectory = "Content";
            graphics.ApplyChanges();
        }

 
        protected override void Initialize()
        {
            gameState = new GameState(this, graphics.GraphicsDevice, Content);
            menuState = new MenuState(this, graphics.GraphicsDevice, Content);
            instructionsState = new InstructionsState(this, graphics.GraphicsDevice, Content);
            settingsState = new SettingsState(this, graphics.GraphicsDevice, Content);
            gameOverState = new GameOverState(this, graphics.GraphicsDevice, Content);

            mouseState = Mouse.GetState();
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = menuState;

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            /*if (gameOverState.IsRestarted == true)
            {
                Initialize();
            }*/

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _currentState.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
