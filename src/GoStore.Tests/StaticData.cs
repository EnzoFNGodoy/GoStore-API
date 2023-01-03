using GoStore.Domain.Enums;
using GoStore.Domain.ValueObjects;
using GoStore.Domain.Entities;

namespace GoStore.Tests;


internal sealed class StaticData
{
    #region Constants
    internal const string MORE_THAN_50_CHARACTERS = "fhbunjieyswefhnwwefhujniklofoehujniFHUNIOOfnidbhhbns";
    internal const string MORE_THAN_100_CHARACTERS = "fhbunjieyswefhnwwefhujniklofoehujniFHUNIOOfnidbhhbnsdfosdfbnidbsUIOFJDSBNOJIFDOBJIKdfbikodfbkodSBdasdaasd";
    internal const string MORE_THAN_150_CHARACTERS = "fhjisdbfihsdbfhjndimiqjnxomwvdwfopwobfjibsdomcpsdocmioasdbnciuasbnxoamdopaknofbasviojaspovaionhdvoaijdoiajmdioawjcduiohqvnwohqwioumhjoqiwmjvhcioqhwnhvci";
    internal const string MORE_THAN_20_CHARACTERS = "gbnigdfbiumaikdmasjdass";

    internal const string ONE_HUNDRED_CHARACTERS = "fgu9obhwenasfiouasdhnfgusdg8sdhgisdjgnsdkojngosdknfkp[NDOasbfjmsdkpfasjbdakodmoaskdnsjoandmkoasmddda";
    internal const string FIFTY_CHARACTERS = "gbnigdfbiumaikdmasjndoamfasifnasfkomasopfmasfmoada";
    internal const string TWENTY_CHARACTERS = "gbnigdfbiumaikdmasjs";
    #endregion

    #region Address
    internal static Address ValidAddress = new(
         neighborhood: "Vila Velha",
         street: "Rua Nova",
         number: "123",
         zipCode: "12345678",
         city: "Araraquara",
         state: EState.SP
         );

    internal static Address InvalidAddress = new(
         neighborhood: "",
         street: "",
         number: "",
         zipCode: "",
         city: "",
         state: EState.SP
         );
    #endregion

    #region CreditCard
    internal const string VALID_CREDIT_CARD_NUMBER_UNFORMATTED = "5163297127551202";
    internal const string VALID_CREDIT_CARD_NUMBER_FORMATTED = "5163 2971 2755 1202";
    private const string INVALID_CREDIT_CARD_NUMBER = "51297125202";
    internal static CreditCard ValidCreditCard = new("Lionel Messi", VALID_CREDIT_CARD_NUMBER_FORMATTED);
    internal static CreditCard InvalidCreditCard = new("", INVALID_CREDIT_CARD_NUMBER);
    #endregion

    #region Email
    internal static Email ValidEmail = new("lionel.messi@psg.com");
    internal static Email InvalidEmail = new("");
    #endregion

    #region Name
    internal static Name ValidName = new("Lionel", "Messi");
    internal static Name InvalidName = new("", "");
    #endregion

    #region Price
    internal static Price ValidPrice = new((decimal)12.34);
    internal static Price InvalidPrice = new(-1);
    #endregion

    #region Password
    internal static Password InvalidPassword = new("");
    internal static Password ValidPassword = new("Messi123@");
    #endregion

    #region Title
    internal static Title ValidTitle = new("Lionel Messi");
    internal static Title InvalidTitle = new("");
    #endregion

    #region Description
    internal static Description ValidDescription = new("Lionel Messi");
    internal static Description InvalidDescription = new("");
    #endregion

    #region Slug
    internal static Slug ValidSlug = new("lionel-messi");
    internal static Slug InvalidSlug = new("");
    #endregion

    #region Tag
    internal static Tag ValidTag = new("messi");
    internal static Tag InvalidTag = new("");
    #endregion

    #region Stock
    internal static Stock ValidStock = new(10);
    internal static Stock InvalidStock = new(-1);
    #endregion

    #region Customer

    internal static Customer InvalidCustomer = new(
        name: InvalidName,
        email: InvalidEmail,
        password: InvalidPassword,
        address: InvalidAddress
        );

    internal static Customer ValidCustomer = new(
        name: ValidName,
        email: ValidEmail,
        password: ValidPassword,
        address: ValidAddress
        );
    #endregion

    #region Order

    internal Order InvalidOrder = new(
        InvalidCustomer,
        new DateTime(2023, 02, 01)
        );

    internal Order ValidOrder = new(
        ValidCustomer,
        new DateTime(2023, 02, 01)
        );
    #endregion

    #region Product
    internal Product InvalidProduct = new(
        title: InvalidTitle,
        description: InvalidDescription,
        price: InvalidPrice,
        slug: InvalidSlug,
        stock: InvalidStock
        );

    internal Product ValidProduct = new(
        title: ValidTitle,
        description: ValidDescription,
        price: ValidPrice,
        slug: ValidSlug,
        stock: ValidStock
        );
    #endregion

    #region CreditCardPayment

    internal CreditCardPayment ValidCreditCardPayment = new(
            creditCard: ValidCreditCard,
            lastTransactionNumber: "3981321",
            paymentDate: new DateTime(2023, 12, 01),
            expirationDate: new DateTime(2023, 12, 20),
            total: ValidPrice,
            totalPaid: ValidPrice,
            payer: ValidName,
            address: ValidAddress,
            email: ValidEmail
        );

    internal CreditCardPayment InvalidCreditCardPayment = new(
           creditCard: InvalidCreditCard,
           lastTransactionNumber: "",
           paymentDate: DateTime.Now.AddDays(-1),
           expirationDate: new DateTime(2023, 02, 20),
           total: InvalidPrice,
           totalPaid: InvalidPrice,
           payer: InvalidName,
           address: InvalidAddress,
           email: InvalidEmail
       );
    #endregion
}