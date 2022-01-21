using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix,
            int left, int right)
        {
            while (right - left > 1)
            {
                var centre = left + (right - left) / 2;
                if (string.Compare(prefix, phrases[centre], StringComparison.OrdinalIgnoreCase) >= 0
                   || phrases[centre].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = centre;
                else
                    right = centre;
            }
            return right;
        }
    }
}