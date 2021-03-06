using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lonernot.Engine
{
    public class AnimationManager
    {
        public Animation _animation;
        private float _timer;
        public Vector2 Position { get; set; }

        public AnimationManager(Animation animation) 
        {
            _animation = animation;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture,
                            Position,
                             new Rectangle(_animation.CurrentFrame * 
                                           _animation.FrameWidth,0,
                                           _animation.FrameWidth,
                                           _animation.FrameHeight),
                             Color.White);
        }

        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;
            _animation.CurrentFrame = 0;
            _timer = 0;
        }      

        public void PlayOneFrame(Animation animation, int frame)
        {
            _animation = animation;
            _animation.CurrentFrame = frame;
        }

        public void Stop()
        {
            _timer = 0f;
            _animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed && _animation.IsLooping == true)
            {
                _timer = 0f;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
            if (_timer > _animation.FrameSpeed && _animation.IsLooping == false)
            {
                _timer = 0f;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = _animation.FrameCount;
                }
            }
        }
    }
}
