using System.ComponentModel;

namespace OpticaVision;

public partial class MainForm : Form
{
    private List<Product> _products = [];
    private List<Customer> _customers = [];
    private List<Supplier> _suppliers = [];
    private List<Appointment> _appointments = [];
    private List<SaleRecord> _sales = [];
    private List<PurchaseRecord> _purchases = [];
    private readonly Dictionary<string, DataGridView> _grids = new();

    public MainForm()
    {
        InitializeComponent();
        Theme.ApplyTo(this);
        ConfigureColumns();
        WireEvents();
        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            Shown += async (_, _) => await RunDb(RefreshDataAsync);
    }

    private void ConfigureColumns()
    {
        AddColumns(appointmentsGrid, ("Cliente", nameof(Appointment.CustomerName), 180, ""), ("Fecha y hora", nameof(Appointment.Date), 145, "g"), ("Servicio", nameof(Appointment.Service), 165, ""), ("Estado", nameof(Appointment.Status), 105, ""), ("Notas", nameof(Appointment.Notes), 220, ""));
        AddColumns(salesGrid, ("Fecha", nameof(SaleRecord.Date), 145, "g"), ("Cliente", nameof(SaleRecord.CustomerName), 160, ""), ("Código", nameof(SaleRecord.ProductCode), 90, ""), ("Producto", nameof(SaleRecord.ProductName), 190, ""), ("Cantidad", nameof(SaleRecord.Quantity), 85, ""), ("Precio unitario", nameof(SaleRecord.UnitPrice), 115, "C2"), ("Total", nameof(SaleRecord.Total), 110, "C2"), ("Pago", nameof(SaleRecord.PaymentMethod), 120, ""));
        AddColumns(purchasesGrid, ("Fecha", nameof(PurchaseRecord.Date), 145, "g"), ("Proveedor", nameof(PurchaseRecord.SupplierName), 160, ""), ("Código", nameof(PurchaseRecord.ProductCode), 90, ""), ("Producto", nameof(PurchaseRecord.ProductName), 190, ""), ("Cantidad", nameof(PurchaseRecord.Quantity), 85, ""), ("Costo unitario", nameof(PurchaseRecord.UnitCost), 115, "C2"), ("Total", nameof(PurchaseRecord.Total), 110, "C2"));
        AddColumns(inventoryGrid, ("Código", nameof(Product.Code), 95, ""), ("Nombre", nameof(Product.Name), 190, ""), ("Categoría", nameof(Product.Category), 130, ""), ("Marca", nameof(Product.Brand), 120, ""), ("Modelo", nameof(Product.Model), 110, ""), ("Precio", nameof(Product.Price), 115, "C2"), ("Existencias", nameof(Product.Stock), 95, ""));
        AddColumns(customersGrid, ("Nombre", nameof(Customer.Name), 220, ""), ("Teléfono", nameof(Customer.Phone), 150, ""), ("Correo", nameof(Customer.Email), 260, ""));
        AddColumns(suppliersGrid, ("Nombre", nameof(Supplier.Name), 220, ""), ("Teléfono", nameof(Supplier.Phone), 150, ""), ("Correo", nameof(Supplier.Email), 260, ""));
        _grids["Citas"] = appointmentsGrid; _grids["Ventas"] = salesGrid; _grids["Compras"] = purchasesGrid;
        _grids["Inventario"] = inventoryGrid; _grids["Clientes"] = customersGrid; _grids["Proveedores"] = suppliersGrid;
    }

    private static void AddColumns(DataGridView grid, params (string Header, string Property, int Width, string Format)[] columns)
    {
        foreach (var c in columns) grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = c.Header, DataPropertyName = c.Property, Name = c.Property, Width = c.Width, AutoSizeMode = c.Property is nameof(Product.Name) or nameof(SaleRecord.ProductName) or nameof(PurchaseRecord.ProductName) or nameof(Appointment.Notes) or nameof(Customer.Email) or nameof(Supplier.Email) ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.None, DefaultCellStyle = new DataGridViewCellStyle { Format = c.Format } });
    }

    private void WireEvents()
    {
        appointmentAddButton.Click += async (_, _) => await AddAppointment(); appointmentEditButton.Click += async (_, _) => await EditAppointment(); appointmentDeleteButton.Click += async (_, _) => await DeleteAppointment();
        saleAddButton.Click += async (_, _) => await AddSale(); saleDeleteButton.Click += async (_, _) => await DeleteSale();
        purchaseAddButton.Click += async (_, _) => await AddPurchase(); purchaseDeleteButton.Click += async (_, _) => await DeletePurchase();
        productAddButton.Click += async (_, _) => await AddProduct(); productEditButton.Click += async (_, _) => await EditProduct(); productDeleteButton.Click += async (_, _) => await DeleteProduct();
        customerAddButton.Click += async (_, _) => await AddCustomer(); customerEditButton.Click += async (_, _) => await EditCustomer(); customerDeleteButton.Click += async (_, _) => await DeleteCustomer();
        supplierAddButton.Click += async (_, _) => await AddSupplier(); supplierEditButton.Click += async (_, _) => await EditSupplier(); supplierDeleteButton.Click += async (_, _) => await DeleteSupplier();
        appointmentsGrid.DoubleClick += async (_, _) => await EditAppointment(); inventoryGrid.DoubleClick += async (_, _) => await EditProduct(); customersGrid.DoubleClick += async (_, _) => await EditCustomer(); suppliersGrid.DoubleClick += async (_, _) => await EditSupplier();
    }

    private async Task RefreshDataAsync()
    {
        _products = await Database.ProductsAsync(); _customers = await Database.CustomersAsync(); _suppliers = await Database.SuppliersAsync();
        _appointments = await Database.AppointmentsAsync(); _sales = await Database.SalesAsync(); _purchases = await Database.PurchasesAsync();
        BindAll();
    }
    private void BindAll()
    {
        Bind("Citas", _appointments.OrderBy(x => x.Date).ToList()); Bind("Ventas", _sales); Bind("Compras", _purchases);
        Bind("Inventario", _products.OrderBy(x => x.Name).ToList()); Bind("Clientes", _customers.OrderBy(x => x.Name).ToList()); Bind("Proveedores", _suppliers.OrderBy(x => x.Name).ToList());
        summaryLabel.Text = "RESUMEN DEL NEGOCIO\n\n" + $"Productos registrados:  {_products.Count}\n" + $"Unidades disponibles:     {_products.Sum(x => x.Stock):N0}\n" + $"Citas pendientes:              {_appointments.Count(x => x.Status is "Pendiente" or "Confirmada")}\n" + $"Ventas registradas:          {_sales.Count}  |  Total vendido: C$ {_sales.Sum(x => x.Total):N2}\n" + $"Compras registradas:       {_purchases.Count}  |  Total comprado: C$ {_purchases.Sum(x => x.Total):N2}\n" + $"Productos con poco stock: {_products.Count(x => x.Stock <= 5)} (5 unidades o menos)";
    }
    private void Bind(string key, object rows) { if (_grids.TryGetValue(key, out var grid)) grid.DataSource = rows; }
    private T? Selected<T>(string key) where T : class => _grids.TryGetValue(key, out var grid) ? grid.CurrentRow?.DataBoundItem as T : null;
    private async Task RunDb(Func<Task> work)
    {
        try { UseWaitCursor = true; await work(); }
        catch (Exception ex) { MessageBox.Show($"No se pudo completar la operación.\n\n{ex.Message}\n\nRevisa que SQL Server esté instalado y que hayas ejecutado database/OpticaVision_SQLServer.sql.", "Conexión con SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        finally { UseWaitCursor = false; }
    }
    private static bool ConfirmDelete(string text) => MessageBox.Show($"¿Deseas eliminar {text}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
    private static void ShowInfo(string message) => MessageBox.Show(message, "Óptica Visión", MessageBoxButtons.OK, MessageBoxIcon.Information);

    private async Task AddAppointment() { using var d = new AppointmentDialog(); if (d.ShowDialog(this) != DialogResult.OK) return; var a = new Appointment { CustomerName=d.CustomerName, Date=d.AppointmentDate, Service=d.Service, Status=d.Status, Notes=d.Notes }; await RunDb(async () => { await Database.SaveAppointmentAsync(a,false); await RefreshDataAsync(); }); }
    private async Task EditAppointment() { var a=Selected<Appointment>("Citas"); if(a is null)return; using var d=new AppointmentDialog(a); if(d.ShowDialog(this)!=DialogResult.OK)return; a.CustomerName=d.CustomerName;a.Date=d.AppointmentDate;a.Service=d.Service;a.Status=d.Status;a.Notes=d.Notes;await RunDb(async()=>{await Database.SaveAppointmentAsync(a,true);await RefreshDataAsync();}); }
    private async Task DeleteAppointment() { var a=Selected<Appointment>("Citas");if(a is null||!ConfirmDelete($"la cita de {a.CustomerName}"))return;await RunDb(async()=>{await Database.DeleteAppointmentAsync(a.DatabaseId);await RefreshDataAsync();}); }
    private async Task AddSale() { if(_products.Count==0){ShowInfo("Primero registra productos en Inventario.");return;}using var d=new TransactionDialog(true,_products,_customers,_suppliers);if(d.ShowDialog(this)!=DialogResult.OK)return;await RunDb(async()=>{await Database.SaveSaleAsync(d.SelectedProduct,d.CounterpartyName,d.Quantity,d.UnitPrice,d.PaymentMethod);await RefreshDataAsync();}); }
    private async Task DeleteSale() { var x=Selected<SaleRecord>("Ventas");if(x is null||!ConfirmDelete($"la venta de {x.ProductName}"))return;await RunDb(async()=>{await Database.DeleteSaleAsync(x.DatabaseId);await RefreshDataAsync();}); }
    private async Task AddPurchase() { if(_products.Count==0||_suppliers.Count==0){ShowInfo("Registra primero al menos un producto y un proveedor.");return;}using var d=new TransactionDialog(false,_products,_customers,_suppliers);if(d.ShowDialog(this)!=DialogResult.OK)return;await RunDb(async()=>{await Database.SavePurchaseAsync(d.SelectedProduct,d.CounterpartyName,d.Quantity,d.UnitPrice);await RefreshDataAsync();}); }
    private async Task DeletePurchase() { var x=Selected<PurchaseRecord>("Compras");if(x is null||!ConfirmDelete($"la compra de {x.ProductName}"))return;await RunDb(async()=>{await Database.DeletePurchaseAsync(x.DatabaseId);await RefreshDataAsync();}); }
    private async Task AddProduct() { using var d=new ProductDialog();if(d.ShowDialog(this)!=DialogResult.OK)return;await RunDb(async()=>{await Database.SaveProductAsync(d.Product);await RefreshDataAsync();}); }
    private async Task EditProduct() { var x=Selected<Product>("Inventario");if(x is null)return;using var d=new ProductDialog(x);if(d.ShowDialog(this)!=DialogResult.OK)return;d.Product.DatabaseId=x.DatabaseId;await RunDb(async()=>{await Database.UpdateProductAsync(d.Product);await RefreshDataAsync();}); }
    private async Task DeleteProduct() { var x=Selected<Product>("Inventario");if(x is null||!ConfirmDelete(x.Name))return;await RunDb(async()=>{await Database.DeleteProductAsync(x.DatabaseId);await RefreshDataAsync();}); }
    private async Task AddCustomer() { using var d=new PersonDialog("Nuevo cliente");if(d.ShowDialog(this)!=DialogResult.OK)return;await RunDb(async()=>{await Database.SaveCustomerAsync(new Customer{Name=d.PersonName,Phone=d.Phone,Email=d.Email});await RefreshDataAsync();}); }
    private async Task EditCustomer() { var x=Selected<Customer>("Clientes");if(x is null)return;using var d=new PersonDialog("Editar cliente",x.Name,x.Phone,x.Email);if(d.ShowDialog(this)!=DialogResult.OK)return;x.Name=d.PersonName;x.Phone=d.Phone;x.Email=d.Email;await RunDb(async()=>{await Database.UpdateCustomerAsync(x);await RefreshDataAsync();}); }
    private async Task DeleteCustomer() { var x=Selected<Customer>("Clientes");if(x is null||!ConfirmDelete(x.Name))return;await RunDb(async()=>{await Database.DeleteCustomerAsync(x.DatabaseId);await RefreshDataAsync();}); }
    private async Task AddSupplier() { using var d=new PersonDialog("Nuevo proveedor");if(d.ShowDialog(this)!=DialogResult.OK)return;await RunDb(async()=>{await Database.SaveSupplierAsync(new Supplier{Name=d.PersonName,Phone=d.Phone,Email=d.Email});await RefreshDataAsync();}); }
    private async Task EditSupplier() { var x=Selected<Supplier>("Proveedores");if(x is null)return;using var d=new PersonDialog("Editar proveedor",x.Name,x.Phone,x.Email);if(d.ShowDialog(this)!=DialogResult.OK)return;x.Name=d.PersonName;x.Phone=d.Phone;x.Email=d.Email;await RunDb(async()=>{await Database.UpdateSupplierAsync(x);await RefreshDataAsync();}); }
    private async Task DeleteSupplier() { var x=Selected<Supplier>("Proveedores");if(x is null||!ConfirmDelete(x.Name))return;await RunDb(async()=>{await Database.DeleteSupplierAsync(x.DatabaseId);await RefreshDataAsync();}); }
}
