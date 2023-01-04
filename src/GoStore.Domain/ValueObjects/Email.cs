using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;

namespace GoStore.Domain.ValueObjects;

public sealed class Email : ValueObject
{
	public Email(string address)
	{
		Address = address;

		AddNotifications(new Contract<Email>()
			.Requires()
			.IsEmail(Address, "Email.Address", "Email is invalid.")
			);
	}

    public string Address { get; private set; }

	public override string ToString() => Address;
}