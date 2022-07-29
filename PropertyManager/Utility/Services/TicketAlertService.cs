using PropertyManager.Db;
using PropertyManager.Models;

namespace PropertyManager.Utility.Services;

public interface ITicketAlertService
{
    Task<List<Ticket>> GetAllTickets();

    Task<Ticket> CreateNewTicket(Ticket ticket);

    Task<Ticket> UpdateTicket(Ticket ticket);

    Task<TicketReply> ReplyToTicket(Ticket ticket, TicketReply reply);

    Task<Alert> CreateNewAlert(Alert alert);

    Task<Alert> UpdateAlert(Alert alert);

    Task DeleteAlert(Alert alert);
}

public class TicketAlertService :  ITicketAlertService
{
    private readonly DatabaseContext _databaseContext;
    
    public TicketAlertService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task<List<Ticket>> GetAllTickets()
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> CreateNewTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> UpdateTicket(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task<TicketReply> ReplyToTicket(Ticket ticket, TicketReply reply)
    {
        throw new NotImplementedException();
    }

    public Task<Alert> CreateNewAlert(Alert alert)
    {
        throw new NotImplementedException();
    }

    public Task<Alert> UpdateAlert(Alert alert)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAlert(Alert alert)
    {
        throw new NotImplementedException();
    }
}