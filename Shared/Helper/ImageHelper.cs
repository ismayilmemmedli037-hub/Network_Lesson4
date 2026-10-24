using System.Drawing;

namespace Shared.Helper;

public class ImageHelper
{
    public ImageHelper()
    {
        var pathForServer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Server");
        var pathForClient = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Client");

        if (!Directory.Exists(pathForServer))
        {
            Directory.CreateDirectory(pathForServer);
        }

        if (!Directory.Exists(pathForClient))
        {
            Directory.CreateDirectory(pathForClient);
        }

    }

    public string GetImagePath(byte[] buffer)
    {
        ImageConverter ic = new ImageConverter();
        var data = ic.ConvertFrom(buffer);


        Image img = data as Image;
        if (img != null)
        {
            Bitmap bitmap1 = new Bitmap(img);

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images2");
            Directory.CreateDirectory(path);
            var strGuid = Guid.NewGuid().ToString();
            bitmap1.Save($@"{path}\image{strGuid}.png");
            var imagepath = $@"{path}\image{strGuid}.png";
            return imagepath;
        }
        else
        {
            return String.Empty;
        }
    }

    public byte[] GetBytesOfImage(string path)
    {
        var image = new Bitmap(path);

        ImageConverter imageconverter = new ImageConverter();
        var imagebytes = ((byte[])imageconverter.ConvertTo(image, typeof(byte[])));

        return imagebytes;
    }

    public string TakeScreenShot(string folderName)
    {
        Bitmap bmp = new Bitmap(1920, 1080);
        string fullPath = string.Empty;

        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080));

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), folderName);

            fullPath = path + "\\screenshot_" + Guid.NewGuid().ToString() + ".png";

            bmp.Save(fullPath);  // saves the image
        }
        Console.WriteLine("Image has been saved to folder");
        return fullPath;
    }


     
}
