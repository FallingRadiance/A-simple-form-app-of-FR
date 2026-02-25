using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _23330159.Data;
using _23330159.Models;
using System.Text.RegularExpressions;

namespace _23330159
{
    public partial class sign_up : Form
    {
        public bool RegistrationSuccessful { get; private set; }
        public string Username { get; private set; }
        public sign_up()
        {
            InitializeComponent();
            RegistrationSuccessful = false; // 默认注册不成功

            // wire validation handlers
            phoneNumber.TextChanged += phoneNumber_TextChanged;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;
            email.TextChanged += email_TextChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 验证用户输入
            if (string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请输入用户名和密码", "错误",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate phone
            var phone = phoneNumber.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(phone) && phone.Length != 11)
            {
                MessageBox.Show("手机号必须是11位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate email
            var mail = email.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(mail) && !IsValidEmail(mail))
            {
                MessageBox.Show("邮箱不合法", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 检查两次密码是否一致（如果有确认密码框）
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("两次输入的密码不一致", "错误",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. 这里可以添加更多验证逻辑，如用户名是否已存在等
            var uname = txtUsername.Text.Trim();
            try
            {
                var users = DataStore.LoadUsers();
                if (users.Exists(u => string.Equals((u.Username ?? string.Empty).Trim(), uname, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("用户名已存在，请选择其他用户名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Enforce phone uniqueness: one phone number per user
                if (!string.IsNullOrEmpty(phone) && users.Exists(u => (u.PhoneNumber ?? string.Empty).Trim() == phone))
                {
                    MessageBox.Show("该手机号已被使用，一个手机号只能注册一个用户", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. 执行注册逻辑（例如保存到数据库）
                var newUser = new User
                {
                    Username = uname,
                    Password = txtPassword.Text,
                    Email = mail,
                    PhoneNumber = phone,
                    Address = address.Text?.Trim() ?? string.Empty
                };
                users.Add(newUser);
                DataStore.SaveUsers(users);

                // 5. 设置注册结果
                this.Username = newUser.Username;
                this.RegistrationSuccessful = true;

                // 6. 显示成功消息
                MessageBox.Show("注册成功！", "成功",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 7. 关闭注册窗体并返回OK
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"注册失败：{ex.Message}", "错误",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        // validation handlers
        private void phoneNumber_TextChanged(object sender, EventArgs e)
        {
            var p = phoneNumber.Text?.Trim() ?? string.Empty;
            labelPhoneError.Visible = p.Length > 0 && p.Length != 11;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // update confirm check as user types
            labelConfirmPwdError.Visible = !string.IsNullOrEmpty(txtConfirmPassword.Text) && txtConfirmPassword.Text != txtPassword.Text;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            labelConfirmPwdError.Visible = txtConfirmPassword.Text != txtPassword.Text;
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            var m = email.Text?.Trim() ?? string.Empty;
            labelEmailError.Visible = m.Length > 0 && !IsValidEmail(m);
        }

        private bool IsValidEmail(string address)
        {
            if (string.IsNullOrEmpty(address)) return false;

            // Must contain exactly one @
            var atCount = address.Count(c => c == '@');
            if (atCount != 1) return false;

            var parts = address.Split('@');
            var local = parts[0];
            var domain = parts[1];

            // local part checks
            if (string.IsNullOrEmpty(local) || local.Length > 64) return false;
            // cannot start or end with dot
            if (local.StartsWith('.') || local.EndsWith('.')) return false;
            // allowed characters in local: letters, digits, . _ % + -
            if (!Regex.IsMatch(local, "^[A-Za-z0-9._%+\\-]+$")) return false;

            // domain checks
            if (string.IsNullOrEmpty(domain)) return false;
            if (!domain.Contains('.')) return false;
            var domainParts = domain.Split('.');
            // tld must be letters only and at least 2
            var tld = domainParts.Last();
            if (tld.Length < 2 || !Regex.IsMatch(tld, "^[A-Za-z]+$")) return false;

            // basic domain label validation
            foreach (var label in domainParts)
            {
                if (string.IsNullOrEmpty(label)) return false; // no empty labels
                if (!Regex.IsMatch(label, "^[A-Za-z0-9-]+$")) return false;
                if (label.StartsWith("-") || label.EndsWith("-")) return false;
            }

            return true;
        }
    }
}
