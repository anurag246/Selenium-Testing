using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTesting
{
    public class AutomationTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();

           driver.Navigate().GoToUrl("https://www.google.com");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void NavigateToWikipedia()
        {
            driver.FindElement(By.CssSelector("input[name=\"q\"]")).SendKeys("selenium wiki");
            driver.FindElement(By.CssSelector("input[name=\"q\"]")).SendKeys(Keys.Enter);

            driver.FindElement(By.PartialLinkText("Selenium")).Click();

            var result = driver.Title;

            Assert.AreEqual("Selenium - Wikipedia", result);

        }
    }
}
