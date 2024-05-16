// Console Password Generator
using System;

class Strings
{
    public static readonly string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static readonly string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
    public static readonly string Digits = "0123456789";
    public static readonly string SpecialCharacters = "!@#$%^&*()";
}

class BaseRandomGen
{
    private Random random = new Random();

    public string GenerateRandomString(int length)
    {
        string allCharacters = Strings.UppercaseLetters + Strings.LowercaseLetters + Strings.Digits + Strings.SpecialCharacters;
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            int randomIndex = random.Next(0, allCharacters.Length);
            password[i] = allCharacters[randomIndex];
        }

        return new string(password);
    }
}

class CharacterPrinter
{
    public void PrintCharacter(char symbol, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(symbol);
        }
        Console.WriteLine();
    }
}

class ConsolePasswordGeneratorApp
{
    static void Main(string[] args)
    {
        Console.WriteLine("*** Console Password Generator ***");
        BaseRandomGen baseRandomGen = new BaseRandomGen();
        string password = "";
        Console.WriteLine("Введите длину пароля: ");
        CharacterPrinter printer = new CharacterPrinter();
        printer.PrintCharacter('-', 23);
        int passwordLength = 0;
        try
        {
            passwordLength = Convert.ToInt32(Console.ReadLine());
            printer.PrintCharacter('-', 23);
        }
        catch (Exception e)
        {
            printer.PrintCharacter('-', 23);
            passwordLength = 12;
            Console.WriteLine("Ошибка! Вы не ввели длину пароля. Использую 12 символов.");
            printer.PrintCharacter('-', 23);
        }
        if (passwordLength <= 0)
        {
            passwordLength = 12;
            Console.WriteLine("Ошибка! Неверная длина пароля. Использую 12 символов.");
            printer.PrintCharacter('-', 23);
        }
        else if (passwordLength > 1000)
        {
            passwordLength = 1000;
            Console.WriteLine("Ошибка! Пароль не может быть длинее 1000 символов. Использую 1000 символов.");
            printer.PrintCharacter('-', 23);
        }
        password = baseRandomGen.GenerateRandomString(passwordLength);
        Console.WriteLine(password);
        printer.PrintCharacter('-', 23);
        Console.WriteLine("Нажмите <Enter> для выхода...");
        Console.Read();
        printer.PrintCharacter('-', 23);
        Console.WriteLine("=== Smart Legion Lab ===");
    }
}