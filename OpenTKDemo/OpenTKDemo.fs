module OpenTKDemo

open OpenTK
open OpenTK.Graphics
open OpenTK.Graphics.OpenGL

type OpenTKExample() =
    inherit GameWindow(800, 600, GraphicsMode.Default, "Hello OpenTK!")

    override this.Dispose(disposing) =
        base.Dispose(disposing)

    override this.OnLoad e =
        base.OnLoad(e)
        GL.ClearColor(Color4.DarkBlue)

    override this.OnResize e =
        base.OnResize(e)
        // use all the whole area to paint
        GL.Viewport(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()
        GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0)

    override this.OnRenderFrame e =
        base.OnRenderFrame(e)

        GL.Clear(ClearBufferMask.ColorBufferBit)

        GL.Begin(BeginMode.Triangles)

        GL.Color4(Color4.Beige)
        GL.Vertex2(-1.0f, -1.0f)
        GL.Color4(Color4.DarkRed)
        GL.Vertex2(1.0f, -1.0f)
        GL.Color4(Color4.SpringGreen)
        GL.Vertex2(0.0f, 1.0f)

        GL.End()

        this.SwapBuffers()

let runSim() =
    use window = new OpenTKExample()
    window.Run()