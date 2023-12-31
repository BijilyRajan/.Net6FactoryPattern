// See https://aka.ms/new-console-template for more information
using EmployeeFactory;
using EmployeeServiceAPI;

Console.WriteLine("Hello, World!");

CreateFactory createFactory = new CreateFactory();
List<IEmployee> employees = new List<IEmployee>();
createFactory.SetSalary(employees);
decimal totalSalary = 0;

////Using ForEach
//foreach(IEmployee employee in employees)
//{
//    totalSalary += employee.Salary;
//}

//Console.WriteLine($"Total Salary of all Emplyees = { totalSalary }");

////Simplified using LINQ
Console.WriteLine($"Total Salary for all = { employees.Sum(x => x.Salary) }");

Console.ReadKey();


