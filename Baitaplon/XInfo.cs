using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaplon
{
    public class XInfo
    {
        #region Khởi tạo

        public XInfo(string path)
        {
            Picture = XImage.LoadImagebyExt(path);
            Name = XPath.GetFileNameWithoutExtension(path);
            this.Path = path;
        }
        public XInfo(Image picture, string name, string path)
        {
            Picture = picture;
            Name = name;
            Path = path;
        }
        #endregion
        #region Thuộc tính

        public Image Picture;
        public string Name;
        public string Path;
        #endregion
        #region Phương thức

        // TRả về đường dẫn của file
        public override string ToString()
        {
            return Path;
        }
        //Trả về dữ liệu để in
        public string TextData()
        {
            return Name + '\n' + "Path: " + Path;
        }

        // Draw the info's information in the rectangle.
        public void DrawItem(Graphics gr, Rectangle bounds, Font font, bool showPathOnly)
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
                if (showPathOnly)
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
        #endregion

    }
}
