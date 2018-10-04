using CrossMatrix.Model.Services.Abstract;
using System;
using System.Drawing;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MatrixService : IMatrixService
	{
		private int counter = 0;
		private int[,] matrix;
		public int GetSeeded()
		{
			int[,] seeded =
			{
				{ 0,0,0,1,0,0,0,0},
				{ 0,0,0,1,0,0,0,0},
				{ 0,0,0,1,0,0,0,0},
				{ 1,1,1,1,1,1,1,1},
				{ 0,0,0,1,0,0,0,0},
				{ 0,0,0,1,0,0,1,0},
				{ 0,0,0,1,0,1,1,1},
				{ 0,0,0,1,0,0,1,0},
			};
			return GetPluses(seeded);
		}

		public int GetPluses(int[,] _matrix)
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
						IsCenterPlus(x, y, 1);
					}
				}
			}
			return counter; 
		}

		private void IsCenterPlus(int x, int y, int r/*Radius*/)
		{
			try
			{
				if (
				matrix[y, x + r] == 1 &&
				matrix[y, x - r] == 1 &&
				matrix[y + r, x] == 1 &&
				matrix[y - r, x] == 1 &&

				matrix[y, x + r -1] == 1 &&
				matrix[y, x - r +1] == 1 &&
				matrix[y + r -1, x] == 1 &&
				matrix[y - r +1, x] == 1 )
				{
					counter++;
					IsCenterPlus(x, y, r + 2); /*Recursion*/
				}
			}
			catch (Exception)
			{
				return;
			}			
		}
	}
}
