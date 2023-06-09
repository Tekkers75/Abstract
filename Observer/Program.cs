using System;
using System.Collections.Generic;
using System.Threading;

//namespace RefactoringGuru.DesignPatterns.Observer.Conceptual
//{
//    public interface IObserver
//    {
//        // Получает обновление от издателя
//        void Update(ISubject subject);
//    }

//    public interface ISubject
//    {
//        // Присоединяет наблюдателя к издателю.
//        void Attach(IObserver observer);

//        // Отсоединяет наблюдателя от издателя.
//        void Detach(IObserver observer);

//        // Уведомляет всех наблюдателей о событии.
//        void Notify();
//    }

//    // Издатель владеет некоторым важным состоянием и оповещает наблюдателей о
//    // его изменениях.
//    public class Subject : ISubject
//    {
//        // Для удобства в этой переменной хранится состояние Издателя,
//        // необходимое всем подписчикам.
//        public int State { get; set; } = -0;

//        // Список подписчиков. В реальной жизни список подписчиков может
//        // храниться в более подробном виде (классифицируется по типу события и
//        // т.д.)
//        private List<IObserver> _observers = new List<IObserver>();

//        // Методы управления подпиской.
//        public void Attach(IObserver observer)
//        {
//            Console.WriteLine("Subject: Attached an observer.");
//            this._observers.Add(observer);
//        }

//        public void Detach(IObserver observer)
//        {
//            this._observers.Remove(observer);
//            Console.WriteLine("Subject: Detached an observer.");
//        }

//        // Запуск обновления в каждом подписчике.
//        public void Notify()
//        {
//            Console.WriteLine("Subject: Notifying observers...");

//            foreach (var observer in _observers)
//            {
//                observer.Update(this);
//            }
//        }

//        // Обычно логика подписки – только часть того, что делает Издатель.
//        // Издатели часто содержат некоторую важную бизнес-логику, которая
//        // запускает метод уведомления всякий раз, когда должно произойти что-то
//        // важное (или после этого).
//        public void SomeBusinessLogic()
//        {
//            Console.WriteLine("\nSubject: I'm doing something important.");
//            this.State = new Random().Next(0, 10);

//            Thread.Sleep(15);

//            Console.WriteLine("Subject: My state has just changed to: " + this.State);
//            this.Notify();
//        }
//    }

//    // Конкретные Наблюдатели реагируют на обновления, выпущенные Издателем, к
//    // которому они прикреплены.
//    class ConcreteObserverA : IObserver
//    {
//        public void Update(ISubject subject)
//        {
//            if ((subject as Subject).State < 3)
//            {
//                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
//            }
//        }
//    }

//    class ConcreteObserverB : IObserver
//    {
//        public void Update(ISubject subject)
//        {
//            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
//            {
//                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Клиентский код.
//            var subject = new Subject();
//            var observerA = new ConcreteObserverA();
//            subject.Attach(observerA);

//            var observerB = new ConcreteObserverB();
//            subject.Attach(observerB);

//            subject.SomeBusinessLogic();
//            subject.SomeBusinessLogic();

//            subject.Detach(observerB);

//            subject.SomeBusinessLogic();
//        }
//    }
//}



/// <summary>
/// Шаблон интерфейса, главный(подписчики)
/// </summary>
public interface IObserver
{
    // Получает обновление от вахтера
    void Update(IObservable subject);
}

/// <summary>
/// Шаблон интерфейса, реализующий интерфейс (контроллер)
/// </summary>
public interface IObservable
{
    // Присоединяет учеников к вахтеру.
    void Attach(IObserver observer);

    // Отсоединяет учеников от вахтеру.
    void Detach(IObserver observer);

    // Уведомляет всех наблюдателей о событии.
    void Notify();
}





/// <summary>
/// Класс, реализуюший Observable
/// </summary>
public class Porter : IObservable
{
    //// Для удобства в этой переменной хранится состояние Издателя,
    //// необходимое всем подписчикам.
    public int state;

    // Список подписчиков. В реальной жизни список подписчиков может
    // храниться в более подробном виде (классифицируется по типу события и
    // т.д.)

    private List<IObserver> _observers = new List<IObserver>();

    // Методы управления подпиской.
    public void Attach(IObserver observer)
    {
        Console.WriteLine("Пришел в школу"); /// Подписался 
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        if (_observers.Remove(observer) == true)
        {
            _observers.Remove(observer);    /// Отписался
            Console.WriteLine("Вышел из школы");
        }
        else
        {
            Console.WriteLine("Наблюдатель отсутствует");
        }
    }

    // Запуск обновления в каждом подписчике.
    public void Notify()
    {
        Console.WriteLine("Звонок");         /// Получил уведомление

        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    // Обычно логика подписки – только часть того, что делает Издатель.
    // Издатели часто содержат некоторую важную бизнес-логику, которая
    // запускает метод уведомления всякий раз, когда должно произойти что-то
    // важное (или после этого).
    public void Bell(int p)
    {
        state = p;
        Notify();
    }

}


// Конкретные Наблюдатели реагируют на обновления, выпущенные Издателем, к
// которому они прикреплены.
class Child : IObserver
{
    public void Update(IObservable subject)
    {
        if ((subject as Porter).state == 0)
        {
            Console.WriteLine("Child: Ураа, домой");
        }
        else
        {
            Console.WriteLine("Child: Пора на урок");
        }
    }
}

class Child2 : IObserver
{
    public void Update(IObservable subject)
    {
        if ((subject as Porter).state == 0)
        {
            Console.WriteLine("Child2: Перемена!!");
        }
        else
        {
            Console.WriteLine("Child2: Эх");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Клиентский код.
        var Porter = new Porter();
        var Child = new Child();
        var Child2 = new Child2();

        Porter.Bell(0);

        Porter.Attach(Child);
        Porter.Attach(Child);
             
        Porter.Bell(1);
        Porter.Bell(0);
        Porter.Bell(1);
        Porter.Detach(Child);
     
        Porter.Bell(0);
        Porter.Detach(Child);

    }
}
