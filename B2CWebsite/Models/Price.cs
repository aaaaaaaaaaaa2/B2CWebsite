namespace B2CWebsite.Models;

public partial class Price
{
    public int PriceId { get; set; }

    public int? Sid { get; set; }

    public int? Price1 { get; set; }

    public virtual Supplement? SidNavigation { get; set; }
}
