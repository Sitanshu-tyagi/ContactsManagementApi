using ContactsManagementApplication.Commands;
using ContactsManagementInfra.JsonDataStore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddContactsCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dataStore = new ContactsJsonDataStore();
            return Ok(dataStore.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dataStore = new ContactsJsonDataStore();
            var contact = dataStore.GetAll().FirstOrDefault(p => p.Id == id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateContactsCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactsCommand { Id = id };
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }
    }
}
