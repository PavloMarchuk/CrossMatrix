using CrossMatrix.Model.Models;

namespace CrossMatrix.Model.Services.Abstract
{
	public interface IMatrixService
	{
		//MatrixModel GetModel(MatrixModel model);
		int GetNumberOfPluses(string matrixString);
	}
}
