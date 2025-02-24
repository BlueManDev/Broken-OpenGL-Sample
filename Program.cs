using GameThing.Graphics;

using Silk.NET.Maths;
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
            Size = new Vector2D<int>(1280, 720),
            Title = "OpenGL"
        };
        
        _window = Window.Create(options);
        _window.Load += Init;
        _window.Update += Update;
        _window.Render += Render;
        
        _window.Run();
    }

    private static void Init()
    {
        Renderer.Init(_window);

        float[] vertices =
        [
            -0.5f, -0.5f, 0.0f,
            +0.5f, -0.5f, 0.0f,
            -0.5f, +0.5f, 0.0f
        ];

        ushort[] indices =
        [
            0, 1, 2
        ];
        
        _drawable = ContentMgr.Load(vertices, indices);
    }

    private static void Update(double deltaTime)
    {
    }

    private static void Render(double deltaTime)
    {
        Renderer.Begin();
        
        Renderer.Render(_drawable);
    }
}