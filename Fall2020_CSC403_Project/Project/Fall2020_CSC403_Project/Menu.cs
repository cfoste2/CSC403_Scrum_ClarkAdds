using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void Quit(object sender, EventArgs e)
        {
            System.Environment.Exit(0);

        }


        private void change_traditional(object sender, EventArgs e)
        {
            try
            {
                FrmLevel.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player;
                FrmBattle.picPlayer2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player;
                
            }
            catch (NullReferenceException ex)
            {

            }
            Close();

        }

        private void change_hip(object sender, EventArgs e)
        {
            try
            {
                FrmLevel.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player2;
                FrmBattle.picPlayer2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player2;
                this.Hide();
            }
            catch (NullReferenceException ex)
            {

            }
            Close();

        }

        private void change_cute(object sender, EventArgs e)
        {
            try
            {
                FrmLevel.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player3;
                FrmBattle.picPlayer2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player3;
            }
            catch (NullReferenceException ex)
            {

            }
            Close();

        }

        private void change_cool(object sender, EventArgs e)
        {
            try
            {
                FrmLevel.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player5;
                FrmBattle.picPlayer2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player5;
                this.Hide();
            }
            catch (NullReferenceException ex)
            {

            }
            Close();
        }

        private void change_super(object sender, EventArgs e)
        {
            try
            {
                FrmLevel.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player6;
                FrmBattle.picPlayer2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player6;
                this.Hide();
            }
            catch (NullReferenceException ex)
            {

            }
            Close();

        }
    }
}
