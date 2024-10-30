using Microsoft.Extensions.Configuration;
using SalesManagement_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        IMemberRepository _memberRepository;
        IOrderRepository _orderRepository;
        public WindowLogin()
        {
            InitializeComponent();
            _orderRepository = new OrderRepository();
            _memberRepository = new MemberRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input email or password");
                return;
            }

            if (CheckLoginInJsonFile())
            {
                if (cb.SelectedItem == null)
                {
                    MessageBox.Show("Please choose window");
                    return;
                }
                switch (cb.SelectedItem)
                {
                    case "Member window":
                        WindowMembers windowMembers = new WindowMembers();
                        windowMembers.Show();
                        break;
                    case "Oder window":
                        WindowOrders windowOrders = new WindowOrders();
                        windowOrders.Show();
                        break;
                    case "Product window":
                        WindowProducts windowProducts = new WindowProducts();
                        windowProducts.Show();
                        break;
                    case "Category window":
                        WindowCategory windowCategory = new WindowCategory();
                        windowCategory.txtCategoryId.IsReadOnly = true;
                        windowCategory.Show();
                        break;
                }
            }
            else
            {
                var member = _memberRepository.GetMemberByEmail(txtEmail.Text);

                if (member == null)
                {
                    MessageBox.Show("Wrong Email");
                }
                else if (txtPassword.Text.Equals(member.Password))
                {
                    if (cb.SelectedItem == null)
                    {
                        MessageBox.Show("Please choose window");
                        return;
                    }
                    switch (cb.SelectedItem)
                    {
                        case "Member window":
                            WindowMembers windowMembers = new WindowMembers();
                            windowMembers.btnAdd.IsEnabled = false;
                            windowMembers.btnDelete.IsEnabled = false;
                            windowMembers.btnUpdate.IsEnabled = false;
                            windowMembers.btnViewOrder.IsEnabled = false;
                            windowMembers.Show();
                            break;
                        case "Oder window":
                            var order = _orderRepository.GetOrderObjects();
                            WindowOrders windowOrders = new WindowOrders(order);
                            windowOrders.btnCreate.IsEnabled = false;
                            windowOrders.btnDelete.IsEnabled = false;
                            windowOrders.btnUpdate.IsEnabled = false;
                            windowOrders.Show();
                            break;
                        case "Product window":
                            WindowProducts windowProducts = new WindowProducts();
                            windowProducts.btnAdd.IsEnabled = false;
                            windowProducts.btnDelete.IsEnabled = false;
                            windowProducts.btnUpdate.IsEnabled = false;
                            windowProducts.Show();
                            break;
                        case "Category window":
                            WindowCategory windowCategory = new WindowCategory();
                            windowCategory.btnCreate.IsEnabled = false;
                            windowCategory.btnDelete.IsEnabled = false;
                            windowCategory.btnUpdate.IsEnabled = false;
                            windowCategory.txtCategoryId.IsReadOnly = true;
                            windowCategory.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        internal bool CheckLoginInJsonFile()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            if(configuration["AdminAccount:Email"].Equals(txtEmail.Text) && configuration["AdminAccount:Password"].Equals(txtPassword.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cb.Items.Add("Member window");
            cb.Items.Add("Oder window");
            cb.Items.Add("Product window");
            cb.Items.Add("Category window");
        }
    }
}
