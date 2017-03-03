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
            var request = new RestRequest("users/DanielMunger/starred?client_id=0bc0fefe2f144068a8c9&client_secret=b722a7949a1b214c2280a5c7fab51f3bc6b76021");
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

                                                                                                                                                                          
//0bc0fefe2f144068a8c9 clientid

//b722a7949a1b214c2280a5c7fab51f3bc6b76021 client secret
