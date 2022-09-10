using System.Globalization;
using FluentAssertions;

namespace Mc2.CrudTest.Test.Unit.Tests;

using Domain.Entities;
using Xunit;

public class CustomerTests
{
    [Theory]
    [InlineData("James", "Williams", "2011-03-21", "98-21-56870145", "James_Williams_1987@gmail.com",
        "112233445566778899")]
    [InlineData("Robert", "Brown", "1990-12-29", "33-18-05936587", "Robert.Brown_3698@outlook.com",
        "996633558877441122")]
    public void Should_create_one_of_it(string firstname, string lastname, string dateOfBirthString, string phoneNumber,
        string email, string bankAccountNumber)
    {
        //arrange
        var dateOfBirth = DateTime.ParseExact(dateOfBirthString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        //act
        Customer customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);

        //assert
        customer.Firstname.Should().Be(firstname);
        customer.Lastname.Should().Be(lastname);
        customer.DateOfBirth.Should().Be(dateOfBirth);
        customer.PhoneNumber.Should().Be(phoneNumber);
        customer.Email.Should().Be(email);
        customer.BankAccountNumber.Should().Be(bankAccountNumber);
    }

    [Theory]
    [InlineData("James", "Williams", "2011-03-21", "98-21-56870145", "James_Williams_1987@gmail.com",
        "112233445566778899")]
    [InlineData("Robert", "Brown", "1990-12-29", "33-18-05936587", "Robert.Brown_3698@outlook.com",
        "996633558877441122")]
    public void Should_edit_correctly(string firstname, string lastname, string dateOfBirthString, string phoneNumber,
        string email, string bankAccountNumber)
    {
        //arrange
        var dateOfBirth = DateTime.ParseExact(dateOfBirthString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        //act
        Customer customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);
        var randomString = Guid.NewGuid().ToString("N").Substring(0, 5);

        var firstnameChanged = firstname + randomString;
        var lastnameChanged = lastname + randomString;
        var dateOfBirthChanged = dateOfBirth.AddDays(10);
        var phoneNumberChanged = ReplaceNumber(phoneNumber);
        var emailChanged = ChangeEmail(email);
        var bankAccountNumberChanged = ReplaceNumber(bankAccountNumber);

        customer.UpdateMinor(firstnameChanged, lastnameChanged, dateOfBirthChanged);
        customer.UpdateMajor(phoneNumberChanged, emailChanged, bankAccountNumberChanged);

        //assert
        customer.Firstname.Should().Be(firstnameChanged);
        customer.Lastname.Should().Be(lastnameChanged);
        customer.DateOfBirth.Should().Be(dateOfBirthChanged);
        customer.PhoneNumber.Should().Be(phoneNumberChanged);
        customer.Email.Should().Be(emailChanged);
        customer.BankAccountNumber.Should().Be(bankAccountNumberChanged);
    }

    private string ReplaceNumber(string str)
    {
        return str.Replace("0", "9").Replace("1", "8").Replace("2", "7").Replace("3", "6").Replace("4", "5")
            .Replace("5", "4").Replace("6", "3").Replace("7", "2").Replace("8", "1").Replace("9", "0");
    }

    private string ChangeEmail(string email)
    {
        email = email.Substring(0,email.IndexOf("@", StringComparison.CurrentCulture));
        email = $"{email}@{Guid.NewGuid().ToString("N").Substring(0, 5)}.com";
        return email;
    }
}