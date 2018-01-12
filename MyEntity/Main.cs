using CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyEntity
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void RefreshMain() {
            List<User> users = Methods.GetAllUsers();
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = users;
            
            if (users.Count!=0)
            {
                dataGridView1.Rows[0].Selected = true;
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                User user = Methods.FindUser(Convert.ToString(dataGridView1[1, 0].Value));


                List<Account> accounts = user.Accounts.ToList();
                dataGridView2.DataSource = accounts;
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }





        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshMain();
                     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modify modifyform = new Modify();
            modifyform.ShowDialog();
            RefreshMain();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count!=0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                using (UserContext db = new UserContext())
                {
                    User user =  db.Users.Find(id);
                    List<Account> accounts = user.Accounts.ToList();
                    dataGridView2.DataSource = accounts;
                }

            }
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index;
            if (dataGridView2.SelectedRows.Count!=0)
            {
               index = dataGridView2.SelectedRows[0].Index;
            }
            else
            {
                return;
            }
           
            int accnumber = 0;
            bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out accnumber);
            if (converted == false)
                return;
            
            
                
                Account account = Methods.FindAccOwner(accnumber);
                Report report = new Report(account);
                report.Show();
            

           
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


    

}

