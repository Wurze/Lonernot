using Lonernot.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Lonernot
{
    public class Player : Sprite
    {
        public float mSpeed = 1f;
        public bool isCaught = false;
        
        public Player(Dictionary<string,Animation>animations):base(animations)
        {
            
            Input = new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D,
            };
            
        }

       

        public override void UpdateBoundingBox()
        {
            // The collision is at the feet of the player
            BoundingBox = new Rectangle(
            (int)(Position.X + 5),
            (int)(Position.Y + 14),
            16,
            10
            );
        }
        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))

                Velocity.Y = -mSpeed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = mSpeed;
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -mSpeed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = mSpeed;
            
        }
        public bool IsTouchingLeft(Rectangle mapWall)
        {
            return BoundingBox.Right + Velocity.X > mapWall.Left &&
              BoundingBox.Left < mapWall.Left &&
              BoundingBox.Bottom > mapWall.Top &&
              BoundingBox.Top < mapWall.Bottom;
        }

        public bool IsTouchingRight(Rectangle mapWall)
        {
            return BoundingBox.Left + Velocity.X < mapWall.Right &&
              BoundingBox.Right > mapWall.Right &&
              BoundingBox.Bottom > mapWall.Top &&
              BoundingBox.Top < mapWall.Bottom;
        }

        public bool IsTouchingTop(Rectangle mapWall)
        {
            return BoundingBox.Bottom + Velocity.Y > mapWall.Top &&
              BoundingBox.Top < mapWall.Top &&
              BoundingBox.Right > mapWall.Left &&
              BoundingBox.Left < mapWall.Right;
        }

        public bool IsTouchingBottom(Rectangle mapWall)
        {
            return BoundingBox.Top + Velocity.Y < mapWall.Bottom &&
              BoundingBox.Bottom > mapWall.Bottom &&
              BoundingBox.Right > mapWall.Left &&
              BoundingBox.Left < mapWall.Right;
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
            Move();
            SetAnimations();       
            base.Update(gameTime);
            
            
           
        }
    }

    
   
    }
