using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossMatrix.Model
{
	public static class MatrixHelper
	{
		public static int[,] Parse(string text)
		{
			if (string.IsNullOrWhiteSpace(text) | text.Length < 9)
			{
				throw new FormatException("String is empty or too short");
			}

			if (text.IndexOf(Environment.NewLine) < 3)
			{
				throw new FormatException("String have no line breaks");
			}

			int[][] list = ToIntArray(text);
			int[,] matrix = ToMultidimensional(list);

			return matrix;
		}

		private static int[][] ToIntArray(string text)
		{
			text = text.Trim();
			char[] newLine = Environment.NewLine.ToCharArray();
			List<string> stringsList = text.Split(newLine).ToList();
			stringsList.RemoveAll(s => s.Length < 3);
			char[][] rows = stringsList.Select(row => row.ToCharArray()).ToArray();

			int[][] list;
			try
			{
				list = rows.Select(row => row.Select(i => Convert.ToInt32(new string(new char[] { i }))).ToArray()).ToArray();
			}
			catch (Exception)
			{
				throw new FormatException("Matrix is not correct");
			}

			return list;
		}

		private static int[,] ToMultidimensional(int[][] list)
		{
			int arrayWidth = list.GetUpperBound(0) + 1;
			int[,] matrix = new int[arrayWidth, arrayWidth];

			for (int y = 0; y < arrayWidth; y++)
			{
				for (int x = 0; x < arrayWidth; x++)
				{
					matrix[y, x] = list[y][x];
				}
			}
			return matrix;
		}
	}
}
