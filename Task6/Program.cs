﻿using System;
namespace AdapterExample
{
    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // Система яку будемо адаптовувати
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }

    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }
    class NewTVsystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new TV system";
        }
    }
    // Адаптер назовні виглядає як нові євророзетки, шляхом наслідування прийнятного у 
    // системі інтерфейсу

    

    class Adapter : INewElectricitySystem
    {
        // Але всередині він старий
        private readonly OldElectricitySystem _adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        // А тут відбувається вся магія: наш адаптер «перекладає»
        // функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            // Якщо б була різниця 
            // то тут ми б помістили трансформатор
            return _adaptee.MatchThinSocket();
        }
    }

    class TVAdapter : INewElectricitySystem
    {
        // Але всередині він старий
        private readonly OldElectricitySystem _TVadaptee;
        public TVAdapter(OldElectricitySystem adaptee)
        {
            _TVadaptee = adaptee;
        }

        // А тут відбувається вся магія: наш адаптер «перекладає»
        // функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            // Якщо б була різниця 
            // то тут ми б помістили трансформатор
            return _TVadaptee.MatchThinSocket();
        }
    }

    class ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    

    public class AdapterDemo
    {
        static void Main()
        {
            // 1) Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            // 2) Ми повинні адаптуватися до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            var oldTV = new OldElectricitySystem();
            var TVadapter = new TVAdapter(oldTV);
            ElectricityConsumer.ChargeNotebook(TVadapter);

            var newTV = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newTV);

            Console.ReadKey();
        }
    }
}