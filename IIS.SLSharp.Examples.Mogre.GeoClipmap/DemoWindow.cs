using System;
using System.IO;
using IIS.SLSharp.Bindings.MOGRE;
using IIS.SLSharp.Examples.MOGRE.GeoClipmap.GeoClipmap;
using IIS.SLSharp.Examples.MOGRE.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using Mogre;
using Math = System.Math;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap
{
    public sealed class DemoWindow 
    {
        private readonly Root _root;
        private SceneManager _scene;
        private Camera _camera;
        private readonly RenderWindow _window;
        private Clipmap _clipmap;
        private float _z;

        public DemoWindow(Root root, RenderWindow renderWindow)
        {
            _root = root;
            _window = renderWindow;
        }

        private float Lerp(float a, float b, float w)
        {
            return w * b + (1 - w) * a;
        }

        private void RecalcHeight()
        {
            _z = _clipmap.GeneratePixelAt(-(_clipmap.Position.X.Integer * 2 - 1), -(_clipmap.Position.Y.Integer * 2 - 1));
            var zx = _clipmap.GeneratePixelAt(-(_clipmap.Position.X.Integer * 2 + 1), -(_clipmap.Position.Y.Integer * 2 - 1));
            var zy = _clipmap.GeneratePixelAt(-(_clipmap.Position.X.Integer * 2 - 1), -(_clipmap.Position.Y.Integer * 2 + 1));
            var zxy = _clipmap.GeneratePixelAt(-(_clipmap.Position.X.Integer * 2 + 1), -(_clipmap.Position.Y.Integer * 2 + 1));

            var v1 = Lerp(_z, zx, _clipmap.Position.X.Fraction);
            var v2 = Lerp(zy, zxy, _clipmap.Position.X.Fraction);
            _z = Lerp(v1, v2, _clipmap.Position.Y.Fraction);
        }

        public void OnLoad()
        {
            var dir = Directory.GetCurrentDirectory();
            ResourceGroupManager.Singleton.AddResourceLocation(dir, "FileSystem");
            MaterialManager.Singleton.Initialise();

            _scene = _root.CreateSceneManager("DefaultSceneManager", "SLSharpInstance");
            _scene.ClearScene();

            Bindings.MOGRE.SLSharp.Init();
            Shader.DebugMode = true;
            
            //Shader.DebugMode = true;

            _clipmap = new Clipmap(_scene);
            RecalcHeight();

            _camera = _scene.CreateCamera("MainCamera");
            _camera.Position = new Vector3(0, 0, 5);
            _camera.LookAt(Vector3.ZERO);
            _camera.NearClipDistance = 0.001f;
            _camera.FarClipDistance = 20.0f;
            _camera.AutoAspectRatio = true;

            var vp = _window.AddViewport(_camera);
            vp.BackgroundColour = ColourValue.Blue;
        }

        public void OnUnload()
        {
            _clipmap.Dispose();
        }

        public bool OnRenderFrame(FrameEvent evt)
        {
            _clipmap.MoveBy(0.0f, 0.4f);
            RecalcHeight();

            var angle = Mogre.Math.DegreesToRadians((DateTime.Now.Millisecond / 1000.0f + DateTime.Now.Second) * 6);

            angle *= 4;
            var z = 1.0f + (float)Math.Sin(angle);
            if (z < _z)
                z = _z;
           
            var cam = new Vector3(0.0f, 0.0f, z);
            var look = new Vector3((float)Math.Sin(angle), (float)Math.Cos(angle), 0.1f);
            var up = new Vector3(0.0f, 0.0f, 1.0f);

            _camera.Position = cam;
            _camera.LookAt(look);
            _camera.SetFixedYawAxis(true, up);      

            return !_window.IsClosed;
        }
      
    }
}
