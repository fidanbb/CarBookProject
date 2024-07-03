using CarBookProject.Application.Feautures.CQRS.Commands.ContactCommands;
using CarBookProject.Application.Feautures.CQRS.Handlers.ContactHandlers;
using CarBookProject.Application.Feautures.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler,
                                GetContactByIdQueryHandler getContactByIdQueryHandler,
                                GetContactQueryHandler getContactQueryHandler,
                                UpdateContactCommandHandler updateContactCommandHandler,
                                RemoveContactCommandHandler removeContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));

            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);

            return Ok("Contact is added succesfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));

            return Ok("Contact is removed succesfully");
        }



        [HttpPut]

        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);

            return Ok("Contact is updated succesfully");
        }
    }
}
