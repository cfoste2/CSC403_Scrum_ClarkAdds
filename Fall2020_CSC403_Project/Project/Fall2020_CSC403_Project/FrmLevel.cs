﻿using Fall2020_CSC403_Project.code;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
  public partial class FrmLevel : Form {
    private Player player;

    private Enemy enemyPoisonPacket;
    private Enemy bossKoolaid;
    private Enemy enemyCheeto;
    private Character[] walls;
    private Character sword;  // sword////////////////////////////////////////////////////////////////////////////////

    private DateTime timeBegin;
    private FrmBattle frmBattle;

    public FrmLevel() {
      this.KeyPreview = true;
      InitializeComponent();
    }

    private void FrmLevel_Load(object sender, EventArgs e) {
      const int PADDING = 7;
      const int NUM_WALLS = 13;

      player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
      bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
      enemyPoisonPacket = new Enemy(CreatePosition(picEnemyPoisonPacket), CreateCollider(picEnemyPoisonPacket, PADDING));
      enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));

      bossKoolaid.Img = picBossKoolAid.BackgroundImage;
      enemyPoisonPacket.Img = picEnemyPoisonPacket.BackgroundImage;
      enemyCheeto.Img = picEnemyCheeto.BackgroundImage;

      bossKoolaid.Color = Color.Red;
      enemyPoisonPacket.Color = Color.Green;
      enemyCheeto.Color = Color.FromArgb(255, 245, 161);

      walls = new Character[NUM_WALLS];
      for (int w = 0; w < NUM_WALLS; w++) {
        PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
        walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
      }
      sword = new Character(CreatePosition(this.pictureBox2), CreateCollider(this.pictureBox2, PADDING));///////////////////////////

      Game.player = player;
      timeBegin = DateTime.Now;
    }

    private Vector2 CreatePosition(PictureBox pic) {
      return new Vector2(pic.Location.X, pic.Location.Y);
    }

    private Collider CreateCollider(PictureBox pic, int padding) {
      Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
      return new Collider(rect);
    }

    private void FrmLevel_KeyUp(object sender, KeyEventArgs e) {
      player.ResetMoveSpeed();
    }

    private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
      TimeSpan span = DateTime.Now - timeBegin;
      string time = span.ToString(@"hh\:mm\:ss");
      lblInGameTime.Text = "Time: " + time.ToString();
    }

    private void tmrPlayerMove_Tick(object sender, EventArgs e) {
      // move player
      player.Move();

      // check collision with walls
      if (HitAWall(player)) {
        player.MoveBack();
      }

      if (HitSword(player, sword))
      {
         try
         {
             picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.armorSword;
             FrmBattle.picPlayer2.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.armorSword;

         }
         catch (NullReferenceException ex)
                {

                }
         FrmBattle.healthMultEnemy = 2;
      }

      // check collision with enemies
      if (HitAChar(player, enemyPoisonPacket)) {
        Fight(enemyPoisonPacket);
      }
      else if (HitAChar(player, enemyCheeto)) {
        Fight(enemyCheeto);
      }
      if (HitAChar(player, bossKoolaid)) {
        Fight(bossKoolaid);
      }
      /*
      // check collision with sword (upgrade)
      if (HitASword(player))
       {
          picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.armorSword;
            }
      */

      // update player's picture box
      picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
    }

    private bool HitAWall(Character c) {
      bool hitAWall = false;
      for (int w = 0; w < walls.Length; w++) {
        if (c.Collider.Intersects(walls[w].Collider)) {
          hitAWall = true;
          break;
        }
      }
      return hitAWall;
    }

    private bool HitSword(Character you, Character sword)
    {
        return you.Collider.Intersects(sword.Collider);
    }

    private bool HitAChar(Character you, Character other) {
      return you.Collider.Intersects(other.Collider);
    }
        /*
    private bool HitASword(Character you, Character other)
     {
      return you.Collider.Intersects(other.Collider);
     }
        */
    private void Fight(Enemy enemy) {
      player.ResetMoveSpeed();
      player.MoveBack();
      frmBattle = FrmBattle.GetInstance(enemy);
      frmBattle.Show();

      if (enemy == bossKoolaid) {
        frmBattle.SetupForBossBattle();
      }
    }

    private void FrmLevel_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.Left:
          player.GoLeft();
          break;

        case Keys.Right:
          player.GoRight();
          break;

        case Keys.Up:
          player.GoUp();
          break;

        case Keys.Down:
          player.GoDown();
          break;

        default:
          player.ResetMoveSpeed();
          break;
      }
    }

    private void lblInGameTime_Click(object sender, EventArgs e) {

    }

        //private void button1_(object sender, KeyPressEventArgs e)
        //{

        //}

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void FrmLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void menu_click(object sender, EventArgs e)
        {
            Menu m = new Menu(); //this is the change, code for redirect  
            m.ShowDialog();
        }

        
    }
}
