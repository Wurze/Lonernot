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
    public class Player : AnimationManager
    {
        public float mSpeed = 1.2f;
        public bool isCaught = false;
        public Player(Dictionary<string,Animation>animations): base(animations)
        {
            this._animations = animations;
            this._animationManager = new AnimationManager(animations);
            
        }
        public Rectangle InteractionBox
        {
            get
            {
                // interactionBox need to be bigger than bounding box
                Rectangle interactionBox = _animationManager.BoundingBox;

                interactionBox.X += 0;
                interactionBox.Y += 5;
                interactionBox.Width -= 20;
                interactionBox.Height -= 15;

                return interactionBox;
            }
        }
        /* protected override void SetAnimations()
         {

         }*/


        public override void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            if (_animationManager != null && IsActive)
            {
                _animationManager.Draw(spriteBatch, spriteEffects);
            }
        }
    }

    
   
    }
