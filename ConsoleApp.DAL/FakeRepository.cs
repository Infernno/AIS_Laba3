using System.Linq;
using System.Collections.Generic;
using ConsoleApp.Model;

namespace ConsoleApp.DAL
{
    public class FakeRepository : IEmployeeRepository
    {
        private readonly List<Employee> mEmployees = new List<Employee>();
        /*
        {
            new Employee(0, "Свиридов Владислав Сергеевич", "СЕО", 250),
            new Employee(1, "Исмагилов Антон Русланович", "Программист", 1000),
            new Employee(2, "Еливанов Алексей Евгеньевич", "Инженер", 1200)
        };
        */

        public IEnumerable<Employee> GetAll()
        {
            return mEmployees;
        }

        public Employee GetById(int id)
        {
            return mEmployees.SingleOrDefault(e => e.ID == id);
        }

        public void Add(Employee employee)
        {
            if (mEmployees.Count > 0)
            {
                employee.ID = mEmployees.Last().ID + 1;
            }

            mEmployees.Add(employee);
        }

        public void Edit(Employee employee)
        {
            for (int i = 0; i < mEmployees.Count; i++)
            {
                if (mEmployees[i].ID == employee.ID)
                {
                    mEmployees[i] = employee;
                    break;
                }
            }
        }

        public void Remove(Employee employee)
        {
            mEmployees.Remove(employee);
        }
    }
}
