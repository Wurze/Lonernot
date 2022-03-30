using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.Engine
{
    public class Timer
    {
        protected int counter = 1;
        protected int limit = 10;
        protected float countDuration = 2f; //every  2s.
        protected float currentTime = 0f;
        public bool spawn = false;


        public Timer()
        {

        }

        public bool GetSpawn()
        {
            return spawn;
        }

        public void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= countDuration)
            {
                counter++;                      
            }

            if (counter >= limit)
            {
                spawn = true;
            }

        }





    }
}
