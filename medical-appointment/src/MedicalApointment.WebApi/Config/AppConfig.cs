using MedicalApointment.Shared;

namespace MedicalApointment.WebApi.Config;

public class AppConfig : IAppConfig
{
  private readonly ConfigurationManager _configurationManager;
  public AppConfig(ConfigurationManager configurationManager)
  {
    _configurationManager = configurationManager;
  }
  public string ConnectionString => _configurationManager.GetConnectionString("AppContext")!;

  public string ApiKey => _configurationManager.GetValue<string>("OpenRouter:ApiKey") ?? throw new NotImplementedException();

  public string AIModel => _configurationManager.GetValue<string>("OpenRouter:AIModel") ?? throw new NotImplementedException();

  public string UrlApi => _configurationManager.GetValue<string>("OpenRouter:UrlApi") ?? throw new NotImplementedException();
}
