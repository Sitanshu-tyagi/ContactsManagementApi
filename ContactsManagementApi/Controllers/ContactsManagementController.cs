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

        /// <summary>
        /// This function will be used to craete new contacts.
        /// </summary>
        /// <param name="command">AddContactsCommand class type of input is required.</param>
        /// <returns>Success task when done creating new contact.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddContactsCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        /// <summary>
        /// This function will be used to get all contacts.
        /// </summary>
        /// <param name="">No input parameter.</param>
        /// <returns>List of all contacts.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var dataStore = new ContactsJsonDataStore();
            return Ok(dataStore.GetAll());
        }

        /// <summary>
        /// This function will be used to get one contact against the Id passed as input.
        /// </summary>
        /// <param name="id">Integer type of input will be required.</param>
        /// <returns>Single contact will be returned.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dataStore = new ContactsJsonDataStore();
            var contact = dataStore.GetAll().FirstOrDefault(p => p.Id == id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        /// <summary>
        /// This function will be used to update one contact against the Id passed as input.
        /// </summary>
        /// <param name="id">Integer type of input will be required.</param>
        /// <returns>Success task when done updating new contact.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateContactsCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        /// <summary>
        /// This function will be used to delete one contact against the Id passed as input.
        /// </summary>
        /// <param name="id">Integer type of input will be required.</param>
        /// <returns>Success task when done deleting new contact.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactsCommand { Id = id };
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }
    }
}
