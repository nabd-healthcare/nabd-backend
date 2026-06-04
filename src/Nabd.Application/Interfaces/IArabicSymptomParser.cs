namespace Nabd.Application.Interfaces;

public interface IArabicSymptomParser
{
    Task<List<string>> ParseSymptomsAsync(string text);
}
