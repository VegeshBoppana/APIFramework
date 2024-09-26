using Utilities.Configure;
using System.Reflection;
using Utilities.APIUtility;
using SpecFlowProjectPractice.API.Model;


namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class APITestStepDefinitions
    {
        private APIUtility apiUtility;
        private ScenarioContext scenarioContext;
        private TestSettings testSettings;
        public APITestStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            testSettings = ConfigReader.GetConfig("C:\\Users\\vegeshsai_boppana\\source\\repos\\APIFramework\\APIFramework\\appSetting.json");
        }

        [Given(@"I call the API")]
        public void GivenICallTheAPI()
        {
            apiUtility = new APIUtility(testSettings.Url);
            scenarioContext["response"] = apiUtility.Get<BreedData>("breeds");

            Dictionary<string, string> paramters = new Dictionary<string, string>();
            paramters.Add("Limit", "1");
            // scenarioContext["responseWithParams"]= apiUtility.Get<BreeData>("breeds",null,paramters);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            scenarioContext["responseWithHeadersAndParameter"] = apiUtility.Get<BreedData>("breeds", headers, paramters);
        }

        [Then(@"I should get the response")]
        public void ThenIShouldGetTheResponse()
        {
            var data = scenarioContext.Get<BreedData>("response");


            //BreeData dataWithParameter = scenarioContext.Get<BreeData>("responseWithParams");
            BreedData dataWitHeader = scenarioContext.Get<BreedData>("responseWithHeadersAndParameter");
        }
    }
}