using NUnit.Framework;
using OpenQA.Selenium;
using SearchDuckDuckGoTests;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System;

Tests test = new Tests();
test.Setup();
test.Test1();
test.TearDown();

namespace SearchDuckDuckGoTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _searchInputButton = By.XPath("//input[@id='search_form_input_homepage']");
        private readonly By _searchButton = By.XPath("//input[@id='search_button_homepage']");
        private readonly By _searchMoreButton = By.XPath("//a[@class='result--more__btn btn btn--full']");
        private readonly By _search = By.XPath(" //a[@data-testid='result-title-a']");
       
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
            Thread.Sleep(300);
            searchInput.SendKeys("Weather");                      //ввід в пошуковому вікні
            var search = driver.FindElement(_searchButton);
            Thread.Sleep(300);
            search.Click();                                       //кнопка пошуку
            var collectionLinks = driver.FindElements(_search)    //Получення колекції
           .Where(webElement => (webElement.Displayed == true));  //Фільтрація
            int i = 0;
            foreach (var link in collectionLinks)
            {
                i++;
            }
            Console.WriteLine($"The display shows {i} search results");
            var searchMore = driver.FindElement(_searchMoreButton);
            Thread.Sleep(300);
            searchMore.Click();                                    //кнопка більше "More Resulst"
            Thread.Sleep(300);
            collectionLinks = driver.FindElements(_search)         //Получення колекції
           .Where(webElement => (webElement.Displayed == true));   //Фільтрація
            int x = 0;
            foreach (var link in collectionLinks)
            {
                x++;
            }
            Console.WriteLine($"The display shows {x} search results after click 'More Resulst' button");
            if(x>i)
            {
                Console.WriteLine("Additional test results are displayed");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Additional test results are not displayed");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Assert.AreNotEqual(x,i);
            Thread.Sleep(1000);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }

}