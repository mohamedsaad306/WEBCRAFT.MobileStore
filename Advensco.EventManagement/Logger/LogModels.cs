using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Advensco.EventManagement.Logger
{
    public class ApiLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Method { get; set; }
        public string URL { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedOn { get; set; }

    }

    public class CustomLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public bool IsException { get;  set; }
        //public string LogType { get; set; }
    }

}