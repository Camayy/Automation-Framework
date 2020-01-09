using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Project.Steps
{
    [Binding]
    class SampleSteps
    {
        [Given(@"I have navigated to amazon")]
        public void GivenIHaveNavigatedToAmazon()
        {
            Assert.IsTrue(new Pages.amazonpage().TestMethod());
        }

        [Given(@"I enter football")]
        public void GivenIEnterFootball()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click search")]
        public void WhenIClickSearch()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the site will load the search")]
        public void ThenTheSiteWillLoadTheSearch()
        {
            ScenarioContext.Current.Pending();
        }



    }
}
