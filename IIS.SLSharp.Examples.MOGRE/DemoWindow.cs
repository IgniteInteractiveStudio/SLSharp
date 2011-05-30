using System;
using System.IO;
using IIS.SLSharp.Bindings.MOGRE;
using IIS.SLSharp.Examples.Axiom.Shaders;
using IIS.SLSharp.Shaders;
using Mogre;
using Math = System.Math;

namespace IIS.SLSharp.Examples.MOGRE
{
    public sealed class DemoWindow 
    {
        private SimpleShader _shader;
        private readonly Root _root;
        private SceneManager _scene;
        private Entity _patchEntity;
        private Camera _camera;
        private readonly RenderWindow _window;

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
            //Shader.DebugMode = true;

            _shader = Shader.CreateSharedShader<SimpleShader>();

            _patchEntity = _scene.CreateEntity("Entity1", "test.mesh");
            _scene.RootSceneNode.AttachObject(_patchEntity);

            var mat = _shader.ToMaterial();
            
            // SL# on OGRE: bind auto semantic to a uniform!
            // (we might automate this via semantic attributes within the SL# shaders in future!)
            _shader.SetAuto(() => _shader.ModelviewProjection, GpuProgramParameters.AutoConstantType.ACT_WORLDVIEWPROJ_MATRIX);

            _patchEntity.SetMaterial(mat);

            _camera = _scene.CreateCamera("MainCamera");
            _camera.Position = new Vector3(0, 0, 5);
            _camera.LookAt(Vector3.ZERO);
            _camera.NearClipDistance = 0.01f;
            _camera.AutoAspectRatio = true;

            var vp = _window.AddViewport(_camera);
            vp.BackgroundColour = ColourValue.Blue;

            

        }

        public void OnUnload()
        {
            _shader.Dispose();
        }

        public bool OnRenderFrame(FrameEvent evt)
        {
            var angle = Mogre.Math.DegreesToRadians((DateTime.Now.Millisecond / 1000.0f + DateTime.Now.Second) * 6 * 4);
            var cam = new Vector3((float)Math.Sin(angle), 0.0f, (float)Math.Cos(angle));
            var look = Vector3.ZERO;

            cam *= 3.0f;
            cam.y += 1.5f;
            _camera.LookAt(look);
            _camera.Position = cam + look;

            // SL# allows direct manipulation of uniforms like this!
            _shader.Blue = (float)Math.Sin(angle * 8.0f);
          

            return !_window.IsClosed;
        }
      
    }
}
