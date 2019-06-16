using System;
using System.Collections.Generic;
using System.Text;

namespace ToysApplication.Interfaces
{
    public interface IEmail
    {
        string ToEmail { get; set; }
        string Body { get; set; }
        string Subject { get; set; }

        void Send();
    }
}
