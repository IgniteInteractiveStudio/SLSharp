using System;
using IIS.SLSharp.Bindings.XNA;
using IIS.SLSharp.Examples.XNA.Shaders;
using IIS.SLSharp.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IIS.SLSharp.Examples.XNA
{
    class DemoWindow: Game
    {
        private readonly GraphicsDeviceManager _gdm;
        private SimpleShader _shader;
        private Model _model;

        public DemoWindow()
        {
            _gdm = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void LoadContent()
        {
            Bindings.XNA.SLSharp.Init(GraphicsDevice);
            Shader.DebugMode = true;
            _shader = Shader.CreateSharedShader<SimpleShader>();
            _model = Content.Load<Model>("xwing");
        }

        protected override void UnloadContent()
        {
            _shader.Dispose();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var angle = MathHelper.ToRadians((DateTime.Now.Millisecond / 1000.0f + DateTime.Now.Second) * 6 * 4);
            var cam = new Vector3((float) Math.Sin(angle), 0.0f, (float) Math.Cos(angle));
            var aspect = ((float) Window.ClientBounds.Width)/Window.ClientBounds.Height;
            var world = Matrix.CreateScale(0.005f);
            var view = Matrix.CreateLookAt(cam,Vector3.Zero, Vector3.UnitY);
            var proj = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45.0f), aspect, 0.1f, 10.0f);



            _shader.Begin();
            foreach (var mesh in _model.Meshes)
            {
                var modelview = world * view * mesh.ParentBone.Transform;
                var mvp = Matrix.Transpose(modelview*proj);

                _shader.Blue = (float)Math.Sin(angle * 8.0f);
                _shader.ModelviewProjection = mvp.ToMatrix4F();
                foreach (var part in mesh.MeshParts)
                {
                    GraphicsDevice.SetVertexBuffer(part.VertexBuffer, part.VertexOffset);
                    GraphicsDevice.Indices = part.IndexBuffer;
                    GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList,
                        0, part.VertexOffset, part.NumVertices, part.StartIndex, part.PrimitiveCount);
                }
            }
            _shader.End();
            
            //_model.Draw(model, view, proj);

            base.Draw(gameTime);
        }
    }
}
