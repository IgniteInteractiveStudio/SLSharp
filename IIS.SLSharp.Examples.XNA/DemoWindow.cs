using System;
using IIS.SLSharp.Examples.XNA.Shaders;
using IIS.SLSharp.Shaders;
using Microsoft.Xna.Framework;

namespace IIS.SLSharp.Examples.XNA
{
    class DemoWindow: Game
    {
        private readonly GraphicsDeviceManager _gdm;
        private SimpleShader _shader;

        public DemoWindow()
        {
            _gdm = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void LoadContent()
        {
            Bindings.XNA.SLSharp.Init();
            _shader = Shader.CreateSharedShader<SimpleShader>();
        }

        protected override void UnloadContent()
        {
            _shader.Dispose();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
