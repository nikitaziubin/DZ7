using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telestialAntenaConector
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new ConcreteProductA();
                //повертає об'єкт B, якщо type==2  
                case 2: return new ConcreteProductB();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product { } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class ConcreteProductA : Product { }

    public class ConcreteProductB : Product { }
}
