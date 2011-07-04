using System;
using System.IO;
using IIS.SLSharp.Bindings.MOGRE;
using IIS.SLSharp.Examples.MOGRE.Shaders;
using IIS.SLSharp.Examples.MOGRE.Textures;
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
            Shader.DebugMode = true;
            
            //Shader.DebugMode = true;

            _shader = Shader.CreateSharedShader<SimpleShader>();

            _patchEntity = _scene.CreateEntity("Box", "box.mesh");
            _scene.RootSceneNode.AttachObject(_patchEntity);

            var mat = _shader.ToMaterial();
            var pass = mat.GetTechnique(0).GetPass(0);
            pass.SetAlphaRejectSettings(CompareFunction.CMPF_GREATER_EQUAL, 128);
            pass.CullingMode = CullingMode.CULL_NONE;
            
            // SL# on OGRE: bind auto semantic to a uniform!
            // (we might automate this via semantic attributes within the SL# shaders in future!)
            _shader.SetAuto(() => _shader.ModelviewProjection, GpuProgramParameters.AutoConstantType.ACT_WORLDVIEWPROJ_MATRIX);

            _shader.Begin();

            // Set a texture
            /*
            var smp = _shader.Sampler(() => _shader.Texture);
            smp.SetTextureName(TextureManager.Singleton.Load("test.png", ResourceGroupManager.DEFAULT_RESOURCE_GROUP_NAME).Name);
            smp.SetTextureName(_wang.AsTexture.Name);
            smp.SetTextureFiltering(FilterOptions.FO_POINT, FilterOptions.FO_POINT, FilterOptions.FO_POINT);
             */

            _patchEntity.SetMaterial(mat);

            _camera = _scene.CreateCamera("MainCamera");
            _camera.Position = new Vector3(0, 0, 5);
            _camera.LookAt(Vector3.ZERO);
            _camera.NearClipDistance = 0.0001f;
            _camera.FarClipDistance = 4.0f;
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
            var cam = new Vector3((float)Math.Sin(angle), 0.5f, (float)Math.Cos(angle)) * ((float)Math.Sin(angle*4) + 1.7f);
            var look = Vector3.ZERO;
            
            _camera.Position = cam + look;
            _camera.LookAt(look);


            // SL# allows direct manipulation of uniforms like this!
            _shader.Blue = (float)Math.Sin(angle * 8.0f);
          

            return !_window.IsClosed;
        }
      
    }
}
