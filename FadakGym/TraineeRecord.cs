//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FadakGym
{
    using System;
    using System.Collections.Generic;
    
    public partial class TraineeRecord
    {
        public int TraineeRecordID { get; set; }
        public Nullable<int> UsedID { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> BodyFat { get; set; }
        public Nullable<double> BMI { get; set; }
        public Nullable<double> BodyWater { get; set; }
        public Nullable<double> Protein { get; set; }
        public Nullable<double> Muscle { get; set; }
        public Nullable<System.DateTime> AssessmentDate { get; set; }
    
        public virtual User User { get; set; }
    }
}