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
        private Entity _patchEntity;
        private Camera _camera;
        private readonly RenderWindow _window;
        private Clipmap _clipmap;

        public DemoWindow(Root root, RenderWindow renderWindow)
        {
            _root = root;
            _window = renderWindow;
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

            
            //_patchEntity = _scene.CreateEntity("Box", "box.mesh");
            //_scene.RootSceneNode.AttachObject(_patchEntity);

            _clipmap = new Clipmap(_scene);

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
            var angle = Mogre.Math.DegreesToRadians((DateTime.Now.Millisecond / 1000.0f + DateTime.Now.Second) * 6);

            angle *= 4;
            var z = 0.1f + (1.0f + (float)Math.Sin(angle));
            
            

            var cam = new Vector3(0.0f, 0.0f, z);
            var look = new Vector3((float)Math.Sin(angle), (float)Math.Cos(angle), 0.1f);
            var up = new Vector3(0.0f, 0.0f, 1.0f);

            /*
            var cam = new Vector3(0.0f, 0.0f, 10.00f+8.0f*(float)Math.Sin(angle*4.0f));
            var look = Vector3.ZERO;
            var up = Vector3.UNIT_Y;
             */
            _camera.Position = cam;
            _camera.LookAt(look);
            _camera.SetFixedYawAxis(true, up);

            return !_window.IsClosed;
        }
      
    }
}
