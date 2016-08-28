using LD36.Extensions;
using LD36.Game_Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Characters
{
    public class Player : BaseGameEntity
    {
        public Vector2 Destination { get; set; }
        public float Speed { get; set; }

        public Player(Texture2D texture, int x = 0, int y = 0, int width = 32, int height = 32)
        {
            Texture = texture;
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            Tint = Color.White;

            Destination = Vector2.Zero.MinValue();
            Speed = 3f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Destination != Vector2.Zero.MinValue())
            {
                var dx = Destination.X > Position.X ? 1 : -1;
                var dy = Destination.Y > Position.Y ? 1 : -1;
                Position = Position.Add(dx * Speed, dy * Speed);
                if ((int)Position.X == (int)Destination.X && (int)Position.Y == (int)Destination.Y)
                {
                    Destination = Vector2.Zero.MinValue();
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            ArchaicGame.SpriteBatch.Draw(Texture, Bounds, Tint);
        }
    }
}