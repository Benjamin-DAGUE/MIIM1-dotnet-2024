using System.Text.Json.Serialization;

namespace CoursBlazor.Models;

public class Fact
{
    public int Id { get; set; }

    [JsonPropertyName("fact")]
    public string Data {  get; set; } = string.Empty;

    public long Lenght { get; set; }
}
