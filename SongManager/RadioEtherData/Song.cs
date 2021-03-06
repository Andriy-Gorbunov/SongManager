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
    
    public partial class Song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Song()
        {
            this.Performances = new HashSet<Performance>();
        }
    
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }
        public Nullable<System.Guid> PerformerId { get; set; }
        public Nullable<System.Guid> PerformerId1 { get; set; }
        public Nullable<System.Guid> LanguageId { get; set; }
    
        public virtual Performer Performer { get; set; }
        public virtual Language Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Performance> Performances { get; set; }
    }
}
