using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IIS.SLSharp.Bindings.MOGRE;
using IIS.SLSharp.Examples.MOGRE.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;
using Mogre;

namespace IIS.SLSharp.Examples.MOGRE.GeoClipmap.GeoClipmap
{
    internal class PatchRenderable: Renderable
    {
        private readonly ClipmapShader _shader;

        private readonly Patch _patch;

        private static readonly LightList _nullLights = new LightList();

        public Vector4 ScaleFactor;

        public Vector4 FineBlockOrigin;

        private readonly string _scaleFactorName;

        private readonly string _fineBlockOriginName;

        public ClipmapLevel Level;

        public PatchRenderable(Patch patch, ClipmapShader shader)
        {
            _patch = patch;
            _shader = shader;

            _scaleFactorName = Shader.UniformName(() => _shader.ScaleFactor);
            _fineBlockOriginName = Shader.UniformName(() => _shader.FineBlockOrigin);
        }

        public override MaterialPtr GetMaterial()
        {
            return Level.Material;
        }

        public override ushort NumWorldTransforms
        {
            get
            {
                return 1;
            }
        }

        public override void GetRenderOperation(RenderOperation op)
        {
            op.useIndexes = true;
            op.operationType = RenderOperation.OperationTypes.OT_TRIANGLE_LIST;
            op.vertexData = _patch.VertexData;
            op.indexData = _patch.IndexData;
        }

        public override void _updateCustomGpuParameter(GpuProgramParameters.AutoConstantEntry_NativePtr constantEntry, GpuProgramParameters @params)
        {
            base._updateCustomGpuParameter(constantEntry, @params);
            @params.SetNamedConstant(_scaleFactorName, ScaleFactor);
            @params.SetNamedConstant(_fineBlockOriginName, FineBlockOrigin);
        }

        public override unsafe void GetWorldTransforms(Matrix4.NativeValue* xform)
        {
            *xform = Matrix4.IDENTITY.value;
        }

        public override float GetSquaredViewDepth(Camera cam)
        {
            return 0.0f;
        }

        public override Const_LightList GetLights()
        {
            return _nullLights;
        }
    }
}
