using System.Text.Json;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SecretsManagement.Api.AWS;

namespace SecretsManagement.Api.Controllers;

[ApiController]
public class ExampleController : ControllerBase
{
    private readonly MyCredentials _myCredentials;

    public ExampleController(IOptions<MyCredentials> myCredentials)
    {
        _myCredentials = myCredentials.Value;
    }

    [HttpGet("settings")]
    public async Task<IActionResult> GetSettingsAsync()
    {
        var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName("ap-southeast-2"));
        
        var settings = _myCredentials;
        
        try
        {
            var secrets = await client.GetSecretValueAsync(new GetSecretValueRequest()
            {
                SecretId = "mohrapi/mohrwebhost/appconfig",
                VersionStage = "AWSCURRENT",
            });
            var response = new { settings = settings, secrets = JsonSerializer.Deserialize<Dictionary<string, string>>(secrets.SecretString), };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Ok(new { settings = settings, secrets = new Dictionary<string, string>() {{ "exception", ex.ToString() }} });
        }
    }
}
