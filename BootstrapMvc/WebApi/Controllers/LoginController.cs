using BLL;
using BootstrapMvc.UI.Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utils;

namespace BootstrapMvc.UI.WebApi.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private UserInfoService service = new UserInfoService();

        [Route("login")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetLogin(string username, string password)
        {
            ResponseModel<string> responseModel = service.Login(EncyptHelper.StringDecode(username), EncyptHelper.StringDecode(password));
            return HttpResponseCreator.CreateResponse(Request, responseModel);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}