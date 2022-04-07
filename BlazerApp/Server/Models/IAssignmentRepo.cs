using BlazerApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazerApp.Server.Models
{
    public interface IAssignmentRepo
    {
        Task<IEnumerable<Assignment>> Search(string name);
        Task<IEnumerable<Assignment>> GetAssignments();
        Task<Assignment> GetAssignment(int assignmentId);
        Task<Assignment> AddAssignment(Assignment assignment);
        Task<Assignment> UpdateAssignment(Assignment assignment);
        Task DeleteAssignment(int assignmentId);


    }
}
