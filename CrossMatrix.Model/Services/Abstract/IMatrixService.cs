namespace CrossMatrix.Model.Services.Abstract
{
	public interface IMatrixService
	{
		int GetSeeded();
		int GetPluses(int[,] matrix);
	}
}
