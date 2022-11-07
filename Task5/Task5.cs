using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IFigure figure = new Rectangle(10, 20);
            buildFigure(figure);

            figure = new Circle(15);
            buildFigure(figure);

            figure = new Triangle(4, 25 ,10);
            buildFigure(figure);

            Console.Read();
        }
        static void buildFigure(IFigure figure)
        {
            IFigure clonedFigure = figure.Clone();
            figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }
    
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", height, width);
        }
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", radius);
        }
    }

    class Triangle : IFigure
    {
        int len1;
        int len2;
        int len3;
        public Triangle(int len1, int len2, int len3)
        {
            this.len1 = len1;
            this.len2 = len2;
            this.len3 = len3;
        }
        public IFigure Clone()
        {
            return new Triangle(this.len1, this.len2, this.len3);
        }
        public void GetInfo()
        {
            Console.WriteLine("Трикутник зі сторонами {0} {1} {2}", len1, len2, len3);
        }
    }
}