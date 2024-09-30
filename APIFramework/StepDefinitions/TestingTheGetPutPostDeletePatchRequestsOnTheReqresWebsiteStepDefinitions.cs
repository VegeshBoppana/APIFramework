using System;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Utilities.APIUtility;
using System.Xml.Linq;

namespace APIFramework.StepDefinitions
{
    [Binding]
    public class TestingTheGetPutPostDeletePatchRequestsOnTheReqresWebsiteStepDefinitions
    {


        private APIHelper _apiHelper;
        private HttpStatusCode _statusCode;
        private string _endpoint;
        private object _requestData;
        private object _responseContent;


        public TestingTheGetPutPostDeletePatchRequestsOnTheReqresWebsiteStepDefinitions()
        {
            // Initialize the helper with the base URL
            _apiHelper = new APIHelper("https://reqres.in");
        }



        [Given(@"User has the base URL")]
        public void GivenUserHasTheBaseURL()
        {
            Console.WriteLine("Welcome to the beautiful world of API Testing");
        }

        [Given(@"User sets the endpoint as ""([^""]*)""")]
        public void GivenUserSetsTheEndpointAs(string endpoint)
        {
            _endpoint = endpoint;
        }

        [When(@"User makes a ""([^""]*)"" request")]
        public async Task WhenUserMakesARequest(string methodType)
        {
            HttpMethodType httpMethodType = Enum.Parse<HttpMethodType>(methodType, true);
            _statusCode = await _apiHelper.GetResponseStatusCode<object>(_endpoint, httpMethodType);
            Console.WriteLine($"Requesting: {_endpoint}");
            Console.WriteLine($"Response Status Code: {_statusCode}");

        }

        [Then(@"User should receive a status response as ""([^""]*)""")]
        public void ThenUserShouldReceiveAStatusResponseAs(string expectedStatusCode)
        {
            HttpStatusCode expectedCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expectedStatusCode, true);

            Assert.AreEqual(expectedCode, _statusCode, $"Expected status code {expectedCode}, but received {_statusCode}.");

        }


        [When(@"User makes a ""([^""]*)"" requestt")]
        public async Task WhenUserMakesARequesttAsync(string methodType)
        {
            HttpMethodType httpMethodType = Enum.Parse<HttpMethodType>(methodType, true);
            _responseContent = await _apiHelper.GetResponseContent<object>(_endpoint, httpMethodType) ?? string.Empty;
            Console.WriteLine($"Requesting: {_endpoint}");
            Console.WriteLine($"Response Content: {_responseContent}");
        }

        [Then(@"User should receive a status response in json format")]
        public void ThenUserShouldReceiveAStatusResponseInJsonFormat()
        {
            Console.WriteLine("efda");
        }



        //put(update/replace)

      








        [When(@"User makes a ""([^""]*)"" request and sends the data as ""([^""]*)"" and ""([^""]*)""")]
        public async Task WhenUserMakesARequestAndSendsTheDataAsAnd(string methodType, string name, string job)
        {
            HttpMethodType httpMethodType = Enum.Parse<HttpMethodType>(methodType, true);
            _requestData = new { name, job };
            _statusCode = await _apiHelper.GetResponseStatusCode<object>(_endpoint, httpMethodType, _requestData);
            _responseContent = await _apiHelper.GetResponseContent<object>(_endpoint, httpMethodType, _requestData) ?? string.Empty;
            Console.WriteLine(_statusCode);
            Console.WriteLine(_responseContent);


        }

        [Then(@"User should receive a status response as ""([^""]*)"" and also print the response")]
        public void ThenUserShouldReceiveAStatusResponseAsAndAlsoPrintTheResponse(HttpStatusCode expectedcode)
        {
            Console.WriteLine("here");
            Console.WriteLine(expectedcode);
            if (_statusCode == expectedcode)
            {

                Console.WriteLine(_statusCode);
                Console.WriteLine(_responseContent);
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }


        [When(@"User makes a ""([^""]*)"" request and sends the data with email ""([^""]*)"" and password ""([^""]*)""")]
        public async Task WhenUserMakesAPostRequestAndSendsTheDataWithEmailAndPassword(string methodType, string email, string password)
        {
            HttpMethodType httpMethodType = Enum.Parse<HttpMethodType>(methodType, true);

            _requestData = new { email = email, password = password }; // Using anonymous type here, consider a strongly-typed model
            _statusCode = await _apiHelper.GetResponseStatusCode<object>(_endpoint, httpMethodType, _requestData);
            _responseContent = await _apiHelper.GetResponseContent<object>(_endpoint, httpMethodType, _requestData) ?? string.Empty;
            Console.WriteLine(_statusCode);
            Console.WriteLine(_responseContent);
        }






    }
}
