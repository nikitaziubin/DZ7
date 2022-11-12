// See hProgram.cs
﻿using System;
namespace telestialAntenaConector
{

    interface AntenaPort
    {
        SetelitePort ReturnAntenaPort();
        string Conect();
    }

    class TelestialPort : AntenaPort
    {
        public SetelitePort ReturnAntenaPort()
        {

            return new SetelitePort();
        }
        public string Conect()
        {
            return "TV connect to telestial";
        }
    }

    class SetelitePort 
    {
        private SetelitePort setelitePort { get; set; }
        public string Connect()
        {
            return "Chanel is on";
        }

    }    
    class TvAdapter
    {
        private TelestialPort adapteeAntenaPort;
        
        public TvAdapter(TelestialPort TVport)
        {
            adapteeAntenaPort = TVport;
        }

        public SetelitePort seteliteAntenaConector()
        {
            return adapteeAntenaPort.ReturnAntenaPort();
        }
    }

    class USBTvAdapter
    {
        private TelestialPort adapteeAntenaPort;

        public USBTvAdapter(TelestialPort TVport)
        {
            adapteeAntenaPort = TVport;
        }

        public SetelitePort seteliteAntenaConector()
        {
            return adapteeAntenaPort.ReturnAntenaPort();
        }
    }

    public class Program
    {
        static void Main()
        {
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }


            TelestialPort TV = new TelestialPort();
            TvAdapter adapter = new TvAdapter(TV);
            Console.WriteLine(adapter.seteliteAntenaConector().Connect());

            TelestialPort USBTV = new TelestialPort();
            USBTvAdapter USBadapter = new USBTvAdapter(USBTV);
            Console.WriteLine(USBadapter.seteliteAntenaConector().Connect());
        }
    }
}