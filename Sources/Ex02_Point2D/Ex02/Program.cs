using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Program
    {
struct Struct_2D
{
    //Initialized to default values
    public double x;
    public double y;
}

struct Struct_o_2D
{
    #region private data members

    private double x;
    private double y;

    #endregion

    public double X
    {
        get { return x; }
    }
    public double Y
    {
        get { return y; }
    }

    public double radius
    {
        get
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
    public double phi
    {
        get
        {
            return Math.Atan2(x, y) * (180.0 / Math.PI);
        }
    }

    public void setEucledian(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public void setPolar(double phi, double radius)
    {
        phi = phi * (Math.PI / 180);
        this.x = Math.Sin(phi) * radius;
        this.y = Math.Cos(phi) * radius;
    }
}

class Point_2D
{
    #region private data members

    private double x = default(double);
    private double y = default(double);

    #endregion

    public double X
    {
        get { return x; }
    } 
    public double Y
    {
        get { return y; }
    }

    public double radius
    {
        get
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
    public double phi
    {
        get
        {
            return Math.Atan2(x, y) * (180.0 / Math.PI);
        }
    }

    public void setEucledian(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public void setPolar(double phi, double radius)
    {
        phi = phi * (Math.PI / 180);
        this.x = Math.Sin(phi) * radius;
        this.y = Math.Cos(phi) * radius;
    }

}

static double radius(double x, double y)
{
    return Math.Sqrt(x * x + y * y);
}

static double phi(double x, double y)
{
    return Math.Atan2(x, y) * (180.0 / Math.PI);
}

static void Main(string[] args)
{
    double x, y;
    x = 5;
    y = 8;
    Console.WriteLine(string.Format("Vars: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", x, y, phi(x, y), radius(x, y)));


    Struct_2D s = new Struct_2D();
    s.x = 5;
    s.y = 8;
    Console.WriteLine(string.Format("Struct: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", s.x, s.y, phi(s.x, s.y), radius(s.x, s.y)));

    Console.WriteLine();

    Point_2D p1 = new Point_2D();
    p1.setEucledian(5, 8);
    Console.WriteLine(string.Format("P1: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", p1.X, p1.Y, p1.phi, p1.radius));


    Point_2D p2 = new Point_2D();
    p2.setPolar(32.01, 9.434);
    Console.WriteLine(string.Format("P2: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", p2.X, p2.Y, p2.phi, p2.radius));

    Console.WriteLine();

    Struct_o_2D so = new Struct_o_2D();
    so.setEucledian(5, 8);
    Console.WriteLine(string.Format("StructObj: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", so.X, so.Y, so.phi, so.radius));

    Console.WriteLine();

    Struct_o_2D soTemp = so;
    Point_2D pTemp = p2;
    Console.WriteLine(string.Format("STemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", soTemp.X, soTemp.Y, soTemp.phi, soTemp.radius));
    Console.WriteLine(string.Format("PTemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", pTemp.X, pTemp.Y, pTemp.phi, pTemp.radius));

    so.setEucledian(3, 3);
    p2.setEucledian(3, 3);

    Console.WriteLine();

    Console.WriteLine(string.Format("STemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", soTemp.X, soTemp.Y, soTemp.phi, soTemp.radius));
    Console.WriteLine(string.Format("PTemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", pTemp.X, pTemp.Y, pTemp.phi, pTemp.radius));

    Console.WriteLine();
}
    }
}
