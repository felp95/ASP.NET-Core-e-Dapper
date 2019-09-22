using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("api/v1/customers")]
        [ResponseCache(Duration = 60)]
        public List<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("api/v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("api/v1/customers/{id}/orders")]
        public List<ListCustomerOrdersQueryResult> Orders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("api/v1/customers")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            
            return result;
        }

        [HttpGet]
        [Route("error")]
        public string Error([FromBody] CreateCustomerCommand command)
        {
            throw new Exception("erro");

            return "erro";
        }
    }
}