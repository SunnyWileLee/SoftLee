using AutoBid.Client.Domain;
using AutoBid.Client.Models;
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
    public partial class FormCart : Form
    {
        private readonly BidTask bidder = new BidTask { };
        private readonly BidPriceService bidPriceService = new BidPriceService { };
        private string productid = string.Empty;

        public FormCart()
        {
            InitializeComponent();
        }

        private void FormCart_Load(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void dgvProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int row = e.RowIndex;
                if (row < 0)
                {
                    return;
                }
                try
                {
                    productid = dgvProducts.Rows[row].Cells["商品编号"].Value.ToString();
                }
                catch
                {

                }
            }
        }

        private void btnSetPrice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productid))
            {
                MessageBox.Show("请先选择商品");
                return;
            }
            else
            {
                FormMoney form = new FormMoney(productid);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    var price = new BidPriceModel()
                    {
                        MaxPrice = form.Money,
                        IdResoTemp = productid
                    };
                    bidPriceService.SetPrice(price);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "开始")
            {
                btnStart.Text = "暂停";
                bidder.StartBid();
            }
            else
            {
                btnStart.Text = "开始";
                bidder.Pause();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void LoadCart()
        {
            var prices = bidPriceService.GetPrices();
            CartSearcher searcher = new CartSearcher();
            var products = searcher.Search();

            DataTable table = new DataTable();
            table.Columns.Add("商品信息", typeof(string));
            table.Columns.Add("商品重量", typeof(string));
            table.Columns.Add("商品底价", typeof(string));
            table.Columns.Add("当前加价", typeof(string));
            table.Columns.Add("我的加价", typeof(string));
            table.Columns.Add("最高加价", typeof(string));
            table.Columns.Add("是否领先", typeof(string));
            table.Columns.Add("商品编号", typeof(string));

            foreach (var product in products)
            {

                DataRow row = table.NewRow();
                row["商品信息"] = product.Info;
                row["商品重量"] = product.Weight;
                row["商品底价"] = product.Price;
                row["当前加价"] = product.CurrentPrice;
                row["我的加价"] = product.MyPrice;
                row["是否领先"] = product.IsOwn;
                row["商品编号"] = product.IdResoTemp;
                var price = prices.FirstOrDefault(s => s.IdResoTemp == product.IdResoTemp);
                if (price != null)
                {
                    row["最高加价"] = price.MaxPrice;
                }

                table.Rows.Add(row);
            }

            dgvProducts.DataSource = table;

            for (int i = 0; i < dgvProducts.RowCount; i++)
            {
                var isown = dgvProducts.Rows[i].Cells["是否领先"].Value.ToString();
                if (Convert.ToBoolean(isown))
                {
                    dgvProducts.Rows[i].Cells["是否领先"].Style.BackColor = Color.Green;
                }
                else
                {
                    dgvProducts.Rows[i].Cells["是否领先"].Style.BackColor = Color.Red;
                }
            }
        }
    }
}
