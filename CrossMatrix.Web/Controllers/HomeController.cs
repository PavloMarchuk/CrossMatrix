using CrossMatrix.Model.Models;
using CrossMatrix.Model.Services.Abstract;
using CrossMatrix.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CrossMatrix.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IMatrixService _matrixService;

		public HomeController(IMatrixService matrixService)
		{
			_matrixService = matrixService;
		}
		public IActionResult Index(MatrixModel model)
		{
			if (model == null || string.IsNullOrWhiteSpace(model.MatrixString))
			{
				model = new MatrixModel
				{
					MatrixString = string.Format("010{0}111{0}010", Environment.NewLine),
					PlusesСounter = 0,
					InvalidFeedback = ""
				};
			}

			try
			{
				model.PlusesСounter = _matrixService.GetNumberOfPluses(model.MatrixString);
			}
			catch (Exception e)
			{
				model.InvalidFeedback = e.Message;
				model.PlusesСounter = 0;
			}
			return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
