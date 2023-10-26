using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendedoresMVC.Models;

public class Seller
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double Salary { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
    
    
public Seller(){}
    public Seller(int id, string name, string email, DateTime birthDate, double salary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Salary = salary;
        Department = department;
    }

    public void AddSales(SalesRecord sr)
    {
        Sales.Add(sr);
    }
    
    public void RemoveSales(SalesRecord sr)
    {
        Sales.Remove(sr);
    }

    public double TotalSales(DateTime initial, DateTime final)
    {
        return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
    }

    
    
    
    
    
    
    
    
}