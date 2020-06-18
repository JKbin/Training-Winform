﻿using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class LoginForm : MetroForm              //메트로폼 적용
    {
        string strConnString = "Data Source=192.168.0.83;Initial Catalog=BookRentalDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
                                              //    IP,           사용하고자하는 DB, 연결문자열이 필수로 들어가야함                                   
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }
        /// <summary>
        /// 캔슬버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            //Application.Exit();                   //프로그램 종료
            Environment.Exit(0);                    //프로그램 종료 (이 코드를 쓰는것을 권장)

        }
        /// <summary>
        /// 로그인 처리버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void TxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)        // 엔터
            {
                TxtPassword.Focus();
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)        //로그인메서드로 이동
            {
                LoginProcess();
            }
        }

        private void LoginProcess()
        {
            //throw new NotImplementedException();
            if (string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))         //null이거나 값이 비어있을 때
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                      //ID,Password창이 비어있을 때 오류가 뜬다고 알려줘야함
                return;

            }
            //로그인 창, 비밀번호 창의 값이 비어있으면 안된다.

            string strUserid = string.Empty;

            using (SqlConnection conn = new SqlConnection(strConnString))               //Sql 연결하는 것
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select userID from usertbl " +
                    " where userid = @userID " +
                    " and password = @Password";
                SqlParameter parmUserID = new SqlParameter("@userID", SqlDbType.VarChar, 12);               //DB의 type과 int size를 넣어야함
                parmUserID.Value = TxtUserID.Text;
                cmd.Parameters.Add(parmUserID);
                //ID
                SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                parmPassword.Value = TxtPassword.Text;
                cmd.Parameters.Add(parmPassword);
                //Password

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                strUserid = reader["userID"].ToString();

                MetroMessageBox.Show(this, "접속성공", "로그인");
                Debug.WriteLine("On the Debug");





            }
        }
    }
}