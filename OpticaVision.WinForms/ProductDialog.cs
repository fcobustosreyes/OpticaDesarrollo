namespace OpticaVision;

public sealed class ProductDialog : Form
{
    private readonly TextBox _code = new();
    private readonly TextBox _name = new();
    private readonly ComboBox _category = new();
    private readonly TextBox _brand = new();
    private readonly TextBox _model = new();
    private readonly NumericUpDown _price = new();
    private readonly NumericUpDown _stock = new();
    private readonly TextBox _description = new();

    public Product Product { get; private set; }

    public ProductDialog(Product? product = null)
    {
        Product = product is null ? new Product() : new Product
        {
            Id = product.Id, Code = product.Code, Name = product.Name, Category = product.Category,
            Brand = product.Brand, Model = product.Model, Price = product.Price,
            Stock = product.Stock, Description = product.Description
        };

        Text = product is null ? "Nuevo producto" : "Editar producto";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(540, 550);
        BackColor = Color.White;
        Font = new Font("Segoe UI", 9.5F);

        BuildForm();
        FillForm();
    }

    private void BuildForm()
    {
        var title = new Label
        {
            Text = "Datos del producto", Font = new Font("Segoe UI Semibold", 16F),
            ForeColor = Color.FromArgb(25, 54, 72), AutoSize = true, Location = new Point(28, 22)
        };
        Controls.Add(title);

        var table = new TableLayoutPanel
        {
            Location = new Point(28, 68), Size = new Size(484, 390), ColumnCount = 2,
            RowCount = 8, Padding = new Padding(0),
        };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        for (var i = 0; i < 8; i++) table.RowStyles.Add(new RowStyle(SizeType.Absolute, i == 7 ? 92 : 43));

        _category.DropDownStyle = ComboBoxStyle.DropDownList;
        _category.Items.AddRange(["Armazones", "Lentes", "Gafas de sol", "Accesorios", "Otros"]);
        ConfigureNumeric(_price, 0, 1000000, 2);
        ConfigureNumeric(_stock, 0, 1000000, 0);
        _stock.ReadOnly = true;
        _stock.TabStop = false;
        _description.Multiline = true;
        _description.ScrollBars = ScrollBars.Vertical;
        _description.MaxLength = 500;

        AddRow(table, 0, "Código *", _code);
        AddRow(table, 1, "Nombre *", _name);
        AddRow(table, 2, "Categoría *", _category);
        AddRow(table, 3, "Marca", _brand);
        AddRow(table, 4, "Modelo", _model);
        AddRow(table, 5, "Precio (C$) *", _price);
        AddRow(table, 6, "Existencias (compras)", _stock);
        AddRow(table, 7, "Descripción", _description);
        Controls.Add(table);

        var hint = new Label
        {
            Text = "* Campos requeridos", AutoSize = true, ForeColor = Color.FromArgb(105, 120, 132),
            Location = new Point(30, 470)
        };
        Controls.Add(hint);

        var cancel = new Button
        {
            Text = "Cancelar", DialogResult = DialogResult.Cancel, Size = new Size(110, 38),
            Location = new Point(274, 495), FlatStyle = FlatStyle.Flat, BackColor = Color.White
        };
        cancel.FlatAppearance.BorderColor = Color.FromArgb(210, 219, 224);
        var save = new Button
        {
            Text = "Guardar", Size = new Size(120, 38), Location = new Point(392, 495),
            FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(0, 126, 142),
            ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 9.5F)
        };
        save.FlatAppearance.BorderSize = 0;
        save.Click += (_, _) => SaveProduct();
        Controls.Add(cancel);
        Controls.Add(save);
        AcceptButton = save;
        CancelButton = cancel;
        Theme.ApplyTo(this);
    }

    private static void ConfigureNumeric(NumericUpDown input, decimal max, decimal upper, int decimals)
    {
        input.Minimum = 0;
        input.Maximum = upper;
        input.DecimalPlaces = decimals;
        input.ThousandsSeparator = true;
        input.Dock = DockStyle.Fill;
        input.Font = new Font("Segoe UI", 9.5F);
    }

    private static void AddRow(TableLayoutPanel table, int row, string label, Control input)
    {
        var caption = new Label
        {
            Text = label, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.FromArgb(64, 79, 89)
        };
        input.Dock = DockStyle.Fill;
        if (input is TextBox or ComboBox)
        {
            input.Font = new Font("Segoe UI", 9.5F);
            if (input is TextBox textBox) textBox.MaxLength = 100;
        }
        table.Controls.Add(caption, 0, row);
        table.Controls.Add(input, 1, row);
    }

    private void FillForm()
    {
        _code.Text = Product.Code;
        _name.Text = Product.Name;
        var categoryIndex = _category.Items.IndexOf(Product.Category);
        if (categoryIndex >= 0) _category.SelectedIndex = categoryIndex;
        else if (!string.IsNullOrWhiteSpace(Product.Category))
        {
            _category.Items.Add(Product.Category);
            _category.SelectedItem = Product.Category;
        }
        else _category.SelectedIndex = 0;
        _brand.Text = Product.Brand;
        _model.Text = Product.Model;
        _price.Value = Math.Min(_price.Maximum, Product.Price);
        _stock.Value = Math.Min(_stock.Maximum, Product.Stock);
        _description.Text = Product.Description;
    }

    private void SaveProduct()
    {
        if (string.IsNullOrWhiteSpace(_code.Text) || string.IsNullOrWhiteSpace(_name.Text) || _category.SelectedItem is null)
        {
            MessageBox.Show("Completa el código, el nombre y la categoría.", "Faltan datos",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        Product.Code = _code.Text.Trim();
        Product.Name = _name.Text.Trim();
        Product.Category = _category.Text;
        Product.Brand = _brand.Text.Trim();
        Product.Model = _model.Text.Trim();
        Product.Price = _price.Value;
        Product.Stock = (int)_stock.Value;
        Product.Description = _description.Text.Trim();
        DialogResult = DialogResult.OK;
        Close();
    }
}
