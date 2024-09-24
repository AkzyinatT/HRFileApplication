using System.Text;
namespace ConsoleApp1;

internal class Helper
{
    private static string directory = @"/Users/akzyinat/Desktop/HRFileApp/";
    static string fileName = "employee.txt";
        
    internal static void RegisterEmployee(List<Employee> employees)
    {
        
        Console.WriteLine("Creating an employee");
        Console.WriteLine("Enter the first name: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter the last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter the email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter the birth day: ");
        DateTime birthDay = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter the hourly rate: ");
        string hourlyRate = Console.ReadLine();
        double rate = double.Parse(hourlyRate);


        Employee employee = new Employee(firstName, lastName, email, birthDay, rate);

        employees.Add(employee);
        Console.WriteLine("Employee is succesfully created!\n");
    }
    internal static void CheckForExistingEmployeeFile()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string path = $"{directory}{fileName}";
        bool existingFileFound = File.Exists(path);
        if (existingFileFound)
        {
                Console.WriteLine("An existing file with Employee data is found");   
        }
        else
        {
            if (!Directory.Exists(path))
            Directory.CreateDirectory(directory);
            Console.WriteLine("Directory is ready for saving files.");
        }
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    internal static void ViewAllEmployees(List<Employee> employees)
    {
        for (int i = 0; i < employees.Count; i++)
        {
                employees[i].DisplayEmployeeInformation();
        }
    }

    internal static void LoadEmployees(List<Employee> employees)
    {
        string path = $"{directory}{fileName}";
        if (File.Exists(path))
        {
            employees.Clear();
            string[] employeesAsString = File.ReadAllLines(path);
            for (int i = 0; i < employeesAsString.Length; i ++)
            {

            // employeeSplits - массив из элементов:
            // employeeSplits[0] - firstName: Azhar
            // employeeSplits[1] - lastName: Kazakbaeva
            // employeeSplits[2] - email: ajara @gmail.com
            // employeeSplits[3] - birthDay: 10 / 22 / 1993
            // employeeSplits[4] - hourlyRate: 20
            
            // substring - string phrase = "HelloWorld" 
            // World
            // string mySubstring = phrase.Substring(5); - World
            // OR
            // string mySubstring = phrase.Substring(phrase.IndexOf('o') + 1); - World
                string[] employeeSplits = employeesAsString[i].Split(';');
                string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);
                string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));

                Employee employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                employees.Add(employee);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
            Console.ResetColor();
        }  
    }

    internal static void SaveEmployees(List<Employee> employees)
    {
    string path = $"{directory}{fileName}";
    StringBuilder sb = new StringBuilder();

    foreach (var employee in employees)
    {
        sb.Append($"firstName:{employee.FirstName};");
        sb.Append($"lastName:{employee.LastName};");
        sb.Append($"email: {employee.Email};");
        sb.Append($"birthDay:{employee.BirthDay.ToShortDateString()};");
        sb.Append($"hourlyRate:{employee.HourlyWage};");
        sb.Append(Environment.NewLine);
    }
File.WriteAllText(path, sb.ToString());
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Saved employees succesfully");
Console.ResetColor();

}
}