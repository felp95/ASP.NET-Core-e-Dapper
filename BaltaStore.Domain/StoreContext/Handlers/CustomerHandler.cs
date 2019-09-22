using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<CreateAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF existe
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já esta em uso");

            // Verificar se o email existe
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");

            // Criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new EmailAddress(command.Email);

            // Criar Entidade
            var customer = new Customer(name, document, email, "987176812");

            // Validar entidades e VOs
            AddNotifications(name, document, email, customer);

            if (Invalid) return null;

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar um email
            _emailService.SendEmail(email.Email, "felp95@gmail.com", "Titulo", "Corpo do email");

            // Retornar o resultado para a tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Email);
        }

        public ICommandResult Handle(CreateAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
