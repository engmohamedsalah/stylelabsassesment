using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.IO;
using System.Net;

namespace Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class ImageUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte[] GetImageFromURL(string imageUrl)
        {
            //WebClient client = new WebClient();
            //Stream stream = client.OpenRead(imageUrl);

            //Bitmap bitmap = new Bitmap(stream);
            //return bitmap;
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(imageUrl);
            return imageBytes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="newSize"></param>
        /// <param name="newFormat"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static byte[] RescaleImage(byte[] imageBytes, Size newSize, ISupportedImageFormat newFormat)
        {
            using (MemoryStream inStream = new MemoryStream(imageBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                                    .Resize(newSize)
                                    .Format(newFormat)
                                    .Save(outStream);
                    }
                    //  return the new byte array
                    return outStream.ToArray();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Bitmap ByteArrayToBitmap(byte[] byteArray)
        {
            ImageConverter ic = new ImageConverter();

            Image img = (Image)ic.ConvertFrom(byteArray);

            Bitmap bitmap = new Bitmap(img);
            return bitmap;
        }

       

    }
}
