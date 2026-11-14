namespace OpticaVision;

public sealed class PersonDialog : Form
{
    private readonly TextBox _name = new();
    private readonly TextBox _phone = new();
    private readonly TextBox _email = new();

    public string PersonName => _name.Text.Trim();
    public string Phone => _phone.Text.Trim();
    public string Email => _email.Text.Trim();

    public PersonDialog(string title, string name = "", string phone = "", string email = "")
    {
        Text = title;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(440, 265);
        Font = new Font("Segoe UI", 9.5F);

        AddField("Nombre *", _name, 22);
        AddField("Teléfono", _phone, 78);
        AddField("Correo electrónico", _email, 134);
        _name.Text = name;
        _phone.Text = phone;
        _email.Text = email;

        var cancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(200, 205), Size = new Size(100, 36) };
        var save = new Button { Text = "Guardar", Location = new Point(308, 205), Size = new Size(105, 36), BackColor = Color.FromArgb(0, 126, 142), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
        save.FlatAppearance.BorderSize = 0;
        save.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(_name.Text))
            {
                MessageBox.Show("Escribe el nombre.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        };
        Controls.Add(cancel);
        Controls.Add(save);
        AcceptButton = save;
        CancelButton = cancel;
        Theme.ApplyTo(this);
    }

    private void AddField(string caption, Control input, int top)
    {
        Controls.Add(new Label { Text = caption, Location = new Point(24, top), Size = new Size(150, 28), TextAlign = ContentAlignment.MiddleLeft });
        input.Location = new Point(174, top);
        input.Size = new Size(238, 30);
        input.Font = Font;
        Controls.Add(input);
    }
}

public sealed class AppointmentDialog : Form
{
    private readonly TextBox _customer = new();
    private readonly DateTimePicker _date = new();
    private readonly ComboBox _service = new();
    private readonly ComboBox _status = new();
    private readonly TextBox _notes = new();

    public string CustomerName => _customer.Text.Trim();
    public DateTime AppointmentDate => _date.Value;
    public string Service => _service.Text;
    public string Status => _status.Text;
    public string Notes => _notes.Text.Trim();

    public AppointmentDialog(Appointment? appointment = null)
    {
        Text = appointment is null ? "Programar cita" : "Editar cita";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(500, 395);
        Font = new Font("Segoe UI", 9.5F);
        _date.Format = DateTimePickerFormat.Custom;
        _date.CustomFormat = "dd/MM/yyyy HH:mm";
        _date.ShowUpDown = true;
        _service.DropDownStyle = ComboBoxStyle.DropDownList;
        _service.Items.AddRange(["Examen visual", "Control", "Entrega de lentes", "Asesoría", "Otro"]);
        _status.DropDownStyle = ComboBoxStyle.DropDownList;
        _status.Items.AddRange(["Pendiente", "Confirmada", "Completada", "Cancelada"]);
        _notes.Multiline = true;
        _notes.ScrollBars = ScrollBars.Vertical;

        AddField("Cliente *", _customer, 22, 36);
        AddField("Fecha y hora *", _date, 72, 36);
        AddField("Tipo de cita", _service, 122, 36);
        AddField("Estado", _status, 172, 36);
        AddField("Notas", _notes, 222, 92);

        if (appointment is not null)
        {
            _customer.Text = appointment.CustomerName;
            _date.Value = appointment.Date < _date.MinDate ? DateTime.Now : appointment.Date;
            if (_service.Items.Contains(appointment.Service)) _service.SelectedItem = appointment.Service;
            if (_status.Items.Contains(appointment.Status)) _status.SelectedItem = appointment.Status;
            _notes.Text = appointment.Notes;
        }
        else
        {
            _service.SelectedIndex = 0;
            _status.SelectedIndex = 0;
        }

        var cancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(256, 338), Size = new Size(100, 36) };
        var save = new Button { Text = "Guardar cita", Location = new Point(364, 338), Size = new Size(112, 36), BackColor = Color.FromArgb(0, 126, 142), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
        save.FlatAppearance.BorderSize = 0;
        save.Click += (_, _) =>
        {
            if (string.IsNullOrWhiteSpace(_customer.Text))
            {
                MessageBox.Show("Escribe el nombre del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        };
        Controls.Add(cancel);
        Controls.Add(save);
        AcceptButton = save;
        CancelButton = cancel;
        Theme.ApplyTo(this);
    }

    private void AddField(string caption, Control input, int top, int height)
    {
        Controls.Add(new Label { Text = caption, Location = new Point(24, top), Size = new Size(130, 30), TextAlign = ContentAlignment.MiddleLeft });
        input.Location = new Point(160, top);
        input.Size = new Size(316, height);
        input.Font = Font;
        Controls.Add(input);
    }
}

public sealed class TransactionDialog : Form
{
    private readonly bool _isSale;
    private readonly ComboBox _counterparty = new();
    private readonly ComboBox _product = new();
    private readonly NumericUpDown _quantity = new();
    private readonly NumericUpDown _unitPrice = new();
    private readonly ComboBox _payment = new();
    private readonly Label _total = new();

    public Product SelectedProduct => (Product)_product.SelectedItem!;
    public string CounterpartyName => _counterparty.Text;
    public int Quantity => (int)_quantity.Value;
    public decimal UnitPrice => _unitPrice.Value;
    public string PaymentMethod => _payment.Text;
    public decimal Total => Quantity * UnitPrice;

    public TransactionDialog(bool isSale, IEnumerable<Product> products, IEnumerable<Customer> customers, IEnumerable<Supplier> suppliers)
    {
        _isSale = isSale;
        Text = isSale ? "Registrar venta" : "Registrar compra";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(500, 370);
        Font = new Font("Segoe UI", 9.5F);

        if (isSale)
        {
            _counterparty.DropDownStyle = ComboBoxStyle.DropDown;
        }
        else
        {
            _counterparty.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        _counterparty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        _counterparty.AutoCompleteSource = AutoCompleteSource.ListItems;
        _counterparty.Items.AddRange((isSale ? customers.Cast<object>() : suppliers.Cast<object>()).ToArray());
        _product.DropDownStyle = ComboBoxStyle.DropDownList;
        _product.Items.AddRange(products.Cast<object>().ToArray());
        _quantity.Minimum = 1;
        _quantity.Maximum = 100000;
        _quantity.Value = 1;
        _unitPrice.Minimum = 0;
        _unitPrice.Maximum = 1000000;
        _unitPrice.DecimalPlaces = 2;
        _unitPrice.ThousandsSeparator = true;
        _unitPrice.ReadOnly = isSale;
        _payment.DropDownStyle = ComboBoxStyle.DropDownList;
        _payment.Items.AddRange(["Efectivo", "Tarjeta", "Transferencia"]);
        _payment.SelectedIndex = 0;
        _total.Font = new Font("Segoe UI Semibold", 15F);
        _total.ForeColor = Color.FromArgb(25, 54, 72);

        AddField(isSale ? "Cliente" : "Proveedor", _counterparty, 22);
        AddField("Producto *", _product, 72);
        AddField("Cantidad", _quantity, 122);
        AddField(isSale ? "Precio unitario" : "Costo unitario", _unitPrice, 172);
        if (isSale) AddField("Forma de pago", _payment, 222);
        var totalTop = isSale ? 275 : 230;
        Controls.Add(new Label { Text = "Total", Location = new Point(26, totalTop), Size = new Size(120, 32), TextAlign = ContentAlignment.MiddleLeft });
        _total.Location = new Point(160, totalTop);
        _total.Size = new Size(300, 34);
        Controls.Add(_total);

        _product.SelectedIndexChanged += (_, _) =>
        {
            if (_product.SelectedItem is Product item && isSale) _unitPrice.Value = Math.Min(_unitPrice.Maximum, item.Price);
            UpdateTotal();
        };
        _quantity.ValueChanged += (_, _) => UpdateTotal();
        _unitPrice.ValueChanged += (_, _) => UpdateTotal();
        if (_product.Items.Count > 0) _product.SelectedIndex = 0;

        var cancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Location = new Point(260, 322), Size = new Size(100, 36) };
        var save = new Button { Text = isSale ? "Confirmar venta" : "Registrar compra", Location = new Point(368, 322), Size = new Size(108, 36), BackColor = Color.FromArgb(0, 126, 142), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
        save.FlatAppearance.BorderSize = 0;
        save.Click += (_, _) =>
        {
            if (_product.SelectedItem is null || string.IsNullOrWhiteSpace(_counterparty.Text))
            {
                MessageBox.Show("Selecciona un producto y completa el cliente o proveedor.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_unitPrice.Value <= 0)
            {
                MessageBox.Show("El precio o costo debe ser mayor que cero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        };
        Controls.Add(cancel);
        Controls.Add(save);
        AcceptButton = save;
        CancelButton = cancel;
        Theme.ApplyTo(this);
    }

    private void AddField(string caption, Control input, int top)
    {
        Controls.Add(new Label { Text = caption, Location = new Point(24, top), Size = new Size(130, 34), TextAlign = ContentAlignment.MiddleLeft });
        input.Location = new Point(160, top);
        input.Size = new Size(316, 34);
        input.Font = Font;
        Controls.Add(input);
    }

    private void UpdateTotal() => _total.Text = $"C$ {Total:N2}";
}
