//using System;

//namespace RefactoringGuru.DesignPatterns.AbstractFactory.Conceptual
//{
//    // Интерфейс Абстрактной Фабрики объявляет набор методов, которые возвращают
//    // различные абстрактные продукты.  Эти продукты называются семейством и
//    // связаны темой или концепцией высокого уровня. Продукты одного семейства
//    // обычно могут взаимодействовать между собой. Семейство продуктов может
//    // иметь несколько вариаций,  но продукты одной вариации несовместимы с
//    // продуктами другой.
//    public interface IAbstractFactory
//    {
//        IAbstractProductA CreateProductA();

//        IAbstractProductB CreateProductB();
//    }

//    // Конкретная Фабрика производит семейство продуктов одной вариации. Фабрика
//    // гарантирует совместимость полученных продуктов.  Обратите внимание, что
//    // сигнатуры методов Конкретной Фабрики возвращают абстрактный продукт, в то
//    // время как внутри метода создается экземпляр  конкретного продукта.
//    class ConcreteFactory1 : IAbstractFactory
//    {
//        public IAbstractProductA CreateProductA()
//        {
//            return new ConcreteProductA1();
//        }

//        public IAbstractProductB CreateProductB()
//        {
//            return new ConcreteProductB1();
//        }
//    }

//    // Каждая Конкретная Фабрика имеет соответствующую вариацию продукта.
//    class ConcreteFactory2 : IAbstractFactory
//    {
//        public IAbstractProductA CreateProductA()
//        {
//            return new ConcreteProductA2();
//        }

//        public IAbstractProductB CreateProductB()
//        {
//            return new ConcreteProductB2();
//        }
//    }

//    // Каждый отдельный продукт семейства продуктов должен иметь базовый
//    // интерфейс. Все вариации продукта должны реализовывать этот интерфейс.
//    public interface IAbstractProductA
//    {
//        string UsefulFunctionA();
//    }

//    // Конкретные продукты создаются соответствующими Конкретными Фабриками.
//    class ConcreteProductA1 : IAbstractProductA
//    {
//        public string UsefulFunctionA()
//        {
//            return "The result of the product A1.";
//        }
//    }

//    class ConcreteProductA2 : IAbstractProductA
//    {
//        public string UsefulFunctionA()
//        {
//            return "The result of the product A2.";
//        }
//    }

//    // Базовый интерфейс другого продукта. Все продукты могут взаимодействовать
//    // друг с другом, но правильное взаимодействие возможно только между
//    // продуктами одной и той же конкретной вариации.
//    public interface IAbstractProductB
//    {
//        // Продукт B способен работать самостоятельно...
//        string UsefulFunctionB();

//        // ...а также взаимодействовать с Продуктами А той же вариации.
//        //
//        // Абстрактная Фабрика гарантирует, что все продукты, которые она
//        // создает, имеют одинаковую вариацию и, следовательно, совместимы.
//        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
//    }

//    // Конкретные Продукты создаются соответствующими Конкретными Фабриками.
//    class ConcreteProductB1 : IAbstractProductB
//    {
//        public string UsefulFunctionB()
//        {
//            return "The result of the product B1.";
//        }

//        // Продукт B1 может корректно работать только с Продуктом A1. Тем не
//        // менее, он принимает любой экземпляр Абстрактного Продукта А в
//        // качестве аргумента.
//        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
//        {
//            var result = collaborator.UsefulFunctionA();

//            return $"The result of the B1 collaborating with the ({result})";
//        }
//    }

//    class ConcreteProductB2 : IAbstractProductB
//    {
//        public string UsefulFunctionB()
//        {
//            return "The result of the product B2.";
//        }

//        // Продукт B2 может корректно работать только с Продуктом A2. Тем не
//        // менее, он принимает любой экземпляр Абстрактного Продукта А в качестве
//        // аргумента.
//        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
//        {
//            var result = collaborator.UsefulFunctionA();

//            return $"The result of the B2 collaborating with the ({result})";
//        }
//    }

//    // Клиентский код работает с фабриками и продуктами только через абстрактные
//    // типы: Абстрактная Фабрика и Абстрактный Продукт. Это позволяет передавать
//    // любой подкласс фабрики или продукта клиентскому коду, не нарушая его.
//    class Client
//    {
//        public void Main()
//        {
//            // Клиентский код может работать с любым конкретным классом фабрики.
//            Console.WriteLine("Client: Testing client code with the first factory type...");
//            ClientMethod(new ConcreteFactory1());
//            Console.WriteLine();

//            Console.WriteLine("Client: Testing the same client code with the second factory type...");
//            ClientMethod(new ConcreteFactory2());
//        }

//        public void ClientMethod(IAbstractFactory factory)
//        {
//            var productA = factory.CreateProductA();
//            var productB = factory.CreateProductB();

//            Console.WriteLine(productB.UsefulFunctionB());
//            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            new Client().Main();
//        }
//    }
//}



//abstract class Weapon
//{
//    public abstract void Hit();

//}

//abstract class Movement
//{
//    public abstract void Move();

//}


//class Bow : Weapon
//{
//    public override void Hit()
//    {
//        Console.WriteLine("Выстрел из лука");
//    }
//}

//class Sword : Weapon
//{
//    public override void Hit()
//    {
//        Console.WriteLine("Удар мечом");
//    }
//}


///// <summary>
///// 
///// </summary>
//class FlyMovement : Movement
//{
//    public override void Move()
//    {
//        Console.WriteLine("Летим");
//    }
//}

//class RunMovement : Movement
//{
//    public override void Move()
//    {
//        Console.WriteLine("Бежим");
//    }
//}


//abstract class HeroFactory
//{
//    public abstract Movement CreateMovement();
//    public abstract Weapon CreateWeapon();
//}



//class ElfFactory : HeroFactory
//{
//    public override Movement CreateMovement()
//    {
//        return new FlyMovement();
//    }

//    public override Weapon CreateWeapon()
//    {
//        return new Bow();
//    }

//}

//class WarriorFactory : HeroFactory
//{
//    public override Movement CreateMovement()
//    {
//        return new RunMovement();
//    }

//    public override Weapon CreateWeapon()
//    {
//        return new Sword();
//    }

//}


//class Hero
//{
//    private Weapon weapon;
//    private Movement movement;
//    public Hero(HeroFactory factory)
//    {
//        weapon = factory.CreateWeapon();
//        movement = factory.CreateMovement();
//    }

//    public void Run()
//    {
//        movement.Move();
//    }

//    public void Hit()
//    {
//        weapon.Hit();
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Hero elf = new Hero(new ElfFactory());
//        elf.Hit();
//        elf.Run();

//        Hero Warrior = new Hero(new WarriorFactory());
//        Warrior.Hit();
//        Warrior.Run();

        

//    }
//}



abstract class Weapon
{
    public abstract void Hit();
}

abstract class Armor
{
    public abstract void Damage();
}

abstract class Accessory
{
    public abstract void Name();
}

class Sword : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Бьет мечом");
    }
}


class Bow : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Стреляет из лука");
    }
}

class Staff : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Делает магический выстрел");
    }
}


class Plate: Armor
{
    public override void Damage()
    {
        Console.WriteLine("Имеет латную броню - 50% урона");
    }
}

class Leather : Armor
{
    public override void Damage()
    {
        Console.WriteLine("Имеет кожаную броню - 30% урона");
    }
}

class Cloth : Armor
{
    public override void Damage()
    {
        Console.WriteLine("Имеет тканевую броню - 15% урона");
    }
}

class Ring : Accessory
{
    public override void Name()
    {
        Console.WriteLine("Есть кольцо, которое дает интеллект");
    }
}

class Cloak : Accessory
{
    public override void Name()
    {
        Console.WriteLine("Есть плащ, который дает ловкость");
    }
}

class Chain : Accessory
{
    public override void Name()
    {
        Console.WriteLine("Есть цепь, которая дает силу");
    }
}


abstract class CharacterFactory
{
    public abstract Weapon CreateWeapon();
    public abstract Armor CreateArmor();
    public abstract Accessory CreateAccessory();
}

class Warrior : CharacterFactory
{
    public override Weapon CreateWeapon()
    {
        return new Sword();
    }

    public override Armor CreateArmor()
    {
        return new Plate();
    }

    public override Accessory CreateAccessory()
    {
        return new Chain();
    }
}


class Hunter : CharacterFactory
{
    public override Weapon CreateWeapon()
    {
        return new Bow();
    }

    public override Armor CreateArmor()
    {
        return new Leather();
    }

    public override Accessory CreateAccessory()
    {
        return new Cloak();
    }
}

class Mage : CharacterFactory
{
    public override Weapon CreateWeapon()
    {
        return new Staff();
    }

    public override Armor CreateArmor()
    {
        return new Cloth();
    }

    public override Accessory CreateAccessory()
    {
        return new Ring();
    }
}


class Hero
{
    private Weapon weapon;
    private Armor armor;
    private Accessory accessory;


    public Hero (CharacterFactory factory)
    {
        weapon = factory.CreateWeapon();
        armor = factory.CreateArmor();
        accessory = factory.CreateAccessory();
    }

    public void Attack()
    {
        weapon.Hit();
    }

    public void Defense()
    {
        armor.Damage();
    }

    public void Buff()
    {
        accessory.Name();
    }
}

class Program
{
    static void Main()
    {
        Hero Warrior = new Hero(new Warrior());
        Warrior.Attack();
        Warrior.Defense();
        Warrior.Buff();
        
        Console.WriteLine("\n");

        Hero Mage = new Hero(new Mage());
        Mage.Attack();
        Mage.Defense();
        Mage.Buff();

        Console.WriteLine("\n");

        Hero Hunter = new Hero(new Hunter());
        Hunter.Attack();
        Hunter.Defense();
        Hunter.Buff();

    }
}