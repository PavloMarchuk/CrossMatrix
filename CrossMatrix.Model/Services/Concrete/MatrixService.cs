using CrossMatrix.Model.Services.Abstract;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MatrixService : IMatrixService
	{
		public int GetNumberOfPluses(string matrixString)
		{
			matrixString = new Regex(@"\D").Replace(matrixString, string.Empty);
			int width = (Int32)Math.Sqrt(matrixString.Length);
			int[][] matrix = MatrixHelper.Parse(matrixString, width);
					
			int count = PlusesCounter(matrix, width);
			return count;
		}		 

		private int PlusesCounter(int[][] matrix, int width)
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
	}
}
