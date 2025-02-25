using Silk.NET.OpenGL;


namespace GameThing.Graphics;

public class ContentMgr
{
    public static Drawable Load(float[] positions, ushort[] indices)
    {
        Drawable drawable = new Drawable((ushort)indices.Length, DrawElementsType.UnsignedShort);
        
        UploadData(drawable.PositionBuffer, positions, 0);
        UploadData(drawable.IndexBuffer, indices);

        return drawable;
    }

    private static unsafe void UploadData(uint buffer, float[] data, uint location)
    {
        Renderer.GL.BindBuffer(BufferTargetARB.ArrayBuffer, buffer);
        fixed (void* buf = &data[0])
        {
            Renderer.GL.BufferData(BufferTargetARB.ArrayBuffer, (nuint) (data.Length * sizeof(float)),
                buf, BufferUsageARB.StaticDraw);
        }
        
        Renderer.GL.VertexAttribPointer(location, 3, VertexAttribPointerType.Float,
            false, 0, null);
        Renderer.GL.EnableVertexAttribArray(location);
    }

    private static unsafe void UploadData(uint buffer, ushort[] data)
    {
        Renderer.GL.BindBuffer(BufferTargetARB.ElementArrayBuffer, buffer);
        fixed (void* buf = &data[0])
        {
            Renderer.GL.BufferData(BufferTargetARB.ElementArrayBuffer,
                (nuint) (data.Length * sizeof(ushort)), buf, BufferUsageARB.StaticDraw);
        }
    }
}
