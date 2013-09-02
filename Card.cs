using System;
using System.Drawing;

namespace Apophenia
{
	public enum Suit { Trumps, Swords, Wands, Coins, Cups };
	public enum Rank
	{
		Fool, Magician, HighPriestess, Empress, Emperor, Hierophant, Lovers, Chariot, Strength, Hermit, WheelOfFortune, Justice,
		HangedMan, Death, Temperance, Devil, Tower, Star, Moon, Sun, Judgment, World,
		Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Page, Knight, Queen, King
	};
	public enum Rotation { Zero, Ninety, OneEighty, TwoSeventy };

	public class Card
	{
		public Suit Suit { get; private set; }
		public Rank Rank { get; private set; }
		public Bitmap Front { get; private set; }
		public Bitmap Back { get; private set; }
		public Bitmap FrontOriginal { get; private set; }
		public Bitmap BackOriginal { get; private set; }
		public bool Flipped { get; set; }
		public Rotation Rotation { get; private set; }

		public Card(string frontFilename, string backFilename)
		{
			Front = new Bitmap(frontFilename);
			Back = new Bitmap(backFilename);
			FrontOriginal = (Bitmap)Front.Clone();
			BackOriginal = (Bitmap)Back.Clone();
		}

		public void RotateRight()
		{
			switch (Rotation)
			{
			case Rotation.Zero:
				Rotation = Rotation.Ninety;
				break;
			case Rotation.Ninety:
				Rotation = Rotation.OneEighty;
				break;
			case Rotation.OneEighty:
				Rotation = Rotation.TwoSeventy;
				break;
			case Rotation.TwoSeventy:
				Rotation = Rotation.Zero;
				break;
			}
			Front.RotateFlip(RotateFlipType.Rotate90FlipNone);
			Back.RotateFlip(RotateFlipType.Rotate90FlipNone);
		}

		public override string ToString()
		{
			if (Suit == Suit.Trumps)
			{
				return Enum.GetName(typeof(Rank), Rank);
			}
			return Enum.GetName(typeof(Rank), Rank) + " of " + Enum.GetName(typeof(Suit), Suit);
		}
	}
}
