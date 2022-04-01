using Lonernot.Engine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Lonernot
{
    public class Enemy:Sprite
    {

        public float mSpeed = 1.2f;
        public Vector2 One { get; }
        public float LinearVelocity = 4f;
        public float enemySpeed = 0;

        // for following
        public Sprite FollowTarget { get; set; }
        public float FollowDistance { get; set; }

        public Enemy(Dictionary<string, Animation> animations, float enemySpeed) : base(animations)
        {
            this.enemySpeed = enemySpeed; 
        }

        public override void UpdateBoundingBox()
        {
            // The collision is at the feet of the player
            BoundingBox = new Rectangle(
            (int)(Position.X ),
            (int)(Position.Y + 14),
            16,
            10
            );
        }

        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["Walking_right"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["Walking_left"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["Walking_down"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["Walking_up"]);
            else _animationManager.Stop();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateBoundingBox();
            base.Update(gameTime);
        }
    }
}
