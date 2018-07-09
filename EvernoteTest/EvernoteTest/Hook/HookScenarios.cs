using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace EvernoteTest
{
    //Enum for the browser type
    public enum BrowserType
    {
        Firefox,
        Chrome,
        IE
    }

    [Binding]
    public class HookScenarios : PageProperties
    {
        private static ExtentTest featureName;
        private static ExtentTest scenarioName;
        private static ExtentReports extentReport;

        private BrowserType _browserType;

        [BeforeScenario ()]
        public void BeforeScenario()
        {
            //get browser type according to scenario tag
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("chrome"))
                SetBrowserType(BrowserType.Chrome);
            else if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("firefox"))
                SetBrowserType(BrowserType.Firefox);

            //get the scenario name being testing and return it to the reporting html
            scenarioName = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //close driver
            driver.Close();
            driver.Quit();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //initialiee reporting
            var htmlReporter = new ExtentHtmlReporter(@"E:\Google Drive\LeoVentures\EvernoteTest\ExtentReport " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //close extent report
            extentReport.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //get the feature name being testing and return it to the reporting html
            featureName = extentReport.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public static void AfterStep()
        {
            //provide the correct scenario feature step for the reporting
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "And")
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

            //Log an Pending Status step methods
            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And")
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            } 
        }

        //Initialise browser type according to the scenario tag
        private void SetBrowserType(BrowserType browserType)
        {
            if(browserType == BrowserType.Firefox)
                driver = new FirefoxDriver();
            else if (browserType == BrowserType.Chrome)
                driver = new ChromeDriver();
        }
    }
}
