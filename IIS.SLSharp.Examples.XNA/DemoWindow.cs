using Microsoft.Xna.Framework;

namespace IIS.SLSharp.Examples.XNA
{
    class DemoWindow: Game
    {
        private readonly GraphicsDeviceManager _gdm;

        public DemoWindow()
        {
            _gdm = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
