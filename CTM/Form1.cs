using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CTM
{
    //------------------------------------------NOTICE-----------------------------------------------------------------
    //  This Project is part from TCM, a project develolped by Everson Vieira https://github.com/EversonVieira
    //  This project is a simple demonstration of my work, feel free to use this class in anyone project you want to do.
    //------------------------------------------NOTICE-----------------------------------------------------------------
    #region Comments - ENGLISH 
    //  This project is licensed by GNU General Public License v3.0, visit https://www.gnu.org/licenses/gpl-3.0.en.html for more information.
    //  This project use the library SQLITE, visit https://www.sqlite.org/index.html for more information.
    //  This project is part from Everson Vieira portfolio, visit https://github.com/EversonVieira for more of my work.
    #endregion
    #region Comentários - PORTUGUÊS BRASIL
    // Esse projeto é licenciado por GNU General Public License v3.0, visite https://www.gnu.org/licenses/gpl-3.0.en.html para mais informações.
    // Esse projeto utiliza a biblioteca SQLITE, visite https://www.sqlite.org/index.html para mais informações.
    // Esse projeto é parte do Portifólio de Everson Vieira, visite https://github.com/EversonVieira para mais do meu trabalho.

    #endregion
    #region Code

    public partial class Form1 : Form
    {
        Controllers.AlunosController alunosController = new Controllers.AlunosController();
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Ts()
        {
            Thread t1 = new Thread(Loader);
            t1.IsBackground = true;
            t1.Start();
                
        }
        private void Loader()
        {
            try
            {
                Thread.Sleep(2000);
                this.BeginInvoke((MethodInvoker)delegate
               {
                   try
                   {
                       if (Grid.grid_Create == true)
                       {
                           grid1.dataGridView1.DataSource = alunosController.tabelaAlunos();
                       }
                       else { }
                   }
                   catch (Exception e)
                   {
                       MessageBox.Show(e.ToString());
                   }
               });
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }
        private void App_Load(object sender, EventArgs e)
        {
            Ts();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if(WindowState == FormWindowState.Normal)
            { WindowState = FormWindowState.Maximized;
                button2.BackgroundImage = Properties.Resources.normalizar3;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                button2.BackgroundImage = Properties.Resources.Maximizar2;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Button4_Click_3(object sender, EventArgs e)
        {
            Point p = new Point(0, 0);
            pictureBox1.Location = p;
            
        }
        private void Button5_Click_1(object sender, EventArgs e)
        {
            Point p = new Point(0, 83);
            pictureBox1.Location = p;
        }

    }
    #endregion
}
