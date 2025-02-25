using GameThing.Graphics;

using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;


namespace GameThing;

public class Program
{
    private static IWindow _window;

    private static Drawable _drawable;
    
    public static void Main(string[] args)
    {
        WindowOptions options = WindowOptions.Default with
        {
            Size = new Vector2D<int>(1024, 768),
            Title = "OpenGL"
        };
        
        _window = Window.Create(options);
        _window.Load += Init;
        _window.Update += Update;
        _window.Render += Render;
        _window.FramebufferResize += Resize;
        
        _window.Run();
    }

    private static unsafe void Init()
    {
        Renderer.Init(_window);
        
        Renderer.GL.ClearColor(0.0f, 0.0f, 1.0f, 1f);

        float[] positions =
        {
            +0.5f, +0.5f, 0.0f,
            +0.5f, -0.5f, 0.0f,
            -0.5f, -0.5f, 0.0f,
            -0.5f, +0.5f, 0.0f
        };

        ushort[] indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        _drawable = ContentMgr.Load(positions, indices);
    }

    private static void Update(double deltaTime)
    {
    }

    private static unsafe void Render(double deltaTime)
    {
        Renderer.Begin();
        Renderer.Render(_drawable);
    }

    private static void Resize(Vector2D<int> size)
    {
        Renderer.GL.Viewport(size);
    }
}
