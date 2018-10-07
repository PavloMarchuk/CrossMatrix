using CrossMatrix.Model.Services.Abstract;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MatrixService : IMatrixService
	{
		private int counter = 0;
		private int[,] matrix;

		public int GetNumberOfPluses(string matrixString)
		{
			//matrix = MatrixHelper.Parse(matrixString);
			//CountPluses();

			//return counter;
			int newCount = ArturGetNumberOfPluses(matrixString);
			return newCount;
		}

		private int ArturGetNumberOfPluses(string matrixString)
		{
			matrixString = new Regex(@"\D").Replace(matrixString, string.Empty);
			int width = (Int32)Math.Sqrt(matrixString.Length);

			int[][] matrix = MatrixHelper.ArthurParse(matrixString, width);
			int count = ArthurCountPluses(matrix, width);
			return count;
		}

		private int ArthurCountPluses(int[][] matrix, int width)
		{
			int count = 0;
			const int START_PLUSES_SIZE = 3;
			const int PLUSES_SIZE_INCREMENT = 2;

			for (int size = START_PLUSES_SIZE; size < width + 1; size += PLUSES_SIZE_INCREMENT)
			{
				for (int y = 0; y < width - size + 1; y++)
				{
					for (int x = 0; x < width - size + 1; x++)
					{
						int radius = size / 2;
						int Y_MedianaIndex = y + radius;
						int X_MedianaIndex = x + radius;
						int expextedElementSuma = 2 * size - 1;

						int actualElementSuma = 0;

						for (int i = 0; i < size; i++)
						{
							actualElementSuma += matrix[y + i].Skip(x).Take(size).Sum();

							if (!(matrix[y + i][X_MedianaIndex] == 1 && matrix[Y_MedianaIndex][x + i] == 1))
							{
								actualElementSuma = -1;
								break;
							}
						}
						if (expextedElementSuma == actualElementSuma)
						{
							count++;
						}
					}
				}
			}
			return count;
		}

		private void CountPluses()
		{
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
