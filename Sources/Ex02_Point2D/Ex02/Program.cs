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
            //global data
            double x, y;
            x = 5;
            y = 8;
            Console.WriteLine(string.Format("Vars: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", x, y, phi(x, y), radius(x, y)));

            //Struct
            Struct_2D s = new Struct_2D();
            s.x = 5;
            s.y = 8;
            Console.WriteLine(string.Format("Struct: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", s.x, s.y, phi(s.x, s.y), radius(s.x, s.y)));

            Console.WriteLine();
            //Object
            Point_2D o1 = new Point_2D();
            o1.setEucledian(5, 8);
            Console.WriteLine(string.Format("O1: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", o1.X, o1.Y, o1.phi, o1.radius));

            Point_2D o2 = new Point_2D();
            o2.setPolar(32.01, 9.434);
            Console.WriteLine(string.Format("O2: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", o2.X, o2.Y, o2.phi, o2.radius));

            Console.WriteLine();
            //Object like structure
            Struct_o_2D so = new Struct_o_2D();
            so.setEucledian(5, 8);
            Console.WriteLine(string.Format("Obj like struct: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", so.X, so.Y, so.phi, so.radius));

            Console.WriteLine();
            //Difference between structures and objects
            Struct_o_2D soTemp = so;
            Point_2D oTemp = o2;
            Console.WriteLine(string.Format("SOTemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", soTemp.X, soTemp.Y, soTemp.phi, soTemp.radius));
            Console.WriteLine(string.Format("OTemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", oTemp.X, oTemp.Y, oTemp.phi, oTemp.radius));

            so.setEucledian(3, 3);
            o2.setEucledian(3, 3);
            Console.WriteLine();
            Console.WriteLine("Set SO and O2 to (3, 3)");
            Console.WriteLine(string.Format("SO: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", so.X, so.Y, so.phi, so.radius));
            Console.WriteLine(string.Format("O2: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", o2.X, o2.Y, o2.phi, o2.radius));

            Console.WriteLine();

            Console.WriteLine(string.Format("STemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", soTemp.X, soTemp.Y, soTemp.phi, soTemp.radius));
            Console.WriteLine(string.Format("OTemp: ({0:0.00};{1:0.00}) = ({2:0.00};{3:0.00})", oTemp.X, oTemp.Y, oTemp.phi, oTemp.radius));

            Console.WriteLine();
        }
    }
}
