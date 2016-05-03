using System;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Collections.Generic;

public class SearchTwitter

{
    public static async void search(TwitterContext twitterCtx)
        {
            var  querystring = System.Configuration.ConfigurationManager.AppSettings["qstring"];
            string qstringfilter = System.Configuration.ConfigurationManager.AppSettings["qstringfilter"];
            string qstringruleout = System.Configuration.ConfigurationManager.AppSettings["qstringruleout"];
            Int32 time = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["time"]);

        
            List<string> result = qstringfilter.Split(',').ToList();
            List<string> resultruleout = qstringruleout.Split(',').ToList();

            var searchResponse =
        
                await
                (from search in twitterCtx.Search
                 where 
                       search.Type == SearchType.Search &&
                      search.Query == querystring
                 select search).SingleOrDefaultAsync();
                     
                 for (int i = 0; i < searchResponse.Statuses.Count ; i++)   
	             {
                     
                     
                    if (searchResponse.Statuses[i].CreatedAt > DateTime.Now.AddMinutes(time))


                        if ( searchResponse != null && searchResponse.Statuses != null && searchResponse.Statuses[i].Text != null &&  !searchResponse.Statuses[i].Text.Contains("RT")   && searchResponse.Statuses[i].InReplyToUserID == 0)
                            {
                                var idioma = searchResponse.Statuses[i].Lang;
                                var text = searchResponse.Statuses[i].Text;

                                bool bruleout = resultruleout.Any(text.Contains);
                                bool brule = result.Any(text.Contains);
                                if (!bruleout)
                                { 
                                    if (brule)
                                    {
                                       await twitterCtx.RetweetAsync(searchResponse.Statuses[i].StatusID);                                    


                               }     
                            }
                 }
            }                    

            
                                
               
               
                    

        }
}
