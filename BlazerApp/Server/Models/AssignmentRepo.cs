using BlazerApp.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazerApp.Server.Models
{
    public class AssignmentRepo : IAssignmentRepo
    {
        private readonly AppDbContext appDbContext;

        public AssignmentRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            var result = await appDbContext.Assignments.AddAsync(assignment);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAssignment(int assignmentId)
        {
            var result = await appDbContext.Assignments
                .FirstOrDefaultAsync(e => e.Id == assignmentId);

            if (result != null) {
                appDbContext.Assignments.Remove(result);
                await appDbContext.SaveChangesAsync();

            }
        }

        public async Task<Assignment> GetAssignment(int assignmentId)
        {
            return await appDbContext.Assignments
                
                .FirstOrDefaultAsync(e => e.Id == assignmentId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
            return await appDbContext.Assignments.ToListAsync();

        }

        public async Task<IEnumerable<Assignment>> Search(string name)
        {
            IQueryable<Assignment> query = appDbContext.Assignments;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Assignment> UpdateAssignment(Assignment assignment)
        {
            var result = await appDbContext.Assignments
                .FirstOrDefaultAsync(e => e.Id == assignment.Id);

            if (result != null) {
                result.Name = assignment.Name;
                result.Status = assignment.Status;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
