using System;
using LD36.Input;
using Microsoft.Xna.Framework;

namespace LD36.Game_Entities.Controls
{
    public sealed class Button : BaseGameEntity
    {
        public Color HoverColor { get; set; }
        public bool IsHover { get; private set; }
        public Action OnClick { get; set; }

        public Button(string textureName, int x, int y, Action onClick)
        {
            Texture = ArchaicGame.Textures[textureName];
            Size = new Vector2(Texture.Width, Texture.Height);
            Position = new Vector2(x, y);
            OnClick = onClick;
            Tint = Color.White;
            HoverColor = Color.Coral;

            ArchaicGame.Sounds.Load(SoundNames.VintageButton1);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Tint = Color.White;
            IsHover = false;

            if (ArchaicGame.Input.Mouse.Bounds.Intersects(Bounds))
            {
                IsHover = true;
                Tint = HoverColor;
            }

            if (IsHover && ArchaicGame.Input.Mouse.IsButtonPressed(MouseButtons.Left))
            {
                ArchaicGame.Sounds.Play(SoundNames.VintageButton1);
                OnClick?.Invoke();
            }
        }

        public void Draw()
        {
            ArchaicGame.SpriteBatch.Draw(Texture, Bounds, Tint);
        }
    }
}
