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
namespace StudentDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData";
                if(Directory.Exists(path))
                {
                    MessageBox.Show("Directory Exist...");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory Created...");
                }

            }catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData\stud.txt";
                if(File.Exists(path))
                {
                    MessageBox.Show("File Exists...");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File Created...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData\stud.dat";
                FileStream fs=new FileStream(path,FileMode.Create,FileAccess.Write);
                StreamWriter sw=new StreamWriter(fs);
                sw.WriteLine(txtRollNo.Text);
                sw.WriteLine(txtName.Text);
                sw.WriteLine(txtMark.Text);

                MessageBox.Show("Done...");
                sw.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btmRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData\stud.dat";
                FileStream fs=new FileStream(path,FileMode.Open, FileAccess.Read);
                StreamReader sr=new StreamReader(fs);
                txtRollNo.Text = sr.ReadLine();
                txtName.Text = sr.ReadLine();
                txtMark.Text = sr.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData\stud2.txt";
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(richTextBox1.Text);
                MessageBox.Show("Done...");
                sw.Close();
                fs.Close() ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData\stud2.txt";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text=sr.ReadToEnd();
                sr.Close();
                fs.Close() ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\StudentData\stud2.dat";
                FileStream fs=new FileStream(path,FileMode.Create, FileAccess.Write);
                BinaryWriter bs=new BinaryWriter(fs);

                bs.Write(Convert.ToInt32(txtRollNo.Text));
                bs.Write(txtName.Text);
                bs.Write(Convert.ToDouble(txtMark.Text));

                MessageBox.Show("Done...");
                bs.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string path = @"E:\StudentData\stud2.dat";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br=new BinaryReader(fs);
            txtRollNo.Text=br.ReadInt32().ToString();
            txtName.Text=br.ReadString();
            txtMark.Text=br.ReadDouble().ToString();

            br.Close();
            fs.Close();

        }
    }
}
