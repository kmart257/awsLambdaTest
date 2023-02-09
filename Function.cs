using Amazon.Lambda.Core;
using System.Text;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace MyFunction
{
	public class Function
	{
	    
	    /// <summary>
	    /// A simple function that takes a string and does a ToUpper
	    /// </summary>
	    /// <param name="input"></param>
	    /// <param name="context"></param>
	    /// <returns></returns>
	    public static async Task<string> FunctionHandler(ILambdaContext context)
	    {
	        HttpClient client = new HttpClient();
	        var url = new Uri("https://hooks.slack.com/workflows/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");

	        using StringContent jsonContent = new(
	        JsonSerializer.Serialize(new
	        {
	            person = "foo bar",
	            date = "230209"
	        }),
	        Encoding.UTF8,
	        "application/json");

	        var res = 
	            await client.PutAsync(
	            url,
	            jsonContent);

	        return await res.Content.ReadAsStringAsync();
	    }
	}
}
