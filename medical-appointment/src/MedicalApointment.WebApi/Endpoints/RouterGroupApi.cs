using System;

namespace MedicalApointment.WebApi.Endpoints;

public static class RouterGroupApi
{
  public static RouteGroupBuilder MapApi(this IEndpointRouteBuilder routes)
  {
    return routes.MapGroup("/api");
  }
}
