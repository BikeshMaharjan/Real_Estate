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
    
    public partial class Blog
    {
        public string BlogID { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Category { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Thumbnail { get; set; }
        public string AlbumID { get; set; }
        public string Highlight { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public string PostedBy { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsVerified { get; set; }
    }
}
