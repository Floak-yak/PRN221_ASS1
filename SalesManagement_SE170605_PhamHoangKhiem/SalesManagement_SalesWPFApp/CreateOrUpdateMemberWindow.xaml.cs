using SalesManagement_BussinessObject;
using SalesManagement_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for CreateOrUpdateMemberWindow.xaml
    /// </summary>
    public partial class CreateOrUpdateMemberWindow : Window
    {
        private readonly IMemberRepository _memberRepository;
        public MemberObject mem;
        public CreateOrUpdateMemberWindow()
        {
            _memberRepository = new MemberRepository();
            InitializeComponent();
        }
        public CreateOrUpdateMemberWindow(MemberObject memberObject)
        {
            mem = memberObject;
            _memberRepository = new MemberRepository();
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var member = new MemberObject();
            member.Email = txtEmail.Text;
            member.Country = txtCountry.Text;
            member.CompanyName = txtCompanyName.Text;
            member.City = txtCity.Text;
            member.Password = txtPassword.Text; 
            if (_memberRepository.Create(member))
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
            mem.Email = txtEmail.Text;
            mem.Country = txtCountry.Text;
            mem.CompanyName = txtCompanyName.Text;
            mem.City = txtCity.Text;
            mem.Password = txtPassword.Text;
            mem.MemberId = mem.MemberId;
            if (_memberRepository.Update(mem))
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
            WindowMembers windowMembers = new();
            windowMembers.Show();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (mem != null)
            {
                txtEmail.Text = mem.Email;
                txtCountry.Text = mem.Country;
                txtCompanyName.Text = mem.CompanyName;
                txtCity.Text = mem.City;
                txtPassword.Text = mem.Password;
            }
        }
    }
}
