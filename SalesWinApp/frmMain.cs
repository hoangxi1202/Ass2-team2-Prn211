using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.Models;
namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
       
        public bool IsAdmin { get; set; }
        public Member Mem { get; set; }
        void authen()
        {
            mnProduct.Enabled = false;
            mnReport.Enabled = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (IsAdmin == false)
            {
                authen();
            }
        }

        private void mnMember_Click(object sender, EventArgs e)
        {
            frmMember frm;
            if (IsAdmin)
            {
                frm = new frmMember
                {
                    IsAdmin = IsAdmin
                };
            }
            else
            {
                frm = new frmMember
                {
                    IsAdmin = IsAdmin,
                    Mem = Mem
                };

            }
            if (checkMidChildren(frm.Name))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void mnExit_Click(object sender, EventArgs e) => this.Close();

        private void mnProduct_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();

            if (checkMidChildren(frm.Name))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void mnOrder_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            if (IsAdmin)
            {
                frm = new frmOrder
                {
                    IsAdmin = IsAdmin
                };
            }
            else
            {
                frm = new frmOrder
                {
                    IsAdmin = IsAdmin,
                    Mem = Mem

                };
            }

            if (checkMidChildren(frm.Name))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void mnReport_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            if (checkMidChildren(frm.Name))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private bool checkMidChildren(string frmFormName)
        {
            if (this.MdiChildren.Length > 0)
            {
                Form[] frm = this.MdiChildren;
                for (int i = 0; i < frm.Length; i++)
                    if (frm[i].Name == frmFormName)
                        return false;
            }
            return true;
        }
    }
}
