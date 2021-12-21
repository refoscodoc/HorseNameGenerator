using System.ComponentModel.DataAnnotations;

namespace HorsesApi.Models;

public class EngWord
{
    [Key]
    public string? Word { get; set; }
    public string? WordType { get; set; }
}