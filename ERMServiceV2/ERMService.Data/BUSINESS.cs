//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERMService.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BUSINESS
    {
        public BUSINESS()
        {
            this.ERM_BUSINESS_COMPANY_ASSOC = new HashSet<ERM_BUSINESS_COMPANY_ASSOC>();
        }
    
        public int BUSINESS_ID { get; set; }
        public string BUSINESS_CODE { get; set; }
        public string BUSINESS_DESC { get; set; }
        public System.DateTime INSERT_DT { get; set; }
    
        public virtual ICollection<ERM_BUSINESS_COMPANY_ASSOC> ERM_BUSINESS_COMPANY_ASSOC { get; set; }
    }
}