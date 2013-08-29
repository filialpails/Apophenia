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
		private static readonly string[] interps = new[]
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
		}.Union(Enumerable.Range('A', 26).Select(c => "Does a name that starts with " + (char)c + " have any kind of meaning to you? Yes? Magic.")).ToArray();

		public Apophenia()
		{
			InitializeComponent();
			cmbDeckSelect.DataSource = Directory.EnumerateDirectories(Path.Combine("..", "..", "decks")).Select(dir => new Deck(dir)).ToList();
			if (cmbDeckSelect.Items.Count == 0)
			{
				MessageBox.Show("You have no decks installed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}
			cmbDeckSelect.SelectedIndex = 0;
		}
		
		private void btnClear_Click(object sender, EventArgs e)
		{
			for (var i = 0; i < cardNum; ++i)
			{
				Controls.RemoveByKey("pbxNewCard" + i);
			}
			cardNum = 0;
			selectedDeck.reset();
			pbxZoom.Image = null;
			lblInterpretation.Text = "";
		}

		private void pbxDeck_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			var pbxNewCard = new PictureBox
			{
				Name = "pbxNewCard" + cardNum++,
				SizeMode = PictureBoxSizeMode.Zoom,
				Image = pbxDeck.Image,
				Size = pbxDeck.Size,
				Location = grpDeck.Location + new Size(pbxDeck.Location) + new Size(e.Location)
			};
			pbxNewCard.MouseDown += pbxNewCard_MouseDown;
			pbxNewCard.MouseMove += pbxNewCard_MouseMove;
			pbxNewCard.MouseDoubleClick += pbxNewCard_MouseDoubleClick;
			Controls.Add(pbxNewCard);
			pbxNewCard.BringToFront();
			lastClick = new Point(pbxNewCard.Width / 2, pbxNewCard.Height / 2);
			pbxDeck.Capture = false;
		}

		private void pbxNewCard_MouseDown(object sender, MouseEventArgs e)
		{
			var pb = (PictureBox)sender;
			switch (e.Button)
			{
			case MouseButtons.Left:
				lastClick = e.Location;
				pbxZoom.Image = pb.Image;
				break;
			case MouseButtons.Right:
				pb.Image = (Bitmap)pb.Image.Clone();
				pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
			if (e.Button != MouseButtons.Left || (string)pb.Tag == "flipped") return;
			pb.Tag = "flipped";
			var b = selectedDeck.draw();
			if (pb.Width > pb.Height)
			{
				b = (Bitmap)b.Clone();
				b.RotateFlip(RotateFlipType.Rotate90FlipNone);
			}
			if (Rand.Next(2) % 2 == 0)
			{
				b = (Bitmap)b.Clone();
				b.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
			pb.Image = b;
			lblInterpretation.Text = interps.Shuffle().First();
			pbxZoom.Image = pb.Image;
		}
		
		private void cmbDeckSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDeck = (Deck)((ComboBox)sender).SelectedItem;
			pbxDeck.Image = selectedDeck.CardBack;
			btnClear_Click(btnDeal, EventArgs.Empty);
		}
	}
}
