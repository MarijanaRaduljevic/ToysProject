using System;
using System.Collections.Generic;
using System.Text;

namespace ToysApplication.DTO
{
    public class GetImageDto
    {
        public int Id { get; set; }

        public string Src { get; set; }
        public string Alt { get; set; }

        public string Title { get; set; }
    }
}
