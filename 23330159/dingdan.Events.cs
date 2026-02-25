using System;
using System.Windows.Forms;
using _23330159.Data;
using _23330159.Models;

namespace _23330159
{
    public partial class dingdan : Form
    {
        // Provide constructor overload used by Main
        public dingdan(string username) : this()
        {
            try
            {
                // Directly call runtime attach method implemented in runtime partial
                AttachRuntimeHandlers(username);
            }
            catch
            {
                // fallback: store username in a private field if present
                try
                {
                    var f = this.GetType().GetField("username", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (f != null) f.SetValue(this, username);
                }
                catch { }
            }
        }

        private void dingdan_Load(object sender, EventArgs e)
        {
            // no-op here; runtime partial will handle loading if attached
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // no-op
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // no-op
        }
    }
}
