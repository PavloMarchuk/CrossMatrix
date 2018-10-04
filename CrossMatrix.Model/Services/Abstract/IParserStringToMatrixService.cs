namespace CrossMatrix.Model.Services.Abstract
{
	public interface IParserStringToMatrixService
	{
		int[,] Parse(string text);
	}
}
