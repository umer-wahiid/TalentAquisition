using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<List<DropdownDto>> GetLeadSourceDropdownAsync()
        {
            return await _context.TasMainUsers
                .Where(s => s.IsDeleted != true && s.IsLead == true)
                .OrderBy(s => s.FullName)
                .Select(s => new DropdownDto
                {
                    Value = s.UserId,
                    Text = s.FullName
                })
                .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetStatusDropdownAsync()
        {
            return await _context.TasSetupStatuses
                .Where(s => s.IsDeleted != true)
                .OrderBy(s => s.Name)
                .Select(s => new DropdownDto
                {
                    Value = s.StatusId,
                    Text = s.Name
                })
                .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetTypeDropdownAsync()
        {
            return await _context.TasSetupTypes
                .Where(s => s.IsDeleted != true)
                .OrderBy(s => s.Name)
                .Select(s => new DropdownDto
                {
                    Value = s.TypeId,
                    Text = s.Name
                })
                .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetCompanyDropdownAsync()
        {
            return await _context.TasSetupCurrentcompanies
                .Where(s => s.IsDeleted != true)
                .OrderBy(s => s.Name)
                .Select(s => new DropdownDto
                {
                    Value = s.CurrentCompanyId,
                    Text = s.Name
                })
                .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetStateDropdownAsync()
        {
            return await _context.TasSetupStates
                .Where(s => s.IsDeleted != true)
                .OrderBy(s => s.StateFullName)
                .Select(s => new DropdownDto
                {
                    Value = s.Id,
                    Text = s.StateFullName
                })
                .ToListAsync();
        }

        public async Task<List<DropdownDto>> GetHierarchyDropdownAsync()
        {
            return await _context.TasSetupHierarchies
                .Where(s => s.IsDeleted != true)
                .OrderBy(s => s.Name)
                .Select(s => new DropdownDto
                {
                    Value = s.HierarchyId,
                    Text = s.Name
                })
                .ToListAsync();
        }
    }
}
