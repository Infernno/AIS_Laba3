using System.Collections.Generic;
using System.Linq;
using ConsoleApp.DAL;
using ConsoleApp.Model;

namespace ConsoleApp.ViewModel
{
    /// <summary>
    /// Модель отображения сотрудников
    /// </summary>
    public class EmployeeViewModel
    {
        #region Fields

        private readonly IEmployeeRepository mRepository;
        private List<Employee> mEmployees;

        #endregion

        #region Properties

        public List<Employee> Employees
        {
            get { return mEmployees; }
        }

        #endregion

        #region Constructor

        public EmployeeViewModel(IEmployeeRepository repository)
        {
            mRepository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Загружает данные из базы
        /// </summary>
        public void LoadFromDatabase()
        {
            mEmployees = mRepository.GetAll().ToList();
        }

        /// <summary>
        /// Повышает или понижает зарплату сотруднику с указанным ID
        /// </summary>
        public void ChangeSalary(int id, int salary)
        {
            var employee = mEmployees.SingleOrDefault(e => e.ID == id);

            if (employee != null)
            {
                employee.Salary += salary;
            }
        }

        /// <summary>
        /// Увольняет сотрудника с указанным ID
        /// </summary>
        public void Fire(int id)
        {
            var employee = mEmployees.SingleOrDefault(e => e.ID == id);

            if (employee != null)
            {
                employee.Position = "Уволен";
                employee.Salary = 0;
            }
        }

        /// <summary>
        /// Сохраняет данные в базу
        /// </summary>
        public void Save()
        {
            foreach (var employee in mEmployees)
            {
                if (mRepository.GetById(employee.ID) != null)
                {
                    mRepository.Edit(employee);
                }
                else
                {
                    mRepository.Add(employee);
                }
            }
        }

        #endregion
    }
}
