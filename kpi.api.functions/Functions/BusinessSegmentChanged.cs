using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using kpi.api.functions.Model.Events;
using kpi.api.functions.Services;

namespace kpi.api.functions.Functions
{
    public class BusinessSegmentChanged : BaseEventFunction
    {
        [FunctionName("BusinessSegmentChanged")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "BusinessSegmentChanged")] HttpRequest req,
            ILogger log)
        {
            try
            {
                // Reads body content
                string data = await new StreamReader(req.Body).ReadToEndAsync();

                // Validades JWT and gets payload
                string payload = ValidateJWT(data);

                // Deserializes the payload
                BusinessSegmentEventArgs eventArgs = JsonConvert.DeserializeObject<BusinessSegmentEventArgs>(payload);

                // Validates the event
                ValidateEventArgs(eventArgs, "BusinessSegmentChanged");

                // Updates kpis
                await SellerService.CreateKpiEventAsync(eventArgs);

                // Returns no content status code
                return new NoContentResult();
            }
            catch (Exception e)
            {
                log.LogError(e, e.Message);
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}