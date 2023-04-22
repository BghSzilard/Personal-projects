using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balogh_Szilard___tema_2.Model
{
    public class CategoryModel
    {
        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string> { "Personal", "Work", "Other" };
        private static readonly CategoryModel _categoryModel = new CategoryModel();
        public static CategoryModel Instance { get { return _categoryModel; } }
    }
}
