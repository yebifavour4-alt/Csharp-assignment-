using System;

namespace GeometryCalculator
{
    class Program
    {
        // 1) Area methods

        // Circle: A = πr²
        static double AreaOfCircle(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        // Triangle: A = ½ * b * h
        static double AreaOfTriangle(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }

        // Square: A = L²
        static double AreaOfSquare(double side)
        {
            return Math.Pow(side, 2);
        }

        // Rectangle: A = l * b
        static double AreaOfRectangle(double length, double breadth)
        {
            return length * breadth;
        }

        // 2) Quadratic formula: x = (-b ± √(b² - 4ac)) / 2a
        // Returns the real roots (0, 1 or 2 values)
        static double[] SolveQuadratic(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("'a' cannot be zero in a quadratic equation.");

            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
                return new double[0]; // no real roots

            if (discriminant == 0)
                return new double[] { -b / (2 * a) }; // one repeated root

            double sqrtD = Math.Sqrt(discriminant);
            double x1 = (-b + sqrtD) / (2 * a);
            double x2 = (-b - sqrtD) / (2 * a);
            return new double[] { x1, x2 };
        }

        static double ReadNumber(string prompt)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. " + prompt);
            }
            return value;
        }

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Area of Circle");
                Console.WriteLine("2. Area of Triangle");
                Console.WriteLine("3. Area of Square");
                Console.WriteLine("4. Area of Rectangle");
                Console.WriteLine("5. Quadratic Formula");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        double r = ReadNumber("Enter radius: ");
                        Console.WriteLine($"Area of circle = {AreaOfCircle(r):F2}");
                        break;

                    case "2":
                        double bs = ReadNumber("Enter base: ");
                        double h = ReadNumber("Enter height: ");
                        Console.WriteLine($"Area of triangle = {AreaOfTriangle(bs, h):F2}");
                        break;

                    case "3":
                        double l = ReadNumber("Enter side length: ");
                        Console.WriteLine($"Area of square = {AreaOfSquare(l):F2}");
                        break;

                    case "4":
                        double len = ReadNumber("Enter length: ");
                        double br = ReadNumber("Enter breadth: ");
                        Console.WriteLine($"Area of rectangle = {AreaOfRectangle(len, br):F2}");
                        break;

                    case "5":
                        double a = ReadNumber("Enter a: ");
                        double b = ReadNumber("Enter b: ");
                        double c = ReadNumber("Enter c: ");
                        try
                        {
                            double[] roots = SolveQuadratic(a, b, c);
                            if (roots.Length == 0)
                                Console.WriteLine("No real roots (discriminant is negative).");
                            else if (roots.Length == 1)
                                Console.WriteLine($"One repeated root: x = {roots[0]:F2}");
                            else
                                Console.WriteLine($"x1 = {roots[0]:F2}, x2 = {roots[1]:F2}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
