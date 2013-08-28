using System;
using System.Collections.Generic;
using System.Linq;

namespace Apophenia
{
	static class Rand
	{
		private static readonly Random rnd = new Random();

		public static int Next()
		{
			return rnd.Next();
		}

		public static int Next(int max)
		{
			return rnd.Next(max);
		}

		public static int Next(int min, int max)
		{
			return rnd.Next(min, max);
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.OrderBy(i => rnd.Next());
		}
	}
}
