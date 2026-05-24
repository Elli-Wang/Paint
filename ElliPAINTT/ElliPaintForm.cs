using System.Drawing.Imaging;
using System.Globalization;
using System.IO.Ports;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElliPAINTT
{
    public partial class ElliPaintForm : Form
    {
        const int ImageWidth = 430;
        const int ImageHeight = 398;

        enum Shapes
        {
            Circle,
            Square,
            Triangle,
            Custom,
            Eraser
        }

        public ElliPaintForm()
        {
            InitializeComponent();
        }

        Image smallImage;
        Graphics smallGfx;

        Image testImage;
        Graphics testGfx;

        Shapes shape;

        Brush newBrush;

        bool isPressed = false;

        bool somethingToSend = false;

        List<byte> pixelRGB = new List<byte>();

        SerialPort port = new SerialPort("COM3", 115200);



        int ___currentFrameIndexDoNotTouchManually = 0;
        int CurrentFrameIndex // property that uses ___currentFrameIndexDoNotTouchManually but also sets Canvas.Image
        {
            get => ___currentFrameIndexDoNotTouchManually;
            set
            {
                CurrentFrame.PictureBoxesToUpdate.Remove(Canvas);

                ___currentFrameIndexDoNotTouchManually = value;
                Canvas.Image = CurrentFrame.FrameImage;

                CurrentFrame.PictureBoxesToUpdate.Add(Canvas);
            }
        }
        Frame CurrentFrame => frames[CurrentFrameIndex];

        // Property above ^^^ is equivalent to the functions below
        //int GetCurrentFrameIndex() => ___currentFrameIndexDoNotTouchManually;
        //void SetCurrentFrameIndex(int value)
        //{
        //    ___currentFrameIndexDoNotTouchManually = value;
        //    Canvas.Image = CurrentFrame.FrameImage;
        //}

        List<Frame> frames = new List<Frame>();


        private void ElliPaintForm_Load(object sender, EventArgs e)
        {

            Bitmap bitmap1 = new Bitmap(ImageWidth, ImageHeight);

            AddFrame(bitmap1);

            Canvas.Image = frames[0].FrameImage;
            frames[0].PictureBoxesToUpdate.Add(Canvas);
            Canvas.SizeMode = PictureBoxSizeMode.Normal;
            Canvas.BorderStyle = BorderStyle.FixedSingle;

            //customStamp = image;
            newBrush = Brushes.Black;


            ledDisplay.Image = new Bitmap(ledDisplay.Width, ledDisplay.Height);
            ledDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            ledDisplay.BorderStyle = BorderStyle.FixedSingle;

            smallImage = ledDisplay.Image;
            smallGfx = Graphics.FromImage(smallImage);


            testPictureBox.Image = new Bitmap(testPictureBox.Width, testPictureBox.Height);
            testPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            testPictureBox.BorderStyle = BorderStyle.FixedSingle;

            testImage = testPictureBox.Image;
            testGfx = Graphics.FromImage(testImage);

            port.DataReceived += HandleArduinoMessage;

            try
            {
                port.Open();
            }
            catch
            {
                MessageBox.Show("Yo COM3 cannot be opened. Check if existing programs are using it.");
                //return;
            }

            //getting a color of a pixel
            /*
             *image is off Image type which does not contain GetPixel so we cast to Bitmap to use GetPixel function
             *
            Bitmap imageBitmap = (Bitmap)image;

            Color pixelColor = imageBitmap.GetPixel(0, 0);
            */
        }

        private void AddFrame(Bitmap bitmap)
        {
            Frame frame = new Frame(bitmap);

            frames.Add(frame);
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Width = 60;
            pictureBox.Height = 60;
            pictureBox.Image = frame.FrameImage;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            framesPanel.Controls.Add(pictureBox);

            frame.PictureBoxesToUpdate.Add(pictureBox);

            updateFrameDetails();
        }
        //custom class to track frames

        private void CircleBrush_Click(object sender, EventArgs e)
        {
            shape = Shapes.Circle;
        }

        private void SquareBrush_Click(object sender, EventArgs e)
        {
            shape = Shapes.Square;
        }

        private void TriangleBrush_Click(object sender, EventArgs e)
        {
            shape = Shapes.Triangle;
        }

        private void makeCustomButton_Click(object sender, EventArgs e)
        {
            shape = Shapes.Custom;
        }
        private void EraserBrush_Click(object sender, EventArgs e)
        {
            shape = Shapes.Eraser;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color color = colorDialog1.Color;
            newBrush = new SolidBrush(color);
        }

        void Draw(MouseEventArgs e)
        {
            //gfx.DrawLine(new Pen(newBrush, BrushWidth.Value), Point.Empty, new Point(image.Width, image.Height));

            switch (shape)
            {
                case Shapes.Circle:
                    frames[CurrentFrameIndex].Gfx.FillEllipse(newBrush, new Rectangle(e.Location.X - BrushWidth.Value / 2, e.Location.Y - BrushHeight.Value / 2, BrushWidth.Value, BrushHeight.Value));
                    break;

                case Shapes.Square:
                    frames[CurrentFrameIndex].Gfx.FillRectangle(newBrush, new Rectangle(e.Location.X - BrushWidth.Value / 2, e.Location.Y - BrushHeight.Value / 2, BrushWidth.Value, BrushHeight.Value));
                    break;

                case Shapes.Triangle:
                    frames[CurrentFrameIndex].Gfx.FillPolygon(newBrush, new Point[] {
                        new Point(e.Location.X, e.Location.Y - (BrushHeight.Value / 2)),
                        new Point(e.Location.X - (BrushWidth.Value / 2), e.Location.Y + (BrushHeight.Value / 2)),
                        new Point(e.Location.X + (BrushWidth.Value / 2), e.Location.Y + (BrushHeight.Value / 2))
                    });

                    break;
                //case Shapes.Custom:
                //    frames[CurrentFrameIndex].Gfx.DrawImage(customStamp, new Rectangle(e.Location.X - BrushWidth.Value / 2, e.Location.Y - BrushHeight.Value / 2, BrushWidth.Value, BrushHeight.Value));
                //    break;
                case Shapes.Eraser:
                    frames[CurrentFrameIndex].Gfx.FillEllipse(new SolidBrush(this.BackColor), new Rectangle(e.Location.X - BrushWidth.Value / 2, e.Location.Y - BrushHeight.Value / 2, BrushWidth.Value, BrushHeight.Value));
                    break;

            }

            frames[CurrentFrameIndex].UpdatePictureBoxes();
            //Canvas.Image = image;
        }

        private void BrushWidth_Scroll(object sender, EventArgs e)
        {
            TrackBar selectedTrackBar = (TrackBar)sender;

            if (ScrollSizeButton.Checked)
            {
                if (selectedTrackBar == BrushWidth)
                {
                    BrushHeight.Value = BrushWidth.Value;
                }
                else if (selectedTrackBar == BrushHeight)
                {
                    BrushWidth.Value = BrushHeight.Value;
                }
            }
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            frames[CurrentFrameIndex].Gfx.Clear(Color.Transparent);

            Canvas.Image = frames[CurrentFrameIndex].FrameImage;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            Draw(e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed == true)
            {
                Draw(e);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            RenameFilePanel.Visible = true;
        }
        private void SaveConfirmButton_Click(object sender, EventArgs e)
        {
            RenameFilePanel.Visible = false;
            frames[CurrentFrameIndex].FrameImage.Save($"{textBox1.Text}.png", ImageFormat.Png);

            //Stamp myStamp = new Stamp(image, textBox1.Text);
            //myStamp.Name = textBox1.Text;
            //myStamp.Image = (Image)image.Clone();

            //comboBox1.Items.Add(myStamp);
        }

        private void LoadPreviousButton_Click(object sender, EventArgs e)
        {
            // make sure savedImage exists
            openFileDialog1.ShowDialog();

            string filePath = openFileDialog1.FileName;
            try
            {
                frames[CurrentFrameIndex].FrameImage = new Bitmap(Image.FromFile(filePath));
                frames[CurrentFrameIndex].Gfx = Graphics.FromImage(frames[CurrentFrameIndex].FrameImage);
                Canvas.Image = frames[CurrentFrameIndex].FrameImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a valid File");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox combobox = (ComboBox)sender;
            //object? stampAsObject = combobox.Items[combobox.SelectedIndex];
            //if (stampAsObject is Stamp stamp)
            //{
            //    customStamp = stamp.Image;
            //}

        }

        private Color GetAvgColor(Image image, int startX, int startY, int width, int height)
        {
            Bitmap imageBitmap = (Bitmap)image;

            int redSum = 0;

            int greenSum = 0;

            int blueSum = 0;

            for (int x = startX; x < (startX + width); x++)
            {
                for (int y = startY; y < (startY + height); y++)
                {
                    Color pixelColor = imageBitmap.GetPixel(x, y);

                    redSum += pixelColor.R;
                    greenSum += pixelColor.G;
                    blueSum += pixelColor.B;
                }

            }

            int avgRed = redSum / (width * height);
            int avgGreen = greenSum / (width * height);
            int avgBlue = blueSum / (width * height);

            Color avgColor = Color.FromArgb(avgRed, avgGreen, avgBlue);

            return avgColor;
        }



        public List<byte> AvgImgColor(int colAmount, int rowAmount)
        {
            List<byte> pixelRGBs = new List<byte>();

            int sectionWidth = frames[CurrentFrameIndex].FrameImage.Width / colAmount;
            int sectionHeight = frames[CurrentFrameIndex].FrameImage.Height / rowAmount;

            smallImage = new Bitmap(colAmount * 10, rowAmount * 10);
            smallGfx = Graphics.FromImage(smallImage);

            //float smallWidth = (sectionWidth / (float)image.Width) * smallImage.Width;
            //float smallHeight = (sectionHeight / (float)image.Height) * smallImage.Height;

            pixelRGBs.Add((byte)colAmount);
            pixelRGBs.Add((byte)rowAmount);

            for (int x = 0; x < colAmount; x++) //loop through the whole image 
            {
                for (int y = 0; y < rowAmount; y++)
                {
                    Color avgColor = GetAvgColor(frames[CurrentFrameIndex].FrameImage, x * sectionWidth, y * sectionHeight, sectionWidth, sectionHeight);

                    pixelRGBs.Add(avgColor.R);
                    pixelRGBs.Add(avgColor.G);
                    pixelRGBs.Add(avgColor.B);

                    //smallGfx.FillRectangle(new SolidBrush(avgColor), new Rectangle(x * (int)smallWidth, y * (int)smallHeight, (int)smallWidth, (int)smallHeight));
                    smallGfx.FillRectangle(new SolidBrush(avgColor), new Rectangle(x * 10, y * 10, 10, 10));
                }

            }

            ledDisplay.Image = smallImage;

            return pixelRGBs;
        }


        private void scaleDown_Click(object sender, EventArgs e)
        {
            smallGfx.Clear(Color.Transparent);

            bool widthSucceded = int.TryParse(widthEntered.Text, out int scaledWidth);
            bool heightSucceded = int.TryParse(heightEntered.Text, out int scaledHeight);

            if (widthSucceded == false || heightSucceded == false)
            {
                //failed
                MessageBox.Show("Invalid parameters");
            }
            else
            {
                pixelRGB = AvgImgColor(scaledWidth, scaledHeight);
                ledDisplay.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }



        private async void sendToMatrix_Click(object sender, EventArgs e)
        {
            //File.WriteAllBytes("output.bin", pixelRGB.ToArray());
            ;

            // Show preview in WinForms
            testGfx.Clear(BackColor);

            float testSmallWidth = (testImage.Width / pixelRGB[0]);
            float testSmallHeight = (testImage.Height / pixelRGB[1]);

            int i = 2;
            for (int x = 0; x < pixelRGB[0]; x++)
            {
                for (int y = 0; y < pixelRGB[1]; y++)
                {
                    Color customColor = Color.FromArgb(pixelRGB[i + 0], pixelRGB[i + 1], pixelRGB[i + 2]);
                    i += 3;

                    testGfx.FillRectangle(new SolidBrush(customColor), new Rectangle(x * (int)testSmallWidth, y * (int)testSmallHeight, (int)testSmallWidth, (int)testSmallHeight));
                }
            }

            // Send to Arduino
            //string myColorValues = "";

            //for (int index = 2; index < pixelRGB.Count; index++)
            //{
            //    myColorValues += $"{pixelRGB[index].ToString()},";
            //}

            //port.Write([42], 0, 1);

            somethingToSend = true;
        }

        const int askCode = 42;
        const int readyCode = 8;

        async void HandleArduinoMessage(object sender, EventArgs e)
        {
            // validate message
            int response = port.ReadByte();

            if (response == askCode)
            {
                //port.Open();

                if (somethingToSend == true)
                {
                    port.Write([1], 0, 1);
                }
                else
                {
                    port.Write([0], 0, 1);
                }
            }
            else if (response == readyCode)
            {
                //sendProgressBar.Minimum = 0;
                //sendProgressBar.Maximum = pixelRGB.Count;
                //sendProgressBar.Step = 1;
                //sendProgressBar.Value = 0;

                for (int index = 0; index < pixelRGB.Count; index++)
                {
                    byte byteToSend = pixelRGB[index];
                    port.Write([byteToSend], 0, 1);
                    //sendProgressBar.Value++;
                    await Task.Yield();
                }
                somethingToSend = false;
            }



            //port.Close();
        }

        private void animateOptions_Click(object sender, EventArgs e)
        {
            animatePanel.Visible = true;
        }

        private void addFrame_Click(object sender, EventArgs e)
        {
            AddFrame(new Bitmap(ImageWidth, ImageHeight));

            if (CurrentFrameIndex < frames.Count - 1)
            {
                CurrentFrameIndex++;
                updateFrameDetails();
            }
        }

        private void nextFrame_Click(object sender, EventArgs e)
        {
            if(CurrentFrameIndex < frames.Count-1)
            {
                CurrentFrameIndex++;
                updateFrameDetails();
            }
        }

        private void previousFrame_Click(object sender, EventArgs e)
        {
            if(CurrentFrameIndex > 0)
            {
                CurrentFrameIndex--;
                updateFrameDetails();
            }
        }

        void updateFrameDetails()
        {
            frameCounter.Text = $"{CurrentFrameIndex + 1}/{frames.Count}";

            // updating the border style of the current picture box frame 
            :)
        }


    }
}

