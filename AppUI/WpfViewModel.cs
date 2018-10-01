using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ConsoleApp.DAL;
using ConsoleApp.Model;

namespace AppUI
{
    public class WpfViewModel : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IEmployeeRepository mRepository;

        private ObservableCollection<Employee> mContainer;
        private Employee mSelectedValue = new Employee() { HomeCat = new Cat() };

        private string mFullname;
        private string mPosition;
        private int mSalary;
        private string mCatName;
        private string mCatBreed;

        #endregion

        #region Bindings

        public Employee Selected
        {
            get => mSelectedValue;
            set
            {
                mSelectedValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Employee> Items
        {
            get => mContainer;
            set
            {
                mContainer = value;
                OnPropertyChanged();
            }
        }

        public string Fullname
        {
            get => mFullname;
            set
            {
                mFullname = value;
                OnPropertyChanged();
            }
        }

        public string Position
        {
            get => mPosition;
            set
            {
                mPosition = value;
                OnPropertyChanged();
            }
        }

        public int Salary
        {
            get => mSalary;
            set
            {
                mSalary = value;
                OnPropertyChanged();
            }
        }

        public string CatName
        {
            get => mCatName;
            set
            {
                mCatName = value;
                OnPropertyChanged();
            }
        }

        public string CatBreed
        {
            get => mCatBreed;
            set
            {
                mCatBreed = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Properties

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand CopyCommand { get; }

        public ICommand SaveDataCommand { get; }

        #endregion

        #region Constructor

        public WpfViewModel(IEmployeeRepository repository)
        {
            mRepository = repository;

            AddCommand = new RelayCommand(AddEmployee);
            EditCommand = new RelayCommand(EditEmployee);
            RemoveCommand = new RelayCommand(RemoveEmployee);
            CopyCommand = new RelayCommand(CopyData);
            SaveDataCommand = new RelayCommand(Save);

            Load();
        }

        #endregion

        #region Methods

        public void Load()
        {
            if (!mRepository.GetAll().Any())
            {
                mRepository.Add(new Employee(1, "Свиридов Владислав Сергеевич", "СЕО", 1232, new Cat("Сильвана", "Рэгдолл")));
                mRepository.Add(new Employee(2, "Исмагилов Антон Русланович", "Программист", 1000, new Cat("Валера", "Сфинкс")));
                mRepository.Add(new Employee(3, "Будажапова Алтана Генадьевна", "Инженер", 2312, new Cat("Батон", "Британская короткошерстная")));
            }

            Items = new ObservableCollection<Employee>(mRepository.GetAll());
        }

        public void AddEmployee()
        {
            var item = new Employee();
            var last = Items.Last();

            if (last != null)
            {
                item.ID = last.ID + 1;
            }

            item.Fullname = Fullname;
            item.Position = Position;
            item.Salary = Salary;

            item.HomeCat = new Cat(CatName, CatBreed);

            Items.Add(item);
        }

        public void EditEmployee()
        {
            if (Selected != null)
            {
                Selected.Fullname = Fullname;
                Selected.Position = Position;
                Selected.Salary = Salary;
                Selected.HomeCat.Name = CatName;
                Selected.HomeCat.Breed = CatBreed;
            }
        }

        public void RemoveEmployee()
        {
            if (Selected != null)
            {
                Debug.WriteLine($"Removed: {Selected}");
                Items.Remove(Selected);
            }
        }

        public void CopyData()
        {
            Fullname = Selected.Fullname;
            Position = Selected.Position;
            Salary = Selected.Salary;
            CatName = Selected.HomeCat.Name;
            CatBreed = Selected.HomeCat.Breed;
        }

        public void Save()
        {
            foreach (var item in Items)
            {
                if (mRepository.GetById(item.ID) != null)
                {
                    mRepository.Edit(item);
                }
                else
                {
                    mRepository.Add(item);
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
