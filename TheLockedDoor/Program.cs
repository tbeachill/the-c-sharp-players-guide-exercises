Console.Write("Enter a numeric password: ");
string password = Console.ReadLine();
Door newDoor = new Door(password);

while (true)
{
    Console.WriteLine();
    PromptInput(newDoor);
}

void PromptInput(Door newDoor)
{
    Console.Write("What do you want to do (open, close, lock, unlock, changepass): ");
    string userInput = Console.ReadLine();

    switch (userInput)
    { 
        case "open":
            newDoor.Open();
            break;
        case "close":
            newDoor.Close();
            break;
        case "lock":
            newDoor.Lock();
            break;
        case "unlock":
            newDoor.Unlock();
            break;
        case "changepass":
            newDoor.ChangePassword();
            break;
        default:
            Console.WriteLine("You can't do that.");
            break;
    }
}

public class Door
{
    public DoorState doorState;
    private int password;

    public Door(string password)
    {
        bool success = int.TryParse(password, out int intPassword);
        if (success)
        {
            this.password = intPassword;
            doorState = DoorState.Locked;
            Console.WriteLine("Password set.");
        }
        else
        {
            Console.WriteLine("Only numeric passwords allowed.");
        }
        
    }

    public void ChangePassword()
    {
        while (true)
        {
            Console.Write("Enter the current password: ");
            string oldPassword = Console.ReadLine();
            bool oldSuccess = int.TryParse(oldPassword, out int intOldPassword);

            if (oldSuccess && intOldPassword == this.password)
            {
                while (true)
                {
                    Console.Write("Enter a new password: ");
                    string newPassword = Console.ReadLine();
                    bool newSuccess = int.TryParse(newPassword, out int intNewPassword);
                    if (newSuccess)
                    {
                        this.password = intNewPassword;
                        Console.WriteLine("New password set.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Only numeric passwords allowed.");
                    }
                }
            }
            else if (oldPassword == "exit")
            {
                return;
            }
            else
            {
                Console.WriteLine("Incorrect password.");
            }
        }
    }

    public void Unlock()
    {
        if (this.doorState == DoorState.Locked)
        {
            while (true)
            {
                Console.Write("Enter the password: ");
                string password = Console.ReadLine();
                bool success = int.TryParse(password, out int intPassword);

                if (success && intPassword == this.password)
                {
                    this.doorState = DoorState.Closed;
                    Console.WriteLine("You have unlocked the door.");
                    return;
                }
                else if (password == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password.");
                }
            }
        }
        else
        {
                Console.WriteLine($"You can't do that. The door is currently {this.doorState.ToString().ToLower()}.");
        }
    }

    public void Lock()
    {
        if (this.doorState == DoorState.Closed)
        {
            this.doorState = DoorState.Locked;
            Console.WriteLine("You have locked the door.");
        }
        else
        {
            Console.WriteLine($"You can't do that. The door is currently {this.doorState.ToString().ToLower()}.");
        }
    }

    public void Open()
    {
        if (this.doorState == DoorState.Closed)
        {
            this.doorState = DoorState.Open;
            Console.WriteLine("You have opened the door.");
        }
        else
        {
            Console.WriteLine($"You can't do that. The door is currently {this.doorState.ToString().ToLower()}.");
        }
    }

    public void Close()
    {
        if (this.doorState == DoorState.Open)
        {
            this.doorState = DoorState.Closed;
            Console.WriteLine("You have closed the door.");
        }
        else
        {
            Console.WriteLine($"You can't do that. The door is currently {this.doorState.ToString().ToLower()}.");
        }
    }
    public enum DoorState { Locked, Open, Closed }
}