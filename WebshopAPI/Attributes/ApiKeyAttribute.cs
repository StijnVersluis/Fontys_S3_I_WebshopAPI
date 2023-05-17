using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebshopAPI_DAL;
using WebshopAPI_Logic;

namespace WebshopAPI.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";
        private const string COMPKEYNAME = "Company";
        private CompanyDAL companyDAL = new CompanyDAL();
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            #region Admin Key Value
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided!"
                };
                return;
            }
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var adminApiKey = appSettings.GetValue<string>(APIKEYNAME);
            #endregion
            //Check if api key provided is admin key
            if (!adminApiKey.Equals(extractedApiKey))
            {

                //check if company name is given
                if (!context.HttpContext.Request.Headers.TryGetValue(COMPKEYNAME, out var extractedCompanyUserName))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Company name was not provided!\n" +
                        "Provide the company name with \"Company\""
                    };
                    return;
                }

                //Get api keys here
                Company company = new Company();
                company.UserName = extractedCompanyUserName;

                //Get api key of company from database
                var companyApiKey = company.GetCompanyApiKeyByUserName(companyDAL);

                if (!companyApiKey.Equals(extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Api Key is not valid!"
                    };
                    return;
                }
            }
            await next();
        }
    }
}
