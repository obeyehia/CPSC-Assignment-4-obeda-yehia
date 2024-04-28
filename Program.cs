using client;

Client myClient = new Client();
List<Client> listOfClients = new List<Client>();


bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMenuOptions();
        string mainMenuChoice = Prompt("\nEnter main menu selection: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientBmiInfo(myClient);
        if (mainMenuChoice == "Q")
        {
            loopAgain = false;
            throw new Exception("Program ended, thank you.");
        }
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nWhat would you like to edit? ");
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("Returning to Main Menu");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void DisplayMenuOptions()
{
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("============");
    Console.WriteLine("[N]ew client");
    Console.WriteLine("[S]how client BMI info");
    Console.WriteLine("[E]dit client");
    Console.WriteLine("[Q]uit");
}

void DisplayEditMenu()
{
    Console.WriteLine("Edit client");
    Console.WriteLine("============");
    Console.WriteLine("[F]irst name");
    Console.WriteLine("[L]ast name");
    Console.WriteLine("[H]eight");
    Console.WriteLine("[W]eight");
    Console.WriteLine("[R]eturn to Main Menu");
}

void ShowClientBmiInfo(Client client)
{
    if (client == null)
        throw new Exception($"No client info stored");
    Console.WriteLine($"BMI Score: {client.BmiScore}");
    Console.WriteLine($"BMI Status: {client.BmiStatus}");
    Console.WriteLine($"Full Name: {client.FullName}");
}

string Prompt(string prompt)
{
    string myString = "";
    while (true)
    {
        try
        {
            Console.Write(prompt);
            myString = Console.ReadLine();
            if (string.IsNullOrEmpty(myString))
                throw new Exception($"Empty Input: Please enter something.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return myString;
}


double PromptDoubleBetweenMinMax(string msg, double min, double max)
{
    double num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max} inclusive: ");
            if (num < min || num > max)
                throw new Exception($"Must be between {min:n2} and {max:n2}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return num;
}

Client NewClient()
{
    Client newClient = new Client();
    GetFirstName(newClient);
    GetLastName(newClient);
    GetWeight(newClient);
    GetHeight(newClient);
    Console.WriteLine("Client info successfully entered");
    return newClient;
}

void GetFirstName(Client client)
{
    string myString = Prompt($"Enter client's first name: ");
    client.FirstName = myString;
}

void GetLastName(Client client)
{
    string myString = Prompt($"Enter client's last name: ");
    client.LastName = myString;
}

void GetWeight(Client client)
{
    double myDouble = PromptDoubleBetweenMinMax($"Enter Weight in pounds: ", 0, 1500);
    client.Weight = myDouble;
}


void GetHeight(Client client)
{
    double myDouble = PromptDoubleBetweenMinMax($"Enter Height in inches: ", 0, 1500);
    client.Height = myDouble;
}