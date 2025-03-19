using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Enter the length of the password: ");
        if (int.TryParse(Console.ReadLine(), out int length) && length > 0)
        {
            string password = GeneratePassword(length);
            Console.WriteLine($"Generated Password: {password}");
        }
        else
        {
            Console.WriteLine("Invalid num, enter positive number ");
        }
        Console.ReadKey();
    }

    static string GeneratePassword(int length)
    {
        const string digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder password = new StringBuilder();
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            password.Append(digits[random.Next(digits.Length)]);
        }

        return password.ToString();
    }
}

