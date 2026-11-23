using System;
using MedicalApointment.Application.Plugins;
using MedicalApointment.Application.UseCases.Chat.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace MedicalApointment.WebApi.Endpoints;

public static class ChatEndpoint
{
  public static void MapChatEndpoint(this IEndpointRouteBuilder routes)
  {
    var group = routes.MapGroup("/chat");
    group.MapPost("/", async (
      [FromBody] ChatRequest request,
      Kernel kernel,
      [FromServices] MedicoPlugin medicoPlugin,
      IChatCompletionService chatService) =>
    {
      if (string.IsNullOrWhiteSpace(request.Mensagem))
        return Results.BadRequest(new { erro = "A mensagem não pode ser vazia." });

      try
      {
        kernel.Plugins.AddFromObject(medicoPlugin, "Medicos");

        ChatHistory chatHistory = [];
        chatHistory.AddSystemMessage(
          "Você é um assistente corporativo para uma clínica médica. " +
          "**ATENÇÃO**: Você deve sempre utilizar as funções do plugin chamado 'Medicos' de médicos para consultar dados reais no banco de dados. " +
          "quando usuário perguntar sobre médicos disponíveis, especialidades médicas e disponibilidade de agendamento de consultas"
        );

        chatHistory.AddUserMessage(request.Mensagem);

        OpenAIPromptExecutionSettings executionSettings = new()
        {
          ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
          Temperature = 0.3
        };

        var resultado = await chatService.GetChatMessageContentAsync(
          chatHistory,
          executionSettings,
          kernel
        );

        string respostaFinal = resultado.Content ?? "Não foi possíve gerar uma resposta válida";

        return Results.Ok(new ChatResponse(respostaFinal));
      }
      catch (Exception ex)
      {
        return Results.BadRequest(ex.Message);
      }
    });
  }
}
