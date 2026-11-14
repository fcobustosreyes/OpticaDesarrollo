namespace OpticaVision;

public sealed class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long DatabaseId { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public override string ToString() => Name;
}

public sealed class Supplier
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long DatabaseId { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public override string ToString() => Name;
}

public sealed class Appointment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long DatabaseId { get; set; }
    public string CustomerName { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Today.AddHours(9);
    public string Service { get; set; } = "Examen visual";
    public string Status { get; set; } = "Pendiente";
    public string Notes { get; set; } = "";
}

public sealed class PurchaseRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long DatabaseId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string SupplierName { get; set; } = "";
    public string ProductCode { get; set; } = "";
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal Total => Quantity * UnitCost;
}

public sealed class SaleRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public long DatabaseId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string CustomerName { get; set; } = "";
    public string ProductCode { get; set; } = "";
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string PaymentMethod { get; set; } = "Efectivo";
    public decimal Total => Quantity * UnitPrice;
}

