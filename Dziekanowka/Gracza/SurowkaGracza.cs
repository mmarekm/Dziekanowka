public class SurowkaGracza(bool jestMajonez, string? jajo, HashSet<string> warzywa)
{
    public bool JestMajonez { get; set; } = jestMajonez;
    public string? Jajo { get; set; } = jajo;
    public HashSet<string> Warzywa { get; set; } = warzywa;
}