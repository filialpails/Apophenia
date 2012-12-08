using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Apophenia
{
	public partial class Apophenia : Form
	{
		private static readonly Random rnd = new Random();
		private readonly List<Deck> decks = new List<Deck>();
		private Deck selectedDeck;
		private Queue<int> drawnCards = new Queue<int>();

		public Apophenia()
		{
			InitializeComponent();
			Directory.SetCurrentDirectory("../..");
			string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "decks");
			foreach (var dir in dirs)
			{
				decks.Add(new Deck(dir));
				cmbDeckSelect.Items.Add(dir.Substring(dir.LastIndexOf('/') + 1));
			}
			selectedDeck = decks.First();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = selectedDeck.CardBack;
			pictureBox2.Image = selectedDeck.CardBack;
			pictureBox3.Image = selectedDeck.CardBack;
			pictureBox4.Image = selectedDeck.CardBack;
			pictureBox5.Image = selectedDeck.CardBack;
			int size = selectedDeck.Cards.Count;
			if (radioButton1.Checked)
			{
				drawnCards = new Queue<int>(Enumerable.Range(0, size).OrderBy(x => rnd.Next(0, size)).Take(2));
				pictureBox1.Visible = true;
				pictureBox2.Visible = false;
				pictureBox3.Visible = true;
				pictureBox4.Visible = false;
				pictureBox5.Visible = false;
			}
			else if (radioButton2.Checked)
			{
				drawnCards = new Queue<int>(Enumerable.Range(0, size).OrderBy(x => rnd.Next(0, size)).Take(3));
				pictureBox1.Visible = true;
				pictureBox2.Visible = true;
				pictureBox3.Visible = true;
				pictureBox4.Visible = false;
				pictureBox5.Visible = false;
			}
			else if (radioButton3.Checked)
			{
				drawnCards = new Queue<int>(Enumerable.Range(0, size).OrderBy(x => rnd.Next(0, size)).Take(4));
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
			pb.Image = selectedDeck.Cards[drawnCards.Dequeue()];
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			pictureBox1.Image = null;
			pictureBox2.Image = null;
			pictureBox3.Image = null;
			pictureBox4.Image = null;
			pictureBox5.Image = null;
		}

		private void cmbDeckSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDeck = decks.Where(d => d.Name == ((ComboBox)sender).SelectedText).Single();
			button1_Click(null, EventArgs.Empty);
		}
	}
}
