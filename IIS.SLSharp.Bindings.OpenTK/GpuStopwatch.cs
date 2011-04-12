using System;
using System.Diagnostics;
using System.Threading;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK
{
    public sealed class GpuStopwatch : IDisposable
    {
        private readonly bool _hasArbTimer;

        private readonly Stopwatch _simpleWatch;

        private uint _query;

        public GpuStopwatch()
        {
            _hasArbTimer = GL.GetString(StringName.Extensions).Contains("ARB_timer_query");

            if (_hasArbTimer)
                GL.GenQueries(1, out _query);
            else
                _simpleWatch = new Stopwatch();
        }

        public void Restart()
        {
            if (!_hasArbTimer)
                _simpleWatch.Restart();
            else
                GL.BeginQuery((QueryTarget)(0x88BF), _query);
        }

        public void Stop()
        {
            if (!_hasArbTimer)
                _simpleWatch.Stop();
            else
                GL.EndQuery((QueryTarget)(0x88BF));
        }

        public void StopAndFinish()
        {
            if (_hasArbTimer)
            {
                Stop();
                GL.Finish();
            }
            else
            {
                GL.Finish();
                Stop();
            }
        }

        public bool IsGpuWatch
        {
            get { return _hasArbTimer; }
        }

        public bool Available
        {
            get
            {
                if (!_hasArbTimer)
                    return true;

                int available;
                GL.GetQueryObject(_query, GetQueryObjectParam.QueryResultAvailable, out available);
                return available != 0;
            }
        }

        public void WaitForResult()
        {
            while (!Available)
                Thread.Yield();
        }

        public long ElapsedTicks
        {
            get
            {
                if (!_hasArbTimer)
                    return _simpleWatch.ElapsedTicks;

                WaitForResult();
                uint time;
                GL.GetQueryObject(_query, GetQueryObjectParam.QueryResult, out time);
                return time;
            }
        }

        public void Dispose()
        {
            if (_query == 0)
                return;

            GL.DeleteQueries(1, ref _query);
            _query = 0;

            GC.SuppressFinalize(this);
        }

        ~GpuStopwatch()
        {
            Dispose();
        }
    }
}
