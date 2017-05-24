using CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEntity
{
    public partial class Modify : Form
    {
        public Modify()
        {
            InitializeComponent();
        }

        private void Modify_Load(object sender, EventArgs e)
        {

            RefreshAll();

        }
        private void RefreshAll()
        {
            
            RefreshUsers(DeleteUserComboBox);
            RefreshUsers(comboBox1);
            RefreshUsers(comboBox2);
            RefreshUsers(comboBox7);
            RefreshUsers(comboBox4);
            RefreshUsers(comboBox9);


            RefreshAccounts(DeleteAccComboBox,DeleteUserComboBox);
            RefreshAccounts(comboBox3, comboBox2);
            RefreshAccounts(comboBox5, comboBox7);
            RefreshAccounts(comboBox8, comboBox4);
            RefreshAccounts(comboBox10, comboBox9);
            RefreshContribution(DeleteContrComboBox, comboBox3);
            RefreshContribution(comboBox6, comboBox5);



        }

        private void RefreshUsers(ComboBox combobox)
        {
            combobox.Items.Clear();
            combobox.Text = "";
            List<User> lst = Methods.GetAllUsers();
            foreach (User user in lst)
            {

                combobox.Items.Add(user.Name);
               
            }
            if (lst.Count != 0)
            {
                combobox.SelectedIndex = 0;
            }



        }

        private void RefreshAccounts(ComboBox combobox, ComboBox depending)
        {
            combobox.Items.Clear();
            combobox.Text = "";
            List<Account> lst = Methods.GetUserAccounts(depending.SelectedItem.ToString());
            foreach (Account account in lst)
            {
                combobox.Items.Add(account.AccNumber);
            }
            if (lst.Count != 0)
            {
                combobox.SelectedIndex = 0;
            }

        }

        private void RefreshContribution(ComboBox combobox, ComboBox depending)
        {
            
            combobox.Items.Clear();
            combobox.Text = "";
            if (depending.SelectedItem!=null)
            {
                List<Contribution> lst = Methods.GetAccContributions(Convert.ToInt32(depending.SelectedItem.ToString()));
                foreach (Contribution contrib in lst)
                {
                    combobox.Items.Add(contrib.Name);
                }
                if (lst.Count != 0)
                {
                    combobox.SelectedIndex = 0;
                }
            }
            
        }
        

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {

            Methods.RemoveUser(DeleteUserComboBox.SelectedItem.ToString());
            RefreshUsers(DeleteUserComboBox);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {


        }

        public void button1_Click(object sender, EventArgs e)
        {
            Methods.AddUser(new User { Name = NewNameBox.Text });
            RefreshAll();
            MessageBox.Show("User " + NewNameBox.Text+" successfully added");

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void AddAcc_Click(object sender, EventArgs e)
        {
            Account acc = new Account { AccNumber = Convert.ToInt32(NewAccountID.Text), Cash = Convert.ToInt32(NewAccountCash.Text) };
            Methods.AddAccount(Methods.FindUser(comboBox1.SelectedItem.ToString()),acc );
            RefreshAll();
            MessageBox.Show("Account with number " + NewAccountID.Text + " successfully added");

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void DeleteUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    RefreshAccounts(DeleteAccComboBox);
        //}

        private void DeleteAccComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void DeleteAccButton_Click(object sender, EventArgs e)
        //{

        //}

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RefreshAccounts(DeleteAccComboBox, comboBox1);
        }

        private void DeleteAccButton_Click_1(object sender, EventArgs e)
        {
            Methods.RemoveAccount(Convert.ToInt32(DeleteAccComboBox.SelectedItem.ToString()));
            RefreshAccounts(DeleteAccComboBox, comboBox1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Account acc = Methods.FindAccOwner(Convert.ToInt32(comboBox3.SelectedItem.ToString()));
            Contribution contr = new Contribution {Name= textBox1.Text};
            Methods.AddContribution(acc,contr);
            RefreshContribution(DeleteContrComboBox, comboBox3);
            RefreshContribution(comboBox6, comboBox5);
            MessageBox.Show("Contribution with name " + textBox1.Text + " successfully added");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAccounts(comboBox3, comboBox2);
            RefreshContribution(DeleteContrComboBox, comboBox3);
        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshContribution(DeleteContrComboBox,comboBox3);
        }

        private void DeleteContrButton_Click(object sender, EventArgs e)
        {
            Methods.RemoveContribution(Convert.ToInt32(comboBox3.SelectedItem.ToString()), DeleteContrComboBox.SelectedItem.ToString());
            RefreshContribution(DeleteContrComboBox, comboBox3);
            RefreshContribution(comboBox6, comboBox5);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshContribution(comboBox6, comboBox5);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            //RefreshUsers(comboBox4);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAccounts(comboBox5, comboBox7);
            RefreshContribution(comboBox6, comboBox5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account acc = Methods.FindAccOwner(Convert.ToInt32(comboBox5.SelectedItem.ToString()));
            Contribution contribution = acc.Contributions.Where(x => x.Name == comboBox6.SelectedItem.ToString()).First();
           
            try
            {

                Methods.AddOperation(contribution, acc, Double.Parse(textBox2.Text, CultureInfo.InvariantCulture));
                MessageBox.Show("Operation successfully added");
            }
            catch (NotEnoughMoneyException)
            {
               
                MessageBox.Show("Not enough money on your account!");
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Double.Parse(textBox3.Text, CultureInfo.InvariantCulture)<=0)
            {
                MessageBox.Show("Invalid summ for transfer!");
            }
            else
            {

                Account from = Methods.FindAccOwner(Convert.ToInt32(comboBox8.SelectedItem.ToString()));
                Account to = Methods.FindAccOwner(Convert.ToInt32(comboBox10.SelectedItem.ToString()));
                try
                {
                    Methods.TransferMoney(from.AccNumber, to.AccNumber, Double.Parse(textBox3.Text, CultureInfo.InvariantCulture));
                    MessageBox.Show("Successfull transfer!");
                }
                catch (NotEnoughMoneyException)
                {

                    MessageBox.Show("Not enough money to transfer!");
                }

            }


            


        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RefreshAccounts(comboBox8, comboBox4);
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAccounts(comboBox10, comboBox9);
        }

        private void DeleteUserComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

