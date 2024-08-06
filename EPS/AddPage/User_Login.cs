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
using EPS.PL;
using EPS.BL;
using System.IO;

namespace EPS.AddPage
{
    public partial class User_Login : DevExpress.XtraEditors.XtraForm
    {
        public  int id;
        bool state;
        TB_Users add;
        DBEPSEntities db;
       


        public User_Login()
        {
            InitializeComponent();
        }

        private bool Save()
        {
            // check fields

            if (edt_username.Text == "" || edt_password.Text == ""  )
            {
                Message("اكمل الحقل لطفا");
            }
            else
            {
                // Add or edit
                if (id == 0)
                {
                    // Add
                    // Check Duplicate Data
                    
                    
                    
                        // Add
                        AddData();
                        state = true;
                    


                       


                    
                    
                }
               
            }
            return state;
        }

        private void AddData()
        {
            try
            {
                db = new DBEPSEntities();
                add = new TB_Users();
                var username = edt_username.Text;
                var password = edt_password.Text;
                add = db.TB_Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                if (add != null)
                {
                    // Login

                    FRM_Main main = new FRM_Main();
                    main.txt_username.Caption = add.FullName;
                    main.txt_role.Caption = "مدير";
                    add.UserState = 1;
                    db.Entry(add).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    main.Show();
                    Hide();


                }
                else
                {
                    Message("خطأ في معلومات تسجيل الدخول");
                }

                
               
               
            }
            catch
            {
                Message("خطأ , لطفا تحقق من متطلبات الادخال والاتصال بالسيرفر");

            }
        }


             
       


       

        
        private void Message( string message)
        {
            txt_message.Visible = true;
            timer1.Enabled = true;
            txt_message.Text = message;
            txt_message.BackColor = Color.Red;
            state = false;
        }

       

        private void btn_add_Click(object sender, EventArgs e)
        {
            Save();
        }

       

        private void Add_Categories_Activated(object sender, EventArgs e)
        {
            
        }

       

        private byte[] ConvertToByte()
        {
            MemoryStream ma = new MemoryStream();
            return ma.ToArray();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_message.Visible = false;
        }

        private void User_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void edt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}