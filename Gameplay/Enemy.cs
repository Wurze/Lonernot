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
    public class Enemy:Sprite
    {

        public float mSpeed = 1.2f;
        
        public Vector2 One { get; }
        
        public Enemy(Dictionary<string, Animation> animations) : base(animations)
        {
            
            SetPosition(new Vector2(160,630));
            
        }

        public void FollowPlayer(Player player)
        {
            
            var distance = player.GetPosition() - Position;
            SetRotation((float)Math.Atan2(distance.Y, distance.X));
            SetDirection(new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation)));
            var currentDistance = Vector2.Distance(Position, player.BoundingBox.Location.ToVector2());

            var t = MathHelper.Min((float)Math.Abs(currentDistance), Velocity.X);
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


       






        public override void Update(GameTime gameTime)
        {

            
            base.Update(gameTime);
        }

















    }
}
