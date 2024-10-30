using Microsoft.EntityFrameworkCore.Query.Internal;
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
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        private IOrderRepository _orderRepository ;
        ICollection<OrderObject> orders;
        public WindowOrders()
        {
            _orderRepository = new OrderRepository();
            InitializeComponent();
        }

        public WindowOrders(ICollection<OrderObject> orderObjects)
        {
            _orderRepository = new OrderRepository();
            orders = orderObjects;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dtgDataGrid.ItemsSource = orders;
            if (orders != null)
            {
                dtgDataGrid.ItemsSource = _orderRepository.GetOrderObjects();
            }
        }

        private void dtgDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

            if (row != null)
            {
                DataGridCell dataGridCell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)dataGridCell.Content).Text;
                var order = _orderRepository.GetOrderById(int.Parse(id));
                if (order != null)
                {
                    txtMemberId.Text = order.MemberId.ToString();
                    txtFreight.Text = order.Freight.ToString(); 
                    txtOrderDate.Text = order.OrderDate.ToString();
                    txtRequiredDate.Text = order.RequiredDate.ToString();   
                    txtShippedDate.Text = order.ShippedDate.ToString();
                    txtOrderId.Text = order.OrderId.ToString();
                }
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            OrderObject order = new();
            if (!string.IsNullOrEmpty(txtFreight.Text) && !string.IsNullOrEmpty(txtRequiredDate.Text) && !string.IsNullOrEmpty(txtOrderDate.Text) && !string.IsNullOrEmpty(txtShippedDate.Text))
            {
                try
                {
                    order.MemberId = int.Parse(txtMemberId.Text);
                    order.Freight = decimal.Parse(txtFreight.Text);
                    order.RequiredDate = DateTime.Parse(txtRequiredDate.Text);
                    order.OrderDate = DateTime.Parse(txtOrderDate.Text);
                    order.ShippedDate = DateTime.Parse(txtShippedDate.Text);
                    _orderRepository.CreateOrder(order);
                    MessageBox.Show("Create success");

                }
                catch
                {
                    MessageBox.Show("Some thing wrong");
                }
            }
            else
            {
                MessageBox.Show("Please input Order");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            OrderObject order = _orderRepository.GetOrderById(int.Parse(txtOrderId.Text));
            if (!string.IsNullOrEmpty(txtFreight.Text) && !string.IsNullOrEmpty(txtRequiredDate.Text) && !string.IsNullOrEmpty(txtOrderDate.Text) && !string.IsNullOrEmpty(txtShippedDate.Text))
            {
                try
                {
                    order.Freight = decimal.Parse(txtFreight.Text);
                    order.RequiredDate = DateTime.Parse(txtRequiredDate.Text);
                    order.OrderDate = DateTime.Parse(txtOrderDate.Text);
                    order.ShippedDate = DateTime.Parse(txtShippedDate.Text);
                    _orderRepository.CreateOrder(order);
                    MessageBox.Show("Update success");

                }
                catch
                {
                    MessageBox.Show("Some thing wrong");
                }
            }
            else
            {
                MessageBox.Show("Please input Order");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderId.Text))
            {
                _orderRepository.DeleteOrder(int.Parse(txtOrderId.Text));
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Please choose order");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dtgDataGrid.ItemsSource = orders;
            if (orders != null)
            {
                dtgDataGrid.ItemsSource = _orderRepository.GetOrderObjects();
            }
        }
    }
}
