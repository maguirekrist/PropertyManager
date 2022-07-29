using PropertyManager.Db;
using PropertyManager.Models;

namespace PropertyManager.Utility.Services;

public interface IResidentInterface
{
    Task<List<Resident>> GetAllResidents();

    Task<Guest> CreateNewGuest(Guest guest);

    Task<Guest> UpdateGuest(Guest guest);

    Task DeleteGuest(Guest guest);

    Task CreateNewResident(Resident resident);

    Task<Resident> UpdateResident(Resident resident);
}

public class ResidentService : IResidentInterface
{
    private readonly DatabaseContext _databaseContext;
    
    public ResidentService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public Task<List<Resident>> GetAllResidents()
    {
        throw new NotImplementedException();
    }

    public Task<Guest> CreateNewGuest(Guest guest)
    {
        throw new NotImplementedException();
    }

    public Task<Guest> UpdateGuest(Guest guest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteGuest(Guest guest)
    {
        throw new NotImplementedException();
    }

    public Task CreateNewResident(Resident resident)
    {
        throw new NotImplementedException();
    }

    public Task<Resident> UpdateResident(Resident resident)
    {
        throw new NotImplementedException();
    }
}