//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseOperation
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbltraining_topics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbltraining_topics()
        {
            this.tblbatches = new HashSet<tblbatch>();
            this.tbltopic_contents = new HashSet<tbltopic_contents>();
            this.tbltrainer_topics = new HashSet<tbltrainer_topics>();
            this.tblcourse_topics = new HashSet<tblcourse_topics>();
        }
    
        public int topic_id { get; set; }
        public string topic_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblbatch> tblbatches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbltopic_contents> tbltopic_contents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbltrainer_topics> tbltrainer_topics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblcourse_topics> tblcourse_topics { get; set; }
    }
}
