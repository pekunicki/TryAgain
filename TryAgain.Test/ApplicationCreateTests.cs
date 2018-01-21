using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TryAgain.Utils;

namespace TryAgain.Test
{
    public class ApplicationCreateTests
    {
        private ChromeDriver _driver;
        private Uri _baseUri;
        private string _courseFieldId = "Course_CourseName";
        private string _teacherFieldId = "ProposedTeacherFullName";
        private string _classroomFieldId = "Classroom";
        private string _startTimeFieldId = "Date_StartTime";
        private string _endTimeFieldId = "Date_EndTime";
        private string _submitButtonId = "CreateApplication";

        [SetUp]
        public void Setup()
        {
            var pathToWebDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(pathToWebDriver);
            _baseUri = new Uri(Settings.BaseUrl);
        }

        [Test]
        [Category("UITest")]
        public void ApplicationCreate_FillingValidDataAndSubmit_CreatedApplication()
        {
            _driver.Navigate().GoToUrl(GetEndpoint("/Application/Create"));
            var courseName = _driver.FindElementById(_courseFieldId);
            var teacher = _driver.FindElementById(_teacherFieldId);
            var classRoom = _driver.FindElementById(_classroomFieldId);
            var startTime = _driver.FindElementById(_startTimeFieldId);
            var endTime = _driver.FindElementById(_endTimeFieldId);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var submitButton = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(_submitButtonId)));

            Actions actions = new Actions(_driver);
            actions.SendKeys(courseName, "nowy");
            actions.SendKeys(teacher, "bill gates");
            actions.SendKeys(classRoom, "A1 202");
            actions.SendKeys(startTime, "11:15");
            actions.SendKeys(endTime, "13:15");
            actions.Click(submitButton);
            actions.Perform();

            Assert.AreEqual(GetEndpoint("/Application/CreateSuccessResult"), _driver.Url);
        }

        private Uri GetEndpoint(string endpoint)
        {
            return new Uri(_baseUri, endpoint);
        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//
//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (_driver != null)
//                {
//                    _driver.Dispose();
//                    _driver = null;
//                }
//            }
//        }
    }
}