using Lonernot.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot
{
    public class Enemy: AnimationManager 
    {

        public float mSpeed = 1.2f;
        
        public Vector2 One { get; }
        
        public Enemy(Dictionary<string, Animation> animations) : base(animations)
        {
            this._animations = animations;
            this._animationManager = new AnimationManager(animations);
            SetPosition(new Vector2(160,630));
            
        }

        public void FollowPlayer(Player player)
        {
            
            var distance = player.GetPosition() - Position;
            SetRotation((float)Math.Atan2(distance.Y, distance.X));
            SetDirection(new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation)));
            var currentDistance = Vector2.Distance(Position, player.InteractionBox.Location.ToVector2());

            var t = MathHelper.Min((float)Math.Abs(currentDistance), xVelocity);
            var velocity = GetDirection() * t;

            SetPosition(GetPosition() + velocity);
            
        }


        public void MoveUp()
        {

            SetPosition(GetPosition() + new Vector2(1f, 0));

        }



        public void MoveDown()
        {
            
         SetPosition(GetPosition() + new Vector2(-1f, 0));
            
        }


        public override void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            if (_animationManager != null && IsActive)
            {
                _animationManager.Draw(spriteBatch, spriteEffects);
            }
        }






        public override void Update(GameTime gameTime)
        {

            
            base.Update(gameTime);
        }

















    }
}
