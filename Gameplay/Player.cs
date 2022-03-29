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
            Move();
            SetAnimations();
            Position += Velocity;
            Velocity = Vector2.Zero;
            base.Update(gameTime);
            
            
           
        }
    }

    
   
    }
