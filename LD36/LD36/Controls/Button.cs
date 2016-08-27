using System;
using LD36.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD36.Controls
{
	public class Button
	{
		private Texture2D _texture;
		private Color _tint;

		public int X { get; set; }
		public int Y { get; set; }
		public Color HoverColor { get; set; }

		public Rectangle Bounds { get; private set; }
		public bool IsHover { get; private set; }
		public Action OnClick { get; set; }

		public Button(string textureName, int x, int y, Action onClick)
		{
			_texture = ArchaicGame.Textures[textureName];
			X = x;
			Y = y;
			OnClick = onClick;
			_tint = Color.White;
			HoverColor = Color.Coral;
		}

		public void Update(GameTime gameTime)
		{
			Bounds = new Rectangle(X, Y, _texture.Width, _texture.Height);
			_tint = Color.White;
			IsHover = false;

			if (ArchaicGame.Input.Mouse.Bounds.Intersects(Bounds))
			{
				IsHover = true;
				_tint = HoverColor;
			}

			if (IsHover && ArchaicGame.Input.Mouse.IsButtonPressed(MouseButtons.Left))
			{
				OnClick?.Invoke();
			}
		}

		public void Draw()
		{
			ArchaicGame.SpriteBatch.Draw(_texture, Bounds, _tint);
		}
	}
}
