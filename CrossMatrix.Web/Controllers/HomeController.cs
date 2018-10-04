using CrossMatrix.Model.Models;
using CrossMatrix.Model.Services.Abstract;
using CrossMatrix.Web.Models;
using Microsoft.AspNetCore.Mvc;
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
		public IActionResult Index()
		{
			MatrixModel model = new MatrixModel();
			model.PlusesСounter = _matrixService.GetSeeded();
			return View(model);
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
