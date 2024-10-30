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
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        private readonly IMemberRepository _memberRepository;
        ICollection<OrderObject> orderObject = new List<OrderObject>();
        public WindowMembers()
        {
            _memberRepository = new MemberRepository();
            InitializeComponent();
        }

        private void dtgDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);

            DataGridCell dataGridCell = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)dataGridCell.Content).Text;
            var member = _memberRepository.GetMemberById(int.Parse(id));
            if (member != null)
            {
                txtMemberId.Text = member.MemberId.ToString();
                txtEmail.Text = member.Email;
                txtCountry.Text = member.Country;
                txtCompanyName.Text = member.CompanyName;
                txtCity.Text = member.City;
                if (member.Orders != null)
                {
                    orderObject = member.Orders;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateOrUpdateMemberWindow createOrUpdateMemberWindow = new CreateOrUpdateMemberWindow();
            createOrUpdateMemberWindow.btnUpdate.IsEnabled = false;
            createOrUpdateMemberWindow.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMemberId.Text))
            {
                var mem = _memberRepository.GetMemberById(int.Parse(txtMemberId.Text));
                CreateOrUpdateMemberWindow createOrUpdateMemberWindow = new (mem);
                createOrUpdateMemberWindow.btnCreate.IsEnabled = false;
                createOrUpdateMemberWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please choose member to update");
            }         
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMemberId.Text))
            {
                _memberRepository.Delete(int.Parse(txtMemberId.Text));
                Load();
            }
            else
            {
                MessageBox.Show("Please select member to delete");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        public void Load()
        {
            dtgDataGrid.ItemsSource = _memberRepository.GetAllMembers();
        }

        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders windowOrders = new WindowOrders(orderObject);
            windowOrders.Show();
        }
    }
}
