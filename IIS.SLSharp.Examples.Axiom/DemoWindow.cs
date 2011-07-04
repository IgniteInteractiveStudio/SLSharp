using System;
using System.IO;
using System.Linq;
using Axiom.Core;
using Axiom.Graphics;
using Axiom.Math;
using IIS.SLSharp.Bindings.Axiom;
using IIS.SLSharp.Examples.Axiom.Shaders;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Axiom
{
    public sealed class DemoWindow 
    {
        private SimpleShader _shader;
        private readonly Root _root;
        private SceneManager _scene;
        private Entity _patchEntity;
        private Camera _camera;

        public DemoWindow(Root root)
        {
            _root = root;
        }

        public void OnLoad()
        {
            var dir = Directory.GetCurrentDirectory();
            ResourceGroupManager.Instance.AddResourceLocation(dir, "Folder");
            //MaterialManager.Instance.Initialize();

            _scene = _root.CreateSceneManager("DefaultSceneManager", "SLSharpInstance");
            _scene.ClearScene();

            Bindings.Axiom.SLSharp.Init();
            Shader.DebugMode = true;

            //Shader.DebugMode = true;

            _shader = Shader.CreateSharedShader<SimpleShader>();

            _patchEntity = _scene.CreateEntity("Box", "box.mesh");
            _scene.RootSceneNode.AttachObject(_patchEntity);

            var mat = _shader.ToMaterial();
            var pass = mat.GetTechnique(0).GetPass(0);
            pass.SetAlphaRejectSettings(CompareFunction.GreaterEqual, 128);
            pass.CullingMode = CullingMode.None;

            // SL# on OGRE: bind auto semantic to a uniform!
            // (we might automate this via semantic attributes within the SL# shaders in future!)
            _shader.SetAuto(() => _shader.ModelviewProjection, GpuProgramParameters.AutoConstantType.WorldViewProjMatrix);

            _shader.Begin();

            _patchEntity.MaterialName = mat.Name;
            //_patchEntity.Material = mat;


            _camera = _scene.CreateCamera("MainCamera");
            _camera.Position = new Vector3(0, 0, 5);
            _camera.LookAt(Vector3.Zero);
            _camera.Near = 0.00001f;
            _camera.Far = 4.0f;
            _camera.AutoAspectRatio = true;

            var vp = _root.AutoWindow.AddViewport(_camera);
            vp.BackgroundColor = ColorEx.CornflowerBlue;

        }

        public void OnUnload()
        {
            _shader.Dispose();
        }

        public void OnRenderFrame(object s, FrameEventArgs e)
        {
            var angle = Utility.DegreesToRadians((DateTime.Now.Millisecond / 1000.0f + DateTime.Now.Second) * 6 * 4);
            var cam = new Vector3((float)Math.Sin(angle), 0.5f, (float)Math.Cos(angle)) * ((float)Math.Sin(angle * 4) + 1.7f);
            var look = Vector3.Zero;

            _camera.Position = cam + look;
            _camera.LookAt(look);

            // Axiom Bug: cant set in GL mode properly atm
            // SL# allows direct manipulation of uniforms like this!
            //_shader.Blue = (float)Math.Sin(angle * 8.0f);
        }
      
    }
}
