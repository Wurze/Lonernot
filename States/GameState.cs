using Lonernot.Engine;
using Lonernot.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = Lonernot.Engine.Timer;

namespace Lonernot.States
{
    public class GameState : State
    {
        public Map map;
        public Player player;
        public Enemy enemy;
        public List<Rectangle> collison;
        public Timer timer;
        public float score;
        public Portals portals;
        public SpriteFont font;
        public Dictionary<string, Animation> enemyAnimations;

        public List<Enemy> enemyList;

        //public SpriteFont textFont;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            font = _content.Load<SpriteFont>("Fonts/Font");
            //create Timer
            timer = new Timer();

            enemyList = new List<Enemy>();

            //create map
            map = new Map(content, "Content/Lonernot.tmx");
            map.AddCollision();
            
            collison = map.GetCollisionPath();

            //create portals
            portals = new Portals(map);



            //loading animation for player
            var playerAnimations = new Dictionary<string, Animation>()
            {
                {"Walking_up", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_up"),4) },
                {"Walking_down", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_down"),4) },
                {"Walking_right", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_right"),4) },
                {"Walking_left", new Animation(content.Load<Texture2D>("Spritesheets/Player/Walking_left"),4) }
            };

            player = new Player(playerAnimations);
            player.SetPosition(map.GetStartingPoint());

            //loading animations for enemy
            enemyAnimations = new Dictionary<string, Animation>()
            {
                {"Walking_up", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_up"),4) },
                {"Walking_down", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_down"),4) },
                {"Walking_right", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_right"),4) },
                {"Walking_left", new Animation(content.Load<Texture2D>("Spritesheets/Enemy/Walking_left"),4) }

            };

            AddEnemy();

        }

        public void AddEnemy()
        {
            Semaphore monsterSemaphore = new Semaphore(initialCount: 3, maximumCount: 3, name: "monsterSemaphore");

            for (int i = 8; i < 10; i++)
            {
               
                Task.Factory.StartNew(() =>
                {
                    monsterSemaphore.WaitOne();
                    CreateEnemy(i);
                    monsterSemaphore.Release();
                });
            }

        }

        public void CreateEnemy(int speed)
        {
           
                Enemy enemy = new Enemy(enemyAnimations, speed);
                enemy.SetPosition(map.GetStartingPoint());
                enemyList.Add(enemy);
                Thread.Sleep(TimeSpan.FromSeconds(10));
  
        }


        public void DrawMap(SpriteBatch spriteBatch)
        {
            map.DrawMapLayer(spriteBatch);
        }


        public void GameOver()
        {
            foreach (Enemy enemy in enemyList)
                if (player.CheckCollisonEnemy(enemy))
                    {

                        _game.ChangeState(_game.gameOverState);

                    }
        }

        public void WinGame()
        {
            if (player.BoundingBox.Intersects(map.GetEndingPoint()))
            {
                _game.ChangeState(_game.gameOverState);
            }
        }

        public void Follow()
        {
            foreach (Enemy enemy in enemyList)
            {
                if (timer.GetSpawn())
                {
                    var distance = player.Position - enemy.Position;
                    enemy._rotation = (float)Math.Atan2(distance.Y, distance.X);

                    enemy.Direction = new Vector2((float)Math.Cos(enemy._rotation), (float)Math.Sin(enemy._rotation));

                    var currentDistance = Vector2.Distance(enemy.Position, player.Position);
                    if (currentDistance > enemy.FollowDistance)
                    {
                        var t = MathHelper.Min((float)Math.Abs(currentDistance - enemy.FollowDistance), enemy.LinearVelocity);
                        var velocity = enemy.Direction * t;

                        enemy.Position += velocity / enemy.enemySpeed;
                    }

                }
            }
               
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawMap(spriteBatch);
            player.Draw(spriteBatch);
            if (timer.GetSpawn())
            {
                foreach (Enemy enemy in enemyList)
                    enemy.Draw(spriteBatch);
            }

            spriteBatch.DrawString(font, "Score  " + score, new Vector2(1100, 10), Color.White);

        }



        public override void Update(GameTime gameTime)
        {
            score = timer.GetGameTime();
            foreach (var wall in map.pathList)
            {
                if ((player.Velocity.X > 0 && player.IsTouchingLeft(wall)) ||
                (player.Velocity.X < 0 & player.IsTouchingRight(wall)))
                    player.Velocity.X = 0;

                if ((player.Velocity.Y > 0 && player.IsTouchingTop(wall)) ||
                    (player.Velocity.Y < 0 & player.IsTouchingBottom(wall)))
                    player.Velocity.Y = 0;
            }

            player.Position += player.Velocity;
            player.Velocity = Vector2.Zero;
            player.Update(gameTime);
            if (timer.GetSpawn())
            {
                foreach(Enemy enemy in enemyList)
                    enemy.Update(gameTime);
                
                
            }
            timer.Update(gameTime);
            portals.CheckTeleportation(player);
            Follow();  
            WinGame();
            GameOver();
        }
    }
}
