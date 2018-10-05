using CrossMatrix.Model.Services.Abstract;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MatrixService : IMatrixService
	{
		private readonly IOldService _oldService;

		public MatrixService(IOldService matrixService )
		{
			_oldService = matrixService;
		}
		
		public int GetNumberOfPluses(string matrixString)
		{
			int[,] matrix = MatrixHelper.Parse(matrixString);
			int result = _oldService.GetPluses(matrix);
			return result;
		}		
	}
}
