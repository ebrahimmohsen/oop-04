using System;

namespace oop_04;

#region part 1  Q1 Write a class named Calculator that contains a method named Add. Overload the Add method
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}

#endregion


#region part 1 Q2 Create a class named Rectangle with the following constructors
class Rectangle
{
    int width, height;

    public Rectangle()
    {
        width = 0;
        height = 0;
    }

    public Rectangle(int w, int h)
    {
        width = w;
        height = h;
    }

    public Rectangle(int size)
    {
        width = height = size;
    }
}

#endregion

#region part 1 Q3 Define a class Complex Number that represents a complex number with real and imaginary parts.

class ComplexNumber
{
    public int Real { get; set; }
    public int Imaginary { get; set; }

    public ComplexNumber(int r, int i)
    {
        Real = r;
        Imaginary = i;
    }

    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}
#endregion

#region part 1 Q4 a- Create a base class named Employee with method That Work as it prints    "Employee is  working".
b- Create a derived class named Manager that overrides the Work method to print "Manager is managing". 

    class Employee
{
    public virtual void Work()
    {
        Console.WriteLine("Employee is working");
    }
}

class Manager : Employee
{
    public override void Work()
    {
        base.Work();
        Console.WriteLine("Manager is managing");
    }
}
#endregion

#region part1 Q5 a) Create a base class BaseClass with a virtual method DisplayMessage that prints  "Message from BaseClass".

b) Create a derived class DerivedClass1 that overrides the DisplayMessage method using the override keyword.

C) Create another derived class DerivedClass2 that hides the DisplayMessage method using the new keyword.

    class BaseClass
{
    public virtual void DisplayMessage()
    {
        Console.WriteLine("Message from BaseClass");
    }
}

class DerivedClass1 : BaseClass
{
    public override void DisplayMessage()
    {
        Console.WriteLine("Message from DerivedClass1 (override)");
    }
}

class DerivedClass2 : BaseClass
{
    public new void DisplayMessage()
    {
        Console.WriteLine("Message from DerivedClass2 (new)");
    }
}

#endregion

# region part2 Q1 Define Class Duration To include Three Attributes Hours, Minutes and Seconds
class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Duration() { }

    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        totalSeconds %= 3600;
        Minutes = totalSeconds / 60;
        Seconds = totalSeconds % 60;
    }

    public override string ToString()
    {
        string result = "";
        if (Hours > 0) result += $"Hours: {Hours}, ";
        if (Minutes > 0 || Hours > 0) result += $"Minutes :{Minutes}, ";
        result += $"Seconds :{Seconds}";
        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj is Duration other)
            return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        return false;
    }

    public override int GetHashCode()
    {
        return (Hours, Minutes, Seconds).GetHashCode();
    }
}
#endregion

class Program
{
    static void Main(string[] args)
    {
       
    }
}
