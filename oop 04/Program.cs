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

#region part 2 Q2 Override All System. Object Members [To String(), Equals(),GetHashCode() ]
public static class DurationOperators
{
    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(ToSeconds(d1) + ToSeconds(d2));
    }

    public static Duration operator +(Duration d1, int seconds)
    {
        return new Duration(ToSeconds(d1) + seconds);
    }

    public static Duration operator +(int seconds, Duration d1)
    {
        return new Duration(ToSeconds(d1) + seconds);
    }

    public static Duration operator ++(Duration d)
    {
        return new Duration(ToSeconds(d) + 60);
    }

    public static Duration operator --(Duration d)
    {
        return new Duration(ToSeconds(d) - 60);
    }

    public static Duration operator -(Duration d1, Duration d2)
    {
        return new Duration(ToSeconds(d1) - ToSeconds(d2));
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return ToSeconds(d1) > ToSeconds(d2);
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return ToSeconds(d1) < ToSeconds(d2);
    }

    public static bool operator <=(Duration d1, Duration d2)
    {
        return ToSeconds(d1) <= ToSeconds(d2);
    }

    public static bool operator >=(Duration d1, Duration d2)
    {
        return ToSeconds(d1) >= ToSeconds(d2);
    }

    public static bool operator true(Duration d)
    {
        return ToSeconds(d) > 0;
    }

    public static bool operator false(Duration d)
    {
        return ToSeconds(d) == 0;
    }

    public static explicit operator DateTime(Duration d)
    {
        return new DateTime().AddHours(d.Hours).AddMinutes(d.Minutes).AddSeconds(d.Seconds);
    }

    private static int ToSeconds(Duration d) => d.Hours * 3600 + d.Minutes * 60 + d.Seconds;
}
#endregion

#region part 2 Q3 Define All Required Constructors to Produce this output
class Program
{
    static void Main()
    {
        Duration D1 = new Duration(1, 10, 15);
        Console.WriteLine(D1.ToString()); // Hours: 1, Minutes :10, Seconds :15

        D1 = new Duration(3600);
        Console.WriteLine(D1.ToString()); // Hours: 1, Minutes :0, Seconds :0

        Duration D2 = new Duration(7800);
        Console.WriteLine(D2.ToString()); // Hours: 2, Minutes :10, Seconds :0

        Duration D3 = new Duration(666);
        Console.WriteLine(D3.ToString()); // Minutes :11, Seconds :6

        D3 = D1 + D2;
        Console.WriteLine(D3); // should display sum

        D3 = D1 + 7800;
        Console.WriteLine(D3);

        D3 = 666 + D3;
        Console.WriteLine(D3);

        D3 = ++D1;
        Console.WriteLine(D3);

        D3 = --D2;
        Console.WriteLine(D3);

        D1 = D1 - D2;
        Console.WriteLine(D1);

        if (D1 > D2) Console.WriteLine("D1 is greater");
        if (D1 <= D2) Console.WriteLine("D1 is less or equal");
        if (D1) Console.WriteLine("D1 has time");

        DateTime dt = (DateTime)D1;
        Console.WriteLine("Converted to DateTime: " + dt.ToLongTimeString());
    }
}
#endregion

class Program
{
    static void Main(string[] args)
    {
       
    }
}
