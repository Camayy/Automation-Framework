using System;
using TechTalk.SpecFlow;
using AutomationFramework.Base;
using System.Configuration;
using SpecFlowTests.Pages;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class SearchSteps : BaseSteps
    {
        [Given(@"I have navigated to amazon website")]
        public void GivenIHaveNavigatedToAmazonWebsite()
        {
            Drivers.Browser.NavigateToUrl(ConfigurationManager.AppSettings["URL"].ToString());
            CurrentPage = GetInstance<AmazonHome>();
        }
        
        [Given(@"I type football into the search bar")]
        public void GivenITypeFootballIntoTheSearchBar()
        {
            CurrentPage.As<AmazonHome>().TypeTextIntoSearchBar("FOOTBALL");
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            //returns a different page type so needs assignment
            CurrentPage = CurrentPage.As<AmazonHome>().ClickSearchOnSearchBar();
        }
        
        [Then(@"items relating to football should show")]
        public void ThenItemsRelatingToFootballShouldShow()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
