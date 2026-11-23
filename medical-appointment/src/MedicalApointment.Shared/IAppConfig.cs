using System;

namespace MedicalApointment.Shared;

public interface IAppConfig
{
  public string ConnectionString { get; }
  public string ApiKey { get; }
  public string AIModel { get; }
  public string UrlApi { get; }
}
