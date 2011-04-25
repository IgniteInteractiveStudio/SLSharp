using System;

namespace IIS.SLSharp.Annotations
{
    public enum UsageSemantic
    {
        /*
        Binormal,
        Blendindices,
        Blendweight,
        Color,
        Normal,
        Position,
        PositionT,
        PSize,
        Tangent,
        Texcoord,
        Fog,
        TessFactor,
        VFace,
        VPos,
        Depth*/
        Unknown,

        PositionX,
        Position0,
        Position1,
        Position2,
        Position3,
        Position4,
        Position5,
        Position6,
        Position7,
        Position8,
        Position9,
        Position10,
        Position11,
        Position12,
        Position13,
        Position14,
        Position15,

        ColorX,
        Color0,
        Color1,
        Color2,
        Color3,
        Color4,
        Color5,
        Color6,
        Color7,
        Color8,
        Color9,
        Color10,
        Color11,
        Color12,
        Color13,
        Color14,
        Color15,
    };


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class VertexInAttribute : ShaderVariableAttribute
    {
        public VertexInAttribute(UsageSemantic hint) { }
    }
}