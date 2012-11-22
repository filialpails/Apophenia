using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Apophenia.Properties;

namespace Apophenia
{
	public partial class Apophenia : Form
	{
		private Random rnd = new Random();
		private Bitmap[] cards = new[] { Resources._00Fool, Resources._01Magician, Resources._02Priestess, Resources._03Empress, Resources._04Emperor, Resources._05Hierophant, Resources._06Lovers, Resources._07Chariot, Resources._08Justice, Resources._09Hermit, Resources._10Fotune, Resources._11Strength, Resources._12Hangedman, Resources._13Death, Resources._14Tenperance, Resources._15Devil, Resources._16Tower, Resources._17Star, Resources._18Moon, Resources._19Sun, Resources._20Judgement, Resources._21World };
		private Queue<int> drawnCards = null;

		public Apophenia()
		{
			InitializeComponent();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = Resources._00CardBack;
			pictureBox2.Image = Resources._00CardBack;
			pictureBox3.Image = Resources._00CardBack;
			pictureBox4.Image = Resources._00CardBack;
			pictureBox5.Image = Resources._00CardBack;
			if (radioButton1.Checked)
			{
				drawnCards = new Queue<int>(Enumerable.Range(0, 22).OrderBy(x => rnd.Next(0, 22)).Take(2));
				pictureBox1.Visible = true;
				pictureBox2.Visible = false;
				pictureBox3.Visible = true;
				pictureBox4.Visible = false;
				pictureBox5.Visible = false;
			}
			else if (radioButton2.Checked)
			{
				drawnCards = new Queue<int>(Enumerable.Range(0, 22).OrderBy(x => rnd.Next(0, 22)).Take(3));
				pictureBox1.Visible = true;
				pictureBox2.Visible = true;
				pictureBox3.Visible = true;
				pictureBox4.Visible = false;
				pictureBox5.Visible = false;
			}
			else if (radioButton3.Checked)
			{
				drawnCards = new Queue<int>(Enumerable.Range(0, 22).OrderBy(x => rnd.Next(0, 22)).Take(4));
				pictureBox1.Visible = true;
				pictureBox2.Visible = false;
				pictureBox3.Visible = true;
				pictureBox4.Visible = true;
				pictureBox5.Visible = true;
			}
			label2.Text = "Click cards to reveal them.";
		}

		private void pictureBox_Click(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			pb.Image = cards[drawnCards.Dequeue()];
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox1.Image = null;
			pictureBox2.Image = null;
			pictureBox3.Image = null;
			pictureBox4.Image = null;
			pictureBox5.Image = null;
		}
	}
}
