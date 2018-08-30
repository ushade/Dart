using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ATF.PageOperations
{
    class AboutPage
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AboutPage()
        {
            PageFactory.InitElements(DriverUtils.driver, this);
        }
        //Home Page Objects
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'About')]")]
        public IWebElement AboutTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'User Manual')]")]
        public IWebElement UserManualTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Release Notes')]")]
        public IWebElement ReleaseNotesTab { get; set; }

        public void VerifyReleaseNotes()
        {
            // BasicMethods.SwitchFrameByID("releasenotespdfview");
            //  DriverUtils.driver.SwitchTo().DefaultContent();
            IList<IWebElement> iframe = DriverUtils.driver.FindElements(By.TagName("iframe"));
            int size = iframe.Count;
            Console.WriteLine("Total frames" + size);
            
        }
        public void VerifyUserManual()
        {
            BasicMethods.SwitchFrameByID("pdfview");
            DriverUtils.driver.SwitchTo().DefaultContent();
        }

        private string GetTextFromPDF()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader("D:\\RentReceiptFormat.pdf"))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }

    }
}
