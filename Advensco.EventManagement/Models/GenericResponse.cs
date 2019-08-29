using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Advensco.EventManagement.Models
{
   
    public class GenericResponse<T> : HttpResponseMessage where T : class
    {
        public ResponseStatusEnum Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
    public enum ResponseStatusEnum
    {
        error = 0,
        sucess = 1
    }
}