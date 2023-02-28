// See https://aka.ms/new-console-template for more information
using e4.ConsoleApp;

Console.Write("Enter numbers separated by commas: ");
string input = Console.ReadLine();

try
{
    int result = StringCalculator.Add(input);
    Console.WriteLine($"The sum is: {result}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
