using System;

namespace Instances

{
    public enum MONTH { JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OKT, NOV, DEC };
    //A class which represents a month, and the worked hours of an employee within the month
    [Serializable]
    public class MonthlyWorkedHours
    {

        public Int32 Id { get; set; }
        public MONTH Month { get; set; }
        public Int32 HoursWorked { get; set; }
    }
}
