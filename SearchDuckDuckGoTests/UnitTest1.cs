using NUnit.Framework;
using OpenQA.Selenium;




namespace SearchDuckDuckGoTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _searchInputButton = By.XPath("//input[@id='search_form_input_homepage']");
        private readonly By _searchButton = By.XPath("//input[@id='search_button_homepage']");
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Test1()
        {
            var searchInput = driver.FindElement(_searchInputButton);
            searchInput.SendKeys("Weather");
            var search = driver.FindElement(_searchButton);
            search.Click();
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}