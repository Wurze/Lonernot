using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.Engine
{
    public delegate void PassObject(object i);
    public class Global
    {
        public static ContentManager content;
        public static string appDataFilePath;
        public static Save save;
       
    }
}
