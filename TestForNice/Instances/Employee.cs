using System;
using System.Xml.Serialization;

namespace Instances
    
{
    //A class, implementing an employee within a company, the one with the fixed wage rate
    [Serializable]
    [XmlInclude(typeof(EmployeeWithHourlyWageRate)), XmlInclude(typeof(MonthlyWorkedHours))]
    public class Employee
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public DateTime BDate { get; set; }
        public String Position { get; set; }
        public Decimal WageRate { get; set; }
        public virtual Decimal AverageSalary { get { return WageRate; } }
        

    }
}
