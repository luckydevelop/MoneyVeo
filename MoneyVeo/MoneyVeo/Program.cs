using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace MoneyVeo
{
    internal class Program
    {
        private static readonly IWebDriver Driver = new FirefoxDriver();

        private static readonly By ButtonSearch = By.XPath(".//*[@id='sblsbb']/button");
        private static readonly By FieldSearch = By.XPath(".//input[@id='lst-ib']");
        private static readonly By TextForthResultHeader = By.XPath(".//*[@id='rso']/div/div[4]/div/h3/a");

        private const string ExpectedResult = "Selenium IDE";
        private const string PageAdres = "http://www.google.com";
        private const string SearchingInquiry = "Selenium IDE export to C#";

        private static void Main(string[] args)
        {
            Driver.Manage().Window.Maximize();
            Driver.Url = PageAdres;
            FindElementWithWait(FieldSearch).SendKeys(SearchingInquiry);
            FindElementWithWait(ButtonSearch).Click();
            string actualResult = FindElementWithWait(TextForthResultHeader).Text;
            bool res = actualResult.Contains(ExpectedResult);
            //Assert.IsTrue(res, $"Actual result '{actualResult}' should contain next subString '{ExpectedResult}'");
            Assert.IsTrue(res, "Actual result '" + actualResult + "'should contain next subString '" + ExpectedResult + "'");
        }

        private static IWebElement FindElementWithWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(5000));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }
    }
}