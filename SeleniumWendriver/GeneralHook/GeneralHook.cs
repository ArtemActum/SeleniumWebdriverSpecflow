using SeleniumWendriver.ComponentHelper;
using System;
using TechTalk.SpecFlow;

namespace SeleniumWendriver.GeneralHook
{
    [Binding]
    public sealed class GeneralHook
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun Hook");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun Hook");
        }

        [BeforeFeature("Tag1")]
        public static void BeforeFeature()
        {
            Console.WriteLine("BeforeFeature Hook");
        }

        [AfterFeature("Tag1")]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature Hook");
        }

        [BeforeScenario("Tag1")]
        public static void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario Hook");
        }

        [AfterScenario("Tag1")]
        public static void AfterScenario()
        {
            Console.WriteLine("AfterScenario Hook");
            //Console.WriteLine("Title : {0}", ScenarioContext.Current.ScenarioInfo.Title);
            //Console.WriteLine("Title : {0}", ScenarioContext.Current.TestError);
            if (ScenarioContext.Current.TestError != null)
            {
                string name = ScenarioContext.Current.ScenarioInfo.Title + ".jpeg";
                GenericHelper.TakeScreenShot(name);
                Console.WriteLine(ScenarioContext.Current.TestError.Message);
                Console.WriteLine(ScenarioContext.Current.TestError.StackTrace);
            }
        }
    }
}