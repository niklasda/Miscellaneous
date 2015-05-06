using System;
using System.Drawing;
using System.IO;
using Microsoft.DirectX;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using Font=System.Drawing.Font;

namespace DirectxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bDoSomething_Click(object sender, EventArgs e)
        {
            AdapterCollection.Enumerator en = new AdapterCollection.Enumerator();

            do
            {
                AdapterDetails ad = en.Current;
                AdapterInformation ai = ad.GetWhqlInformation();
                int level = ai.WhqlLevel;
                Console.WriteLine(ad.Information.Driver);

                Graphics g = pDrawArea.CreateGraphics();
                g.DrawString(ad.Information.Driver + ", " + ad.Information.DeviceName +" "+ level, new Font("Arial", 12), new SolidBrush(Color.Black), 2, 3);
            } while (en.MoveNext());
        }

        private void b3d_Click(object sender, EventArgs e)
        {
            drawSprite();
        }
        
        private Device d;
        private Texture texture;
        private int offset = 1;
        
        public void OnResetDevice(object sender, EventArgs e)
        {
            d = (Device)sender;
        }

        private void pDrawArea_Paint(object sender, PaintEventArgs e)
        {
            drawSprite();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializationEventAttribute();
        }
        
        private void bClear_Click(object sender, EventArgs e)
        {
            clearArea();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            resetDeviceAndTexture();
        }
        
        private void InitializationEventAttribute()
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.IsWindowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.BackBufferFormat = Format.Unknown;
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;
            presentParams.EnableAutoDepthStencil = true;

            // Store the default adapter
            int adapterOrdinal = Manager.Adapters[0].Adapter;
            CreateFlags flags = CreateFlags.SoftwareVertexProcessing;

            // Check to see if we can use a pure hardware device
            Capabilities caps = Manager.GetDeviceCapabilities(adapterOrdinal, DeviceType.Hardware);

            // Do we support hardware vertex processing?
            if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
            {
                // Replace the software vertex processing
                flags = CreateFlags.HardwareVertexProcessing;
            }

            // Do we support a pure device?
            if (caps.DeviceCaps.SupportsPureDevice)
            {
                flags |= CreateFlags.PureDevice;
            }
            
            d = new Device(0, DeviceType.Hardware, pDrawArea.Handle, flags, presentParams);
            d.DeviceReset += new System.EventHandler(this.OnResetDevice);
        }
        
        private void drawSprite()
        {
            if (texture == null)
            {
                FileInfo fi = new FileInfo(@"..\..\robot_1.jpg");
                texture = new Texture(d, fi.OpenRead());
            }
            
            d.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Blue, 1.0f, 0);
            d.BeginScene();
            using (Sprite sprite = new Sprite(d))
            {
                sprite.Begin(SpriteFlags.AlphaBlend);

                Vector3? vecCent = new Vector3(0F, 0F, 1F);
                Vector3? vec2 = new Vector3(10F + offset++, 10F + offset++, 1F);

                Rectangle? rect = new Rectangle(1, 1, 50, 50);

                sprite.Draw(texture, rect, vecCent, vec2, Color.Yellow);
                sprite.End();
            }
            d.EndScene();
            d.Present();
            this.Invalidate();
        }

        private void clearArea()
        {
            d.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Green, 1.0f, 0);
            d.Present();
        }

        // must recreate device to prevent resizeing texture
        // must then recreate texture since the device is new
        private void resetDeviceAndTexture()
        {
            InitializationEventAttribute();
            texture = null;
        }

        private void pDrawArea_Resize(object sender, EventArgs e)
        {
            resetDeviceAndTexture();
        }
    }
}