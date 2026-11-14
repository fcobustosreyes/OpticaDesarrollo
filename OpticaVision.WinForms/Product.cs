namespace OpticaVision;

public sealed class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long DatabaseId { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Brand { get; set; } = "";
    public string Model { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = "";

    public override string ToString() => $"{Code} — {Name} (disp.: {Stock})";
}
