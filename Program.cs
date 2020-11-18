using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace instaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.instagram.com/");
            
            Console.WriteLine("Siteye gidildi..");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("username")).SendKeys("sennaboutigue");
            driver.FindElement(By.Name("password")).SendKeys("Airtes1991.");
            driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF")).Click();
            Console.WriteLine("Siteye giriş gerçekleşti.");
            Thread.Sleep(3000);

            driver.Navigate().GoToUrl("https://www.instagram.com/hasanbasdemir39/");
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@id=\"react-root\"]/section/main/div/header/section/ul/li[2]/a")).Click();
            
            Thread.Sleep(3000);
            

            string jsCommand = "" +
                "sayfa = document.querySelector('.isgrP');" +
                "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                "var sayfaSonu = sayfa.scrollHeight;" +
                "return sayfaSonu;";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

            while (true)
            {
                var son = sayfaSonu;
                Thread.Sleep(750);
                sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                if (son == sayfaSonu)
                    break;
            }
            
            

            

            Thread.Sleep(3000);

                                                                                                 
             IReadOnlyCollection<IWebElement> list = driver.FindElements(By.CssSelector(".Pkbci")); 

            Thread.Sleep(3000);   

            foreach (var item in list)
            {

                
                if (item.Text == "İstek Gönderildi" || item.Text == "Takiptesin")
                {
                    
                }
                else{
                    item.Click();
                    Thread.Sleep(2000);
                    Console.WriteLine("istek gönderildi");
                }
                
            }        
            
        }
    }
}
