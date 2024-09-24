// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using ConsoleApp1;

List <Employee> employees = new List<Employee>();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("**********************");
Console.WriteLine("* HR Database App *");
Console.WriteLine("**********************");
Console.ForegroundColor = ConsoleColor.Blue;
string userSelection;
Helper.CheckForExistingEmployeeFile();
do
{
    Console.WriteLine("***************");
    Console.WriteLine("* Select an action *");
    Console.WriteLine("*****************");

    Console.WriteLine("1: Register employee");
    Console.WriteLine("2: View all employees");
    Console.WriteLine("3: Save data");
    Console.WriteLine("4: Load data");
    Console.WriteLine("9: Quit application");
    Console.Write("Your selection: ");

    userSelection = Console.ReadLine();
    switch (userSelection)
    {
        case "1":
            Helper.RegisterEmployee(employees);
            break;

        case "2":
        Helper.ViewAllEmployees(employees);
            break;

        case "3":
        Helper.SaveEmployees(employees);
            break;

        case "4":
        Helper.LoadEmployees(employees);
            break;

        case "9":
        Console.WriteLine("Method is not implemented yet");
            break;
         }
    }
        while (userSelection != "9");
        Console.WriteLine("Thanks for using the application");





