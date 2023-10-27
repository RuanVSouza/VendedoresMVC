using VendedoresMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendedoresMVC.Data;
using VendedoresMVC.Models;

namespace VendedoresMVC.Services
{
    public class DepartmentService
    {
        private readonly VendedoresMVCContext _context;

        public DepartmentService(VendedoresMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}