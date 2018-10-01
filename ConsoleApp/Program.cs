using System;
using ConsoleApp.DAL;
using ConsoleApp.ViewModel;

namespace ConsoleApp
{
    internal static class Program
    {
        private static EmployeeViewModel viewModel;

        private static void Main()
        {
            Initialize();

            PrintList();
            Console.ReadLine();
            DoAction();
            Console.ReadLine();
            PrintList();

            Console.WriteLine("Завершено.");
            Console.ReadLine();
        }

        private static void Initialize()
        {
            Console.WriteLine("Инициализация...\n");

            var dbContext = new EmployeeContext("SqlDatabase");
            var repository = new EmployeeRepository(dbContext);

            viewModel = new EmployeeViewModel(repository);
            viewModel.LoadFromDatabase();
        }

        private static void PrintList()
        {
            var employees = viewModel.Employees;

            Console.WriteLine("Список сотрудников");
            Console.WriteLine("ID | ФИО | Должность | Зарплата");

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine();
        }

        private static void DoAction()
        {
            Console.WriteLine("Повышаем зарплаты...");
            viewModel.ChangeSalary(2, 2500);

            Console.WriteLine("Уволяняем людей...");
            viewModel.Fire(1);

            viewModel.Save();

            Console.WriteLine();
        }
    }
}
