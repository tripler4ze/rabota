using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp1.MainWindow;

namespace WpfApp1
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        private readonly ProductContext _context;

        public ProductListViewModel()
        {
            _context = new ProductContext();
            Products = _context.Products.Local.ToObservableCollection();
            _context.Products.Load();
        }

        public ObservableCollection<Product> Products { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
