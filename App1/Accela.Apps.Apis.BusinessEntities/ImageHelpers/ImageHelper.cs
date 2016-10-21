using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Accela.Apps.Apis.BusinessEntities.ImageHelpers
{
    public class ImageHelper
    {

        /// <summary>
        /// Converts to thumbnail base64 string.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileBase64String">The file base64 string.</param>
        /// <param name="pixelWidth">Width of the pixel.</param>
        /// <param name="pixelHeight">Height of the pixel.</param>
        /// <returns>
        /// the thumbnail base64 string.
        /// </returns>
        public static string ConvertToThumbnailBase64String(string fileName, string fileBase64String, int pixelWidth, int pixelHeight)
        {
            string result = null;
            Stream resultStream = null;
            Stream originalStream = null;
            var bytes = !String.IsNullOrEmpty(fileBase64String) ? Convert.FromBase64String(fileBase64String) : null;
            var imageFormat = ImageHelper.GetImageFormat(Path.GetExtension(fileName));
            ImageHelper.GetThumbnail(ref pixelWidth, ref pixelHeight, ref resultStream, ref originalStream, bytes, imageFormat);
            result = StreamHelper.GetFileBase64String(resultStream);
            return result;
        }

        /// <summary>
        /// Gets the image format.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>the image format.</returns>
        private static ImageFormat GetImageFormat(string fileExtension)
        {
            ImageFormat result = null;

            if (String.IsNullOrEmpty(fileExtension)) return null;

            switch (fileExtension.ToLowerInvariant())
            {
                case ".bmp":
                    result = ImageFormat.Bmp;
                    break;
                case ".gif":
                    result = ImageFormat.Gif;
                    break;
                case ".icn":
                    result = ImageFormat.Icon;
                    break;
                case ".jpg":
                    result = ImageFormat.Jpeg;
                    break;
                case ".png":
                    result = ImageFormat.Png;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Get image thumbnail.
        /// </summary>
        /// <param name="pixelWidth">Pixel Width.</param>
        /// <param name="pixelHeight">Pixel Height.</param>
        /// <param name="result">Result.</param>
        /// <param name="originalStream">Original stream.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="imageFormat">Image format.</param>
        private static void GetThumbnail(ref int pixelWidth, ref int pixelHeight, ref Stream result, ref Stream originalStream, byte[] bytes, ImageFormat imageFormat)
        {
            if (bytes == null || imageFormat == null) return;

            originalStream = new MemoryStream(bytes);
            var originalImage = Image.FromStream(originalStream);
            var widthHeightRatio = (double)originalImage.Width / (double)originalImage.Height;
            pixelWidth = pixelWidth == 0 ? 70 : pixelWidth;
            pixelWidth = pixelWidth >= originalImage.Width ? originalImage.Width : pixelWidth;
            pixelWidth = widthHeightRatio > 1 ? pixelWidth : (int)Math.Round(pixelWidth * widthHeightRatio);
            pixelHeight = pixelHeight == 0 ? 53 : pixelHeight;
            pixelHeight = pixelHeight >= originalImage.Height ? originalImage.Height : pixelHeight;
            pixelHeight = widthHeightRatio > 1 ? (int)Math.Round(pixelHeight / widthHeightRatio) : pixelHeight;

            if (originalImage.Width <= pixelWidth && originalImage.Height <= pixelHeight)
            {
                result = originalStream;
            }
            else if (pixelWidth > 120 || pixelHeight > 120)
            {
                var thumbnailBitmap = new Bitmap(pixelWidth, pixelHeight);
                var graphics = Graphics.FromImage(thumbnailBitmap);

                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var imageRectangle = new Rectangle(0, 0, pixelWidth, pixelHeight);
                graphics.DrawImage(originalImage, imageRectangle);

                result = new MemoryStream();
                thumbnailBitmap.Save(result, imageFormat);

                graphics.Dispose();
                thumbnailBitmap.Dispose();
            }
            else
            {
                var newimage = originalImage.GetThumbnailImage(pixelWidth, pixelHeight, () => { return false; }, IntPtr.Zero);
                result = new MemoryStream();
                newimage.Save(result, imageFormat);
            }

            originalImage.Dispose();
            result.Position = 0;
        }

        public static Stream ConvertToThumbnail(Stream content, string contentType, int pixelWidth, int pixelHeight)
        {
            if (!IsSupportContentType(contentType)) return null;

            var imageFormat = GetImageFormatFromContentType(contentType);

            var image = Image.FromStream(content);

            var ratio = (double)image.Width / image.Height;

            pixelWidth = pixelWidth == 0 ? 70 : pixelWidth;
            pixelWidth = pixelWidth >= image.Width ? image.Width : pixelWidth;
            pixelWidth = ratio > 1 ? pixelWidth : (int)Math.Round(pixelWidth * ratio);

            pixelHeight = pixelHeight == 0 ? 53 : pixelHeight;
            pixelHeight = pixelHeight >= image.Height ? image.Height : pixelHeight;
            pixelHeight = ratio > 1 ? (int)Math.Round(pixelHeight / ratio) : pixelHeight;

            if (image.Width <= pixelWidth && image.Height <= pixelHeight)
            {
                return content;
            }

            Image thumbnail = null;
            var result = new MemoryStream();

            /*
             * From MSDN Image.GetThumbnailImage Method:
             * The GetThumbnailImage method works well when the requested thumbnail image has a size of about 120 x 120 pixels. 
             * If you request a large thumbnail image (for example, 300 x 300) from an Image that has an embedded thumbnail, 
             * there could be a noticeable loss of quality in the thumbnail image. 
             * It might be better to scale the main image (instead of scaling the embedded thumbnail) by calling the DrawImage method.
             * 
            //*/
            if (pixelWidth > 120 || pixelHeight > 120)
            {
                thumbnail = new Bitmap(pixelWidth, pixelHeight);
                var graphics = Graphics.FromImage(thumbnail);

                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var rectangle = new Rectangle(0, 0, pixelWidth, pixelHeight);

                graphics.DrawImage(image, rectangle);
            }
            else
            {
                thumbnail = image.GetThumbnailImage(pixelWidth, pixelHeight, () => false, IntPtr.Zero);
            }

            thumbnail.Save(result, imageFormat);
            return result;
        }

        private static ImageFormat GetImageFormatFromContentType(string contentType)
        {
            return KnownImageFormat[contentType];
        }

        public static bool IsSupportContentType(string contentType)
        {
            return !String.IsNullOrEmpty(contentType) && KnownImageFormat.ContainsKey(contentType);
        }

        private static readonly Dictionary<string, ImageFormat> KnownImageFormat = new Dictionary<string, ImageFormat>
        {
            {"image/gif", ImageFormat.Gif},
            {"image/jpeg", ImageFormat.Jpeg},
            {"image/pjpeg", ImageFormat.Jpeg},
            {"image/png", ImageFormat.Png},
            {"image/x-png", ImageFormat.Png},
            {"image/tiff", ImageFormat.Tiff},
            {"image/bmp", ImageFormat.Bmp},
            {"image/x-icon", ImageFormat.Icon},
            {"image/icon", ImageFormat.Icon},
            {"image/ico", ImageFormat.Icon}
        };

    }
}
