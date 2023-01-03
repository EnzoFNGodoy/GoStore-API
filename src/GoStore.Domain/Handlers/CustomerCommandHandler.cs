using Flunt.Notifications;
using GoStore.Domain.Commands.Customers;
using GoStore.Domain.Core.Commands;
using GoStore.Domain.Core.Handlers;
using GoStore.Domain.Entities;
using GoStore.Domain.Repositories;
using GoStore.Domain.ValueObjects;
using PaymentContext.Domain.Services;

namespace GoStore.Domain.Handlers;

public sealed class CustomerCommandHandler :
    Notifiable<Notification>,
    IHandler<CreateCustomerCommand>,
    IHandler<UpdateCustomerCommand>,
    IHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmailServices _emailServices;

    public CustomerCommandHandler(ICustomerRepository customerRepository, 
        IEmailServices emailServices)
    {
        _customerRepository = customerRepository;
        _emailServices = emailServices;
    }

    public async Task<ICommandResult> Handle(CreateCustomerCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "The customer couldn't be created.");
        }

        if (await _customerRepository.EmailExists(command.Email))
            AddNotification("Email", "A customer with this email already exists.");

        var name = new Name(command.FirstName, command.LastName);
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var address = new Address(
            command.Neighborhood,
            command.Street,
            command.Number,
            command.ZipCode,
            command.City,
            command.State
            );

        var customer = new Customer(name, email, password, address);

        AddNotifications(name, email, password, address, customer);

        if (!IsValid)
            return new CommandResult(false, "The customer couldn't be created.");

        await _customerRepository.Create(customer);

        _emailServices.Send(name.ToString(), email.ToString(), $"Welcome to GoStore, {name}!", $"Your account has been successfully created. Welcome!");

        return new CommandResult(true, "Customer successfully created.");
    }

    public async Task<ICommandResult> Handle(UpdateCustomerCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "The customer couldn't be updated.");
        }

        var customer = await _customerRepository.CustomerExists(command.Id);

        if (customer is null)
            return new CommandResult(false, "This customer doens't exists.");

        if (await _customerRepository.EmailExists(command.Id, command.Email))
            AddNotification("Email", "A customer with this email already exists.");

        var name = new Name(command.FirstName, command.LastName);
        var password = customer.Password;
        var email = new Email(command.Email);
        var address = new Address(
            command.Neighborhood,
            command.Street,
            command.Number,
            command.ZipCode,
            command.City,
            command.State
            );

        customer = new Customer(name, email, password, address);

        AddNotifications(name, email, password, address, customer);

        if (!IsValid)
            return new CommandResult(false, "The customer couldn't be updated.");

        await _customerRepository.Update(customer);

        _emailServices.Send(name.ToString(), email.ToString(), $"Customer updated, {name}!", $"Your account has been successfully updated. Enjoy!");

        return new CommandResult(true, "Customer successfully updated.");
    }

    public async Task<ICommandResult> Handle(DeleteCustomerCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "The customer couldn't be deleted.");
        }

        var customer = await _customerRepository.CustomerExists(command.Id);

        if (customer is null)
            return new CommandResult(false, "This customer doesn't exists.");

        if (!IsValid)
            return new CommandResult(false, "The customer couldn't be deleted.");

        await _customerRepository.Delete(customer.Id);

        _emailServices.Send(customer.Name.ToString(), customer.Email.ToString(), $"Customer deleted, {customer.Name}!", $"Your account has been successfully deleted. We hope you will come back!");

        return new CommandResult(true, "Customer successfully deleted.");
    }
}