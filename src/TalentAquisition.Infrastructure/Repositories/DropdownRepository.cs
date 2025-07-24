using Microsoft.EntityFrameworkCore;
using TalentAquisition.Core.Dtos;
using TalentAquisition.Core.IRepositories;
using TalentAquisition.Infrastructure.Context;

namespace TalentAquisition.Infrastructure.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly TalentAquisitionDbContext _context;

        public DropdownRepository(TalentAquisitionDbContext context)
        {
            _context = context;
        }

        public async Task<List<DropdownDto>> GetMilestoneDropdownAsync()
        {
            return await _context.TasSetupMilestones
                .OrderBy(s => s.MilestoneId)
                .Select(s => new DropdownDto
                {
                    Value = s.MilestoneId,
                    Text = s.MilestoneName
                })
                .ToListAsync();
        }
    }
}
