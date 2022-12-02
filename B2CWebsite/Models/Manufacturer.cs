namespace B2CWebsite.Models;

public partial class Manufacturer
{
    public int ManuId { get; set; }

    public string? ManuName { get; set; }

    public string? ManuAddress { get; set; }

    public int? ManuPhone { get; set; }

    public string? ManuEmail { get; set; }

    public string? ManuCountry { get; set; }

    public virtual ICollection<Supplement> Supplements { get; } = new List<Supplement>();
}
