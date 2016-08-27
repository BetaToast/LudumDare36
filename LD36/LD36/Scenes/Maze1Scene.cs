using Microsoft.Xna.Framework;

namespace LD36.Scenes
{
	public  class Maze1Scene
		:  Scene
	{
        public const string Title = "AMaz1ng";
        public override void Draw(GameTime gameTime)
		{
			ArchaicGame.Graphics.GraphicsDevice.Clear(Color.Black);
		}
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
