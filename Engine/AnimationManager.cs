﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.Engine
{
    public class AnimationManager : Sprite
    {
        protected Animation _animation;


        public AnimationManager(Dictionary<string, Animation> animations) : base(animations.ElementAt(0).Value.Texture)
        {

        }
        public AnimationManager(Animation animation) : base(animation.Texture)
        {
            _animation = animation;
        }

        public virtual void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {

            int row = _animation.CurrentFrame / _animation.Columns;
            int column = _animation.CurrentFrame % _animation.Columns;
            spriteBatch.Draw(_animation.Texture,
                            Position,
                             new Rectangle(_animation.FrameWidth * column,
                                           _animation.FrameHeight * row,
                                           _animation.FrameWidth,
                                           _animation.FrameHeight),
                             Color.White, _rotation, Origin, Scale, spriteEffects, 0);

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

        public virtual void Update(GameTime gameTime)
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

       



        public override void UpdateBoundingBox()
        {
            int width = 0;
            int height = 0;

            if (_animation != null)
            {
                width = _animation.FrameWidth;
                height = _animation.FrameHeight;
            }

            BoundingBox = new Rectangle(
                (int)(_position.X - (int)Math.Ceiling(Origin.X)),
                (int)(_position.Y - (int)Math.Ceiling(Origin.Y)),
                width, height);
        }

        public void SetAnimation(Animation animation)
        {
            this._animation = animation;
        }

        public Animation GetAnimation()
        {
            return this._animation;
        }
    }
}
