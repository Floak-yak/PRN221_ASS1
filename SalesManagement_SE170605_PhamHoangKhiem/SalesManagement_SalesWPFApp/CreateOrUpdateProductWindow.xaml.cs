using SalesManagement_BussinessObject;
using SalesManagement_DataAccess.Repositories;
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
using System.Windows.Shapes;

namespace SalesManagement_SalesWPFApp
{
    /// <summary>
    /// Interaction logic for CreateOrUpdateProductWindow.xaml
    /// </summary>
    public partial class CreateOrUpdateProductWindow : Window
    {
        private readonly IProductRepository _productRepository;
        public ProductObject product;
        public CreateOrUpdateProductWindow()
        {
            _productRepository = new ProductRepository();
            InitializeComponent();
        }
        public CreateOrUpdateProductWindow(ProductObject productObject)
        {
            product = productObject;
            _productRepository = new ProductRepository();
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                txtCategoryId.Text = product.CategoryId.ToString();
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtUnitStock.Text = product.UnitStock.ToString();
                txtWeight.Text = product.Weight;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var pro = new ProductObject();
            pro.CategoryId = int.Parse(txtCategoryId.Text);
            pro.ProductName = txtProductName.Text;
            pro.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
            pro.Weight = txtWeight.Text;
            pro.UnitStock = int.Parse(txtUnitStock.Text);

            if (_productRepository.CreateProduct(pro))
            {
                MessageBox.Show("Create success");
            }
            else
            {
                MessageBox.Show("Create Fail");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            product.CategoryId = int.Parse(txtCategoryId.Text);
            product.ProductName = txtProductName.Text;
            product.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
            product.Weight = txtWeight.Text;
            product.UnitStock = int.Parse(txtUnitStock.Text);

            if (_productRepository.UpdateProduct(product))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Update Fail");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowProducts windowProducts = new();
            windowProducts.Show();
        }
    }
}
