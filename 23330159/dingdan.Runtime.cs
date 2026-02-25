using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _23330159.Data;
using _23330159.Models;

namespace _23330159
{
    public partial class dingdan : Form
    {
        private string _runtimeUsername;
        private List<Order> _runtimeOrders = new List<Order>();

        // attach additional runtime logic without touching designer-generated partials
        public dingdan(string username, bool runtimeAttach) : this()
        {
            // allow caller to create instance that will wire runtime handlers
            _runtimeUsername = NormalizeUsername(username);
            this.Load += Dingdan_RuntimeLoad;
        }

        // Public method used by reflection from other partials to attach runtime handlers
        public void AttachRuntimeHandlers(string username)
        {
            _runtimeUsername = NormalizeUsername(username);
            this.Load += Dingdan_RuntimeLoad;
        }

        private static string NormalizeUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            // treat the Chinese literal for anonymous as empty so history shows sensible results
            if (string.Equals(username, "匿名", StringComparison.OrdinalIgnoreCase)) return null;
            return username;
        }

        private void Dingdan_RuntimeLoad(object sender, EventArgs e)
        {
            try
            {
                // ensure grids have expected columns
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("Id", "订单号");
                    dataGridView1.Columns.Add("CreatedAt", "创建时间");
                    dataGridView1.Columns.Add("Username", "用户名");
                    dataGridView1.Columns.Add("PhoneNumber", "手机号");
                    dataGridView1.Columns.Add("Total", "总额");
                }

                if (dataGridView2.Columns.Count == 0)
                {
                    dataGridView2.Columns.Add("DrinkName", "名称");
                    dataGridView2.Columns.Add("UnitPrice", "单价");
                    dataGridView2.Columns.Add("Quantity", "数量");
                    dataGridView2.Columns.Add("Subtotal", "小计");
                }

                LoadOrdersForUser();

                dataGridView1.SelectionChanged -= Runtime_SelectionChanged;
                dataGridView1.SelectionChanged += Runtime_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载订单时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrdersForUser()
        {
            _runtimeOrders = DataStore.LoadOrders();
            IEnumerable<Order> list = _runtimeOrders;
            if (!string.IsNullOrEmpty(_runtimeUsername))
            {
                list = _runtimeOrders.Where(o => string.Equals(o.Username ?? string.Empty, _runtimeUsername, StringComparison.OrdinalIgnoreCase));
            }

            dataGridView1.Rows.Clear();
            foreach (var o in list.OrderByDescending(o => o.CreatedAt))
            {
                dataGridView1.Rows.Add(o.Id, o.CreatedAt.ToString("g"), o.Username, o.PhoneNumber, o.Total.ToString("F2"));
            }

            // select first row to show details if exists
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[0].Selected = true;
                Runtime_SelectionChanged(this, EventArgs.Empty);
            }
            else
            {
                dataGridView2.Rows.Clear();
            }
        }

        private void Runtime_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            var order = _runtimeOrders.Find(o => o.Id == id);
            if (order == null) return;

            dataGridView2.Rows.Clear();
            foreach (var it in order.Items)
            {
                dataGridView2.Rows.Add(it.DrinkName, it.UnitPrice.ToString("F2"), it.Quantity, (it.UnitPrice * it.Quantity).ToString("F2"));
            }
        }
    }
}
