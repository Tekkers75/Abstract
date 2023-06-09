namespace MVC
{



    // Представление
    public class UserView
    {
        public void ShowUser(UserModel user)
        {
            Console.WriteLine($"User: Id={user.Id}, Name={user.Name}, Age={user.Age}");
        }

        public UserModel GetUserInput()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();

            Console.Write("Enter user age: ");
            int age = int.Parse(Console.ReadLine());

            return new UserModel { Name = name, Age = age };
        }
    }

    // Контроллер
    public class UserController
    {
        private readonly UserModel model;
        private readonly UserView view;

        public UserController(UserModel model, UserView view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdateUser()
        {
            UserModel user = view.GetUserInput();
            model.Name = user.Name;
            model.Age = user.Age;
        }

        public void DisplayUser()
        {
            view.ShowUser(model);
        }
    }

    // Модель
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }



        // Тестовый код
        public static void Main(string[] args)
        {
            var model = new UserModel { Id = 1, Name = "John", Age = 30 };
            var view = new UserView();

            var controller = new UserController(model, view);

            controller.DisplayUser(); // Выведет "User: Id=1, Name=John, Age=30"

            controller.UpdateUser();
            controller.DisplayUser(); // Выведет введенные пользователем данные
        }
        //В данном примере класс UserModel представляет модель, класс UserView - представление, а класс UserController - контроллер. Модель содержит данные о пользователе, представление отвечает за отображение данных на экране и получение пользовательского ввода, а контроллер управляет взаимодействием между моделью и представлением. Тестовый код создает объекты модели, представления и контроллера, отображает данные пользователя, затем обновляет их на основе пользовательского ввода и отображает обновленные данные.
    }
}



