using Silk.NET.Maths;
using Silk.NET.OpenGL;


namespace GameThing.Graphics;

public class ContentMgr
{
    public static Drawable Load(float[] positions, ushort[] indices)
    {
        Drawable drawable = new Drawable((ushort)indices.Length);
        drawable.Create();
        
        UploadData(drawable.Vbo[0], (ushort)(positions.Length * sizeof(float)),
            0, positions);
        UploadData(drawable.Vbo[1], (ushort)(indices.Length * sizeof(ushort)), indices);
        Renderer.GL.BindVertexArray(0);
        
        return drawable;
    }
    
    public static Drawable Load(float[] positions, uint[] indices)
    {
        Drawable drawable = new Drawable((ushort)indices.Length);
        drawable.Create();
        
        UploadData(drawable.Vbo[0], (ushort)(positions.Length * sizeof(float)),
            0, positions);
        UploadData(drawable.Vbo[1], (ushort)(indices.Length * sizeof(uint)), indices);
        Renderer.GL.BindVertexArray(0);
        
        return drawable;
    }

    private static unsafe void UploadData(uint buffer, ushort size, uint location,
        float[] data)
    {
        Renderer.GL.BindBuffer(BufferTargetARB.ArrayBuffer, buffer);
        Renderer.GL.BufferData(BufferTargetARB.ArrayBuffer, size,
            ConvertToBuffer(data), BufferUsageARB.StaticDraw);
        
        Renderer.GL.EnableVertexAttribArray(location);
        Renderer.GL.VertexAttribPointer(location, 3, VertexAttribPointerType.Float,
            false, 0, 0);
        
        Renderer.GL.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
        
        Renderer.CheckOpenGLError();
    }

    private static unsafe void UploadData(uint buffer, ushort size, ushort[] data)
    {
        Renderer.GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, buffer);
        Renderer.GL.BufferData(BufferTargetARB.ElementArrayBuffer, size,
            ConvertToBuffer(data), BufferUsageARB.StaticDraw);
        
        Renderer.GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);
        
        Renderer.CheckOpenGLError();
    }
    
    private static unsafe void UploadData(uint buffer, ushort size, uint[] data)
    {
        Renderer.GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, buffer);
        Renderer.GL.BufferData(BufferTargetARB.ElementArrayBuffer, size,
            ConvertToBuffer(data), BufferUsageARB.StaticDraw);
        
        Renderer.GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, 0);
        
        Renderer.CheckOpenGLError();
    }

    private static unsafe void* ConvertToBuffer(float[] data)
    {
        fixed (void* buf = &data[0])
        {
            return buf;
        }
    }

    private static unsafe void* ConvertToBuffer(ushort[] data)
    {
        fixed (void* buf = &data[0])
        {
            return buf;
        }
    }
    
    private static unsafe void* ConvertToBuffer(uint[] data)
    {
        fixed (void* buf = &data[0])
        {
            return buf;
        }
    }
}