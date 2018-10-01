using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp.Model
{
    /// <summary>
    /// Модель, описывающая кота сотрудника
    /// </summary>
    public class Cat : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        private string mCatName;
        private string mCatBreed;

        #endregion

        #region Properties

        /// <summary>
        /// ID кота
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Кличка кота
        /// </summary>
        public string Name
        {
            get => mCatName;
            set
            {
                mCatName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Порода кота
        /// </summary>
        public string Breed
        {
            get => mCatBreed;
            set
            {
                mCatBreed = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public Cat()
        {

        }

        public Cat(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public Cat(int id, string name, string breed)
        {
            Id = id;
            Name = name;
            Breed = breed;
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Breed}";
        }

        #endregion
    }
}
