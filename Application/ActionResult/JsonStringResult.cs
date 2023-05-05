using Microsoft.AspNetCore.Mvc;

namespace Application.ActionResult
{
    public class JsonStringResult : ContentResult
    {
        public JsonStringResult(string json, int statusCode)
        {
            Content = json;
            ContentType = "application/json";
            StatusCode = statusCode;
        }
    }
}