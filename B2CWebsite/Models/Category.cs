using System;
using System.Collections.Generic;

namespace B2CWebsite.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string? CatName { get; set; }

    public string? Description { get; set; }

    public string? Thumb { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Supplement> Supplements { get; } = new List<Supplement>();
}
