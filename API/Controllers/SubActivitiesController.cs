using Application.SubActivities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SubActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<SubActivity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubActivity>> GetSubActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
        [HttpPost]
        public async Task<ActionResult<List<SubActivity>>> CreateSubActivity(SubActivity subActivity)
        {
            return Ok(await Mediator.Send(new Create.Command{ SubActivity = subActivity }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSubActivity(Guid id, SubActivity subActivity)
        {
            subActivity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{SubActivity = subActivity}));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}