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
    
    public partial class ERM_BUSINESS_COMPANY_ASSOC
    {
        public int ERM_BUSINESS_COMPANY_ASSOC_SEQ_ID { get; set; }
        public string COMPANY_CODE { get; set; }
        public string ALT_COMP_CODE { get; set; }
        public int BUSINESS_ID { get; set; }
        public int ERM_REPORT_SEGMENT_ID_GAAP { get; set; }
        public int ERM_REPORT_SEGMENT_ID_CAPITAL { get; set; }
        public System.DateTime INSERT_DT { get; set; }
    
        public virtual BUSINESS BUSINESS { get; set; }
        public virtual ERM_REPORT_SEGMENT ERM_REPORT_SEGMENT { get; set; }
        public virtual ERM_REPORT_SEGMENT ERM_REPORT_SEGMENT1 { get; set; }
    }
}
