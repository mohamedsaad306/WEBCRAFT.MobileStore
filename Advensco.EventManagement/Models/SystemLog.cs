//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Advensco.EventManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    //repo class 
    public class  SystemLogRepository : Repository<SystemLog >
    {
    
        public SystemLogRepository(Entities context)
            : base(context)
        {
        }
    }//1
    //repo class 
    public partial class SystemLog
    {
        public System.Guid Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Message { get; set; }
    }


}