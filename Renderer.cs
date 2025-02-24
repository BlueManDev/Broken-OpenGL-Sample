using System.Diagnostics;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;


namespace GameThing.Graphics;

public class Renderer
{
    public static GL GL { get; private set; }

    private static string[] GLErrorDescription =
    {
        "GL_INVALID_ENUM",						// 0x0500
        "GL_INVALID_VALUE",						// 0x0501
        "GL_INVALID_OPERATION",					// 0x0502
        "GL_STACK_OVERFLOW",					// 0x0503
        "GL_STACK_UNDERFLOW",					// 0x0504
        "GL_OUT_OF_MEMORY",						// 0x0505
        "GL_INVALID_FRAMEBUFFER_OPERATION" 		// 0x0506
    };

    public static void Init(IWindow window)
    {
        GL = window.CreateOpenGL();
        
        GL.ClearColor(0.0f, 0.0f, 1.0f, 1f);
        
        Renderer.CheckOpenGLError();
    }

    public static void Begin()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        Renderer.CheckOpenGLError();
    }

    public static void Render(Drawable drawable)
    {
        GL.BindVertexArray(drawable.Vao);
        
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, drawable.Vbo[0]);
        GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, drawable.Vbo[1]);
        
        GL.EnableVertexAttribArray(0);
        GL.DrawElements(PrimitiveType.Triangles, 3, DrawElementsType.UnsignedShort,
            IntPtr.Zero);
        GL.DisableVertexAttribArray(0);

        GL.BindVertexArray(0);
        
        Renderer.CheckOpenGLError();
    }

    public static void CheckOpenGLError()
    {
        GLEnum glErr = GL.GetError();
        if (glErr != GLEnum.NoError)
        {
            Console.WriteLine("[OpenGL Error]");
            Console.WriteLine($"[{glErr}] : {GLErrorDescription[(int)glErr - (int)GLEnum.InvalidEnum]}");
            
            StackFrame frame = new StackTrace(true).GetFrame(1);
            string file = frame.GetFileName();
            int line = frame.GetFileLineNumber();

            Console.WriteLine($"\t[File] : {file}\t[Line] : {line}");
        }
    }
}