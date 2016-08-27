using Microsoft.Xna.Framework;

namespace LD36.Scenes
{
	public  class CampScene
		:  Scene
	{
        public const string Title = "Camp";

        public override void Draw(GameTime gameTime)
		{
			AdventureGame.Graphics.GraphicsDevice.Clear(Color.Black);
		}
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
