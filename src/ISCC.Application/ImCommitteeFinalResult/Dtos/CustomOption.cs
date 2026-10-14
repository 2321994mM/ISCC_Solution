using System;

namespace ISCC.Application.ImCommitteeFinalResult.Dtos
{
    public class CustomOption
    {
        public int? Value { get; set; }
        public bool? Value2 { get; set; }
        public string DisplayText { get; set; }
        //add startdate and enddate to use in stationactivity index to compare dates of ???????? ???????
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
    }
}
