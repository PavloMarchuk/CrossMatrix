using CrossMatrix.Model.Services.Abstract;
using CrossMatrix.Model.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrossMatrix.Tests.Model.MatrixServiceTests
{
	[TestClass]
	public class GetNumberOfPlusesMethodShould
	{
		private readonly IMatrixService _matrixService;

		public GetNumberOfPlusesMethodShould()
		{
			_matrixService = new MatrixService();
		}

		[TestMethod]
		public void Returns0()
		{
			//arrange
			string matrixString = string.Format("00010000{0}00010000{0}00010000{0}11101111{0}00010000{0}00010010{0}00010110{0}00010010", Environment.NewLine);
			int expected = 0;

			//act
			int actual = _matrixService.GetNumberOfPluses(matrixString);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Returns1()
		{
			//arrange
			string matrixString = string.Format("010{0}111{0}010", Environment.NewLine);
			int expected = 1;

			//act
			int actual = _matrixService.GetNumberOfPluses(matrixString);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[DataTestMethod]		 
		public void Returns2()
		{
			//arrange
			string matrixString = string.Format("001000{0}001000{0}111110{0}001000{0}001000{0}001000{0}", Environment.NewLine);
			int expected = 2;

			//act
			int actual = _matrixService.GetNumberOfPluses(matrixString);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[DataTestMethod]
		public void Returns3()
		{
			//arrange
			string matrixString = string.Format("00010000{0}00010000{0}00010000{0}11111111{0}00010000{0}00010010{0}00010111{0}00010010", Environment.NewLine);
			int expected = 3;
			
			//act
			int actual = _matrixService.GetNumberOfPluses(matrixString);

			//assert
			Assert.AreEqual(expected, actual);
		}

		[DataTestMethod]
		public void Returns4()
		{
			//arrange
			string matrixString = string.Format("010010{0}111111{0}010010{0}010010{0}111111{0}010010", Environment.NewLine);
			int expected = 4;
			
			//act
			int actual = _matrixService.GetNumberOfPluses(matrixString);

			//assert
			Assert.AreEqual(expected, actual);
		}



		[DataTestMethod]
		public void ThrowFormatExceptionWhenStringIsShort()
		{
			//arrange
			string matrixString = string.Format("001");

			//act
			FormatException exception = Assert.ThrowsException<FormatException>(() => _matrixService.GetNumberOfPluses(matrixString));

			//assert
			Assert.IsNotNull(exception);
		}

		[DataTestMethod]
		public void ThrowFormatExceptionWhenMatrixContainsLetters()
		{
			//arrange
			string matrixString = string.Format("0qwerty1");

			//act
			FormatException exception = Assert.ThrowsException<FormatException>(() => _matrixService.GetNumberOfPluses(matrixString));

			//assert
			Assert.IsNotNull(exception);
		}
	}
}
