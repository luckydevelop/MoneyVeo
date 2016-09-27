using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace MoneyVeo
{
    [TestFixture, RequiresSTA]
    internal class Program
    {
        private IWebDriver _driver;

        private readonly By _buttonSearch = By.XPath(".//*[@id='sblsbb']/button");
        private readonly By _fieldSearch = By.XPath(".//input[@id='lst-ib']");
        private readonly By _textForthResultHeader = By.XPath(".//*[@id='rso']/div/div[4]/div/h3/a");

        private const string ExpectedResult = "Selenium IDE";
        private const string PageAdres = "http://www.google.com";
        private const string SearchingInquiry = "Selenium IDE export to C#";

        [TestFixtureSetUp]
        public void Init()
        {
            _driver = new FirefoxDriver();
        }

        [Test]
        public void MoneyVeoTest()
        {
            _driver.Manage().Window.Maximize();
            _driver.Url = PageAdres;
            FindElementWithWait(_fieldSearch).SendKeys(SearchingInquiry);
            FindElementWithWait(_buttonSearch).Click();
            string actualResult = FindElementWithWait(_textForthResultHeader).Text;
            bool res = actualResult.Contains(ExpectedResult);
            Assert.IsTrue(res, "Actual result '" + actualResult + "'should contain next subString '" + ExpectedResult + "'");
        }

        [TestFixtureTearDown]
        public void Cleanup()
        {
            _driver.Close();
        }

        public IWebElement FindElementWithWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(5000));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }
    }
}