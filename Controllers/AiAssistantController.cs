// Controllers/AiAssistantController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibreriaWeb.Data;
using LibreriaWeb.Models;


[Route("api/ai")]
[ApiController]
public class AiAssistantController : ControllerBase
{
    private readonly LibreriaContext _context;
    private readonly IBookRecommendationService _aiService;

    public AiAssistantController(LibreriaContext context, IBookRecommendationService aiService)
    {
        _context = context;
        _aiService = aiService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> AskQuestion([FromBody] AiQuestionRequest request)
    {
        var answer = await _aiService.GetAnswerAsync(request.Question);
        return Ok(new { answer });
    }
}

public class AiQuestionRequest
{
    public string Question { get; set; }
}