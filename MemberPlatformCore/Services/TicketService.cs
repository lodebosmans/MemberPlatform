using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;

namespace MemberPlatformCore.Services
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _ticketRepository;
        private IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            TicketEntity entity = await _ticketRepository.GetByIdAsync(id);
            Ticket ticket = _mapper.Map<Ticket>(entity);

            return ticket;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            List<TicketEntity> entities = (List<TicketEntity>)await _ticketRepository.GetAllAsync();
            List<Ticket> tickets = new List<Ticket>();
            foreach (TicketEntity entity in entities)
            {
                Ticket ticket = _mapper.Map<Ticket>(entity);
                tickets.Add(ticket);
            }
            return tickets;
        }

        public async Task<Ticket> UpdateAsync(int id, Ticket ticket)
        {
            TicketEntity ticketEntity = _mapper.Map<TicketEntity>(ticket);
            await _ticketRepository.Update(ticketEntity);

            return ticket;
        }

        public async Task<Ticket> PostAsync(Ticket ticket)
        {
            TicketEntity ticketEntity = _mapper.Map<TicketEntity>(ticket);
            await _ticketRepository.Insert(ticketEntity);

            return ticket;
        }

        public async Task<Ticket> DeleteAsync(int id)
        {
            TicketEntity entity = await _ticketRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Option with id {id} not found");
            }
            // Delete the entity from the repository
            await _ticketRepository.Delete(entity.Id);

            // Map the deleted entity back to an OptionType object and return it
            return _mapper.Map<Ticket>(entity);
        }
    }
}
