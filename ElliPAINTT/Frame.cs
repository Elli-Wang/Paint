namespace ElliPAINTT
{
    public partial class ElliPaintForm
    {
        class Frame
        {
            public Bitmap FrameImage;
            public Graphics Gfx;
            public List<PictureBox> PictureBoxesToUpdate;
            public PictureBox PreviewBox;

            public Frame(Bitmap bitmap)
            {
                FrameImage = bitmap;
                Gfx = Graphics.FromImage(bitmap);
                PictureBoxesToUpdate = new List<PictureBox>();
            }

            public void UpdatePictureBoxes()
            {
                for(int i = 0; i < PictureBoxesToUpdate.Count; i++)
                {
                    PictureBoxesToUpdate[i].Image = FrameImage;
                }
            }
        }
    }
}

