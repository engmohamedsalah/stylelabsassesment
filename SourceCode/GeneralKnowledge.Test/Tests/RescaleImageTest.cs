using Helper;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling test
    /// using ImageProcessor Package
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)


            //image url for test
            string imgUrl = "https://www.gstatic.com/webp/gallery/5.jpg";
            //call method to get image from certain url
            var imagebytes = ImageUtility.GetImageFromURL(imgUrl);
            //new require size 
            Size size = new Size(50, 50);
            //new require format  
            //quality scale from 1 - 100
            ISupportedImageFormat format = new PngFormat { Quality = 70 };
            //ISupportedImageFormat format = new JpegFormat { Quality = 70 };

            //call rescal image
            var newImagebytes = ImageUtility.RescaleImage(imagebytes, size, format);

            ////////////////////////////////////////////
            ///////////////test the resut////////////////
            ////////////////////////////////////////////
            //first bitmap
            Bitmap bitmapSrc = ImageUtility.ByteArrayToBitmap(imagebytes);
            //second bitmap
            Bitmap bitmapDist = ImageUtility.ByteArrayToBitmap(newImagebytes);

            
            //print the first image's length
            Console.WriteLine("length of first image {0}", bitmapSrc.RawFormat.ToString());
            //print the second image's length
            Console.WriteLine("length of second image {0}", bitmapDist.Size);



        }

    }
}
