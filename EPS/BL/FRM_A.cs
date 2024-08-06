using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp;
using System.Data.Entity.Migrations;
using System.Threading;
using System.Diagnostics;

namespace EPS
{
    public partial class FRM_A : DevExpress.XtraEditors.XtraForm
    {
        DBEPSEntities db;
        TB_ABC add;
        public FRM_A()
        {
            InitializeComponent();
            CheckState();
        }

       

        private void CheckState()
        {
            try
            {
                db = new DBEPSEntities();
                var rs1 = db.TB_ABC.Select(X => X.A).First();
                var rs2 = db.TB_ABC.Select(X => X.B).First();
                if (rs1==null)
                {
                    txt_state.Text = "هل تمتلك مفتاح تفعيل مرخص , يمكنك التفعيل الان ";
                    pic_key.BringToFront();
                    panel2.Enabled = true;
                }
                else
                {
                   
                    txt_state.Text = "البرنامج مفعل ";
                    pic_done.BringToFront();
                    textBox1.Text = Encoding.ASCII.GetString(rs1);
                    textBox2.Text = Encoding.ASCII.GetString(rs2);
                    panel2.Enabled = false;


                }
            }
            catch
            {

            }
        }

        private void txt_state_Click(object sender, EventArgs e)
        {
           

        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("قم بمليء الحقول رجاءا");
            }
            else
            {
                try
                {
                    IFirebaseConfig config = new FirebaseConfig
                    {
                        AuthSecret = "Enter AuthSecret",
                        BasePath = "BasePath here"
                    };
                    IFirebaseClient client = new FirebaseClient(config);

                    if (client != null)
                    {
                        // 
                        txt_state.Text = " ...يتم تفعيل المنتج الان ";
                        await Task.Run(()=> Thread.Sleep(2000));
                        FirebaseResponse response = await client.GetAsync($"liclist/{textBox1.Text}");
                        var key = response.Body.ToString();
                        if (key==textBox2.Text)
                        {
                            await Task.Run(() => Done());

                            db = new DBEPSEntities();
                            add = db.TB_ABC.First();
                            add.ID = add.ID;
                            add.A = Encoding.ASCII.GetBytes(textBox1.Text);
                            add.B = Encoding.ASCII.GetBytes(textBox2.Text);
                            db.Set<TB_ABC>().AddOrUpdate(add);
                            db.SaveChanges();
                            CheckState();
                            MessageBox.Show("تهانينا :) تم تفعيل البرنامج بنجاح , سيتم اعادة تشغيل البرنامج لضبط كافة الاعدادات");
                            Application.Restart();
                        }
                        else
                        {
                            CheckState();
                            txt_state.Text = "خطأ مفتاح المنتج غير صالح ";


                        }

                    }
                   


                }
                catch
                {
                    MessageBox.Show("يبدو انك غير متصل في الشبكة , عملية التفعيل تحتاج الى توفر الاتصال في الشبكة");

                }
            }
         
        }


        
     private async void Done()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "enter auth secret",
                BasePath = "enter path"
            };
            IFirebaseClient client = new FirebaseClient(config);

            var Date = new DataDone
            {
                UserName = textBox1.Text,
                Code=textBox2.Text

            };
            FirebaseResponse response = await client.PushAsync("liclistActive", Date);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("enter url here");
        }
    }

    class DataDone
    {
        public string UserName { get; set; }
        public string Code { get; set; }
    }
    
}