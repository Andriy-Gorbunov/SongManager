//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RadioEtherData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quote
    {
        public System.Guid Id { get; set; }
        public decimal Percentage { get; set; }
        public System.Guid CountryGroupId { get; set; }
        public Nullable<System.Guid> LanguageId { get; set; }
        public Nullable<System.Guid> CountryGroupId1 { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual CountryGroup CountryGroup { get; set; }
    }
}
