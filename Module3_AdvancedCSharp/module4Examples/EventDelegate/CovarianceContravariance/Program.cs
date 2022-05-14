using System;

namespace CovarianceContravariance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Ковариантность : позволяет использовать более конкретный тип, чем заданный изначально
            Console.WriteLine("Covariance");
            Console.WriteLine();
            //Здесь мы присвоиваем более общему типу IReserver<Vehicle> более конкретный тип CarReserver
            IReserver<Vehicle> vehicle = new CarReserver();
            Vehicle vehicle2 = vehicle.Reserve("qqq 111");
            Console.WriteLine(vehicle2.CarNumber);

            //Соответсвенно здесь присваиваем более конкретный Car к более общему типу Vehicle
            IReserver<Car> car = new CarReserver();
            IReserver<Vehicle> reserver = car;
            Vehicle ReservingVehicle= reserver.Reserve("aaa 222");
            Console.WriteLine(ReservingVehicle.CarNumber); 

            Console.WriteLine();

            //Контравариантность позволяет использовать более универсальный тип, чем заданный изначально
            Console.WriteLine("Contravariance");
            //здесь более конкретному типу EmailMessage присваиваем более общий тип SimpleMessenger
            IMessenger<EmailMessage> outlook = new SimpleMessenger();
            outlook.SendMessage(new EmailMessage("Hi!"));

            IMessenger<Message> telegram = new SimpleMessenger();
            IMessenger<EmailMessage> emailClient = telegram;
            emailClient.SendMessage(new EmailMessage("Hello"));


        }
    }
    #region Ковариантность
    interface IReserver<out T>
    {
        T Reserve(string carNumber);
    }

    class CarReserver : IReserver<Car>
    {
        public Car Reserve(string carNumber)
        {
            Car car = new Car(carNumber);
            car.IsReserved = true;
            return car;
        }

    }

    class Vehicle
    {
        public string CarNumber { get; set; }

        public Vehicle(string carNumber)
        {
            CarNumber = carNumber;
        }

        public bool IsReserved { get; set; } = false;
    }

    class Car : Vehicle
    {
        public Car(string carNumber) : base(carNumber) { }
    }
    #endregion

    #region Контравариантность
    interface IMessenger<in T>
    {
        void SendMessage(T message);
    }
    class SimpleMessenger : IMessenger<Message>
    {
        public void SendMessage(Message message)
        {
            Console.WriteLine($"Отправляется сообщение: {message.Text}");
        }
    }
    class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
    }
    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }
    #endregion
}
