using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using LinqToTwitter;
using System.Configuration;

namespace retweeter.Controllers
{
    public  class RetweeterController : ApiController
    
    {
         
        [Route("retweeter/do")]
        [HttpGet]
        public  void Retweet ()
        {
           var cns_key = System.Configuration.ConfigurationManager.AppSettings["consumer_KEY"];
           var cns_secret = System.Configuration.ConfigurationManager.AppSettings["consumer_SECRET"];
           var access_token  = System.Configuration.ConfigurationManager.AppSettings["access_TOKEN"];
           var token_secret = System.Configuration.ConfigurationManager.AppSettings["token_SECRET"];

            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = cns_key,
                    ConsumerSecret = cns_secret,
                    AccessToken = access_token,
                    AccessTokenSecret = token_secret
                }
            };

            var twitterCtx = new TwitterContext(auth);
            SearchTwitter.search(twitterCtx);

        }
       
    }
}
