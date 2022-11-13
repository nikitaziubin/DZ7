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
        private SetelitePort setelitePort;
        public string Connect()
        {
            return "Chanel is on";
        }
    }    
    class TvAdapter : TVPort
    {
        private TelestialPort adapteeAntenaPort;
        private TVPort Televisor;
        
        public TvAdapter(TVPort TVport, TelestialPort adapteeAntenaPort)
        {
            Televisor = TVport;
            this.adapteeAntenaPort = adapteeAntenaPort;
        }
        public SetelitePort seteliteAntenaConector()
        {
            return adapteeAntenaPort.ReturnAntenaPort();
            //return adapteeAntenaPort.ReturnAntenaPort();
        }
    }   

    class USBTvAdapter : TVPort
    {
        private TelestialPort adapteeAntenaPort;
        private TVPort USBTelevisor;

        public USBTvAdapter(TVPort USBTVport, TelestialPort adapteeAntenaPort)
        {
            USBTelevisor = USBTVport;
            this.adapteeAntenaPort = adapteeAntenaPort;
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

            TelestialPort port = new TelestialPort();
            var tvtype = creator.FactoryMethod(2, port);
            TvAdapter adapter = new TvAdapter(tvtype, port);
            Console.WriteLine(adapter.seteliteAntenaConector().Connect());



            tvtype = creator.FactoryMethod(2, port);
            TelestialPort USBTV = new TelestialPort();
            USBTvAdapter USBadapter = new USBTvAdapter(tvtype, port);
            Console.WriteLine(USBadapter.seteliteAntenaConector().Connect());
        }
    }
}