using Microsoft.EntityFrameworkCore;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IRepositories;
using TalentAquisition.Infrastructure.Context;
using TalentAquisition.Infrastructure.Extensions.Mappings;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class MainEmployeeRepository : IMainEmployeeRepository
    {
        private readonly TalentAquisitionDbContext _context;

        public async Task<Response<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                var employees = await _context.Set<dynamic>()
                    .FromSqlRaw("EXEC dbo.Get_ProspectiveEmployeesList 2")
                    .AsNoTracking()
                    .ToListAsync();

                return Response<IEnumerable<dynamic>>.SuccessResult(employees);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<dynamic>>.FailureResult(ex.Message, ex);
            }
        }
    }
}
