using Silk.NET.OpenGL;


namespace GameThing.Graphics;

public class Drawable
{
    public uint VertexArray;

    public uint PositionBuffer;
    public uint IndexBuffer;

    public readonly ushort VertexCount;
    public readonly DrawElementsType IndexType;

    public Drawable(ushort vertexCount, DrawElementsType indexType)
    {
        VertexCount = vertexCount;
        IndexType = indexType;
        
        VertexArray = Renderer.GL.GenVertexArray();
        Renderer.GL.BindVertexArray(VertexArray);
        
        PositionBuffer = Renderer.GL.GenBuffer();
        IndexBuffer = Renderer.GL.GenBuffer();
        
        Renderer.CheckOpenGLError();
    }
}
