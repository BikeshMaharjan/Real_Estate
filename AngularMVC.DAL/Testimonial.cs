//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularMVC.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Testimonial
    {
        public string TestimonialID { get; set; }
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
        public string Text { get; set; }
        public string PostedBy { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsVerified { get; set; }
    }
}
