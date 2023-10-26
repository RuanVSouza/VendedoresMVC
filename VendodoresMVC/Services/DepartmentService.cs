using VendedoresMVC.Data;
using VendedoresMVC.Models;

namespace VendedoresMVC.Services;

public class DepartmentService
{
    private readonly VendedoresMVCContext _context;

    public DepartmentService(VendedoresMVCContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }
    
}