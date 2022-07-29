using PropertyManager.Db;

namespace PropertyManager.Utility.Services;

public abstract class Service
{
    protected readonly DatabaseContext _context;

    public Service(DatabaseContext context)
    {
        _context = context;
    }

}