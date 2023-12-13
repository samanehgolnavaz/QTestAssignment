using System.ComponentModel.DataAnnotations;

namespace QTest.Domain.Entities;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "The {0} field must be a positive number.")]
    public decimal  Budget { get; set; }

    public bool HasPrinter { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
