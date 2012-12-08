using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Apophenia
{
	public class Deck
	{
		public string Name { get; private set; }
		public List<Bitmap> Cards { get; private set; }
		public Bitmap CardBack { get; private set; }

		public Deck(string name)
		{
			Name = name.Substring(name.LastIndexOf('/') + 1);
			var files = Directory.GetFiles(name, "*.*").Where(s => Regex.IsMatch(s, @"\.(?:(?:jp(?:e)?g)|(?:gif)|(?:png))$", RegexOptions.IgnoreCase)).ToArray();
			Cards = new List<Bitmap>(files.Length);
			foreach (var file in files)
			{
				if (Regex.IsMatch(file, @"back\.(?:(?:jp(?:e)?g)|(?:gif)|(?:png))$", RegexOptions.IgnoreCase))
				{
					CardBack = new Bitmap(file);
				}
				else
				{
					Cards.Add(new Bitmap(file));
				}
			}
		}
	}
}

