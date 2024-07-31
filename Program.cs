using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTypes__StrategyPattern_
{
    public class Vehicle
    {
        public Speed VehicleSpeed { get; set; }
        public Usage VehicleFunction { get; set; }

        public Vehicle(Speed speed, Usage usage)
        {
            VehicleSpeed = speed;
            VehicleFunction = usage;
        }

        public void DisplayVehicleDetails()
        {
            Console.WriteLine("Speed: " + VehicleSpeed.MaxSpeed() + " km/h");
            Console.WriteLine("Function: " + VehicleFunction.Functions());
            Console.WriteLine();
        }
    }

    public interface Speed
    {
        double MaxSpeed();
    }

    public interface Usage
    {
        string Functions();
    }

    public class Car : Vehicle
    {
        public Car(Speed speed, Usage usage) : base(speed, usage)
        {
        }
    }

    public class Bus : Vehicle
    {
        public Bus(Speed speed, Usage usage) : base(speed, usage)
        {
        }
    }

    public class Truck : Vehicle
    {
        public Truck(Speed speed, Usage usage) : base(speed, usage)
        {
        }
    }

    // SlowVehicleSpeed class
    public class SlowVehicleSpeed : Speed
    {
        public double MaxSpeed()
        {
            return 120.0; // km/h
        }
    }

    // FastVehicleSpeed class
    public class FastVehicleSpeed : Speed
    {
        public double MaxSpeed()
        {
            return 240.0; // km/h
        }
    }

    // PrivateTransporter class
    public class PrivateTransporter : Usage
    {
        public string Functions()
        {
            return "Carries a maximum of 7 passengers and goods up to 350kg.";
        }
    }

    // PublicTransporter class
    public class PublicTransporter : Usage
    {
        public string Functions()
        {
            return "Carries goods of up to 400kg and 65 passengers.";
        }
    }

    // GoodsCarrier class
    public class GoodsCarrier : Usage
    {
        public string Functions()
        {
            return "Carries up to 1500 kg and 5 passengers.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Bus object
            Bus bus = new Bus(new SlowVehicleSpeed(), new PublicTransporter());
            Console.WriteLine("Bus Details:");
            bus.DisplayVehicleDetails();

            // Car object
            Car car = new Car(new FastVehicleSpeed(), new PrivateTransporter());
            Console.WriteLine("Car Details:");
            car.DisplayVehicleDetails();

            // Truck object
            Truck truck = new Truck(new SlowVehicleSpeed(), new GoodsCarrier());
            Console.WriteLine("Truck Details:");
            truck.DisplayVehicleDetails();

            Console.ReadLine(); 
        }
    }
}

