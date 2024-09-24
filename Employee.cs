using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace HRFileApplication {

    internal class Employee
        {
        public string name;
        public int age;
        public Employee (string firstName, int ageGiven)
        
        {
            name = firstName;
            age = ageGiven; 
        }
            }
}

    internal class Employee
    {
        public string firstName;
        public string lastName;
        public string email;

        public int age;
        public int numberOfHoursWorked;
        public double hourlyWage;
        public double wage;

        public DateTime birthday;

        const int minimalHoursWorked = 1;

public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }
 
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }
 
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
 
        public int NumberOfHoursWorked
        {
            get { return numberOfHoursWorked; }
            protected set
            {
                numberOfHoursWorked = value;
            }
        }

        public double HourlyWage
        {
            get { return hourlyWage;}
            protected set
            {
                hourlyWage = value;
            }
        }
        public DateTime BirthDay
        {
            get { return birthday; }
            set
            {
                birthday = value;
            }
        }
        

        public Employee(string first, string last, string em, DateTime bd) : this(first, last, em, bd, 0) // Constructor chaining - Вызов другого конструктора внутри конструктора - например, создаем волонтера в системе с нулевой ставкой оплаты
        {

        }

        public Employee(string first, string last, string em, DateTime bd, double rate)
        {
            firstName = first;
            lastName = last;
            email = em;
            birthday = bd;
            hourlyWage = rate;
        }

        public void PerformWork()
        {
            //numberOfHoursWorked++; // Increment the number of hours worked by 1 hour - Увеличиваем кол-во отработанных часов на 1 час
            PerformWork(minimalHoursWorked); // Вызываем метод PerformWork(int numberOfHours) и передаем в него 1
        }

        public void PerformWork(int numberOfHours)
        {
            numberOfHoursWorked += numberOfHours; // Increment the number of hours worked by the number of hours specified - Увеличиваем кол-во отработанных часов на указанное кол-во часов
            Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHoursWorked} hours");
        }

        // malika.ReceiveWage(true); malika.ReceiveWAge() - эти две строки кода делают одно и тоже, т.к. параметр resetHours - опциональный и по умолчанию = true
        public double ReceiveWage(bool resetHours = true)
        {
            wage = numberOfHoursWorked * hourlyWage;
            Console.WriteLine($"{firstName} {lastName} has received a wage of {wage} for {numberOfHoursWorked} hours of work. ");

            if (resetHours) // (resetHours == true) тоже самое что (resetHours), т.к. оба выражения вернут true
            {
                numberOfHoursWorked = 0;
            }

            return wage;
        }

        public void DisplayEmployeeInformation()
        {
            Console.WriteLine($"\nFirst Name:\t{firstName}\nLast Name:\t{lastName}\nEmail:\t{email}\nBirthday:\t{birthday.ToShortDateString()}\n");
        }


    }
