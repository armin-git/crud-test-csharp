namespace Mc2.CrudTest.Domain.Entities;

using System.Text.RegularExpressions;
using Exceptions;
using Base;

public class Customer : Entity<int>
{
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    public Customer(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email,
        string bankAccountNumber)
    {
        CheckPhoneNumber(phoneNumber);
        CheckEmail(email);
        CheckBankAccountNumber(bankAccountNumber);

        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public Customer UpdateMinor(string firstname, string lastname, DateTime dateOfBirth)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        
        return this;
    }

    public Customer UpdateMajor(string phoneNumber, string email,
        string bankAccountNumber)
    {
        CheckPhoneNumber(phoneNumber);
        CheckEmail(email);
        CheckBankAccountNumber(bankAccountNumber);
        
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        
        return this;
    }
    void CheckPhoneNumber(string phoneNumber)
    {
        string motif = @"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{8})$";
        if (string.IsNullOrEmpty(phoneNumber))
            throw new PropertyNullException<Customer>(nameof(phoneNumber));
        if (!Regex.IsMatch(phoneNumber, motif))
            throw new PropertyBadFormatException<Customer>(nameof(phoneNumber));
    }
    void CheckEmail(string email)
    {
        string motif = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        if (string.IsNullOrEmpty(email))
            throw new PropertyNullException<Customer>(nameof(email));
        if (!Regex.IsMatch(email, motif))
            throw new PropertyBadFormatException<Customer>(nameof(email));
    }
    void CheckBankAccountNumber(string bankAccountNumber)
    {
        string motif = @"^[0-9]{12,18}$";
        if (string.IsNullOrEmpty(bankAccountNumber))
            throw new PropertyNullException<Customer>(nameof(bankAccountNumber));
        if (!Regex.IsMatch(bankAccountNumber, motif))
            throw new PropertyBadFormatException<Customer>(nameof(bankAccountNumber));
    }
}