﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UITAP
{
    public class ClassAttribute
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless=old"); // Run Chrome in headless mode
            //chromeOptions.AddArgument("--no-sandbox"); // Bypass OS security model
            //chromeOptions.AddArgument("--disable-dev-shm-usage"); // Overcome limited resource issue
            _driver = new ChromeDriver(chromeOptions);
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/classattr");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void ClassAttribute_Test()
        {
            var driver = _driver;
            string buttonXPath = "//button[contains(concat(' ', normalize-space(@class), ' '), ' btn-primary ')]";
            IWebElement button = driver.FindElement(By.XPath(buttonXPath));
            Assert.That(button.Enabled && button.Displayed);
            button.Click();
        }
    }
}