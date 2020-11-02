using Inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces {
    class Program {
        static void Main(string[] args) {
            Rectangle rect = new Rectangle();
            Circle circle = new Circle();
            Triangle tri = new Triangle();

            Console.WriteLine("Enter a number to select a shape: \n0 - Circle \n1 - Rectangle \n2 - Triangle");
            int answer = Int32.Parse(Console.ReadLine());

            switch (answer) {
                case 0:
                    Console.WriteLine("Enter the radius of the circle: ");
                    double radius = Double.Parse(Console.ReadLine());
                    circle.radius = radius;
                    circle.displayDetails();
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine("Enter the width of the rectangle: ");
                    double width = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the height of the rectangle: ");
                    double height = Double.Parse(Console.ReadLine());
                    rect.height = height;
                    rect.width = width;
                    rect.displayDetails();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter the base of the triangle: ");
                    double @base = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the height of the triangle: ");
                    double triHeight = Double.Parse(Console.ReadLine());
                    tri.@base = @base;
                    tri.height = triHeight;

                    Console.WriteLine("Enter the length of the first side of the triangle: ");
                    double sideA = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the length of the second side of the triangle: ");
                    double sideB = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the length of the third side of the triangle: ");
                    double sideC = Double.Parse(Console.ReadLine());
                    tri.displayDetails();
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
}
