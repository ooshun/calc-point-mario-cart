using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace kirin_noa
{

    public partial class 初期設定 : Form
    {
        ArrayList boxList = new ArrayList();
        List<marioTeam> mario = new List<marioTeam>();
        public 初期設定()
        {
            InitializeComponent();
            boxList.Add(nameBox1);
            boxList.Add(nameBox2);
            boxList.Add(nameBox3);
            boxList.Add(nameBox4);
            boxList.Add(nameBox5);
            boxList.Add(nameBox6);
            boxList.Add(nameBox7);
            boxList.Add(nameBox8);
            boxList.Add(nameBox9);
            boxList.Add(nameBox10);
            boxList.Add(nameBox11);
            boxList.Add(nameBox12);


            for (int i = 0; i < 12; i++)
            {
                ((TextBox)boxList[i]).Enabled = false;
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < int.Parse(person_box.Text); i++)
            {
                ((TextBox)boxList[i]).Enabled = true;
            }
        }

        private void nemeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(person_box.Text); i++)
            {
                marioTeam np = new marioTeam();
                np.name = ((TextBox)boxList[i]).Text;
                mario.Add(np);
            }
            Console.WriteLine("!!" + mario.Count);
            inputOrder form2 = new inputOrder(mario);
            form2.Show();
        }
    }


    public class marioTeam
    {
        public string name;
        public int[] result = new int[12];
        public int sum = 0;

        public void setName(string n)
        {
            this.name = n;
        }

        /// <summary>
        /// n回目のレースの順位rを代入
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        public void setResult(int n, int r)
        {
            if (r == 1)
            {
                this.sum += 15;
                result[n - 1] = 15;
            }
            else if (r == 2)
            {
                this.sum += 13;
                result[n - 1] = 13;
            }
            else
            {
                this.sum += 13 - r;
                result[n - 1] = 13 - r;
            }
        }

        public double getResult()
        {
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += result[i];
            }
            Console.WriteLine("sum " + sum);
            return (double)sum;
        }
    }
}
