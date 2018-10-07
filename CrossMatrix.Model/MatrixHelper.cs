using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossMatrix.Model
{
	public static class MatrixHelper
	{
		public static int[][] Parse(string text, int widht)
		{
			int[][] result = new int[widht][];
			for (int i = 0; i < widht; i++)
			{
				result[i] = text.Skip(widht * i).Take(widht).Select(x => Convert.ToInt32(x)- Convert.ToInt32('0')).ToArray();
			}
			return result;
		}		
	}
}
