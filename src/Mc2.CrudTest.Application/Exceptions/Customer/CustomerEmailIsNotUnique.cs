namespace Mc2.CrudTest.Application.Exceptions.Customer;

public class CustomerEmailIsNotUnique : Exception
{
    public CustomerEmailIsNotUnique(string email) :
        base($"customer {email} is duplicated")
    {
    }
}