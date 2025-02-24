namespace GameThing.Graphics;

public class Drawable
{
    public uint[] Vbo { get; }
    public uint Vao { get; private set; }
    
    public ushort Count { get; private set; }

    public Drawable(ushort count)
    {
        Count = count;
        
        Vbo = new uint[2];
    }
    
    public void Create()
    {
        Vao = Renderer.GL.GenVertexArray();
        Renderer.GL.BindVertexArray(Vao);
        
        Vbo[0] = Renderer.GL.GenBuffer();
        Vbo[1] = Renderer.GL.GenBuffer();
        
        Renderer.CheckOpenGLError();
    }
}