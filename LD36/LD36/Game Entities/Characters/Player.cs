using System;
using System.Collections.Generic;
using LD36.Animations;
using LD36.Extensions;
using LD36.Game_Entities;
using LD36.Game_Entities.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Characters
{
    public class Player : BaseGameEntity
    {
        private readonly AnimationCollection _animations = new AnimationCollection();
        private float _scale = 1.0f;

        public Vector2 Destination { get; set; }
        public float Speed { get; set; }
        public int Horizon { get; set; }

        public Player(int x = 0, int y = 0)
        {
            Texture = ArchaicGame.Textures[TextureNames.PlayerAnimation];
            Position = new Vector2(x, y);
            Size = new Vector2(32, 48);
            Tint = Color.White;

            Destination = Vector2.Zero.MinValue();
            Speed = 3f;
            Horizon = 256;

            InitializeAnimations();
        }

        public void InitializeAnimations()
        {
            var w = (int)Size.X;
            var h = (int)Size.Y;

            // Right
            _animations.Add(PlayerAnimationNames.IdleRight, 1, new List<Rectangle> { new Rectangle(0, 0, w, h) });
            _animations.Add(PlayerAnimationNames.UseRight, 1, new List<Rectangle> { new Rectangle(32, 0, w, h) });
            _animations.Add(PlayerAnimationNames.WalkRight, 1, new List<Rectangle>
            {
                new Rectangle(64, 0, w, h),
                new Rectangle(96, 0, w, h),
                new Rectangle(128, 0, w, h),
                new Rectangle(160, 0, w, h),
                new Rectangle(192, 0, w, h),
                new Rectangle(224, 0, w, h),
                new Rectangle(256, 0, w, h),
                new Rectangle(288, 0, w, h),
            });

            // Left
            _animations.Add(PlayerAnimationNames.IdleLeft, 1, new List<Rectangle> { new Rectangle(0, 48, w, h) });
            _animations.Add(PlayerAnimationNames.UseLeft, 1, new List<Rectangle> { new Rectangle(32, 48, w, h) });
            _animations.Add(PlayerAnimationNames.WalkLeft, 1, new List<Rectangle>
            {
                new Rectangle(64, 48, w, h),
                new Rectangle(96, 48, w, h),
                new Rectangle(128, 48, w, h),
                new Rectangle(160, 48, w, h),
                new Rectangle(192, 48, w, h),
                new Rectangle(224, 48, w, h),
                new Rectangle(256, 48, w, h),
                new Rectangle(288, 48, w, h),
            });

            _animations.ChangeAnimation(PlayerAnimationNames.IdleRight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Destination != Vector2.Zero.MinValue())
            {
                var dirX = Destination.X > Position.X ? 1 : -1;
                var dirY = Destination.Y > Position.Y ? 1 : -1;

                if (Vector2.Distance(Position, Destination) > Speed)
                {
                    var velocity = Vector2.Subtract(Destination, Position);
                    velocity.Normalize();

                    var vector = velocity * Speed;
                    Position += vector;
                    Position = new Vector2((int)Position.X, (int)Position.Y);
                }
                else
                {
                    Destination = Position;
                }

                _animations.ChangeAnimation(dirX == 1 ? PlayerAnimationNames.WalkRight : PlayerAnimationNames.WalkLeft);

                if (Position.X < 0)
                {
                    Position = Position.SetX(0);
                    Destination = Destination.SetX(0);
                }
                if (Position.Y < Horizon)
                {
                    Position = Position.SetY(Horizon);
                    Destination = Destination.SetY(Horizon);
                }

                if (Position.X + Size.X >= ArchaicGame.ScreenWidth)
                {
                    Position = Position.SetX(ArchaicGame.ScreenWidth - Size.X);
                    Destination = Destination.SetX(ArchaicGame.ScreenWidth - Size.X);
                }
                if (Position.Y + Size.Y >= ArchaicGame.ScreenHeight)
                {
                    Position = Position.SetY(ArchaicGame.ScreenHeight - Size.Y);
                    Destination = Destination.SetY(ArchaicGame.ScreenHeight - Size.Y);
                }

                if ((int)Position.X == (int)Destination.X && (int)Position.Y == (int)Destination.Y)
                {
                    Destination = Vector2.Zero.MinValue();
                    _animations.ChangeAnimation(dirX == 1 ? PlayerAnimationNames.IdleRight : PlayerAnimationNames.IdleLeft);
                }
            }

            _animations.Update(gameTime);

            _scale = (Position.Y / ArchaicGame.ScreenHeight) * 4f;
        }

        public override void Draw(GameTime gameTime)
        {
            var srcRect = _animations.CurrentAnimation.CurrentFrame;

            ArchaicGame.SpriteBatch.Draw(Texture, Position, srcRect, Tint, 0f, new Vector2(16f, 24f), _scale, SpriteEffects.None, 0f);
        }

		public bool WithinInteractionDistance(Vector2 mouseBounds) => Position.DistanceTo(mouseBounds) < 30;

	    public void ChangeAnimation(string animationName) => _animations.ChangeAnimation(animationName);
	}
}