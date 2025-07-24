using Dapper;
using Microsoft.EntityFrameworkCore;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IRepositories;
using TalentAquisition.Infrastructure.Context;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class MainEmployeeRepository : IMainEmployeeRepository
    {
        private readonly TalentAquisitionDbContext _context;

        public MainEmployeeRepository(TalentAquisitionDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<dynamic>>> GetAllAsync()
        {
            try
            {
                using (var conn = _context.Database.GetDbConnection())
                {
                    await conn.OpenAsync();
                    var result = await conn.QueryAsync("EXEC dbo.Get_ProspectiveEmployeesList 2");
                    return Response<IEnumerable<dynamic>>.SuccessResult(result);
                }

            }
            catch (Exception ex)
            {
                return Response<IEnumerable<dynamic>>.FailureResult(ex.Message, ex);
            }
        }
    }
}
