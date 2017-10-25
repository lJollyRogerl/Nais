using System;
using System.Collections.Generic;

namespace Instances
{
    //A class, implementing an employee within a company, the one with the hourly paid check
    [Serializable]
    public class EmployeeWithHourlyWageRate : Employee
    {
        public override decimal AverageSalary
        {
            get
            {
                Decimal result = 0;
                for (int i = 0; i < MonthsWorked.Count; i++)
                {
                    result += MonthsWorked[i].HoursWorked;
                }
                return (result * WageRate) / MonthsWorked.Count;
            }
        }
        //his/her months staticstics
        public List<MonthlyWorkedHours> MonthsWorked { get; set; }
    }
}
