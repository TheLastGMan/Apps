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
    
    public partial class SHOCK
    {
        public int SHOCK_SEQ_ID { get; set; }
        public string SHOCK_TYPE_NM { get; set; }
        public string SHOCK_DESC { get; set; }
        public Nullable<short> EQUITY_IND { get; set; }
        public Nullable<short> TIME_IND { get; set; }
        public Nullable<short> ROLLFORWARD_IND { get; set; }
        public Nullable<short> DEFAULT_CALIBRATION_IND { get; set; }
        public Nullable<short> SHOCK_EXCHANGE_RATE_IND { get; set; }
        public Nullable<short> ERM_IND { get; set; }
    }
}
