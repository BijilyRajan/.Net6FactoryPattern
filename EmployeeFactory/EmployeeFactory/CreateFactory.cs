using EmployeeServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFactory
{
    public class CreateFactory
    {
        public enum EmployeeType
        {
            Teacher,
            HoD,
            HeadMaster
        }
        public void SetSalary(List<IEmployee> employees)
        {
            IEmployee teacher = CreateEmployee(EmployeeType.Teacher, 1, "Thomas", 4000 );
            employees.Add(teacher);

            IEmployee hod = CreateEmployee(EmployeeType.HoD, 2, "Prince", 5000 );
            employees.Add(hod);

            IEmployee headMaster = CreateEmployee(EmployeeType.HeadMaster, 3, "Brenda", 6000 );
            employees.Add(headMaster);
        }

        public IEmployee CreateEmployee(EmployeeType employeeType, int Id, string Name, decimal Salary)
        {
            IEmployee employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryBase<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HoD:
                    employee = FactoryBase<IEmployee, HoD>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryBase<IEmployee, HeadMaster>.GetInstance();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            if (employee!=null)
            {
                employee.Id = Id;
                employee.Name = Name;
                employee.Salary = Salary;
            }

            return employee;
        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.2m); }
    }

    public class HoD : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary* 0.4m); }
    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary*.6m); }

    }

}
