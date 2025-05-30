// Services/BookRecommendationService.cs
using LibreriaWeb.Data;
using System.Linq;
using System.Threading.Tasks;
using LibreriaWeb.Models;

public interface IBookRecommendationService
{
    Task<string> GetAnswerAsync(string question);
}

public class BookRecommendationService : IBookRecommendationService
{
    private readonly LibreriaContext _context;

    public BookRecommendationService(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<string> GetAnswerAsync(string question)
    {
        question = question.ToLower();

        // Risposte predefinite
        if (question.Contains("orario") || question.Contains("aperto"))
            return "La libreria è aperta dal lunedì al sabato, dalle 9:00 alle 19:00.";

        if (question.Contains("contatti") || question.Contains("telefono"))
            return "Puoi contattarci al numero 02 1234567 o via email a info@libreriaweb.it";

        // Cerca libri per genere
        if (question.Contains("fantasy") || question.Contains("fantascienza"))
        {
            var books = _context.Libro
                .Where(l => l.Genere.ToLower().Contains("fantasy") || l.Genere.ToLower().Contains("fantascienza"))
                .Take(3)
                .Select(l => $"{l.Titolo} di {l.Autore.NomeCompleto}")
                .ToList();

            return books.Any()
                ? $"Ecco alcuni libri fantasy: {string.Join(", ", books)}"
                : "Al momento non abbiamo libri fantasy nel catalogo.";
        }

        // Cerca libri per autore
        var authorKeywords = new[] { "autore", "scritto da", "scrittrice" };
        if (authorKeywords.Any(k => question.Contains(k)))
        {
            var authorName = question.Split(' ').Last();
            var books = _context.Libro
                .Where(l => l.Autore.NomeCompleto.ToLower().Contains(authorName))
                .Take(3)
                .Select(l => l.Titolo)
                .ToList();

            return books.Any()
                ? $"L'autore ha scritto: {string.Join(", ", books)}"
                : "Non ho trovato libri di questo autore.";
        }

        // Default: integrazione con servizio AI esterno (es. OpenAI)
        return await GetAiGeneratedResponse(question);
    }

    private async Task<string> GetAiGeneratedResponse(string question)
    {
        // Implementa qui l'integrazione con un servizio AI come:
        // - OpenAI API
        // - Azure Cognitive Services
        // - Hugging Face

        // Esempio con chiamata a API esterna
        // var response = await _httpClient.PostAsJsonAsync(apiUrl, new { question });
        // return await response.Content.ReadAsStringAsync();

        return "Posso aiutarti a trovare libri per genere, autore o argomento. Prova a chiedermi 'Cosa mi consigli di fantasy?' o 'Libri di Italo Calvino'";
    }
}