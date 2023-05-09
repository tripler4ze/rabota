using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Products.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Products.Local.ToObservableCollection();
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UserWindow UserWindow = new UserWindow(new Product());
            if (UserWindow.ShowDialog() == true)
            {
                Product User = UserWindow.Product;
                db.Products.Add(User);
                db.SaveChanges();

            }

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Product? user = usersList.SelectedItem as Product;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            UserWindow UserWindow = new UserWindow(new Product
            {
                Id = user.Id,
                Price = user.Price,
                Name = user.Name,
                Description = user.Description
            }); ;

            if (UserWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Products.Find(UserWindow.Product.Id);
                if (user != null)
                {
                    user.Price = UserWindow.Product.Price;
                    user.Name = UserWindow.Product.Name;
                    user.Description = UserWindow.Product.Description;
                    db.SaveChanges();
                    usersList.Items.Refresh();

                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Product? user = usersList.SelectedItem as Product;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            db.Products.Remove(user);
            db.SaveChanges();
        }
        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public string Description { get; set; }

            public Guid Id { get; set; }

        }
        
    }
}
