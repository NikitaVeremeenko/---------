using System;

// Определяем интерфейс IMath
interface IMath
{
    double Add(double x, double y);
    double Subtract(double x, double y);
    double Multiply(double x, double y);
    double Divide(double x, double y);
}

class Program
{
    // Определяем делегаты для математических операций
    delegate double MathOperation(double x, double y);

    static void Main(string[] args)
    {
        // Создаем экземпляр класса, который реализует интерфейс IMath
        MathClass mathClass = new MathClass();

        // Создаем список делегатов для математических операций
        MathOperation[] mathOperations = new MathOperation[]
        {
            new MathOperation(mathClass.Add),
            new MathOperation(mathClass.Subtract),
            new MathOperation(mathClass.Multiply),
            new MathOperation(mathClass.Divide)
        };

        // Выводим список операций
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("1. Сложение (+)");
        Console.WriteLine("2. Вычитание (-)");
        Console.WriteLine("3. Умножение (*)");
        Console.WriteLine("4. Деление (/)");

        // Получаем выбор пользователя
        int choice = int.Parse(Console.ReadLine());

        // Получаем два числа от пользователя
        Console.WriteLine("Введите первое число:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        double y = double.Parse(Console.ReadLine());

        // Вызываем соответствующий делегат и выводим результат
        double result = mathOperations[choice - 1](x, y);
        Console.WriteLine("Результат: " + result);

        Console.ReadKey();
    }
}

// Класс, реализующий интерфейс IMath
class MathClass : IMath
{
    public double Add(double x, double y)
    {
        return x + y;
    }

    public double Subtract(double x, double y)
    {
        return x - y;
    }

    public double Multiply(double x, double y)
    {
        return x * y;
    }

    public double Divide(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException();
        }
        return x / y;
    }
}
