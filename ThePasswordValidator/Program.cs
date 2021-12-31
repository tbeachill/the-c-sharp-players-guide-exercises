PasswordValidator validator = new PasswordValidator();

while (true)
{
    Console.Write("Enter a password: ");
    string inputPassword = Console.ReadLine();

    if (validator.IsValid(inputPassword))
        Console.WriteLine("Valid");
    else
        Console.WriteLine("Invalid");
}

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (!ContainsLower(password)) return false;
        if (!ContainsUpper(password)) return false;
        if (!ContainsNumber(password)) return false;
        if (Contains(password, 'T')) return false;
        if (Contains(password, '&')) return false;

        return true;
    }

    private bool ContainsUpper(string password)
    {
        foreach (char character in password)
        {
            if (char.IsUpper(character))
            {
                return true;
            }
        }
        return false;
    }

    private bool ContainsLower(string password)
    {
        foreach (char character in password)
        {
            if (char.IsLower(character))
            {
                return true;
            }
        }
        return false;
    }

    private bool ContainsNumber(string password)
    {
        foreach (char character in password)
        {
            if (char.IsDigit(character))
            {
                return true;
            }
        }
        return false;
    }

    private bool Contains(string password, char letter)
    // check if a string contains a specific character
    {
        foreach (char character in password)
        {
            if (character == letter)
                return true;
        }
        return false;
    }
}