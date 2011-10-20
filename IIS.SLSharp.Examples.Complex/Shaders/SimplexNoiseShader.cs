using System.Linq;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Bindings.OpenTK;
using IIS.SLSharp.Bindings.OpenTK.Textures;
using IIS.SLSharp.Shaders;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Examples.Complex.Shaders
{
    /// <summary>
    /// Implements a simplex noise shader as in
    /// http://http.developer.nvidia.com/GPUGems2/gpugems2_chapter26.html
    /// </summary>
    public abstract class SimplexNoiseShader : Shader
    {
        [Uniform]
        protected abstract sampler1D PermGradSampler { set; get; }

        [Uniform]
        protected abstract sampler2D PermSampler2D { set; get;  }

        private Texture2D _perm2D;

        private Texture1D _permGrad3;

        private static readonly int[] _perm =
            {
                151, 160, 137, 91, 90, 15, 131, 13, 201, 95, 96, 53, 194, 233, 7, 225, 140, 36, 103, 30, 69, 142, 8, 99,
                37, 240, 21, 10, 23, 190, 6, 148, 247, 120, 234, 75, 0, 26, 197, 62, 94, 252, 219, 203, 117, 35, 11, 32,
                57, 177, 33, 88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175, 74, 165, 71, 134, 139, 48, 27,
                166, 77, 146, 158, 231, 83, 111, 229, 122, 60, 211, 133, 230, 220, 105, 92, 41, 55, 46, 245, 40, 244,
                102, 143, 54, 65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169, 200, 196, 135, 130,
                116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3, 64, 52, 217, 226, 250, 124, 123, 5, 202, 38, 147,
                118, 126, 255, 82, 85, 212, 207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42, 223, 183, 170, 213, 119,
                248, 152, 2, 44, 154, 163, 70, 221, 153, 101, 155, 167, 43, 172, 9, 129, 22, 39, 253, 19, 98, 108, 110,
                79, 113, 224, 232, 178, 185, 112, 104, 218, 246, 97, 228, 251, 34, 242, 193, 238, 210, 144, 12, 191,
                179, 162, 241, 81, 51, 145, 235, 249, 14, 239, 107, 49, 192, 214, 31, 181, 199, 106, 157, 184, 84, 204,
                176, 115, 121, 50, 45, 127, 4, 150, 254, 138, 236, 205, 93, 222, 114, 67, 29, 24, 72, 243, 141, 128, 195,
                78, 66, 215, 61, 156, 180, 151, 160, 137, 91, 90, 15, 131, 13, 201, 95, 96, 53, 194, 233, 7, 225, 140,
                36, 103, 30, 69, 142, 8, 99, 37, 240, 21, 10, 23, 190, 6, 148, 247, 120, 234, 75, 0, 26, 197, 62, 94,
                252, 219, 203, 117, 35, 11, 32, 57, 177, 33, 88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175,
                74, 165, 71, 134, 139, 48, 27, 166, 77, 146, 158, 231, 83, 111, 229, 122, 60, 211, 133, 230, 220, 105,
                92, 41, 55, 46, 245, 40, 244, 102, 143, 54, 65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89,
                18, 169, 200, 196, 135, 130, 116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3, 64, 52, 217, 226, 250,
                124, 123, 5, 202, 38, 147, 118, 126, 255, 82, 85, 212, 207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28,
                42, 223, 183, 170, 213, 119, 248, 152, 2, 44, 154, 163, 70, 221, 153, 101, 155, 167, 43, 172, 9, 129, 22,
                39, 253, 19, 98, 108, 110, 79, 113, 224, 232, 178, 185, 112, 104, 218, 246, 97, 228, 251, 34, 242, 193,
                238, 210, 144, 12, 191, 179, 162, 241, 81, 51, 145, 235, 249, 14, 239, 107, 49, 192, 214, 31, 181, 199,
                106, 157, 184, 84, 204, 176, 115, 121, 50, 45, 127, 4, 150, 254, 138, 236, 205, 93, 222, 114, 67, 29,
                24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180,
            };

        private static readonly int[,] _grad3 =
            {
                { 1, 1, 0 }, { -1, 1, 0 }, { 1, -1, 0 }, { -1, -1, 0 },
                { 1, 0, 1 }, { -1, 0, 1 }, { 1, 0, -1 }, { -1, 0, -1 },
                { 0, 1, 1 }, { 0, -1, 1 }, { 0, 1, -1 }, { 0, -1, -1 },
                { 1, 1, 0 }, { 0, -1, 1 }, { -1, 1, 0 }, { 0, -1, -1 },
            };

        private void InitTextures()
        {
            var i = byte.MaxValue + 1;
            var perm2 = new byte[i, i, 4];

            for (var y = 0; y < i; y++)
            {
                for (var x = 0; x < i; x++)
                {
                    var a = _perm[x] + y;
                    perm2[y, x, 0] = (byte)_perm[a];
                    perm2[y, x, 1] = (byte)_perm[a + 1];

                    var b = _perm[x + 1] + y;
                    perm2[y, x, 2] = (byte)_perm[b];
                    perm2[y, x, 3] = (byte)_perm[b + 1];
                }
            }

            _perm2D = new Texture2D(i, i, 4, typeof(byte));
            _perm2D.Activate();

            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, i, i, PixelFormat.Rgba, PixelType.Byte, perm2);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            _permGrad3 = new Texture1D(i, 3, typeof(OpenTK.Half));
            var pg3 = _perm.SelectMany(x => new[]
            {
                (float)_grad3[x % 16, 0],
                (float)_grad3[x % 16, 1],
                (float)_grad3[x % 16, 2],
            }).ToArray();

            _permGrad3.Activate();
            GL.TexSubImage1D(TextureTarget.Texture1D, 0, 0, i, PixelFormat.Rgb, PixelType.Float, pg3);
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture1D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        }

        public new void Dispose()
        {
            _perm2D.Dispose();
            _permGrad3.Dispose();
            base.Dispose();
        }

        [FragmentShader]
        protected vec3 Fade(vec3 t)
        {
            return t * t * t * (t * (t * 6.0f - 15.0f) + 10.0f); // new curve
        }

        [FragmentShader]
        protected vec4 Perm2D(vec2 p)
        {
            return Texture(PermSampler2D, p);
        }

        [FragmentShader]
        protected float GradPerm(float x, vec3 p)
        {
            return Dot(Texture(PermGradSampler, x).xyz, p);
        }

        [FragmentShader]
        protected float Noise(vec3 p)
        {
            var q = Floor(p) % 256.0f;
            p -= Floor(p);
            var f = Fade(p);

            q = q / 256.0f;
            const float one = 1.0f / 256.0f;

            var aa = Perm2D(q.xy) + q.z;
            var zo = new vec2(0.0f, 1.0f);

            return Lerp(Lerp(Lerp(GradPerm(aa.x, p), GradPerm(aa.z, p - zo.yxx), f.x),
                Lerp(GradPerm(aa.y, p - zo.xyx), GradPerm(aa.w, p - zo.yyx), f.x),
                f.y),
                Lerp(Lerp(GradPerm(aa.x + one, p - zo.xxy), GradPerm(aa.z + one, p - zo.yxy), f.x),
                Lerp(GradPerm(aa.y + one, p - zo.xyy), GradPerm(aa.w + one, p - zo.yyy), f.x),
                f.y),
                f.z);
        }

        [FragmentShader]
        public float FBm(vec3 p, int octaves, float lacunarity, float gain)
        {
            var freq = 1.0f;
            var amp = 1.0f;
            var sum = 0.0f;

            for (var i = 0; i < octaves; i++)
            {
                sum += Noise(p * freq) * amp;
                freq *= lacunarity;
                amp *= gain;
            }

            return sum;
        }

        protected SimplexNoiseShader()
        {
            InitTextures();
        }

        public override void Begin()
        {
            base.Begin();
            PermSampler2D = BindTexture(_perm2D).ToSampler();
            PermGradSampler = BindTexture(_permGrad3).ToSampler();
        }
    }
}
