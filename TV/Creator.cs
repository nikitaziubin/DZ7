namespace telestialAntenaConector
{
    abstract class Creator
    {
        public abstract TVPort FactoryMethod(int type, TelestialPort TVtype);
    }

    class ConcreteCreator : Creator
    {
        public override TVPort FactoryMethod(int type, TelestialPort TVtype)
        {
            switch (type)
            {
                case 1: return new TV(TVtype);
                case 2: return new USBTV(TVtype);
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }
    abstract class TVPort { }
    class TV : TVPort
    {
        protected TelestialPort TVport { get; }
        public TV(TelestialPort TVport)
        {
            TVport = new TelestialPort();
            this.TVport = TVport;
        }
    }
    class USBTV : TVPort
    {
        protected TelestialPort USBTVport { get; }
        public USBTV(TelestialPort USBTVport)
        {
            USBTVport = new TelestialPort();
            this.USBTVport = USBTVport;
        }
    }
}