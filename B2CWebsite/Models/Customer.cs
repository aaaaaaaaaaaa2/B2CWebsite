namespace B2CWebsite.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
