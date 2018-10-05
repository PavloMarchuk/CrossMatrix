using CrossMatrix.Model.Services.Abstract;
using CrossMatrix.Web.Controllers;
using Moq;

namespace CrossMatrix.Tests.Web.HomeControllerTests
{
	public class HomeControllerSut
	{
		public HomeController Instance { get; set; }
		public Mock<IMatrixService> MockMatrixService { get; set; }

		public HomeControllerSut()
		{
			MockMatrixService = new Mock<IMatrixService>();

			Instance = new HomeController(MockMatrixService.Object);
		}
	}
}
