using CrossMatrix.Model.Services.Abstract;
using System;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MatrixService : IMatrixService
	{
		private int counter = 0;
		private int[,] matrix;

		public int GetNumberOfPluses(string matrixString)
		{
			matrix = MatrixHelper.Parse(matrixString);
			CountPluses(matrix); //Refuc
			return counter;
		}

		private void CountPluses(int[,] _matrix)
		{
			matrix = _matrix;
			int rows = matrix.GetUpperBound(0) + 1;
			int columns = matrix.Length / rows;

			for (int y = 1; y < rows - 1; y++)
			{
				for (int x = 1; x < columns - 1; x++)
				{
					if (matrix[y, x] == 1)
					{
						IsCenterOfPlus(x, y, 1);
					}
				}
			}
		}

		private void IsCenterOfPlus(int x, int y, int r/*Radius*/)
		{
			try
			{
				if (
				matrix[y, x + r] == 1 &&
				matrix[y, x - r] == 1 &&
				matrix[y + r, x] == 1 &&
				matrix[y - r, x] == 1)
				{
					CheckingForZeros(x, y, r);
				}
			}
			catch (Exception)
			{
				return;
			}
		}

		private void CheckingForZeros(int x, int y, int r)
		{
			for (int i = y - r; i <= y + r; i++)
			{
				if (i == y) { continue; }

				if (matrix[i, x + r] != 0 || matrix[i, x - r] != 0)
				{
					return;
				}
			}

			for (int j = x - r; j <= x + r; j++)
			{
				if (j == x) { continue; }

				if (matrix[y + r, j] != 0 || matrix[y - r, j] != 0)
				{
					return;
				}
			}

			counter++;
			IsCenterOfPlus(x, y, r + 1); /*Recursion with Radius++*/
		}
	}
}
