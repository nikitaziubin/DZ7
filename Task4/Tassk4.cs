﻿using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();


            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка ");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "з прикрасами";
            Console.WriteLine(addedState);
        }
    }

    // "ConcreteDecoratorB" 
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("");
        }
        void AddedBehavior()
        {
            Console.WriteLine("світиться");
        }
    }
}