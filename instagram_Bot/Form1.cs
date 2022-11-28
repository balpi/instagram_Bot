using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace instagram_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("i am on instagram");
            Thread.Sleep(2000);

            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));

            
            userName.SendKeys(textBox1.Text);
            password.SendKeys(textBox2.Text);
            loginBtn.Click();
            Console.WriteLine("Logged");
            Thread.Sleep(2500);

            driver.Navigate().GoToUrl($"https://www.instagram.com/{textBox1.Text}");
            Console.WriteLine("Found the profile");
            Thread.Sleep(2500);

            IWebElement followerLink = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a"));
            followerLink.Click();
            Thread.Sleep(2500);


            //ScrollDown Start
            //isgrP
            string jsCommand = "" +
                "pageF = document.querySelector('.isgrP');" +
                "pageF.scrollTo(0,sayfa.scrollHeight);" +
                "var pageEnd = pageF.scrollHeight;" +
                "return pageEnd;";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

            while (true)
            {
                var son = sayfaSonu;
                Thread.Sleep(1500);
                sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                if (son == sayfaSonu)
                    break;
            }

            //ScrollDown End


            //list followers
            Thread.Sleep(1000);
            int numofF = 1;
            IReadOnlyCollection<IWebElement> follwers = driver.FindElements(By.CssSelector(".FPmhX.notranslate._0imsa"));
            foreach (IWebElement follower in follwers)
            {
                Thread.Sleep(100);
                listBox1.Items.Add(numofF + " ==> " + follower.Text);
                numofF++;
            }
        }

    }
}
