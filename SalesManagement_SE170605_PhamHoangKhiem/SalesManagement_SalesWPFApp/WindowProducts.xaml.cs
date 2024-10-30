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
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        private readonly IProductRepository _productRepository;
        public WindowProducts()
        {
            _productRepository = new ProductRepository();
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                var productObject = _productRepository.GetById(int.Parse(txtProductId.Text));
                CreateOrUpdateProductWindow createOrUpdateProductWindow = new(productObject);
                createOrUpdateProductWindow.btnCreate.IsEnabled = false;
                createOrUpdateProductWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please choose product to update");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateOrUpdateProductWindow createOrUpdateProductWindow = new ();
            createOrUpdateProductWindow.btnUpdate.IsEnabled = false;
            createOrUpdateProductWindow.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                _productRepository.RemoveProduct(int.Parse(txtProductId.Text));
                Load();
            }
            else
            {
                MessageBox.Show("Please select product to delete");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
             Load();
        }

        public void Load()
        {
            dtgDataGrid.ItemsSource = _productRepository.GetAll();
        }

        private void dtgDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

            DataGridCell dataGridCell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)dataGridCell.Content).Text;
            var product = _productRepository.GetById(int.Parse(id));
            if (product != null)
            {
                txtProductId.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName;
                txtCategoryId.Text = product.CategoryId.ToString();
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtUnitStock.Text = product.UnitStock.ToString();
                txtWeight.Text = product.Weight;
            }
        }

        private void dtgDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
