using System;

namespace IIS.SLSharp.Bindings
{
    public interface IProgram: IDisposable
    {
        void Activate();
        int GetUniformIndex(string name);
        int GetAttributeIndex(string name);
    }
}