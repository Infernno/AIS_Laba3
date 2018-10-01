using System.Collections.Generic;
using ConsoleApp.Model;

namespace ConsoleApp.DAL
{
    /// <summary>
    /// Интерфейс, описывающий репозиторий сотрудников
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Возвращает <see cref="IEnumerable{T}"/>, содержащий всех сотрудников 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();

        /// <summary>
        /// Возвращает <see cref="Employee"/> с указанным ID
        /// </summary>
        /// <param name="id">ID искомого сотрудника</param>
        /// <returns></returns>
        Employee GetById(int id);

        /// <summary>
        /// Добавляет сотрудника в базу данных
        /// </summary>
        /// <param name="employee"></param>
        void Add(Employee employee);

        /// <summary>
        /// Обновляет данные сотрудника в базе
        /// </summary>
        /// <param name="employee"></param>
        void Edit(Employee employee);

        /// <summary>
        /// Удаляет сотрудника из базы данных
        /// </summary>
        /// <param name="employee"></param>
        void Remove(Employee employee);
    }
}
