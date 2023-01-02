using GoStore.Domain.Enums;
using GoStore.Domain.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Reflection.Emit;

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
    internal static Password ValidPassword = new("Messi123@");
    #endregion
}