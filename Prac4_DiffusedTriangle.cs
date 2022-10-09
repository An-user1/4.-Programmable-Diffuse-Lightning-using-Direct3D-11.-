//
//DiffusedTriangle


using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX; 
using Microsoft.DirectX.Direct3D; 


namespace DiffusedTriangle
{
    public partial class Form1 : Form
    {
        Microsoft.DirectX.Direct3D.Device device;
        private CustomVertex.PositionNormalColored[] vertexes = new CustomVertex.PositionNormalColored[3];
        public Form1()
        {
            InitializeComponent();
            InitDevice();
        }
        public void InitDevice() 
        {
            PresentParameters pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            device = new Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, pp);

            device.Transform.Projection = Matrix.PerspectiveFovLH(3.14f / 4, device.Viewport.Width / device.Viewport.Height, 1f, 100f);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, 10), new Vector3(), new Vector3(0, 1, 0));


            
            device.RenderState.Lighting = true; 
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = Color.LightSkyBlue; 
            device.Lights[0].Direction = new Vector3(0.8f, 0, -1); 
            device.Lights[0].Enabled = true;

        

            vertexes[0] = new CustomVertex.PositionNormalColored(new Vector3(0, 1, 1), new Vector3(1, 0, 1), Color.White.ToArgb());
            vertexes[1] = new CustomVertex.PositionNormalColored(new Vector3(-1, -1, 1), new Vector3(1, 0, 1), Color.LightBlue.ToArgb()); 
            vertexes[2] = new CustomVertex.PositionNormalColored(new Vector3(1, -1, 1), new Vector3(-1, 0, 1), Color.White.ToArgb());



           
        }
        private void Form1_Load(object sender, EventArgs e){}
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            device.Clear(ClearFlags.Target, Color.White, 1.0f, 0);
            device.BeginScene();
            device.VertexFormat = CustomVertex.PositionNormalColored.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleList, vertexes.Length / 3, vertexes);
            device.EndScene();
            device.Present();

        }
    }
}

        