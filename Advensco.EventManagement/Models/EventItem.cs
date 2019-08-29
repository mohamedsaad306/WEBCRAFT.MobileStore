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
    public class  EventItemRepository : Repository<EventItem >
    {
    
        public EventItemRepository(Entities context)
            : base(context)
        {
        }
    }//1
    //repo class 
    public partial class EventItem
    {
        public System.Guid Id { get; set; }
        public System.Guid EventId { get; set; }
        public System.Guid ItemId { get; set; }
        public System.Guid Count { get; set; }
        public string Status { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Item Item { get; set; }
    }


}
