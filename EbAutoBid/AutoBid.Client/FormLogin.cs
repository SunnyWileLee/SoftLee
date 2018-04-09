using AutoBid.Client.Domain;
using AutoBid.Client.Models;
using AutoBid.Client.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoBid.Client
{
    public partial class FormLogin : Form
    {

        private readonly ApiHttpExecutor apiHttpExecutor = new ApiHttpExecutor { };
        public const string VersionXml = "bidder.xml";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var html = webBrowser1.Document.Body.InnerHtml;
            if (!html.Contains("请输入您的用户名和密码"))
            {
                UserService userService = new UserService();
                var users = userService.GetUsers();
                var user = users.FirstOrDefault(s => html.Contains(s.Name));

                if (user != null)//登录成功
                {
                    UserModel.CurrentUserId = user.Id;
                    FormCart form = new FormCart();
                    this.Hide();
                    if (DialogResult.Cancel == form.ShowDialog())
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("用户未授权");
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            var currentVersion = GetCurrentVersion();
            var newVersion = GetNewVersion();
            if (currentVersion >= newVersion)
            {
                webBrowser1.Navigate("https://sso.ansteel.cn/cas/login?service=http://eb.ansteel.cn/sales-web/shiro-cas&locale=zh_CN");
            }
            else
            {
                MessageBox.Show("检测到新版本，点击确认开始更新");
                Process.Start("Update.exe");
                this.Close();
            }
        }

        private int GetNewVersion()
        {
            var version = apiHttpExecutor.Get($"{ApiHttpExecutor.ApiDomian}/Client/Version");
            return int.Parse(version);
        }

        private void UpdateCurrentVersion(int version)
        {
            XDocument xml = XDocument.Load(VersionXml);
            xml.Root.Element("Version").Value = version.ToString();
            xml.Save(VersionXml);
        }

        private int GetCurrentVersion()
        {
            XDocument xml = XDocument.Load(VersionXml);
            var version = xml.Root.Element("Version").Value;
            return int.Parse(version);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var uri = e.Url;
            var cookieString = CookieHelper.GetCookieString(e.Url.ToString());
            if (!string.IsNullOrEmpty(cookieString))
            {
                var cs = cookieString.Split(';');
                CookieContainer cookies = new CookieContainer();
                for (int i = 0; i < cs.Length; i++)
                {
                    try
                    {
                        var array = cs[i].Split('=');
                        string name = array[0].Trim();
                        string value = array[1];
                        Cookie co = new Cookie();
                        co.Name = name;
                        co.Value = value;
                        co.Domain = uri.Host;
                        cookies.Add(co);
                    }
                    catch (Exception ex)
                    {

                    }
                    
                }
                CookieHelper.Cookies = cookies;
            }
        }
    }
}
