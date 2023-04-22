using Balogh_Szilard___tema_2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Balogh_Szilard___tema_2.ViewModel
{
    public class CategoryViewModel:ViewModelBase
    {
        private CategoryModel _categoryModel = CategoryModel.Instance;

        public ObservableCollection<string> Categories { get; }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        private string newCategoryName;
        public string NewCategoryName
        {
            get { return newCategoryName; }
            set
            {
                if (newCategoryName != value)
                {
                    newCategoryName = value;
                    OnPropertyChanged(nameof(NewCategoryName));
                }
            }
        }

        public ICommand AddCategoryCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public CategoryViewModel()
        {
            AddCategoryCommand = new RelayCommand(AddCategory);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory);
            Categories = new ObservableCollection<string>(_categoryModel.Categories);
        }

        private void AddCategory(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewCategoryName))
            {
                Categories.Add(NewCategoryName);
                _categoryModel.Categories.Add(NewCategoryName);
                NewCategoryName = string.Empty;
            }
        }

        private void DeleteCategory(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(SelectedCategory))
            {
                _categoryModel.Categories.Remove(SelectedCategory);
                Categories.Remove(SelectedCategory);
                SelectedCategory = null;
            }
        }
    }
}
