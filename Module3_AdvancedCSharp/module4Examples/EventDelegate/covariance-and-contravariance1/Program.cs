using System;
using System.Collections.Generic;

namespace covariance_and_contravariance1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ковариантность работаtт с Интерфейсами
            List<cat> list = new List<cat>();
            IEnumerable<cat> cats = list;
            IEnumerable<Animal> animals = cats;


            //object[] objects = new string[3];
            //objects[0] = "123";
            //objects[1] = 2.3;
            //objects[2] = 1;
            //foreach(var item in objects)
            //{
            //    Console.WriteLine(item);
            //}


            //Ковариантность
            Lada lada = new Lada();
            ICar<V8Engine> v8Engine = lada;
            // когда мы пытаемся привести этот тип к более общему, проявляется инвариантность.
            // в объявлении обощении в Интерфейсе перед типом ставим "out" чтобы обобщенный интерфейс стал ковариантным
            ICar<Engine> someCar = v8Engine;
             
            Console.WriteLine(lada);
            Console.WriteLine(v8Engine);
            Console.WriteLine(someCar);


            //Контрвариантность
            //чтобы применить контрвариантность перед типом ставим ключевое слово in
            IPushable<Library> libraries = new Stack<Building>();
            libraries.Push(new Library());

            Console.ReadLine();
        }
    }

    abstract class Animal
    {

    }

    class cat : Animal
    {

    }
    #region ковариантность
    interface ICar<out T> where T : Engine
    {
        T GetEngine();
    }

    class Lada : ICar<V8Engine>
    {
        public V8Engine GetEngine()
        {
            return new V8Engine();
        }
    }

    abstract class Engine
    {

    }
    class V8Engine : Engine
    {
    }
    #endregion

    #region контрвариантность
    abstract class Building
    {

    }
    class Library : Building
    {

    }

    interface IPushable<in T> where T : Building
    {
        void Push(T value);
    }
    class Stack<T> : IPushable<T> where T : Building
    {
        public void Push(T value)
        {
            
        }
    }

    #endregion
}
