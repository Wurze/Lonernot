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
        protected int teleportLimit = 9;
        protected int teleportCounter = 1;
        public bool teleport = false;

        protected float countDuration = 2f; //every  2s.
        protected float currentTime = 0f;
        protected int trigger;



        public List<Rectangle> portals;

        public bool activateTeleport;

        public Portals(List<Rectangle> portalsPositions)
        {
            portals = portalsPositions;
            activateTeleport = true; ;
            trigger = 1;
        }

        public void ActivateTeleport()
        {
            activateTeleport = true;
        }

        public void CheckTeleportation(Player player)
        {
            foreach (var portal in portals)
            {
                if (portal.Intersects(player.BoundingBox))
                {
                    //Teleport
                    ActivateTeleport();
                    
                    
                }
            }

        }
        

       
        public Vector2 CreateTeleportTarget()
        {
            Random r = new Random();
            int randomPortal = r.Next(portals.Count);

            Vector2 target = new Vector2((float)portals[randomPortal].X, (float)portals[randomPortal].Y);

            return target;

        }

        public void Teleportation(Player player)
        {
            //set new position for player
            if (activateTeleport)
            {
                player.SetPosition(CreateTeleportTarget());

            }
            

        }


        

    }
}
