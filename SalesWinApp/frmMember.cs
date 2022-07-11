using DataAccess.Repository;
using BusinessObject.Models;

namespace SalesWinApp
{
    public partial class frmMember : Form
    {
        public frmMember()
        {
            InitializeComponent();
        }

        IMemberRepository memberRepository = new MemberRepository();
        public bool IsAdmin { get; set; }
        public Member Mem { get; set; }

        BindingSource source;
        void authen()
        {
            btnLoad.Enabled = false;
            btnNew.Enabled = false;
            // btnDelete.Enabled = false;
        }
        private void frmMember_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            if (IsAdmin == false)
            {
                authen();
                var members = new List<Member>();
                members.Add(Mem);
                LoadMemberList(members);
            }
            //
            dgvMemberList.CellDoubleClick += dgvMemberList_CellDoubleClick;
        }
        private void ClearText()
        {
            txtMemberId.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }
        //
        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = Convert.ToInt32(txtMemberId.Text),
                    CompanyName = txtCompanyName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return member;
        }
        //
        public void LoadMemberList(IEnumerable<Member> members)
        {
            try
            {
                // The BindingSource component is designed to simplify
                // the process of binding controls to an underlying data source
                source = new BindingSource();
                source.DataSource = members;
                txtMemberId.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();

                txtMemberId.DataBindings.Add("Text", source, "MemberID");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                if (members.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var members = memberRepository.GetMembers();
            LoadMemberList(members);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Add car",
                InsertOrUpdate = false,
                MemberRepository = memberRepository

            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {
                var members = memberRepository.GetMembers();
                LoadMemberList(members);
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsAdmin == false)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                try
                {
                    var member = GetMemberObject();
                    //if(Mem != null)
                    //if(member.MemberId == Mem.MemberId)
                    //{
                    //    MessageBox.Show("Login Successfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);                     
                    //}
                    //else
                    //{
                    memberRepository.DeleteMember(member.MemberId);
                    //}                   
                    var members1 = memberRepository.GetMembers();
                    LoadMemberList(members1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a member");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMemberDetail frmMemberDetail = new frmMemberDetail()
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                MemberInfo = GetMemberObject(),
                MemberRepository = memberRepository
            };
            if (frmMemberDetail.ShowDialog() == DialogResult.OK)
            {

                if (IsAdmin == false)
                {
                    var members = new List<Member>();
                    members.Add(memberRepository.GetMemberByID(Mem.MemberId));
                    LoadMemberList(members);
                }
                else
                {
                    var members = memberRepository.GetMembers();
                    LoadMemberList(members);
                }

                //
                source.Position = source.Position - 1;
            }
        }

    }
}
