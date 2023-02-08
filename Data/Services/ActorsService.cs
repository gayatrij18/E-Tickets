using E_Tickets.Data.Base;
using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
       

        public ActorsService(AppDbContext context):base(context)
        {
            
        }
        
    }
}
