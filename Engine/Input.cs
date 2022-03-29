using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.Engine
{
    public static class Input
    {
        static KeyboardState previousKBState;
        static KeyboardState newKBState;

        /// <summary>
        /// Happen when the player release the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        static public bool GetKeyUp(Keys key)
        {
            if (newKBState.IsKeyUp(key) && !previousKBState.IsKeyUp(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Happen when the player press the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        static public bool GetKeyDown(Keys key)
        {
            if (newKBState.IsKeyDown(key) && !previousKBState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
