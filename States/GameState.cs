﻿using Lonernot.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.States
{
    public class GameState:State
    {
        public Map map;
        public Player player;
        public Enemy enemy;
        public List<Rectangle> collison;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            //create map
            map = new Map(content, "Content/Lonernot.tmx");
            map.AddCollision();
            collison = map.GetCollisionPath();
            


        //loading animation for player
        var playerAnimations = new Dictionary<string, Animation>()
            {
                {"Walking_up", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_up"),4) },
                {"Walking_down", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_down"),4) },
                {"Walking_right", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_right"),4) },
                {"Walking_left", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_left"),4) }
            };
            
            player = new Player(playerAnimations);

            //loading animations for enemy
            var enemyAnimations = new Dictionary<string, Animation>()
            {
                {"Walking_up", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_up"),4) },
                {"Walking_down", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_down"),4) },
                {"Walking_right", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_right"),4) },
                {"Walking_left", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_left"),4) }

            };
            
            //create enemy
            enemy = new Enemy(enemyAnimations);
            enemy.SetPosition(map.GetStartingPoint());
            // Buttons Creation
            var buttonTexture = _content.Load<Texture2D>("Controls/button3");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
        }


        public void DrawMap(SpriteBatch spriteBatch)
        {
            
                map.DrawMapLayer(spriteBatch);
                
            
        }

        
        public void PlayerCollideMap()
        {
            if ((player.Velocity.X > 0 && map.IsCollision(player.BoundingBox)) ||
            (player.Velocity.X < 0 & map.IsCollision(player.BoundingBox)))
                player.Velocity.X = 0;

            if ((player.Velocity.Y > 0 && map.IsCollision(player.BoundingBox)) ||
                (player.Velocity.Y < 0 & map.IsCollision(player.BoundingBox)))
                player.Velocity.Y = 0;

            player.Position += player.Velocity;
            player.Velocity = Vector2.Zero;
        }

        public void Follow()
        {


            var distance = player.Position - enemy.Position;
            enemy._rotation = (float)Math.Atan2(distance.Y, distance.X);

            enemy.Direction = new Vector2((float)Math.Cos(enemy._rotation), (float)Math.Sin(enemy._rotation));

            var currentDistance = Vector2.Distance(enemy.Position, player.Position);
            if (currentDistance > enemy.FollowDistance)
            {
                var t = MathHelper.Min((float)Math.Abs(currentDistance - enemy.FollowDistance), enemy.LinearVelocity);
                var velocity = enemy.Direction * t;

                enemy.Position += velocity / 8;
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawMap(spriteBatch);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

        }
        

        public override void Update(GameTime gameTime)
        {

           
            player.Update(gameTime);
            PlayerCollideMap();
            enemy.Update(gameTime);
            Follow();
            //enemy.TestMovement();
           
        }
    }
}
