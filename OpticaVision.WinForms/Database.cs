using Microsoft.Data.SqlClient;

namespace OpticaVision;

// Acceso directo y sencillo a SQL Server usando ADO.NET.
internal static class Database
{
    // Si tu instancia no es LocalDB, cambia Server por el nombre de tu servidor.
    private const string ConnectionString = "Server=DESKTOP-COIBO44\\DESARROLLO;Database=OpticaVision;User Id=sa;Password=Isadiel#141923;TrustServerCertificate=True;";

    private static SqlConnection OpenConnection() => new(ConnectionString);

    public static async Task<bool> IsConnectedAsync()
    {
        await using var connection = OpenConnection();
        await connection.OpenAsync();
        return true;
    }

    public static async Task<List<Product>> ProductsAsync()
    {
        var rows = new List<Product>();
        await using var c = OpenConnection(); await c.OpenAsync();
        await using var cmd = new SqlCommand("SELECT Id,Codigo,Nombre,Categoria,Marca,Modelo,Precio,Existencias,Descripcion FROM Productos WHERE Activo=1 ORDER BY Nombre", c);
        await using var r = await cmd.ExecuteReaderAsync();
        while (await r.ReadAsync()) rows.Add(new Product { DatabaseId=r.GetInt64(0), Code=r.GetString(1), Name=r.GetString(2), Category=r.GetString(3), Brand=r.GetString(4), Model=r.GetString(5), Price=r.GetDecimal(6), Stock=r.GetInt32(7), Description=r.GetString(8) });
        return rows;
    }

    public static async Task<List<Customer>> CustomersAsync()
    {
        var rows = new List<Customer>(); await using var c=OpenConnection(); await c.OpenAsync();
        await using var cmd=new SqlCommand("SELECT Id,Nombre,Telefono,Correo FROM Clientes WHERE Activo=1 ORDER BY Nombre",c); await using var r=await cmd.ExecuteReaderAsync();
        while(await r.ReadAsync()) rows.Add(new Customer { DatabaseId=r.GetInt64(0), Name=r.GetString(1), Phone=r.GetString(2), Email=r.GetString(3) }); return rows;
    }
    public static async Task<List<Supplier>> SuppliersAsync()
    {
        var rows=new List<Supplier>(); await using var c=OpenConnection(); await c.OpenAsync();
        await using var cmd=new SqlCommand("SELECT Id,Nombre,Telefono,Correo FROM Proveedores WHERE Activo=1 ORDER BY Nombre",c); await using var r=await cmd.ExecuteReaderAsync();
        while(await r.ReadAsync()) rows.Add(new Supplier { DatabaseId=r.GetInt64(0), Name=r.GetString(1), Phone=r.GetString(2), Email=r.GetString(3) }); return rows;
    }
    public static async Task<List<Appointment>> AppointmentsAsync()
    {
        var rows=new List<Appointment>(); await using var c=OpenConnection(); await c.OpenAsync();
        await using var cmd=new SqlCommand("SELECT Id,Cliente,Fecha,Servicio,Estado,Notas FROM Citas ORDER BY Fecha",c); await using var r=await cmd.ExecuteReaderAsync();
        while(await r.ReadAsync()) rows.Add(new Appointment { DatabaseId=r.GetInt64(0), CustomerName=r.GetString(1), Date=r.GetDateTime(2), Service=r.GetString(3), Status=r.GetString(4), Notes=r.GetString(5) }); return rows;
    }
    public static async Task<List<SaleRecord>> SalesAsync()
    {
        var rows=new List<SaleRecord>(); await using var c=OpenConnection(); await c.OpenAsync();
        await using var cmd=new SqlCommand("SELECT Id,Fecha,Cliente,CodigoProducto,Producto,Cantidad,PrecioUnitario,FormaPago FROM Ventas WHERE Activo=1 ORDER BY Fecha DESC",c); await using var r=await cmd.ExecuteReaderAsync();
        while(await r.ReadAsync()) rows.Add(new SaleRecord { DatabaseId=r.GetInt64(0), Date=r.GetDateTime(1), CustomerName=r.GetString(2), ProductCode=r.GetString(3), ProductName=r.GetString(4), Quantity=r.GetInt32(5), UnitPrice=r.GetDecimal(6), PaymentMethod=r.GetString(7) }); return rows;
    }
    public static async Task<List<PurchaseRecord>> PurchasesAsync()
    {
        var rows=new List<PurchaseRecord>(); await using var c=OpenConnection(); await c.OpenAsync();
        await using var cmd=new SqlCommand("SELECT Id,Fecha,Proveedor,CodigoProducto,Producto,Cantidad,CostoUnitario FROM Compras WHERE Activo=1 ORDER BY Fecha DESC",c); await using var r=await cmd.ExecuteReaderAsync();
        while(await r.ReadAsync()) rows.Add(new PurchaseRecord { DatabaseId=r.GetInt64(0), Date=r.GetDateTime(1), SupplierName=r.GetString(2), ProductCode=r.GetString(3), ProductName=r.GetString(4), Quantity=r.GetInt32(5), UnitCost=r.GetDecimal(6) }); return rows;
    }

    public static Task SaveProductAsync(Product p) => ProductCommandAsync("INSERT INTO Productos(Codigo,Nombre,Categoria,Marca,Modelo,Precio,Existencias,Descripcion) VALUES(@codigo,@nombre,@categoria,@marca,@modelo,@precio,@stock,@descripcion)", p, false);
    public static Task UpdateProductAsync(Product p) => ProductCommandAsync("UPDATE Productos SET Codigo=@codigo,Nombre=@nombre,Categoria=@categoria,Marca=@marca,Modelo=@modelo,Precio=@precio,Existencias=@stock,Descripcion=@descripcion WHERE Id=@id", p, true);
    private static async Task ProductCommandAsync(string sql, Product p, bool update)
    {
        await using var c=OpenConnection(); await c.OpenAsync(); await using var cmd=new SqlCommand(sql,c);
        cmd.Parameters.AddWithValue("@codigo",p.Code); cmd.Parameters.AddWithValue("@nombre",p.Name); cmd.Parameters.AddWithValue("@categoria",p.Category); cmd.Parameters.AddWithValue("@marca",p.Brand); cmd.Parameters.AddWithValue("@modelo",p.Model); cmd.Parameters.AddWithValue("@precio",p.Price); cmd.Parameters.AddWithValue("@descripcion",p.Description); cmd.Parameters.AddWithValue("@stock",p.Stock);
        if(update) cmd.Parameters.AddWithValue("@id",p.DatabaseId); await cmd.ExecuteNonQueryAsync();
    }
    public static Task DeleteProductAsync(long id) => SetActiveAsync("Productos", id);
    public static Task SaveCustomerAsync(Customer x) => PersonCommandAsync("Clientes",x,false);
    public static Task UpdateCustomerAsync(Customer x) => PersonCommandAsync("Clientes",x,true);
    public static Task DeleteCustomerAsync(long id) => SetActiveAsync("Clientes",id);
    public static Task SaveSupplierAsync(Supplier x) => PersonCommandAsync("Proveedores",x,false);
    public static Task UpdateSupplierAsync(Supplier x) => PersonCommandAsync("Proveedores",x,true);
    public static Task DeleteSupplierAsync(long id) => SetActiveAsync("Proveedores",id);
    private static async Task PersonCommandAsync(string table, object person, bool update)
    {
        string name, phone, email; long id=0;
        if(person is Customer a){name=a.Name;phone=a.Phone;email=a.Email;id=a.DatabaseId;} else {var b=(Supplier)person;name=b.Name;phone=b.Phone;email=b.Email;id=b.DatabaseId;}
        string sql=update?$"UPDATE {table} SET Nombre=@nombre,Telefono=@telefono,Correo=@correo WHERE Id=@id":$"INSERT INTO {table}(Nombre,Telefono,Correo) VALUES(@nombre,@telefono,@correo)";
        await using var c=OpenConnection(); await c.OpenAsync(); await using var cmd=new SqlCommand(sql,c); cmd.Parameters.AddWithValue("@nombre",name);cmd.Parameters.AddWithValue("@telefono",phone);cmd.Parameters.AddWithValue("@correo",email);if(update)cmd.Parameters.AddWithValue("@id",id);await cmd.ExecuteNonQueryAsync();
    }
    private static async Task SetActiveAsync(string table,long id){await using var c=OpenConnection();await c.OpenAsync();await using var cmd=new SqlCommand($"UPDATE {table} SET Activo=0 WHERE Id=@id AND Activo=1",c);cmd.Parameters.AddWithValue("@id",id);await cmd.ExecuteNonQueryAsync();}

    public static async Task SaveAppointmentAsync(Appointment x,bool update)
    {
        string sql=update?"UPDATE Citas SET Cliente=@cliente,Fecha=@fecha,Servicio=@servicio,Estado=@estado,Notas=@notas WHERE Id=@id":"INSERT INTO Citas(Cliente,Fecha,Servicio,Estado,Notas) VALUES(@cliente,@fecha,@servicio,@estado,@notas)";
        await using var c=OpenConnection();await c.OpenAsync();await using var cmd=new SqlCommand(sql,c);cmd.Parameters.AddWithValue("@cliente",x.CustomerName);cmd.Parameters.AddWithValue("@fecha",x.Date);cmd.Parameters.AddWithValue("@servicio",x.Service);cmd.Parameters.AddWithValue("@estado",x.Status);cmd.Parameters.AddWithValue("@notas",x.Notes);if(update)cmd.Parameters.AddWithValue("@id",x.DatabaseId);await cmd.ExecuteNonQueryAsync();
    }
    public static async Task DeleteAppointmentAsync(long id){await using var c=OpenConnection();await c.OpenAsync();await using var cmd=new SqlCommand("DELETE FROM Citas WHERE Id=@id",c);cmd.Parameters.AddWithValue("@id",id);await cmd.ExecuteNonQueryAsync();}

    public static Task SaveSaleAsync(Product p,string customer,int qty,decimal price,string payment) => TransactionAsync(true,p,customer,qty,price,payment);
    public static Task SavePurchaseAsync(Product p,string supplier,int qty,decimal cost) => TransactionAsync(false,p,supplier,qty,cost,"Efectivo");
    private static async Task TransactionAsync(bool sale,Product p,string person,int qty,decimal amount,string payment)
    {
        await using var c=OpenConnection();await c.OpenAsync();await using var tx=await c.BeginTransactionAsync();
        var stockChange=sale?-qty:qty;
        await using(var stock=new SqlCommand("UPDATE Productos SET Existencias=Existencias+@cambio WHERE Codigo=@codigo AND (@cambio>=0 OR Existencias>=@necesario)",c,(SqlTransaction)tx))
        {stock.Parameters.AddWithValue("@cambio",stockChange);stock.Parameters.AddWithValue("@codigo",p.Code);stock.Parameters.AddWithValue("@necesario",qty);if(await stock.ExecuteNonQueryAsync()==0)throw new InvalidOperationException("No hay existencias suficientes para esa venta.");}
        string table=sale?"Ventas":"Compras";string sql=sale?"INSERT INTO Ventas(Cliente,CodigoProducto,Producto,Cantidad,PrecioUnitario,FormaPago) VALUES(@persona,@codigo,@producto,@cantidad,@monto,@pago)":"INSERT INTO Compras(Proveedor,CodigoProducto,Producto,Cantidad,CostoUnitario) VALUES(@persona,@codigo,@producto,@cantidad,@monto)";
        await using(var cmd=new SqlCommand(sql,c,(SqlTransaction)tx)){cmd.Parameters.AddWithValue("@persona",person);cmd.Parameters.AddWithValue("@codigo",p.Code);cmd.Parameters.AddWithValue("@producto",p.Name);cmd.Parameters.AddWithValue("@cantidad",qty);cmd.Parameters.AddWithValue("@monto",amount);if(sale)cmd.Parameters.AddWithValue("@pago",payment);await cmd.ExecuteNonQueryAsync();}
        await tx.CommitAsync();
    }
    public static Task DeleteSaleAsync(long id) => DeleteTransactionAsync(true,id);
    public static Task DeletePurchaseAsync(long id) => DeleteTransactionAsync(false,id);
    private static async Task DeleteTransactionAsync(bool sale,long id)
    {
        string table=sale?"Ventas":"Compras";await using var c=OpenConnection();await c.OpenAsync();await using var tx=await c.BeginTransactionAsync();
        if(sale){await using var reverse=new SqlCommand("UPDATE p SET Existencias=p.Existencias+v.Cantidad FROM Productos p JOIN Ventas v ON p.Codigo=v.CodigoProducto WHERE v.Id=@id AND v.Activo=1",c,(SqlTransaction)tx);reverse.Parameters.AddWithValue("@id",id);await reverse.ExecuteNonQueryAsync();}
        else {await using var reverse=new SqlCommand("UPDATE p SET Existencias=p.Existencias-v.Cantidad FROM Productos p JOIN Compras v ON p.Codigo=v.CodigoProducto WHERE v.Id=@id AND v.Activo=1 AND p.Existencias>=v.Cantidad",c,(SqlTransaction)tx);reverse.Parameters.AddWithValue("@id",id);if(await reverse.ExecuteNonQueryAsync()==0)throw new InvalidOperationException("No se puede eliminar la compra porque esas existencias ya se usaron.");}
        await using var cmd=new SqlCommand($"UPDATE {table} SET Activo=0 WHERE Id=@id AND Activo=1",c,(SqlTransaction)tx);cmd.Parameters.AddWithValue("@id",id);await cmd.ExecuteNonQueryAsync();await tx.CommitAsync();
    }
}
