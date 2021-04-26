using IBL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class UploadImage : IUploadImage
    {
        string selectedDateTime;
        public string GetImageAbsolutePath(string imgPath)
        {
            selectedDateTime = DateTime.Now.Ticks.ToString();
            string fullPath = selectedDateTime + imgPath;
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/"), fullPath);
            return path;
        }

        public string GetImageRelativePath(string imgPath)
        {
            string fullPath = selectedDateTime + imgPath;
            string path = "~/Content/Images/" + fullPath;
            return path;
        }
    }
}