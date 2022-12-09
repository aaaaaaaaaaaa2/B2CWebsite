namespace B2CWebsite.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string? CatName { get; set; }

    public string? Description { get; set; }


    public int? Levels { get; set; }

    public int? Ordering { get; set; }

    public bool? Published { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public string? MetaDesc { get; set; }

    public string? MetaKey { get; set; }

    public string? MetaCover { get; set; }

    public string? MetaSchemeMarkup { get; set; }

    public virtual ICollection<Supplement> Supplements { get; } = new List<Supplement>();
}
