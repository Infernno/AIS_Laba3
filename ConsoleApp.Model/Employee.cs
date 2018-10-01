using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp.Model
{
    /// <summary>
    /// Модель, описывающая сотрудника организации
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        private string mFullname;
        private string mPosition;
        private int mSalary;

        private Cat mCat;

        #endregion

        #region Properties

        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Fullname
        {
            get => mFullname;
            set
            {
                mFullname = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Position
        {
            get => mPosition;
            set
            {
                mPosition = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public int Salary
        {
            get => mSalary;
            set
            {
                mSalary = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Кот сотрудника
        /// </summary>
        public Cat HomeCat
        {
            get => mCat;
            set
            {
                mCat = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public Employee()
        {

        }

        public Employee(int id, string fullname, string position, int salary, Cat cat)
        {
            ID = id;
            Fullname = fullname;
            Position = position;
            Salary = salary;
            HomeCat = cat;
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"#{ID} - {Fullname} - {Position} - {Salary}$";
        }

        #endregion

    }
}
