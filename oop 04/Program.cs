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

class Program
{
    static void Main(string[] args)
    {
       
    }
}
