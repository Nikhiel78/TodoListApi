using BlazerApp.Server.Models;
using BlazerApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazerApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase {
        
        private readonly IAssignmentRepo assignmentRepo;
        public AssignmentsController(IAssignmentRepo assignmentRepo) {
            this.assignmentRepo = assignmentRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAssignments() {
            try
            {
                return Ok(await assignmentRepo.GetAssignments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database.");
            }
            ;
        }
        [HttpGet("{id:int}")] //extention to route
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            try
            {
                var result = await assignmentRepo.GetAssignment(id);

                if (result == null) {

                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
            ;
        }
        [HttpPost] //extention to route
        public async Task<ActionResult<Assignment>> CreateAssignment(Assignment assignment)
        {
            try
            {

                if (assignment == null) 
                    return BadRequest();

                var createdAssignment = await assignmentRepo.AddAssignment(assignment);

                return CreatedAtAction(nameof(GetAssignment),
                    new { id = createdAssignment.Id}, createdAssignment);
                
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new assignment record.");
            }
            ;
        }
        [HttpPut("{id:int}")] //extention to route
        public async Task<ActionResult<Assignment>> UpdateAssignment(int id,Assignment assignment)
        {
            try
            {

                if (id != assignment.Id)
                    return BadRequest("Assignment ID mismatch");

                var assignmentToUpdate = await assignmentRepo.GetAssignment(id);

                if (assignmentToUpdate == null) {
                    return NotFound($"Assignment with Id = {id} not found2");
                }
                return await assignmentRepo.UpdateAssignment(assignment);
                


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating assignment record.");
            }
            ;
        }
        [HttpDelete("{id:int}")] //extention to route
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            try
            {

               

                var assignmentToDelete = await assignmentRepo.GetAssignment(id);

                if (assignmentToDelete == null)
                {
                    return NotFound($"Assignment with Id = {id} not found");
                }
                await assignmentRepo.DeleteAssignment(id);
                
                return Ok($"Assignment with Id = {id} deleted");



            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting assignment record.");
            }
            ;
        }

    }
}
