using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaplon
{
    class XTextInfo
    {
        public Image Picture;
        string name;
        string path;
        string lineresult;
        public XTextInfo(Image Picture, string name, string path, string lineresult)
        {
            this.Picture = Picture;
            this.name = name;
            this.path = path;
            this.lineresult = lineresult;
        }
        // trả về đường dẫn
        public override string ToString()
        {
            return path;
        }

        // Dữ liệu để in
        public string TextData()
        {
            return string.Format("{0}\nPath: {1}\nResult: {2}", name, path, lineresult);
        }
        // Draw the info's information in the rectangle.
        public void DrawItem(Graphics gr, Rectangle bounds, Font font, bool showNameOnly)
        {
            // Calculate a reasonable margin.
            int margin = (int)(bounds.Height * 0.05);
            int height = bounds.Height - 2 * margin;

            // Draw the picture.
            Rectangle srcRect = new Rectangle(0, 0,
                Picture.Width, Picture.Height);
            Rectangle destRect = new Rectangle(
                bounds.Left + margin, bounds.Top + margin,
                height, height);
            gr.DrawImage(Picture, destRect, srcRect,
                GraphicsUnit.Pixel);

            // Draw the name, path
            int textLeft = destRect.Right + margin;
            int width = bounds.Width - textLeft;
            Rectangle layoutRect = new Rectangle(
                textLeft, bounds.Top,
                width, bounds.Height);
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.LineAlignment = StringAlignment.Center;
                if (showNameOnly)
                {
                    gr.DrawString(ToString(), font, Brushes.Black,
                        layoutRect, stringFormat);
                }
                else
                {
                    gr.DrawString(TextData(), font, Brushes.Black,
                        layoutRect, stringFormat);
                }
            }
        }
    }
}
