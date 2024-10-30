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
    /// Interaction logic for WindowCategory.xaml
    /// </summary>
    public partial class WindowCategory : Window
    {
        private readonly ICategoryRepository _categoryRepository;
        public WindowCategory()
        {
            _categoryRepository = new CategoryRepository();
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dtgDataGridView.ItemsSource = _categoryRepository.GetCategoryObjects();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CategoryObject category = new();
            if (!string.IsNullOrEmpty(txtCategoryId.Text) && !string.IsNullOrEmpty(txtCategoryName.Text))
            {
                try
                {
                    category.CategoryName = txtCategoryName.Text;
                    _categoryRepository.CreateCategory(category);
                    MessageBox.Show("Create success");

                }
                catch
                {
                    MessageBox.Show("Some thing wrong");
                }
            }
            else
            {
                MessageBox.Show("Please input Category name and id");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryId.Text) && !string.IsNullOrEmpty(txtCategoryName.Text))
            {
                var category = _categoryRepository.GetCategoryById(int.Parse(txtCategoryId.Text));
                category.CategoryName = txtCategoryName.Text;
                _categoryRepository.UpdateCategory(category);
                Load();
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Please choose category");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryId.Text))
            {
                _categoryRepository.DeleteCategory(int.Parse(txtCategoryId.Text));
                Load();
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Please choose category");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

            if (row != null)
            {
                DataGridCell dataGridCell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)dataGridCell.Content).Text;
                var category = _categoryRepository.GetCategoryById(int.Parse(id));
                if (category != null)
                {
                    txtCategoryId.Text = category.CategoryId.ToString();
                    txtCategoryName.Text = category.CategoryName.ToString();
                }
            }
        }
        public void Load()
        {
            dtgDataGridView.ItemsSource = _categoryRepository.GetCategoryObjects();
        }
        private void dtgDataGridView_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
