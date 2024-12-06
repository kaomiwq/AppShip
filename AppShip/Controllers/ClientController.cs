﻿using AppShip.ActionClass.Account;
using AppShip.ActionClass.HelperClass.DTO;
using AppShip.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppShip.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUser _iUser;
        public ClientController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpPost("user/addAccount")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<string>>> Post(AccountCreate clientData) => await Task.FromResult(_iUser.AddAccount(clientData));

        [HttpGet("clients")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClientsDTO>>> Get() => await Task.FromResult(_iUser.GetClients());

        [HttpGet("client")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClientsDTO>>> Get(int id) => await Task.FromResult(_iUser.GetClient(id));

        [HttpDelete("user/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(int id) => await Task.FromResult(_iUser.DeleteClient(id));

        [HttpPatch("user/updateUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<string>>> Patch(int id, ClientsDTO client) => await Task.FromResult(_iUser.UpdateClient(id, client));

    }
}
