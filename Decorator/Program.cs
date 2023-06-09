//using System;

//namespace RefactoringGuru.DesignPatterns.Composite.Conceptual
//{
//    // Базовый интерфейс Компонента определяет поведение, которое изменяется
//    // декораторами.
//    public abstract class Component
//    {
//        public abstract string Operation();
//    }

//    // Конкретные Компоненты предоставляют реализации поведения по умолчанию.
//    // Может быть несколько вариаций этих классов.
//    class ConcreteComponent : Component
//    {
//        public override string Operation()
//        {
//            return "ConcreteComponent";
//        }
//    }

//    // Базовый класс Декоратора следует тому же интерфейсу, что и другие
//    // компоненты. Основная цель этого класса - определить интерфейс обёртки для
//    // всех конкретных декораторов. Реализация кода обёртки по умолчанию может
//    // включать в себя  поле для хранения завёрнутого компонента и средства его
//    // инициализации.
//    abstract class Decorator : Component
//    {
//        protected Component _component;

//        public Decorator(Component component)
//        {
//            this._component = component;
//        }

//        public void SetComponent(Component component)
//        {
//            this._component = component;
//        }

//        // Декоратор делегирует всю работу обёрнутому компоненту.
//        public override string Operation()
//        {
//            if (this._component != null)
//            {
//                return this._component.Operation();
//            }
//            else
//            {
//                return string.Empty;
//            }
//        }
//    }

//    // Конкретные Декораторы вызывают обёрнутый объект и изменяют его результат
//    // некоторым образом.
//    class ConcreteDecoratorA : Decorator
//    {
//        public ConcreteDecoratorA(Component comp) : base(comp)
//        {
//        }

//        // Декораторы могут вызывать родительскую реализацию операции, вместо
//        // того, чтобы вызвать обёрнутый объект напрямую. Такой подход упрощает
//        // расширение классов декораторов.
//        public override string Operation()
//        {
//            return $"ConcreteDecoratorA({base.Operation()})";
//        }
//    }

//    // Декораторы могут выполнять своё поведение до или после вызова обёрнутого
//    // объекта.
//    class ConcreteDecoratorB : Decorator
//    {
//        public ConcreteDecoratorB(Component comp) : base(comp)
//        {
//        }

//        public override string Operation()
//        {
//            return $"ConcreteDecoratorB({base.Operation()})";
//        }
//    }

//    public class Client
//    {
//        // Клиентский код работает со всеми объектами, используя интерфейс
//        // Компонента. Таким образом, он остаётся независимым от конкретных
//        // классов компонентов, с которыми работает.
//        public void ClientCode(Component component)
//        {
//            Console.WriteLine("RESULT: " + component.Operation());
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Client client = new Client();

//            var simple = new ConcreteComponent();
//            Console.WriteLine("Client: I get a simple component:");
//            client.ClientCode(simple);
//            Console.WriteLine();

//            // ...так и декорированные.
//            //
//            // Обратите внимание, что декораторы могут обёртывать не только
//            // простые компоненты, но и другие декораторы.
//            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
//            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
//            ConcreteDecoratorB decorator3 = new ConcreteDecoratorB(new ConcreteDecoratorA(new ConcreteDecoratorB(decorator1)));
//            Console.WriteLine("Client: Now I've got a decorated component:");
//            client.ClientCode(decorator2);
//        }
//    }
//}


//abstract class Pizza
//{
//    public Pizza(string n)
//    {
//        this.Name = n;
//    }
//    public string Name { get; protected set; }
//    public abstract int GetCost();
//}

//class ItalianPizza : Pizza
//{
//    public ItalianPizza() : base("Итальянская пицца") { }
//    public override int GetCost()
//    {
//        return 10;
//    }
//}

//class BulgerianPizza : Pizza
//{
//    public BulgerianPizza() : base ("Болгарская пицца") { }
//    public override int GetCost()
//    {
//        return 8;
//    }
//}

//abstract class PizzaDecorator : Pizza
//{
//    protected Pizza pizza;
//    public PizzaDecorator(string n, Pizza pizza) : base(n)
//    {
//        this.pizza = pizza;
//    }
//}

//class TomatoPizza : PizzaDecorator
//{
//    public TomatoPizza(Pizza p) : base(p.Name + ", с томатами", p) { }
//    public override int GetCost()
//    {
//        return pizza.GetCost() + 3;
//    }
//}

//class ChessePizza : PizzaDecorator
//{
//    public ChessePizza(Pizza p) : base (p.Name + ", с сыром", p) { }
//    public override int GetCost()
//    {
//        return pizza.GetCost() + 5;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Pizza pizza1 = new ItalianPizza();
//        pizza1 = new ChessePizza(new TomatoPizza(pizza1));
//        Console.WriteLine($"Название: {pizza1.Name}");
//        Console.WriteLine($"Цена: {pizza1.GetCost()}");

//        Pizza pizza2 = new ItalianPizza();
//        pizza2 = new ChessePizza(new ChessePizza(pizza2));
//        Console.WriteLine($"Название: {pizza2.Name}");
//        Console.WriteLine($"Цена: {pizza2.GetCost()}");


//        Pizza pizza3 = new ItalianPizza();
//        Console.WriteLine($"Название: {pizza3.Name}");
//        Console.WriteLine($"Цена: {pizza3.GetCost()}");
//    }


//}


abstract class Character
{
    public Character (string n)
    {
      this.Name = n;
    }
    public string Name { get; protected set; }
    public abstract int Helth();
    public abstract int Attack();
}


class Warrior : Character
{
    public Warrior() : base ("Воин") { }

    public override int Helth()
    {
        return 100;
    }

    public override int Attack()
    {
        return 10;
    }
}



class Mage : Character
{
    public Mage() : base("Маг") { }


    public override int Helth()
    {
        return 60;
    }

    public override int Attack()
    {
        return 20;
    }
}


class Hunter : Character
{
    public Hunter() : base("Охотник") { }


    public override int Helth()
    {
        return 80;
    }

    public override int Attack()
    {
        return 15;
    }
}



abstract class WeaponDecorator : Character
{
    protected Character character;
    public WeaponDecorator(string n, Character character) : base(n) 
    {
        this.character = character;
    }  
}

class Sword: WeaponDecorator
{
    public Sword(Character ch) : base (ch.Name + " с мечом", ch) { }
    public override int Attack()
    {
        return character.Attack() + 10;
    }

    public override int Helth()
    {
        return character.Helth() + 5;
    }
}

class Bow : WeaponDecorator
{
    public Bow(Character ch) : base(ch.Name + " с луком", ch) { }
    public override int Attack()
    {
        return character.Attack() + 15;
    }

    public override int Helth()
    {
        return character.Helth() + 10;
    }

   
}


class Wand : WeaponDecorator
{
    public Wand(Character ch) : base(ch.Name + " с жезлом", ch) { }
    public override int Attack()
    {
        return character.Attack() + 5;
    }

    public override int Helth()
    {
        return character.Helth() + 20;
    }
}



class Program
{
    static void Main()
    {
        Character player1 = new Warrior();
        player1 = new Sword(player1);
        Console.WriteLine($"Класс: {player1.Name}");
        Console.WriteLine($"Урон:{player1.Attack()}");
        Console.WriteLine($"хп:{player1.Helth()}");

        Character player2 = new Mage();
        player2 = new Wand(player2);
        Console.WriteLine($"Класс: {player2.Name}");
        Console.WriteLine($"Урон:{player2.Attack()}");
        Console.WriteLine($"хп:{player2.Helth()}");


        Character player3 = new Hunter();
        player3 = new Bow(player3);
        Console.WriteLine($"Класс: {player3.Name}");
        Console.WriteLine($"Урон:{player3.Attack()}");
        Console.WriteLine($"хп:{player3.Helth()}");


        Character player4 = new Warrior();
        //player4 = new Sword(player4);
        //player4 = new Bow(player4);
        player4 = new Bow(new Wand(new Sword(player4)));
        Console.WriteLine($"Класс: {player4.Name}");
        Console.WriteLine($"Урон:{player4.Attack()}");
        Console.WriteLine($"хп:{player4.Helth()}");
    }
}
