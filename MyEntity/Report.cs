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
    public partial class Report : Form
    {
        Account account;
        public Report(Account acc)
        {
            InitializeComponent();
            account = acc;
        }


        private void InitiateTable(byte mode) {
            dataGridView1.Rows.Clear();
            List<Contribution> contribution = account.Contributions.ToList();
            int rowindex = 0;
            double total=0;
            foreach (Contribution item in contribution)
            {
                List<Operation> operations = item.Operations;
                foreach (Operation operation in operations)
                {
                    switch (mode)
                    {
                        case 0:
                            dataGridView1.Rows.Add();
                            if (operation.ToSum)
                            {

                                dataGridView1.Rows[rowindex].Cells[0].Value = operation.Summ;
                                dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                                dataGridView1.Rows[rowindex].Cells[2].Value = item.Name;
                                total += operation.Summ;
                            }
                            else
                            {
                                dataGridView1.Rows[rowindex].Cells[0].Value = -operation.Summ;
                                dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                                dataGridView1.Rows[rowindex].Cells[2].Value = item.Name;
                                total -= operation.Summ;
                            }
                            rowindex++;

                            break;
                        case 1:

                            if (operation.ToSum)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[rowindex].Cells[0].Value = operation.Summ;
                                dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                                dataGridView1.Rows[rowindex].Cells[2].Value = item.Name;
                                rowindex++;
                                total += operation.Summ;
                            }

                            break;
                        case 2:
                            if (!operation.ToSum)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[rowindex].Cells[0].Value = -operation.Summ;
                                dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                                dataGridView1.Rows[rowindex].Cells[2].Value = item.Name;
                                rowindex++;
                                total -= operation.Summ;
                            }
                            break;

                        default:
                            break;
                    }


                }


            }

            label2.Text = "Total: " + Math.Round(total,2);

        }
        private void ChangeReportTable(byte mode)
        {
            dataGridView1.Rows.Clear();
            Contribution contribution = account.Contributions.Where((x => x.Name == comboBox1.SelectedItem.ToString())).FirstOrDefault();
            int rowindex = 0;
            List<Operation> operations = contribution.Operations;
            double total = 0;
            foreach (Operation operation in operations)
            {
                switch (mode)
                {
                    case 0:
                        dataGridView1.Rows.Add();
                        if (operation.ToSum)
                        {

                            dataGridView1.Rows[rowindex].Cells[0].Value = operation.Summ;
                            dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                            dataGridView1.Rows[rowindex].Cells[2].Value = contribution.Name;
                            total += operation.Summ;
                        }
                        else
                        {
                            dataGridView1.Rows[rowindex].Cells[0].Value = -operation.Summ;
                            dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                            dataGridView1.Rows[rowindex].Cells[2].Value = contribution.Name;
                            total -= operation.Summ;
                        }
                        rowindex++;

                        break;
                    case 1:

                        if (operation.ToSum)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[rowindex].Cells[0].Value = operation.Summ;
                            dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                            dataGridView1.Rows[rowindex].Cells[2].Value = contribution.Name;
                            rowindex++;
                            total += operation.Summ;
                        }

                        break;
                    case 2:
                        if (!operation.ToSum)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[rowindex].Cells[0].Value = -operation.Summ;
                            dataGridView1.Rows[rowindex].Cells[1].Value = operation.date;
                            rowindex++;
                            total -= operation.Summ;
                        }
                        break;

                    default:
                        break;
                }



            }
            label2.Text = "Total: " + Math.Round(total, 2);
        }
        private void Report_Load(object sender, EventArgs e)
        {

            
                
                comboBox1.Items.Add("All");
                comboBox1.SelectedItem = "All";
                List<Contribution> contribution = account.Contributions.ToList();
                foreach (Contribution item in contribution)
                {
                    comboBox1.Items.Add(item.Name);
                }
                
            
            InitiateTable(0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                if (BothRadio.Checked)
                {
                    InitiateTable(0);
                }
                else
                {
                    if (IncomeRadio.Checked)
                    {
                        InitiateTable(1);
                    }
                    else
                    {
                        InitiateTable(2);
                    }
                }
            }
            else
            {
                if (BothRadio.Checked)
                {
                    ChangeReportTable(0);
                }
                else
                {
                    if (IncomeRadio.Checked)
                    {
                        ChangeReportTable(1);
                    }
                    else
                    {
                        ChangeReportTable(2);
                    }
                }
                
            }
        }

        private void BothRadio_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void BothRadio_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                InitiateTable(0);
            }
            else
            {
                ChangeReportTable(0);
            }
            
        }

        private void IncomeRadio_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                InitiateTable(1);
            }
            else
            {
                ChangeReportTable(1);
            }
        }

        private void SpendingRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SpendingRadio_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                InitiateTable(2);
            }
            else
            {
                ChangeReportTable(2);
            }
           
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
