using System.ComponentModel.DataAnnotations;

public class Transaction
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string? Text { get; set; }

    [Required]
    public int Amount { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime? CreatedAt { get; set; }
}