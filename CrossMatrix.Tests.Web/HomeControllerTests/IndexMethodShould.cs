using CrossMatrix.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

//HomeControllerSut
namespace CrossMatrix.Tests.Web.HomeControllerTests
{
	[TestClass]
	public class IndexMethodShould
	{
		public HomeControllerSut Sut { get; set; }

		public IndexMethodShould()
		{
			Sut = new HomeControllerSut();
		}

		[TestMethod]
		public void ReturnViewResultWhenModelIsNull()
		{
			// Arrange

			Sut.MockMatrixService.Setup(x => x.GetNumberOfPluses("010{0}111{0}010")).Returns(1);

			// Action
			IActionResult result = Sut.Instance.Index(null) as IActionResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void ReturnViewResultWhenModelIsValid()
		{
			// Arrange
			ResponseModel model = new ResponseModel
			{
				MatrixString = string.Format("010{0}111{0}010", Environment.NewLine),
				PlusesСounter = 0,
				InvalidFeedback = ""
			};

			Sut.MockMatrixService.Setup(x => x.GetNumberOfPluses(model.MatrixString)).Returns(1);

			// Action
			IActionResult result = Sut.Instance.Index(null) as IActionResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
