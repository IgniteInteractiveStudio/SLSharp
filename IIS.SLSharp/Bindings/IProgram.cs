using System;

namespace IIS.SLSharp.Bindings
{
    public interface IProgram: IDisposable
    {
        void Activate();
        void Finish();
        int GetUniformIndex(string name);
        int GetAttributeIndex(string name);
    }
}