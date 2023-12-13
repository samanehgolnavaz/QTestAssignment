namespace QTest.Domain.Entities;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Salary { get; set; }

    public DateOnly BirthOfDate { get; set; }

    public int DepartmentId { get; set; }

    public Department Department { get; set; }
}
