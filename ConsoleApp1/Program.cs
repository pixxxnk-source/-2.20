using System;
using System.Collections.Generic;
abstract class Employee
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    public Employee(string id, string name)
    {
        Id = id;
        Name = name;
    }
    public abstract int CalculateDailyWage(double hoursWorked);
}
class FullTimeEmployee : Employee
{
    private const double HourlyRate = 1250;

    public FullTimeEmployee(string id, string name)
        : base(id, name)
    { }
    public override int CalculateDailyWage(double hoursWorked)
    {
        double baseHours = Math.Min(8, hoursWorked);
        double overtime = Math.Max(0, hoursWorked - 8);

        double wage = baseHours * HourlyRate
                      + overtime * HourlyRate * 1.25;

        return (int)wage; 
    }
}
class ContractEmployee : Employee
{
    private const double HourlyRate = 1000;

    public ContractEmployee(string id, string name)
        : base(id, name)
    { }
    public override int CalculateDailyWage(double hoursWorked)
    {
        return (int)(hoursWorked * HourlyRate);
    }
}
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new FullTimeEmployee("E001", "山田太郎"),
            new ContractEmployee("C001", "佐藤花子"),
            new FullTimeEmployee("E002", "鈴木一郎")
        };
        double[] hours = { 8.5, 8, 8 };

        int i = 0;
        foreach (Employee employee in employees)
        {
            int wage = employee.CalculateDailyWage(hours[i]);
            Console.WriteLine($"社員ID: {employee.Id}, 名前: {employee.Name}, 給料: {wage}");
            i++;
        }

    }
}
