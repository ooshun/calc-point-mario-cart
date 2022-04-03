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
    public partial class inputOrder : Form
    {
        int race = 1;
        ArrayList boxList = new ArrayList();
        ArrayList nameList = new ArrayList();
        List<marioTeam> mario = new List<marioTeam>();
        public inputOrder(List<marioTeam> list)
        {
            InitializeComponent();
            boxList.Add(dBox1);
            boxList.Add(dBox2);
            boxList.Add(dBox3);
            boxList.Add(dBox4);
            boxList.Add(dBox5);
            boxList.Add(dBox6);
            boxList.Add(dBox7);
            boxList.Add(dBox8);
            boxList.Add(dBox9);
            boxList.Add(dBox10);
            boxList.Add(dBox11);
            boxList.Add(dBox12);

            nameList.Add(dNameLabel1);
            nameList.Add(dNameLabel2);
            nameList.Add(dNameLabel3);
            nameList.Add(dNameLabel4);
            nameList.Add(dNameLabel5);
            nameList.Add(dNameLabel6);
            nameList.Add(dNameLabel7);
            nameList.Add(dNameLabel8);
            nameList.Add(dNameLabel9);
            nameList.Add(dNameLabel10);
            nameList.Add(dNameLabel11);
            nameList.Add(dNameLabel12);

            mario = list;

            Console.WriteLine(mario.Count);
            for (int i = 0; i < mario.Count ; i++)
            {
                ((Label)nameList[i]).Text = mario[i].name;
            }
            for (int i = mario.Count; i < 12; i++)
            {
                ((TextBox)boxList[i]).Enabled = false;
                ((Label)nameList[i]).Text = "";
            }

            teamSumLabel.Text = "チーム得点：";
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (race < 12)
            {
                int teamSum = 0;
                for (int i = 0; i < mario.Count; i++)
                {
                    mario[i].setResult(race, System.Convert.ToInt32(((TextBox)boxList[i]).Text));
                    ((Label)nameList[i]).Text = mario[i].name+ " "+ mario[i].sum;
                    teamSum+= mario[i].sum;
                    ((TextBox)(boxList[i])).Text = "";
                }
                race++;
                raceLabel.Text = "第" + race + "レース";
                teamSumLabel.Text = "チーム得点：" + teamSum;
            }
            else
            {
                raceLabel.Text = "得点結果";

                for (int i = 0; i < mario.Count; i++)
                {
                    mario[i].setResult(race, System.Convert.ToInt32(((TextBox)boxList[i]).Text));
                    ((TextBox)boxList[i]).Text = (mario[i].sum).ToString();
                    ((Label)nameList[i]).Text = mario[i].name + " " + mario[i].sum;
                }

                for (int i = 0; i < 12; i++)
                {
                    ((TextBox)boxList[i]).Enabled = false;
                }

                nextButton.Enabled = false;
            }
        }
    }
}
