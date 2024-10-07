using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Helper
{
    public static class FileHelper
    {
        public static string GetBase64(byte[] fileBytes)
        {
            return Convert.ToBase64String(fileBytes);
        }
        public static string GetBase64Image(byte[] fileBytes)
        {
            return "data:image/jpg;base64," + FileHelper.GetBase64(fileBytes);
        }

        public static string GetBase64Image(string filePath)
        {
            return "data:image/jpg;base64," + FileHelper.GetBase64(File.ReadAllBytes(filePath));
        }
    }
}
