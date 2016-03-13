using System;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace Geocaching.BL
{
    public class AddPhotos
    {
        public string AddImage(HttpPostedFileBase upload, string serverPath, string imgPath)
        {
            string path = null;
            string pathPic = null;
            if (upload != null && upload.ContentLength > 0)
            {
                var generator = RandomNumberGenerator.Create();
                byte[] num = new byte[8];
                generator.GetBytes(num);
                var name = Convert.ToBase64String(num);

                var time = Convert.ToString(DateTime.Now.Millisecond);
                var pic = Path.GetExtension(upload.FileName);
                path = serverPath + name + time + pic;
                pathPic = imgPath + name + time + pic;
                upload.SaveAs(Path.GetFullPath(path));
            }
            return pathPic;
        }
    }
}
