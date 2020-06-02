using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TodoApplication.Web.Helper
{
   
    //{
        public class TodoAPI
	    {  
	        private string _apiBaseURI = "http://localhost:5000";
            // http://localhost:5000/swagger/index.html
            public HttpClient InitializeClient()
	        {  
	            var client = new HttpClient();  
	            //Passing service base url    
	            client.BaseAddress = new Uri(_apiBaseURI);  
	  
	            client.DefaultRequestHeaders.Clear();  
	            //Define request data format    
	            client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));  
	  
	            return client;  
	        }

        
    }  
   
     
   // }
}
