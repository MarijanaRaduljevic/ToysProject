using System;
using System.Collections.Generic;
using System.Text;

namespace ToysApplication.Helpers
{
    public class FileUpload
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpeg", ".jpg", ".gif", ".png" };
    }
}
