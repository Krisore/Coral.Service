
using System.ComponentModel.DataAnnotations;
namespace Coral.Domain;

public class Tag
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
