using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace BootstrapMvc.UI.Common
{
    public class HttpResponseCreator
    {
        public static HttpResponseMessage CreateResponse(HttpRequestMessage request, object responseModel)
        {
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK);

            JsonSerializerSettings setting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            response.Content = new StringContent(JsonConvert.SerializeObject(responseModel, setting), System.Text.Encoding.UTF8, "application/json");
            return response;
        }
    }
}