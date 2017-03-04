using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static GithubApi.Models.GithubObject;


namespace GithubApi.Models
{
    public class GhApi
    {
        public object EnviornmentVariable { get; private set; }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public RootObject[] CallGitHubAPI()
        {
            var client = new RestClient("https://api.github.com/");        
            var request = new RestRequest("users/DanielMunger/starred?client_id="+ EnvironmentVariables.ClientId+"&client_secret="+ EnvironmentVariables.ClientSecret+"");
            request.AddHeader("User-Agent", "DanielMunger");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
                
            }).Wait();
            Debug.WriteLine(response);
            RootObject[] jsonResponse = JsonConvert.DeserializeObject<RootObject[]>(response.Content);     
            return jsonResponse;
        }
        
    }
}

                                                                                                                                                                          

