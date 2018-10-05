using CrossMatrix.Model.Models;
using CrossMatrix.Model.Services.Abstract;
using System;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MatrixService : IMatrixService
	{
		private readonly IOldService _oldService;
		private readonly IParserStringToMatrixService _parserStringToMatrix;

		public MatrixService(IOldService matrixService, IParserStringToMatrixService parserStringToMatrix)
		{
			_oldService = matrixService;
			_parserStringToMatrix = parserStringToMatrix;
		}
		
		public int GetNumberOfPluses(string matrixString)
		{
			int[,] matrix = _parserStringToMatrix.Parse(matrixString);
			int result = _oldService.GetPluses(matrix);
			return result;
		}		
	}
}
