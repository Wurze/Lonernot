using Lonernot.Engine;
using Microsoft.Xna.Framework;
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
        
        public Enemy(Dictionary<string, Animation> animations,Vector2 position) : base(animations)
        {
            this._animations = animations;
            this._animationManager = new AnimationManager(animations);
            this.Position = position;
        }












    }
}
