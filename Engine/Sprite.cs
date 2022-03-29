using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lonernot.Engine
{
    public class Sprite
    {
        public float _timer;
        public float _rotation;
        public float radius;
        public Vector2 Velocity;
        public float LifeSpan = 1f;
        public float Scale { get; set; }
        public Input Input;
        public Vector2 Origin;
        public Vector2 Direction;
        public Vector2 _position;
        public Vector2 _movement;
        public Vector2 _destination;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
                
            }
        }


        public Texture2D _texture;
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;


        public bool IsActive = false;




        public Rectangle BoundingBox { get; protected set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)(_position.X - (int)Math.Ceiling(Origin.X)),
                    (int)(_position.Y - (int)Math.Ceiling(Origin.Y)),
                    (int)Math.Ceiling((double)_texture.Width),
                    (int)Math.Ceiling((double)_texture.Height)
                    );
            }
        }

        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

       
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }

        public virtual void UpdateBoundingBox()
        {
            BoundingBox = new Rectangle(
                (int)(_position.X - (int)Math.Ceiling(Origin.X)),
                (int)(_position.Y - (int)Math.Ceiling(Origin.Y)),
                (int)Math.Ceiling((double)_texture.Width),
                (int)Math.Ceiling((double)_texture.Height)
                );
        }


        public void CenterOrigin()
        {
            Origin = new Vector2(_texture.Width / 2.0f, _texture.Height / 2.0f);

            UpdateBoundingBox();
        }

        public virtual void Update(GameTime gameTime)
        {

            _animationManager.Update(gameTime);
        }

        // get and set methods

        public void SetIsActive(bool IsActive)
        {
            this.IsActive = IsActive;
        }

        public bool GetIsActive()
        {
            return IsActive;
        }

        public void SetLifeSpan(float LifeSpan)
        {
            this.LifeSpan = LifeSpan;
        }

        public float GetLifeSpan()
        {
            return LifeSpan;
        }

       

        public void SetOrigin(Vector2 Origin)
        {
            this.Origin = Origin;
        }

        public Vector2 GetOrigin()
        {
            return Origin;
        }

        public void SetDirection(Vector2 Direction)
        {
            this.Direction = Direction;
        }

        public Vector2 GetDirection()
        {
            return Direction;
        }




        public void SetAnimation(Dictionary<string, Animation> _animations)
        {
            this._animations = _animations;
        }

        public Dictionary<string, Animation> GetAnimations()
        {
            return this._animations;
        }

        public void SetAnimationManager(AnimationManager animation)
        {
            this._animationManager = animation;
        }

        public AnimationManager GetAnimationManager()
        {
            return this._animationManager;
        }

        public void SetMovement(Vector2 movement)
        {
            this._movement = movement;
        }

        public Vector2 GetMovement()
        {
            return this._movement;
        }

        public void SetDestination(Vector2 destiantion)
        {
            this._destination = destiantion;
        }

        public Vector2 GetDestination()
        {
            return this._destination;
        }

        public void SetPosition(Vector2 position)
        {
            this._position = position;
        }

        public Vector2 GetPosition()
        {
            return this._position;
        }

        public void SetRotation(float rotation)
        {
            this._rotation = rotation;
        }

        public float GetRotation()
        {
            return this._rotation;
        }


        public void SetRadius(float radius)
        {
            this.radius = radius;
        }

        public float GetRadius()
        {
            return this.radius;
        }


        public void SetTexture(Texture2D texture)
        {
            this._texture = texture;
        }

        public Texture2D GetTexture()
        {
            return this._texture;
        }

    }
}
