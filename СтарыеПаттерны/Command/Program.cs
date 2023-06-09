//using System;

//namespace RefactoringGuru.DesignPatterns.Command.Conceptual
//{
//    // Интерфейс Команды объявляет метод для выполнения команд.
//    public interface ICommand
//    {
//        void Execute();
//    }

//    // Некоторые команды способны выполнять простые операции самостоятельно.
//    class SimpleCommand : ICommand
//    {
//        private string _payload = string.Empty;

//        public SimpleCommand(string payload)
//        {
//            this._payload = payload;
//        }

//        public void Execute()
//        {
//            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this._payload})");
//        }
//    }

//    // Но есть и команды, которые делегируют более сложные операции другим
//    // объектам, называемым «получателями».
//    class ComplexCommand : ICommand
//    {
//        private Receiver _receiver;

//        // Данные о контексте, необходимые для запуска методов получателя.
//        private string _a;

//        private string _b;

//        // Сложные команды могут принимать один или несколько объектов-
//        // получателей вместе с любыми данными о контексте через конструктор.
//        public ComplexCommand(Receiver receiver, string a, string b)
//        {
//            this._receiver = receiver;
//            this._a = a;
//            this._b = b;
//        }

//        // Команды могут делегировать выполнение любым методам получателя.
//        public void Execute()
//        {
//            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
//            this._receiver.DoSomething(this._a);
//            this._receiver.DoSomethingElse(this._b);
//        }
//    }

//    // Классы Получателей содержат некую важную бизнес-логику. Они умеют
//    // выполнять все виды операций, связанных с выполнением запФроса. Фактически,
//    // любой класс может выступать Получателем.
//    class Receiver
//    {
//        public void DoSomething(string a)
//        {
//            Console.WriteLine($"Receiver: Working on ({a}.)");
//        }

//        public void DoSomethingElse(string b)
//        {
//            Console.WriteLine($"Receiver: Also working on ({b}.)");
//        }
//    }

//    // Отправитель связан с одной или несколькими командами. Он отправляет
//    // запрос команде.
//    class Invoker
//    {
//        private ICommand _onStart;

//        private ICommand _onFinish;

//        // Инициализация команд
//        public void SetOnStart(ICommand command)
//        {
//            this._onStart = command;
//        }

//        public void SetOnFinish(ICommand command)
//        {
//            this._onFinish = command;
//        }

//        // Отправитель не зависит от классов конкретных команд и получателей.
//        // Отправитель передаёт запрос получателю косвенно, выполняя команду.
//        public void DoSomethingImportant()
//        {
//            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
//            if (this._onStart is ICommand)
//            {
//                this._onStart.Execute();
//            }

//            Console.WriteLine("Invoker: ...doing something really important...");

//            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
//            if (this._onFinish is ICommand)
//            {
//                this._onFinish.Execute();
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Клиентский код может параметризовать отправителя любыми
//            // командами.
//            Invoker invoker = new Invoker();
//            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
//            Receiver receiver = new Receiver();
//            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

//            invoker.DoSomethingImportant();
//        }
//    }
//}



class Program
{
    static void Main(string[] args)
    {
        //Pult pult = new Pult();
        //TV tv = new TV();
        //pult.SetCommand(new TVOnCommand(tv));
        //pult.PressButton();
        //pult.PressUndo();
        //pult.PressButton();

        //Microwave microwave = new Microwave();
        //pult.SetCommand(new MicrowaveCommand(microwave, 5000));
        //pult.PressButton();
        //pult.PressUndo();

        MultiPult mPult = new MultiPult();
        TV tv = new TV();
        Volume volume = new Volume();
        Microwave microwave = new Microwave();

        mPult.SetCommand(0, new TVOnCommand(tv));
        mPult.SetCommand(1, new VolumeCommand(volume));
        mPult.SetCommand(2, new MicrowaveCommand(microwave,2000));

        mPult.PressButton(0);
        mPult.PressButton(1);
        mPult.PressButton(1);
        mPult.PressButton(1);
        //mPult.PressButton(2);
        mPult.PressUndoButton();
        //mPult.PressUndoButton(1);
        //mPult.PressUndoButton();
        mPult.PressButton(1);
        mPult.PressButton(1);
        mPult.PressButton(1);




        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();
        //mPult.PressUndoButtonCancel();



    }
}

/// Интерфейс команды
public interface ICommand
{
    void Execute();

    void Undo();
}

/// Получатель команд
class TV
{
    public void On() => Console.WriteLine("Телевизор включен");

    public void Off() => Console.WriteLine("Телевизор выключен");
}

/// Реализация интерфейса ICommand
class TVOnCommand: ICommand
{
    TV tv;

    public TVOnCommand(TV tvSet)
    {
        tv = tvSet;
    }

    public void Execute()
    {
        tv.On();
    }

    public void Undo()
    {
        tv.Off();
    }
}

/// Инициатор команд
//class Pult
//{
//    ICommand command;

//    public Pult() { }

//    public void SetCommand(ICommand com)
//    {
//        command = com;
//    }

//    public void PressButton()
//    {
//        if (command!=null)
//        command.Execute();
//    }

//    public void PressUndo()
//    {
//        if (command!=null)
//        command.Undo();
//    }

//}

class Volume
{
    public const int OFF = 0;
    public const int HIGH = 20;
    private int level;

    public Volume()
    {
        level = OFF;
    }

    public void RaiseLevel()
    {
        if (level < HIGH)
            level++;
        Console.WriteLine($"Уровень звука {level}");
    }


    public void DropLevel()
    {
        if (level > OFF)
            level--;
        Console.WriteLine($"Уровень звука {level}");
    }

}

class VolumeCommand : ICommand
{
    Volume volume;
    public VolumeCommand(Volume v)
    {
        volume = v;
    }

    public void Execute()
    {
        volume.RaiseLevel();
    }

    public void Undo()
    {
        volume.DropLevel();
    }
}


class NoCommand : ICommand
{
    public void Execute()
    {
    }
    public void Undo()
    {
    }
}



//class MultiPult
//{
//    ICommand[] buttons;
//    //List<ICommand> commandsHistory;
//    //Stack<ICommand> commandsHistory;
//    private int lastCommand = -1;

//    public MultiPult()
//    {
//        buttons = new ICommand[3];
//        for (int i = 0; i < buttons.Length; i++)
//        {
//            buttons[i] = new NoCommand();
//        }
//        commandsHistory = new List<ICommand>();
//    }

//    public void SetCommand(int number, ICommand com)
//    {
//        buttons[number] = com;
//    }


//    public void PressButton(int number)
//    {
//        buttons[number].Execute();
//        commandsHistory.Add(buttons[number]);
//            //(buttons[number]);
//    }

//    public void PressUndoButton(int number)
//    {
//        buttons[number].Undo();
//        commandsHistory.Add(buttons[number]);




//        //if (commandsHistory.Count > 0)
//        //{
//        //    ICommand undoCommand = commandsHistory.Pop();
//        //    undoCommand.Undo();
//        //}
//    }


//    public void PressUndoButtonCancel()
//    {
//        //if (commandsHistory.Count > 0)
//        //{
//        //    ICommand undoCommand = commandsHistory[commandsHistory.Count - 1];
//        //    commandsHistory.RemoveAt(commandsHistory.Count - 1);
//        //    undoCommand.Undo();
//        //}

//        //for (int i = 0; commandsHistory.Count > 0; i++)
//        //{
//        //    ICommand undoCommand = commandsHistory[commandsHistory.Count - 1];
//        //    commandsHistory.RemoveAt(commandsHistory.Count - 1);
//        //    undoCommand.Undo();
//        //}

//        if (lastCommand >= 0 && lastCommand < commandsHistory.Count)
//        {
//            ICommand undoCommand = commandsHistory[lastCommand];
//            undoCommand.Undo();
//            lastCommand--;
//        }




//    }

//}


class MultiPult
{
    ICommand[] buttons;
    Stack<ICommand> commandsHistory;

    public MultiPult()
    {
        buttons = new ICommand[3];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = new NoCommand();
        }
        commandsHistory = new Stack<ICommand>();
    }

    public void SetCommand(int number, ICommand com)
    {
        buttons[number] = com;
    }

    public void PressButton(int number)
    {
        buttons[number].Execute();
        // добавляем выполненную команду в историю команд
        commandsHistory.Push(buttons[number]);
    }

    //public void PressUndoButton(int number)
    //{
    //    buttons[number].Undo();
    //    // добавляем выполненную команду в историю команд
    //    commandsHistory.Push(buttons[number]);
    //}



    //public void PressUndoButtonCancel()
    //{
    //    if (commandsHistory.Count > 0)
    //    {
    //        ICommand undoCommand = commandsHistory.Pop();
    //        if (undoCommand.Execute() == true)
            
    //        undoCommand.Undo();
    //    }
    //}


       public void PressUndoButton()
    {
        if(commandsHistory.Count>0)
        {
            ICommand undoCommand = commandsHistory.Pop();
            undoCommand.Undo();
        }
    }
}













class Microwave
{
    public void StartCooking(int time)
    {
        Console.WriteLine("Подогреваем еду");
        Task.Delay(time).GetAwaiter().GetResult();
    }


    public void StopCooking()
    {
        Console.WriteLine("Еда подогрета");
    }

}

class MicrowaveCommand : ICommand
{
    Microwave microwave;
    int time;

    public MicrowaveCommand(Microwave m, int t)
    {
        microwave = m;
        time = t;
    }

    public void Execute()
    {
        microwave.StartCooking(time);
        microwave.StopCooking();
    }

    public void Undo()
    {
        microwave.StopCooking();
    }

}










