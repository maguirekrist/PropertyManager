using Microsoft.EntityFrameworkCore;
using PropertyManager.Db;
using PropertyManager.Models;

namespace PropertyManager.Utility.Services;

public interface IPropertyService
{
    Task<Property> CreateNewProperty(Property property);

    Task<Property> UpdateProperty(Property property);

    Task DeleteProperty(Property property);

    Task<List<Property>> GetResidentProperties(Resident resident);

    Task<List<Property>> GetAllProperties();

    Task<Media> CreateMedia(Media media);

    Task DeleteMedia(Media media);
    
}

public class PropertyService : Service, IPropertyService
{
    
    public PropertyService(DatabaseContext context) : base(context)
    {
    }
    
    public Task<Property> CreateNewProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public Task<Property> UpdateProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public Task<List<Property>> GetResidentProperties(Resident resident)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Property>> GetAllProperties()
    {
        return await _context.Properties.ToListAsync();
    }

    public Task<Media> CreateMedia(Media media)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMedia(Media media)
    {
        throw new NotImplementedException();
    }
}