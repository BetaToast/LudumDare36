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
		
        public Vector2 Destination { get; set; }
        public float Speed { get; set; }
		
        public Player(int x = 0, int y = 0)
        {
            Texture = ArchaicGame.Textures[TextureNames.PlayerAnimation];
            Position = new Vector2(x, y);
            Size = new Vector2(32, 48);
            Tint = Color.White;

            Destination = Vector2.Zero.MinValue();
            Speed = 3f;

			InitializeAnimations();
        }

	    public void InitializeAnimations()
	    {
		    var w = (int) Size.X;
		    var h = (int) Size.Y;
			
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
                Position = Position.Add(dirX * Speed, dirY * Speed);
				
				_animations.ChangeAnimation(dirX == 1 ? PlayerAnimationNames.WalkRight : PlayerAnimationNames.WalkLeft);

				// *BUG* Something is causing destinations to get messed up
				var tolerance = 3f;
				if (IsInRange(Destination.X, Position.X, tolerance)) Destination = Destination.SetX(Position.X);
				if (IsInRange(Destination.Y, Position.Y, tolerance)) Destination = Destination.SetY(Position.Y);
				
				if ((int)Position.X == (int)Destination.X && (int)Position.Y == (int)Destination.Y)
                {
                    Destination = Vector2.Zero.MinValue();
					_animations.ChangeAnimation(dirX == 1 ? PlayerAnimationNames.IdleRight : PlayerAnimationNames.IdleLeft);
                }
			}

			_animations.Update(gameTime);
		}

	    public bool IsInRange(float a, float b, float tolerance)
	    {
		    var d = a - b;
		    return d <= tolerance && d >= -tolerance;
	    }

	    public override void Draw(GameTime gameTime)
	    {
		    var srcRect = _animations.CurrentAnimation.CurrentFrame;
			ArchaicGame.SpriteBatch.Draw(Texture, Bounds, srcRect, Tint);
	    }
    }
}