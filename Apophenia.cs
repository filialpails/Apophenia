using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Apophenia
{
	public partial class Apophenia : Form
	{
		private Deck selectedDeck;
		private Point lastClick;
		private int cardNum;
		private static readonly string[] interps =
		{
			"This card means your spirituality is outweighed only by your gullibility.",
			"This card means you must free your mind from its preoccupation with the relative arrangement of small, colourful rectangles.",
			"The spirits you are trying to contact could not be reached. Please hang up and try again.",
			"Trust me, you'd rather not know what this one means.",
			"The Old Ones have noticed you. Burn the cards immediately.",
			"Your INT attribute is not high enough to read this card.",
			"Your WIS attribute is not high enough to read this card.",
			"This card means you see meaningful patterns or connections in random or meaningless data.",
			"This card represents itself.",
			"It's just as you've always suspected: quantum physics, therefore magic.",
			"Consult your pineal gland.",
			"fnord",
			"This card isn't saying it was aliens... but it was aliens.",
			"Light rain\n23°C\nPrecipitation: 80%\nHumidity: 95%\nWind 2 km/h",
			"This card says that if you open your mind too much your brain will fall out.",
			"This card represents nothingness. So do all the rest of them.",
			"It is too hot to perform a cold reading. Please lower the ambient temperature and try again.",
			"Woolworths stores are sites of great mystical power.",
			"ᛞᛁᚳ ᛒᚢᛏ",
			"ᛈᛁᚾᛏᛖᛚ ᚫᚱᛋ",
			"ᚇᚔᚉ ᚁᚒᚈ",
			"ᚈᚖᚅ ᚁᚑᚈ",
			"It's a get out of jail free card.",
			"You marked this card, you cheater.",
			"Woo!",
			"Blackjack!",
			"Negative energy is preventing a clear reading. Run a magnet over your computer to adjust for it.",
			"tw: tentacles",
			"Your crystals are not compatible with this software. Please use dilithium crystals instead."
		};

		public Apophenia()
		{
			InitializeComponent();
			cmbDeckSelect.DataSource = Directory.EnumerateDirectories("decks").Select(dir => new Deck(dir)).ToList();
			if (cmbDeckSelect.Items.Count == 0)
			{
				MessageBox.Show("You have no decks installed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
			cmbDeckSelect.SelectedIndex = 0;
		}
		
		private void clear()
		{
			for (var i = 0; i < cardNum; ++i)
			{
				string key = "pbxNewCard" + i;
				Controls[key].Dispose();
				Controls.RemoveByKey(key);
			}
			cardNum = 0;
			selectedDeck.Reset();
			pbxZoom.Image = null;
			lblInterpretation.Text = "";
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			clear();
		}

		private PictureBox newCard(Point location)
		{
			var card = selectedDeck.Draw();
			var pbxNewCard = new PictureBox
			{
				Name = "pbxNewCard" + cardNum++,
				SizeMode = PictureBoxSizeMode.Zoom,
				Image = card.Back,
				Size = pbxDeck.Size,
				Location = grpDeck.Location + new Size(pbxDeck.Location) + new Size(location),
				Tag = card
			};
			pbxNewCard.MouseDown += pbxNewCard_MouseDown;
			pbxNewCard.MouseMove += pbxNewCard_MouseMove;
			pbxNewCard.MouseDoubleClick += pbxNewCard_MouseDoubleClick;
			return pbxNewCard;
		}

		private void pbxDeck_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || cardNum >= selectedDeck.Count) return;
			var pbxNewCard = newCard(e.Location);
			Controls.Add(pbxNewCard);
			pbxNewCard.BringToFront();
			lastClick = new Point(pbxNewCard.Width / 2, pbxNewCard.Height / 2);
			pbxDeck.Capture = false;
		}

		private void setZoomImage(Card card)
		{
			pbxZoom.Image = card.Flipped ? card.FrontOriginal : card.BackOriginal;
		}

		private void pbxNewCard_MouseDown(object sender, MouseEventArgs e)
		{
			var pb = (PictureBox)sender;
			var card = (Card)pb.Tag;
			switch (e.Button)
			{
			case MouseButtons.Left:
				lastClick = e.Location;
				setZoomImage(card);
				break;
			case MouseButtons.Right:
				card.RotateRight();
				pb.Size = new Size(pb.Height, pb.Width);
				break;
			}
		}
		
		private void pbxNewCard_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			((PictureBox)sender).Location += new Size(e.Location - new Size(lastClick));
		}
		
		private void pbxNewCard_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var pb = (PictureBox)sender;
			var card = (Card)pb.Tag;
			if (e.Button != MouseButtons.Left || card.Flipped) return;
			card.Flipped = true;
			pb.Image = card.Front;
			lblInterpretation.Text = interps.Shuffle().First();
			setZoomImage(card);
		}
		
		private void cmbDeckSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDeck = (Deck)((ComboBox)sender).SelectedItem;
			pbxDeck.Image = selectedDeck.CardBack;
			clear();
		}
	}
}
