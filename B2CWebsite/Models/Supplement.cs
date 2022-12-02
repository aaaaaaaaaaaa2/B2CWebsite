namespace B2CWebsite.Models;

public partial class Supplement
{
    public int Sid { get; set; }

    public string? Sname { get; set; }

    public string? Slink { get; set; }

    public int? ManuId { get; set; }

    public string? Thumb { get; set; }

    public int? CatId { get; set; }

    public string? Uses { get; set; }

    public string? Ingredient { get; set; }

    public string? Directions { get; set; }

    public string? Warnings { get; set; }

    public string? OtherInfo { get; set; }

    public string? InactiveIngredient { get; set; }

    public bool? BestSeller { get; set; }

    public bool? HomeFlag { get; set; }

    public bool? Active { get; set; }

    public virtual Category? Cat { get; set; }

    public virtual Manufacturer? Manu { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual ICollection<Price> Prices { get; } = new List<Price>();
}
