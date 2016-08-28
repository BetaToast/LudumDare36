using System;
using LD36.Input;
using Microsoft.Xna.Framework;

namespace LD36.Game_Entities.Objects
{
    public sealed class MagicSquare : BaseGameEntity
    {
        public Action OnClick { get; set; }

        public MagicSquare(Vector2 position, Action onClick)
        {
            ArchaicGame.Textures.Load(TextureNames.blockGreen_puzzle);
            ArchaicGame.Sounds.Load(SoundNames.ConfirmBeepy02);

            Texture = ArchaicGame.Textures[TextureNames.blockGreen_puzzle];
            Size = new Vector2(Texture.Width, Texture.Height);
            Position = position;
            OnClick = onClick;
            Tint = Color.White;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Tint = Color.White;

            if (ArchaicGame.Input.Mouse.IsButtonPressed(MouseButtons.Left) && ArchaicGame.Input.Mouse.Bounds.Intersects(Bounds))
            {
                ArchaicGame.Sounds.Play(SoundNames.ConfirmBeepy02);
                OnClick?.Invoke();
            }
        }

    }
}
