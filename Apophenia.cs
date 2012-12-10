using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Apophenia
{
	public partial class Apophenia : Form, IMessageFilter
	{
		private IntPtr WindowFromPoint(Point pt)
		{
			var c = GetChildAtPoint(PointToClient(pt));
			if (c == null) return IntPtr.Zero;
			while (c.HasChildren)
			{
				var c2 = c.GetChildAtPoint(c.PointToClient(pt));
				if (c2 == null) break;
				c = c2;
			}
			return c.Handle;
		}
		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == 0x020a)
			{
				IntPtr hWnd = WindowFromPoint(Cursor.Position);
				if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null && Control.FromHandle(hWnd).Name.StartsWith("pbxNewCard"))
				{
					var pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
					pbxNewCard_MouseWheel(Control.FromHandle(hWnd), new MouseEventArgs(MouseButtons.None, 0, pos.X, pos.Y, m.WParam.ToInt32() >> 16));
					return true;
				}
			}
			return false;
		}

		private static readonly Random rnd = new Random();
		private readonly List<Deck> decks = new List<Deck>();
		private Deck selectedDeck;
		private Queue<int> drawnCards;
		private Point lastClick;
		private int cardNum = 0;

		public Apophenia()
		{
			InitializeComponent();
			Application.AddMessageFilter(this);
			this.DoubleBuffered = true;
			Directory.SetCurrentDirectory("../..");
			string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "decks");
			foreach (var dir in dirs)
			{
				decks.Add(new Deck(dir));
				cmbDeckSelect.Items.Add(dir.Substring(dir.LastIndexOf('/') + 1));
			}
			cmbDeckSelect.SelectedIndex = 0;
		}
		
		private void btnDeal_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < cardNum; ++i)
			{
				this.Controls.RemoveByKey("pbxNewCard" + i);
			}
			cardNum = 0;
			var count = selectedDeck.Cards.Count;
			drawnCards = new Queue<int>(Enumerable.Range(0, count).OrderBy(x => rnd.Next(0, count)));
		}
		private void pbxDeck_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
			var pbxNewCard = new PictureBox();
			pbxNewCard.Name = "pbxNewCard" + cardNum++;
			pbxNewCard.MouseDown += pbxNewCard_MouseDown;
			pbxNewCard.MouseMove += pbxNewCard_MouseMove;
			pbxNewCard.MouseDoubleClick += pbxNewCard_MouseDoubleClick;
			pbxNewCard.MouseWheel += pbxNewCard_MouseWheel;
			pbxNewCard.Location = grpBox.Location + new Size(pbxDeck.Location) + new Size(e.Location) - new Size(100, 150);
			pbxNewCard.Size = new Size(200, 300);
			pbxNewCard.SizeMode = PictureBoxSizeMode.Zoom;
			pbxNewCard.Image = pbxDeck.Image;
			this.Controls.Add(pbxNewCard);
			pbxNewCard.BringToFront();
			lastClick = new Point(100, 150);
			pbxDeck.Capture = false;
		}
		private void pbxNewCard_MouseDown(object sender, MouseEventArgs e)
		{
			var pb = (PictureBox)sender;
			switch (e.Button) {
			case MouseButtons.Left:
				lastClick = e.Location;
				break;
			case MouseButtons.Right:
				pb.Size = new Size(pb.Height, pb.Width);
				pb.Image = (Bitmap)pb.Image.Clone();
				pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
				break;
			}
		}
		private void pbxNewCard_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			var card = (PictureBox)sender;
			card.Location += new Size(e.Location - new Size(lastClick));
		}
		private void pbxNewCard_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var pb = (PictureBox)sender;
			if (e.Button != MouseButtons.Left || (string)pb.Tag == "flipped") return;
			pb.Tag = "flipped";
			Bitmap b = selectedDeck.Cards[drawnCards.Dequeue()];
			if (pb.Width > pb.Height)
			{
				b = (Bitmap)b.Clone();
				b.RotateFlip(RotateFlipType.Rotate90FlipNone);
			}
			if (rnd.Next(2) % 2 == 0)
			{
				b = (Bitmap)b.Clone();
				b.RotateFlip(RotateFlipType.Rotate180FlipNone);
			}
			pb.Image = b;
		}
		private void pbxNewCard_MouseWheel(object sender, MouseEventArgs e)
		{
			if (Math.Abs(e.Delta) < 120) return;
			var pb = (PictureBox)sender;
			double scale = e.Delta * 0.01;
			if (e.Delta < 0) scale = 1/-scale;
			var oldSize = pb.Size;
			pb.Height = (int)(pb.Height * scale);
			pb.Width = (int)(pb.Height * scale);
			pb.Location += new Size((int)((oldSize.Width - pb.Width) / 2), (int)((oldSize.Height - pb.Height) / 2));
		}
		private void cmbDeckSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedDeck = decks.Single(d => d.Name == ((ComboBox)sender).SelectedText);
			pbxDeck.Image = selectedDeck.CardBack;
			btnDeal_Click(btnDeal, EventArgs.Empty);
		}
	}
}
