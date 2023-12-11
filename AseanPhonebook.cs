using System;
using System.Collections.Generic;
using System.Linq;
//This is when the we need get and setter to work
class Student
{
    public string StudentNumber { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Occupation { get; set; }
    public char Gender { get; set; }
    public int CountryCode { get; set; }
    public int AreaCode { get; set; }
    public string PhoneNumber { get; set; }
}
//class program initialize command prompt
class Program
{
    static List<Student> phonebook = new List<Student>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");

            Console.Write("Enter choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    StoreToPhonebook();
                    break;
                case 2:
                    EditEntry();
                    break;
                case 3:
                    SearchByCountry();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void StoreToPhonebook()
    {
        do
        {
            Student student = new Student();

            Console.Write("Enter student number: ");
            student.StudentNumber = Console.ReadLine();

            Console.Write("Enter surname: ");
            student.Surname = Console.ReadLine();

            Console.Write("Enter first name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Enter occupation: ");
            student.Occupation = Console.ReadLine();

            Console.Write("Enter gender (M for male, F for female): ");
            if (char.TryParse(Console.ReadLine(), out char gender))
            {
                student.Gender = gender;
            }
            else
            {
                Console.WriteLine("Invalid gender. Please enter 'M' for male or 'F' for female.");
                continue;
            }

            Console.Write("Enter country code: ");
            if (int.TryParse(Console.ReadLine(), out int countryCode))
            {
                student.CountryCode = countryCode;
            }
            else
            {
                Console.WriteLine("Invalid country code. Please enter a valid number.");
                continue;
            }

            Console.Write("Enter area code: ");
            if (int.TryParse(Console.ReadLine(), out int areaCode))
            {
                student.AreaCode = areaCode;
            }
            else
            {
                Console.WriteLine("Invalid area code. Please enter a valid number.");
                continue;
            }

            Console.Write("Enter number: ");
            student.PhoneNumber = Console.ReadLine();

            phonebook.Add(student);

            Console.Write("Do you want to enter another entry [Y/N]? ");
        } while (Console.ReadLine()?.ToUpper() == "Y");
    }

    //To edit the info
    static void EditEntry()
    {
        Console.Write("Enter student number: ");
        string studentNumber = Console.ReadLine();

        Student student = phonebook.Find(s => s.StudentNumber == studentNumber);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        do
        {
            Console.WriteLine($"Here is the existing information about {student.StudentNumber}: {student.FirstName} {student.Surname} is a {student.Occupation}. His/Her number is {student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}");

            Console.WriteLine("\nWhich of the following information do you wish to change?");
            Console.WriteLine("[1] Student number [2] Surname [3] Gender [4] Occupation");
            Console.WriteLine("[5] Country code [6] Area code [7] Phone number [8] None Go back to main menu");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new student number: ");
                    student.StudentNumber = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new surname: ");
                    student.Surname = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter new gender (M for male, F for female): ");
                    student.Gender = char.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Enter new occupation: ");
                    student.Occupation = Console.ReadLine();
                    break;
                case 5:
                    Console.Write("Enter new country code: ");
                    student.CountryCode = int.Parse(Console.ReadLine());
                    break;
                case 6:
                    Console.Write("Enter new area code: ");
                    student.AreaCode = int.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.Write("Enter new phone number: ");
                    student.PhoneNumber = Console.ReadLine();
                    break;
                case 8:
                    return; // Go back to the main menu
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine($"Updated information: {student.FirstName} {student.Surname} is a {student.Occupation}. His/Her number is {student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}");
        } while (true);
    }
//To search datas in countries
    static void SearchByCountry()
    {
        List<Student> selectedStudents = new List<Student>();

        do
        {
            Console.WriteLine("\nFrom which country:");
            Console.WriteLine("[1] Philippines [2] Thailand [3] Singapore [4] Indonesia [5] Malaysia [6] ALL [0] No More");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
                break;

            int countryCode = GetCountryCode(choice);
            selectedStudents.AddRange(phonebook.Where(s => s.CountryCode == countryCode));
        } while (true);

        if (selectedStudents.Count == 0)
        {
            Console.WriteLine("No students found for the selected countries.");
            return;
        }

        selectedStudents = selectedStudents.OrderBy(s => s.Surname).ToList();

        Console.WriteLine("\nHere are the students:");

        foreach (var student in selectedStudents)
        {
            Console.WriteLine($"{student.Surname}, {student.FirstName}, with student number {student.StudentNumber}, is a {student.Occupation}. His/Her phone number is {student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}\n");
        }
    }
//Country code so it will detect a students or persons info
    static int GetCountryCode(int choice)
    {
        switch (choice)
        {
            case 1: return 63; // Philippines
            case 2: return 66; // Thailand
            case 3: return 65; // Singapore
            case 4: return 62; // Indonesia
            case 5: return 60; // Malaysia
            case 6: return 0;  // ALL
            default: return 0;
        }
    }
}
