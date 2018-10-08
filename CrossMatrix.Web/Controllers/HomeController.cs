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

		[HttpGet]
		public IActionResult Index()
		{
			return View(new ResponseModel { InvalidFeedback ="", MatrixString = "", PlusesСounter =0});
		}

		[HttpPost]
		public IActionResult Index(string matrixString)
		{
			ResponseModel model = new ResponseModel
			{
				MatrixString = matrixString,
				PlusesСounter = 0,
				InvalidFeedback = ""
			};
			if (string.IsNullOrWhiteSpace(matrixString))
			{
				model.InvalidFeedback = "Matrix is void";
				return View(model);
			}

			try
			{
				model.PlusesСounter = _matrixService.GetNumberOfPluses(model.MatrixString);
			}
			catch (Exception e)
			{
				model.InvalidFeedback = e.Message;
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
