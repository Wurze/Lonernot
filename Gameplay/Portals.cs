using Lonernot.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lonernot.Gameplay
{
    public class Portals
    {


        // teleport timer
        protected int teleportCounter = 1;
        protected float countDuration = 2f; //every  2s.
        protected float currentTime = 0f;
        public bool activateTeleport;
        public int limit;
        protected Map map;

        // all the portals across the map 
        public List<Rectangle> portals;



        public Portals(Map Map)
        {
            map = Map;
            map.AddPortals();
            portals = Map.GetPortals();

        }

        public void ActivateTeleport()
        {
            activateTeleport = true;
        }

        public void StopTeleport()
        {
            activateTeleport = false;
        }

        public void CheckTeleportation(Player player)
        {
            foreach (var portal in portals)
            {
                if (portal.Intersects(player.BoundingBox))
                {
                    //Teleport
                    player.SetPosition(CreateTeleportTarget());
                }
            }

        }


        // add player sa scoti portalul pe care e
        public Vector2 CreateTeleportTarget()
        {
            
            return map.GetStartingPoint();

        }


        public void Teleportation(Player player)
        {
            //set new position for player
          
                player.SetPosition(CreateTeleportTarget());
                
            

        }




    }
}
