using System;

namespace IIS.SLSharp.Translation
{
    /// <summary>
    /// Internally used to debug the translation system.
    /// 
    /// Any shader flagged with this attribute will be translated through
    /// A GlslTransform.Test() invocation.
    /// </summary>
    public sealed class DebugTranslatorAttribute : Attribute
    {
    }
}
