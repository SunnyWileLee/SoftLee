using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBid.Client
{
    public partial class FormMoney : Form
    {
        private string _bidsn;
        private string _id;
        private int _money = 0;
        public FormMoney(string package, string bidsn, string id)
        {
            InitializeComponent();
            tbPackage.Text = package;
            _bidsn = bidsn;
            _id = id;
        }
        public FormMoney(string package)
        {
            InitializeComponent();
            tbPackage.Text = package;
        }
        public int Money
        {
            get
            {
                return _money;
            }
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            int money;
            if (!int.TryParse(tbMaxMoney.Text, out money))
            {
                MessageBox.Show("请输入合法的数字");
                return;
            }
            _money = money;
            this.Close();
        }
    }
}
