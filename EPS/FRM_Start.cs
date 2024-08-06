using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EPS.AddPage;
using EPS.PL;

namespace EPS
{
    public partial class FRM_Start : SplashScreen
    {
        int st;
        public FRM_Start()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2021-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void peImage_EditValueChanged(object sender, EventArgs e)
        {

        }

        private async void FRM_Start_Load(object sender, EventArgs e)
        {
            await Task.Run(() => Thread.Sleep(2000));

            // Check Login 

            lb_state.Text = "... الاتصال بقاعدة البيانات";
            var state = await Task.Run(() => CheckLogin());
            if (state == 1)
            {
                AddPage.User_Login _Login = new AddPage.User_Login();
                _Login.Show();
                Hide();
            }
            else if(state==0)
            {
                Add_Users page = new Add_Users();
                UsersPage usersPage = new UsersPage();
                page.btn_add.Text = "تسجيل واعادة تشغيل";
                page.edt_name.Text = "";
                page.id = 0;
                page.page = usersPage;
                page.btn_addclose.Visible = false;
                page.Show();
                Hide();

            }
            else
            {
                MessageBox.Show("خطأ في الاتصال في قاعدة البيانات , يبدو ان لديك مشكلة في عملية تثبيت البرنامج ");
                Application.Exit();
            }

        }

        private int CheckLogin()
        {
            try
            {
                DBEPSEntities db = new DBEPSEntities();

                var data = db.TB_Users.Select(x=>x.FullName).ToList();
                if (data.Count >0)
                {
                    st = 1;
                }
                else
                {
                    st = 0;
                }


            }
            catch
            {
                return 2;
            }
            return st;

        }
    }
}