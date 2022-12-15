
using BusinessObject.Models;
using DataAccess.Repository;
using System.Text.RegularExpressions;

namespace SalesWinApp
{
    public partial class frmMemberDetail : Form
    {
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Member MemberInfo { get; set; }
        public frmMemberDetail()
        {
            InitializeComponent();
        }

        BindingSource source;

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberId.Text = MemberInfo.MemberId.ToString();
                txtEmail.Text = MemberInfo.Email;
                txtCompanyName.Text = MemberInfo.CompanyName;
                txtPassword.Text = MemberInfo.Password;
                txtCity.Text = MemberInfo.City;
                txtCountry.Text = MemberInfo.Country;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MemberError errors = new MemberError();
                bool found = false;
                string memberId = txtMemberId.Text;
                string pattern = @"^[0-9.]*$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(memberId) == false || memberId.Trim().Equals("") || int.Parse(memberId) < 0)
                {
                    found = true;
                    errors.memberIdError = "Member ID must be the number format and greater than 0!";
                }

                string email = txtEmail.Text;
                if (string.IsNullOrEmpty(email) || email.Equals(" "))
                {
                    found = true;
                    errors.emailError = "Email can not be empty";
                }

                string companyName = txtCompanyName.Text;
                if (string.IsNullOrEmpty(companyName) || companyName.Equals(" "))
                {
                    found = true;
                    errors.companyNameError = "Company name can not be empty";
                }

                string city = txtCity.Text;
                if (string.IsNullOrEmpty(city) || city.Equals(" "))
                {
                    found = true;
                    errors.cityError = "City can not be empty";
                }

                string country = txtCountry.Text;
                if (string.IsNullOrEmpty(country) || country.Equals(" "))
                {
                    found = true;
                    errors.countryError = "Country can not be empty";
                }
                string password = txtPassword.Text;
                if (string.IsNullOrEmpty(password) || password.Equals(" "))
                {
                    found = true;
                    errors.passwordError = "password can not be empty";
                }
                if (found)
                {
                    MessageBox.Show($"{errors.memberIdError} \n " +
                        $"{errors.emailError} \n " +
                        $"{errors.companyNameError} \n" +
                        $"{errors.cityError} \n" +
                        $"{errors.countryError} \n" +
                        $"{errors.passwordError}", "Add a new product - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Member mem = new Member
                    {
                        MemberId = int.Parse(memberId),
                        Email = email,
                        CompanyName = companyName,
                        City = city,
                        Country = country,
                        Password = password
                    };
                    if (InsertOrUpdate == false)
                    {
                        MemberRepository.InsertMember(mem);
                    }
                    else
                    {
                        MemberRepository.UpdateMember(mem);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new order" : "Update a order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public record MemberError()
        {
            public string? memberIdError { get; set; }
            public string? emailError { get; set; }
            public string? companyNameError { get; set; }
            public string? cityError { get; set; }
            public string? countryError { get; set; }
            public string? passwordError { get; set; }
        }
        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
