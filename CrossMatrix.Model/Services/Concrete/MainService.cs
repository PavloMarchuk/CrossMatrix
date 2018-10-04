using CrossMatrix.Model.Models;
using CrossMatrix.Model.Services.Abstract;
using System;

namespace CrossMatrix.Model.Services.Concrete
{
	public class MainService : IMainService
	{
		private readonly IMatrixService _matrixService;
		private readonly IParserStringToMatrixService _parserStringToMatrix;

		public MainService(IMatrixService matrixService, IParserStringToMatrixService parserStringToMatrix)
		{
			_matrixService = matrixService;
			_parserStringToMatrix = parserStringToMatrix;
		}
		public MatrixModel GetModel(MatrixModel model)
		{
			if (model == null || string.IsNullOrWhiteSpace(model.MatrixString))
			{
				model = InitSeed(model);
			}

			try
			{
				int[,] matrix = _parserStringToMatrix.Parse(model.MatrixString);

				model.PlusesСounter = _matrixService.GetPluses(matrix);
			}
			catch (Exception e)
			{
				model.MatrixString = e.Message;
				model.PlusesСounter = 0;
			}

			return model;
		}

		private MatrixModel InitSeed(MatrixModel model)
		{

			string newLine = Environment.NewLine;
			model = new MatrixModel
			{
				MatrixString = string.Format("010010{0}111111{0}010010{0}010010{0}111111{0}010010", newLine),
				PlusesСounter = 0
			};
			return model;
		}
	}
}
