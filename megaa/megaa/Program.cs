
class Program
{
    static void Main()
    {
        Console.Write("Enter birthdate like this (yyyy-mm-dd) ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(age))
                age--;

            Console.WriteLine($"Your age is  {age}");
        }
        else
        {
            Console.WriteLine("Invalid date format");
        }
        Console.ReadKey();
    }
}
