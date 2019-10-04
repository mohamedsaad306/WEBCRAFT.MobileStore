using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Advensco.EventManagement.Logger
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            string requestBody = await request.Content.ReadAsStringAsync();


            //Trace.WriteLine(requestBody);


            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);
            
            Logger.LogApi(new ApiLog
            {
                URL = request.RequestUri.LocalPath,
                Method = request.Method.ToString(),
                CreatedOn = DateTime.Now,
                Request = requestBody,
                Response = (result.Content != null) ?await result.Content.ReadAsStringAsync():"No Response",
                Status = (result.StatusCode == HttpStatusCode.OK ) ?"SUCCESS" :"FAIL",
                StatusCode = (int)result.StatusCode,    
            });


            return result;
        }
    }
}