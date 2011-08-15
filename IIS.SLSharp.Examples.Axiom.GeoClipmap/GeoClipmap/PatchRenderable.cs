using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Axiom.Core;
using Axiom.Core.Collections;
using Axiom.Graphics;
using Axiom.Math;
using IIS.SLSharp.Bindings.Axiom;
using IIS.SLSharp.Examples.Axiom.GeoClipmap.Shaders;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Axiom.GeoClipmap.GeoClipmap
{
    internal class PatchRenderable: IRenderable
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

        public bool NormalizeNormals
        {
            get { return false; }
        }

        public ushort NumWorldTransforms
        {
            get { return 1; }
        }

        public bool UseIdentityProjection
        {
            get { return false; }
        }

        public bool UseIdentityView
        {
            get { return false; }
        }

        public bool PolygonModeOverrideable
        {
            get { return true;  }
        }

        public Quaternion WorldOrientation
        {
            get { throw new NotImplementedException(); }
        }

        public Vector3 WorldPosition
        {
            get { throw new NotImplementedException(); }
        }

        public void GetWorldTransforms(Matrix4[] matrices)
        {
            matrices[0] = Matrix4.Identity;
        }

        public float GetSquaredViewDepth(Camera cam)
        {
            return 0.0f;
        }

        public Vector4 GetCustomParameter(int index)
        {
            throw new NotImplementedException();
        }

        public void SetCustomParameter(int index, Vector4 val)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomGpuParameter(GpuProgramParameters.AutoConstantEntry constant, GpuProgramParameters parameters)
        {
            parameters.SetNamedConstant(_scaleFactorName, ScaleFactor);
            parameters.SetNamedConstant(_fineBlockOriginName, FineBlockOrigin);
        }

        public bool CastsShadows
        {
            get { throw new NotImplementedException(); }
        }

        public Material Material
        {
            get { return Level.Material; }
        }

        public Technique Technique
        {
            get { return Level.Material.GetTechnique(0); }
        }

        public RenderOperation RenderOperation
        {
            get
            {
                var op = new RenderOperation();
                op.useIndices = true;
                op.operationType = OperationType.TriangleList;
                op.vertexData = _patch.VertexData;
                op.indexData = _patch.IndexData;
                return op;
            }
        }

        public LightList Lights
        {
            get { return _nullLights; }
        }
    }
}
