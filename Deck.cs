using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Apophenia
{
	class Deck
	{
		public string Name { get; private set; }
		public List<Bitmap> Cards { get; private set; }
		public Bitmap CardBack { get; private set; }
		private Queue<int> drawOrder;

		public Deck(string name)
		{
			Name = Path.GetFileName(name);
			var files = Directory.EnumerateFiles(name).Where(f => Regex.IsMatch(Path.GetFileName(f), @"\.(?:jpe?g|gif|png|bmp)$", RegexOptions.IgnoreCase));
			var back = files.Single(f => Path.GetFileNameWithoutExtension(f).Equals("back", StringComparison.OrdinalIgnoreCase));
			CardBack = new Bitmap(back);
			Cards = files.Where(f => f != back).Select(f => new Bitmap(f)).ToList();
			reset();
		}

		public void reset()
		{
			drawOrder = new Queue<int>(Enumerable.Range(0, Cards.Count).Shuffle());
		}

		public Bitmap draw()
		{
			return Cards[drawOrder.Dequeue()];
		}
	}
}
