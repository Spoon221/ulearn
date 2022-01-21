using System;

namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			if ((count % 10 > 1 && count % 10 < 5) & count / 10 % 10 != 1)
			{
				return "рубля";
			}
			return count % 10 == 1 & count / 10 % 10 != 1 ? "рубль" : "рублей";
		}
	}
}