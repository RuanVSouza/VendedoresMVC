using VendedoresMVC.Data;
using VendedoresMVC.Models;

namespace VendedoresMVC.Services;

public class SellerService
{
    private readonly VendedoresMVCContext _context;

    public SellerService(VendedoresMVCContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
        obj.Department = _context.Department.First();
        _context.Add(obj);
        _context.SaveChanges();
    }
    
}