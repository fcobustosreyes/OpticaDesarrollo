#nullable disable

namespace OpticaVision;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel headerPanel;
    private Label titleLabel;
    private Label subtitleLabel;
    private TabControl tabControl;
    private TabPage tabSummary;
    private TabPage tabAppointments;
    private TabPage tabSales;
    private TabPage tabPurchases;
    private TabPage tabInventory;
    private TabPage tabCustomers;
    private TabPage tabSuppliers;
    private Label summaryLabel;
    private Label appointmentsTitleLabel;
    private Label salesTitleLabel;
    private Label purchasesTitleLabel;
    private Label inventoryTitleLabel;
    private Label customersTitleLabel;
    private Label suppliersTitleLabel;
    private DataGridView appointmentsGrid;
    private DataGridView salesGrid;
    private DataGridView purchasesGrid;
    private DataGridView inventoryGrid;
    private DataGridView customersGrid;
    private DataGridView suppliersGrid;
    private Button appointmentAddButton;
    private Button appointmentEditButton;
    private Button appointmentDeleteButton;
    private Button saleAddButton;
    private Button saleDeleteButton;
    private Button purchaseAddButton;
    private Button purchaseDeleteButton;
    private Button productAddButton;
    private Button productEditButton;
    private Button productDeleteButton;
    private Button customerAddButton;
    private Button customerEditButton;
    private Button customerDeleteButton;
    private Button supplierAddButton;
    private Button supplierEditButton;
    private Button supplierDeleteButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        headerPanel = new Panel();
        titleLabel = new Label();
        subtitleLabel = new Label();
        tabControl = new TabControl();
        tabSummary = new TabPage();
        summaryLabel = new Label();
        tabAppointments = new TabPage();
        appointmentsTitleLabel = new Label();
        appointmentAddButton = new Button();
        appointmentEditButton = new Button();
        appointmentDeleteButton = new Button();
        appointmentsGrid = new DataGridView();
        tabSales = new TabPage();
        salesTitleLabel = new Label();
        saleAddButton = new Button();
        saleDeleteButton = new Button();
        salesGrid = new DataGridView();
        tabPurchases = new TabPage();
        purchasesTitleLabel = new Label();
        purchaseAddButton = new Button();
        purchaseDeleteButton = new Button();
        purchasesGrid = new DataGridView();
        tabInventory = new TabPage();
        inventoryTitleLabel = new Label();
        productAddButton = new Button();
        productEditButton = new Button();
        productDeleteButton = new Button();
        inventoryGrid = new DataGridView();
        tabCustomers = new TabPage();
        customersTitleLabel = new Label();
        customerAddButton = new Button();
        customerEditButton = new Button();
        customerDeleteButton = new Button();
        customersGrid = new DataGridView();
        tabSuppliers = new TabPage();
        suppliersTitleLabel = new Label();
        supplierAddButton = new Button();
        supplierEditButton = new Button();
        supplierDeleteButton = new Button();
        suppliersGrid = new DataGridView();
        headerPanel.SuspendLayout();
        tabControl.SuspendLayout();
        tabSummary.SuspendLayout();
        tabAppointments.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)appointmentsGrid).BeginInit();
        tabSales.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)salesGrid).BeginInit();
        tabPurchases.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)purchasesGrid).BeginInit();
        tabInventory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryGrid).BeginInit();
        tabCustomers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)customersGrid).BeginInit();
        tabSuppliers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)suppliersGrid).BeginInit();
        SuspendLayout();
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.White;
        headerPanel.Controls.Add(titleLabel);
        headerPanel.Controls.Add(subtitleLabel);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1280, 92);
        headerPanel.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI Semibold", 21F);
        titleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        titleLabel.Location = new Point(32, -2);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(321, 57);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "ÓPTICA VISIÓN";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.Font = new Font("Segoe UI", 10F);
        subtitleLabel.ForeColor = Color.FromArgb(105, 120, 132);
        subtitleLabel.Location = new Point(31, 55);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(407, 28);
        subtitleLabel.TabIndex = 1;
        subtitleLabel.Text = "Gestión de citas, compras, ventas e inventario";
        // 
        // tabControl
        // 
        tabControl.Controls.Add(tabSummary);
        tabControl.Controls.Add(tabAppointments);
        tabControl.Controls.Add(tabSales);
        tabControl.Controls.Add(tabPurchases);
        tabControl.Controls.Add(tabInventory);
        tabControl.Controls.Add(tabCustomers);
        tabControl.Controls.Add(tabSuppliers);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Font = new Font("Segoe UI Semibold", 9.5F);
        tabControl.Location = new Point(0, 92);
        tabControl.Name = "tabControl";
        tabControl.Padding = new Point(18, 8);
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1280, 688);
        tabControl.TabIndex = 1;
        // 
        // tabSummary
        // 
        tabSummary.BackColor = Color.FromArgb(246, 249, 250);
        tabSummary.Controls.Add(summaryLabel);
        tabSummary.Location = new Point(4, 44);
        tabSummary.Name = "tabSummary";
        tabSummary.Padding = new Padding(14);
        tabSummary.Size = new Size(1272, 640);
        tabSummary.TabIndex = 0;
        tabSummary.Text = "Resumen";
        // 
        // summaryLabel
        // 
        summaryLabel.Font = new Font("Segoe UI", 12F);
        summaryLabel.ForeColor = Color.FromArgb(43, 57, 67);
        summaryLabel.Location = new Point(28, 30);
        summaryLabel.Name = "summaryLabel";
        summaryLabel.Size = new Size(1100, 290);
        summaryLabel.TabIndex = 0;
        summaryLabel.Text = "Resumen del negocio";
        // 
        // tabAppointments
        // 
        tabAppointments.BackColor = Color.White;
        tabAppointments.Controls.Add(appointmentsTitleLabel);
        tabAppointments.Controls.Add(appointmentAddButton);
        tabAppointments.Controls.Add(appointmentEditButton);
        tabAppointments.Controls.Add(appointmentDeleteButton);
        tabAppointments.Controls.Add(appointmentsGrid);
        tabAppointments.Location = new Point(4, 44);
        tabAppointments.Name = "tabAppointments";
        tabAppointments.Padding = new Padding(14);
        tabAppointments.Size = new Size(1272, 640);
        tabAppointments.TabIndex = 1;
        tabAppointments.Text = "Citas";
        // 
        // appointmentsTitleLabel
        // 
        appointmentsTitleLabel.AutoSize = true;
        appointmentsTitleLabel.Font = new Font("Segoe UI Semibold", 16F);
        appointmentsTitleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        appointmentsTitleLabel.Location = new Point(18, 16);
        appointmentsTitleLabel.Name = "appointmentsTitleLabel";
        appointmentsTitleLabel.Size = new Size(252, 45);
        appointmentsTitleLabel.TabIndex = 0;
        appointmentsTitleLabel.Text = "Agenda de citas";
        // 
        // appointmentAddButton
        // 
        appointmentAddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        appointmentAddButton.BackColor = Color.FromArgb(0, 126, 142);
        appointmentAddButton.FlatAppearance.BorderSize = 0;
        appointmentAddButton.FlatStyle = FlatStyle.Flat;
        appointmentAddButton.ForeColor = Color.White;
        appointmentAddButton.Location = new Point(1075, 14);
        appointmentAddButton.Name = "appointmentAddButton";
        appointmentAddButton.Size = new Size(155, 36);
        appointmentAddButton.TabIndex = 1;
        appointmentAddButton.Text = "Nueva cita";
        appointmentAddButton.UseVisualStyleBackColor = false;
        // 
        // appointmentEditButton
        // 
        appointmentEditButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        appointmentEditButton.Location = new Point(975, 14);
        appointmentEditButton.Name = "appointmentEditButton";
        appointmentEditButton.Size = new Size(92, 36);
        appointmentEditButton.TabIndex = 2;
        appointmentEditButton.Text = "Editar";
        // 
        // appointmentDeleteButton
        // 
        appointmentDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        appointmentDeleteButton.ForeColor = Color.FromArgb(174, 54, 59);
        appointmentDeleteButton.Location = new Point(870, 14);
        appointmentDeleteButton.Name = "appointmentDeleteButton";
        appointmentDeleteButton.Size = new Size(96, 36);
        appointmentDeleteButton.TabIndex = 3;
        appointmentDeleteButton.Text = "Eliminar";
        // 
        // appointmentsGrid
        // 
        appointmentsGrid.AllowUserToAddRows = false;
        appointmentsGrid.AllowUserToDeleteRows = false;
        appointmentsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        appointmentsGrid.BackgroundColor = Color.White;
        appointmentsGrid.ColumnHeadersHeight = 42;
        appointmentsGrid.Location = new Point(18, 62);
        appointmentsGrid.MultiSelect = false;
        appointmentsGrid.Name = "appointmentsGrid";
        appointmentsGrid.ReadOnly = true;
        appointmentsGrid.RowHeadersVisible = false;
        appointmentsGrid.RowHeadersWidth = 62;
        appointmentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        appointmentsGrid.Size = new Size(1230, 554);
        appointmentsGrid.TabIndex = 4;
        // 
        // tabSales
        // 
        tabSales.BackColor = Color.White;
        tabSales.Controls.Add(salesTitleLabel);
        tabSales.Controls.Add(saleAddButton);
        tabSales.Controls.Add(saleDeleteButton);
        tabSales.Controls.Add(salesGrid);
        tabSales.Location = new Point(4, 44);
        tabSales.Name = "tabSales";
        tabSales.Padding = new Padding(14);
        tabSales.Size = new Size(1272, 640);
        tabSales.TabIndex = 2;
        tabSales.Text = "Ventas";
        // 
        // salesTitleLabel
        // 
        salesTitleLabel.AutoSize = true;
        salesTitleLabel.Font = new Font("Segoe UI Semibold", 16F);
        salesTitleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        salesTitleLabel.Location = new Point(18, 16);
        salesTitleLabel.Name = "salesTitleLabel";
        salesTitleLabel.Size = new Size(289, 45);
        salesTitleLabel.TabIndex = 0;
        salesTitleLabel.Text = "Registro de ventas";
        // 
        // saleAddButton
        // 
        saleAddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        saleAddButton.BackColor = Color.FromArgb(0, 126, 142);
        saleAddButton.FlatAppearance.BorderSize = 0;
        saleAddButton.FlatStyle = FlatStyle.Flat;
        saleAddButton.ForeColor = Color.White;
        saleAddButton.Location = new Point(1085, 14);
        saleAddButton.Name = "saleAddButton";
        saleAddButton.Size = new Size(145, 36);
        saleAddButton.TabIndex = 1;
        saleAddButton.Text = "Registrar venta";
        saleAddButton.UseVisualStyleBackColor = false;
        // 
        // saleDeleteButton
        // 
        saleDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        saleDeleteButton.ForeColor = Color.FromArgb(174, 54, 59);
        saleDeleteButton.Location = new Point(980, 14);
        saleDeleteButton.Name = "saleDeleteButton";
        saleDeleteButton.Size = new Size(96, 36);
        saleDeleteButton.TabIndex = 2;
        saleDeleteButton.Text = "Eliminar";
        // 
        // salesGrid
        // 
        salesGrid.AllowUserToAddRows = false;
        salesGrid.AllowUserToDeleteRows = false;
        salesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        salesGrid.BackgroundColor = Color.White;
        salesGrid.ColumnHeadersHeight = 42;
        salesGrid.Location = new Point(18, 62);
        salesGrid.MultiSelect = false;
        salesGrid.Name = "salesGrid";
        salesGrid.ReadOnly = true;
        salesGrid.RowHeadersVisible = false;
        salesGrid.RowHeadersWidth = 62;
        salesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        salesGrid.Size = new Size(1230, 554);
        salesGrid.TabIndex = 3;
        // 
        // tabPurchases
        // 
        tabPurchases.BackColor = Color.White;
        tabPurchases.Controls.Add(purchasesTitleLabel);
        tabPurchases.Controls.Add(purchaseAddButton);
        tabPurchases.Controls.Add(purchaseDeleteButton);
        tabPurchases.Controls.Add(purchasesGrid);
        tabPurchases.Location = new Point(4, 44);
        tabPurchases.Name = "tabPurchases";
        tabPurchases.Padding = new Padding(14);
        tabPurchases.Size = new Size(1272, 640);
        tabPurchases.TabIndex = 3;
        tabPurchases.Text = "Compras";
        // 
        // purchasesTitleLabel
        // 
        purchasesTitleLabel.AutoSize = true;
        purchasesTitleLabel.Font = new Font("Segoe UI Semibold", 16F);
        purchasesTitleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        purchasesTitleLabel.Location = new Point(18, 16);
        purchasesTitleLabel.Name = "purchasesTitleLabel";
        purchasesTitleLabel.Size = new Size(318, 45);
        purchasesTitleLabel.TabIndex = 0;
        purchasesTitleLabel.Text = "Registro de compras";
        // 
        // purchaseAddButton
        // 
        purchaseAddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        purchaseAddButton.BackColor = Color.FromArgb(0, 126, 142);
        purchaseAddButton.FlatAppearance.BorderSize = 0;
        purchaseAddButton.FlatStyle = FlatStyle.Flat;
        purchaseAddButton.ForeColor = Color.White;
        purchaseAddButton.Location = new Point(1075, 14);
        purchaseAddButton.Name = "purchaseAddButton";
        purchaseAddButton.Size = new Size(155, 36);
        purchaseAddButton.TabIndex = 1;
        purchaseAddButton.Text = "Registrar compra";
        purchaseAddButton.UseVisualStyleBackColor = false;
        // 
        // purchaseDeleteButton
        // 
        purchaseDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        purchaseDeleteButton.ForeColor = Color.FromArgb(174, 54, 59);
        purchaseDeleteButton.Location = new Point(970, 14);
        purchaseDeleteButton.Name = "purchaseDeleteButton";
        purchaseDeleteButton.Size = new Size(96, 36);
        purchaseDeleteButton.TabIndex = 2;
        purchaseDeleteButton.Text = "Eliminar";
        // 
        // purchasesGrid
        // 
        purchasesGrid.AllowUserToAddRows = false;
        purchasesGrid.AllowUserToDeleteRows = false;
        purchasesGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        purchasesGrid.BackgroundColor = Color.White;
        purchasesGrid.ColumnHeadersHeight = 42;
        purchasesGrid.Location = new Point(18, 62);
        purchasesGrid.MultiSelect = false;
        purchasesGrid.Name = "purchasesGrid";
        purchasesGrid.ReadOnly = true;
        purchasesGrid.RowHeadersVisible = false;
        purchasesGrid.RowHeadersWidth = 62;
        purchasesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        purchasesGrid.Size = new Size(1230, 554);
        purchasesGrid.TabIndex = 3;
        // 
        // tabInventory
        // 
        tabInventory.BackColor = Color.White;
        tabInventory.Controls.Add(inventoryTitleLabel);
        tabInventory.Controls.Add(productAddButton);
        tabInventory.Controls.Add(productEditButton);
        tabInventory.Controls.Add(productDeleteButton);
        tabInventory.Controls.Add(inventoryGrid);
        tabInventory.Location = new Point(4, 44);
        tabInventory.Name = "tabInventory";
        tabInventory.Padding = new Padding(14);
        tabInventory.Size = new Size(1272, 640);
        tabInventory.TabIndex = 4;
        tabInventory.Text = "Inventario";
        // 
        // inventoryTitleLabel
        // 
        inventoryTitleLabel.AutoSize = true;
        inventoryTitleLabel.Font = new Font("Segoe UI Semibold", 16F);
        inventoryTitleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        inventoryTitleLabel.Location = new Point(18, 16);
        inventoryTitleLabel.Name = "inventoryTitleLabel";
        inventoryTitleLabel.Size = new Size(350, 45);
        inventoryTitleLabel.TabIndex = 0;
        inventoryTitleLabel.Text = "Productos e inventario";
        // 
        // productAddButton
        // 
        productAddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        productAddButton.BackColor = Color.FromArgb(0, 126, 142);
        productAddButton.FlatAppearance.BorderSize = 0;
        productAddButton.FlatStyle = FlatStyle.Flat;
        productAddButton.ForeColor = Color.White;
        productAddButton.Location = new Point(1075, 14);
        productAddButton.Name = "productAddButton";
        productAddButton.Size = new Size(155, 36);
        productAddButton.TabIndex = 1;
        productAddButton.Text = "Nuevo producto";
        productAddButton.UseVisualStyleBackColor = false;
        // 
        // productEditButton
        // 
        productEditButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        productEditButton.Location = new Point(975, 14);
        productEditButton.Name = "productEditButton";
        productEditButton.Size = new Size(92, 36);
        productEditButton.TabIndex = 2;
        productEditButton.Text = "Editar";
        // 
        // productDeleteButton
        // 
        productDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        productDeleteButton.ForeColor = Color.FromArgb(174, 54, 59);
        productDeleteButton.Location = new Point(870, 14);
        productDeleteButton.Name = "productDeleteButton";
        productDeleteButton.Size = new Size(96, 36);
        productDeleteButton.TabIndex = 3;
        productDeleteButton.Text = "Eliminar";
        // 
        // inventoryGrid
        // 
        inventoryGrid.AllowUserToAddRows = false;
        inventoryGrid.AllowUserToDeleteRows = false;
        inventoryGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        inventoryGrid.BackgroundColor = Color.White;
        inventoryGrid.ColumnHeadersHeight = 42;
        inventoryGrid.Location = new Point(18, 62);
        inventoryGrid.MultiSelect = false;
        inventoryGrid.Name = "inventoryGrid";
        inventoryGrid.ReadOnly = true;
        inventoryGrid.RowHeadersVisible = false;
        inventoryGrid.RowHeadersWidth = 62;
        inventoryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        inventoryGrid.Size = new Size(1230, 554);
        inventoryGrid.TabIndex = 4;
        // 
        // tabCustomers
        // 
        tabCustomers.BackColor = Color.White;
        tabCustomers.Controls.Add(customersTitleLabel);
        tabCustomers.Controls.Add(customerAddButton);
        tabCustomers.Controls.Add(customerEditButton);
        tabCustomers.Controls.Add(customerDeleteButton);
        tabCustomers.Controls.Add(customersGrid);
        tabCustomers.Location = new Point(4, 44);
        tabCustomers.Name = "tabCustomers";
        tabCustomers.Padding = new Padding(14);
        tabCustomers.Size = new Size(1272, 640);
        tabCustomers.TabIndex = 5;
        tabCustomers.Text = "Clientes";
        // 
        // customersTitleLabel
        // 
        customersTitleLabel.AutoSize = true;
        customersTitleLabel.Font = new Font("Segoe UI Semibold", 16F);
        customersTitleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        customersTitleLabel.Location = new Point(18, 16);
        customersTitleLabel.Name = "customersTitleLabel";
        customersTitleLabel.Size = new Size(329, 45);
        customersTitleLabel.TabIndex = 0;
        customersTitleLabel.Text = "Directorio de clientes";
        // 
        // customerAddButton
        // 
        customerAddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        customerAddButton.BackColor = Color.FromArgb(0, 126, 142);
        customerAddButton.FlatAppearance.BorderSize = 0;
        customerAddButton.FlatStyle = FlatStyle.Flat;
        customerAddButton.ForeColor = Color.White;
        customerAddButton.Location = new Point(1075, 14);
        customerAddButton.Name = "customerAddButton";
        customerAddButton.Size = new Size(155, 36);
        customerAddButton.TabIndex = 1;
        customerAddButton.Text = "Nuevo cliente";
        customerAddButton.UseVisualStyleBackColor = false;
        // 
        // customerEditButton
        // 
        customerEditButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        customerEditButton.Location = new Point(975, 14);
        customerEditButton.Name = "customerEditButton";
        customerEditButton.Size = new Size(92, 36);
        customerEditButton.TabIndex = 2;
        customerEditButton.Text = "Editar";
        // 
        // customerDeleteButton
        // 
        customerDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        customerDeleteButton.ForeColor = Color.FromArgb(174, 54, 59);
        customerDeleteButton.Location = new Point(870, 14);
        customerDeleteButton.Name = "customerDeleteButton";
        customerDeleteButton.Size = new Size(96, 36);
        customerDeleteButton.TabIndex = 3;
        customerDeleteButton.Text = "Eliminar";
        // 
        // customersGrid
        // 
        customersGrid.AllowUserToAddRows = false;
        customersGrid.AllowUserToDeleteRows = false;
        customersGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        customersGrid.BackgroundColor = Color.White;
        customersGrid.ColumnHeadersHeight = 42;
        customersGrid.Location = new Point(18, 62);
        customersGrid.MultiSelect = false;
        customersGrid.Name = "customersGrid";
        customersGrid.ReadOnly = true;
        customersGrid.RowHeadersVisible = false;
        customersGrid.RowHeadersWidth = 62;
        customersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        customersGrid.Size = new Size(1230, 554);
        customersGrid.TabIndex = 4;
        // 
        // tabSuppliers
        // 
        tabSuppliers.BackColor = Color.White;
        tabSuppliers.Controls.Add(suppliersTitleLabel);
        tabSuppliers.Controls.Add(supplierAddButton);
        tabSuppliers.Controls.Add(supplierEditButton);
        tabSuppliers.Controls.Add(supplierDeleteButton);
        tabSuppliers.Controls.Add(suppliersGrid);
        tabSuppliers.Location = new Point(4, 44);
        tabSuppliers.Name = "tabSuppliers";
        tabSuppliers.Padding = new Padding(14);
        tabSuppliers.Size = new Size(1272, 640);
        tabSuppliers.TabIndex = 6;
        tabSuppliers.Text = "Proveedores";
        // 
        // suppliersTitleLabel
        // 
        suppliersTitleLabel.AutoSize = true;
        suppliersTitleLabel.Font = new Font("Segoe UI Semibold", 16F);
        suppliersTitleLabel.ForeColor = Color.FromArgb(25, 54, 72);
        suppliersTitleLabel.Location = new Point(18, 16);
        suppliersTitleLabel.Name = "suppliersTitleLabel";
        suppliersTitleLabel.Size = new Size(400, 45);
        suppliersTitleLabel.TabIndex = 0;
        suppliersTitleLabel.Text = "Directorio de proveedores";
        // 
        // supplierAddButton
        // 
        supplierAddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        supplierAddButton.BackColor = Color.FromArgb(0, 126, 142);
        supplierAddButton.FlatAppearance.BorderSize = 0;
        supplierAddButton.FlatStyle = FlatStyle.Flat;
        supplierAddButton.ForeColor = Color.White;
        supplierAddButton.Location = new Point(1075, 14);
        supplierAddButton.Name = "supplierAddButton";
        supplierAddButton.Size = new Size(155, 36);
        supplierAddButton.TabIndex = 1;
        supplierAddButton.Text = "Nuevo proveedor";
        supplierAddButton.UseVisualStyleBackColor = false;
        // 
        // supplierEditButton
        // 
        supplierEditButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        supplierEditButton.Location = new Point(975, 14);
        supplierEditButton.Name = "supplierEditButton";
        supplierEditButton.Size = new Size(92, 36);
        supplierEditButton.TabIndex = 2;
        supplierEditButton.Text = "Editar";
        // 
        // supplierDeleteButton
        // 
        supplierDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        supplierDeleteButton.ForeColor = Color.FromArgb(174, 54, 59);
        supplierDeleteButton.Location = new Point(870, 14);
        supplierDeleteButton.Name = "supplierDeleteButton";
        supplierDeleteButton.Size = new Size(96, 36);
        supplierDeleteButton.TabIndex = 3;
        supplierDeleteButton.Text = "Eliminar";
        // 
        // suppliersGrid
        // 
        suppliersGrid.AllowUserToAddRows = false;
        suppliersGrid.AllowUserToDeleteRows = false;
        suppliersGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        suppliersGrid.BackgroundColor = Color.White;
        suppliersGrid.ColumnHeadersHeight = 42;
        suppliersGrid.Location = new Point(18, 62);
        suppliersGrid.MultiSelect = false;
        suppliersGrid.Name = "suppliersGrid";
        suppliersGrid.ReadOnly = true;
        suppliersGrid.RowHeadersVisible = false;
        suppliersGrid.RowHeadersWidth = 62;
        suppliersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        suppliersGrid.Size = new Size(1230, 554);
        suppliersGrid.TabIndex = 4;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(11F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(246, 249, 250);
        ClientSize = new Size(1280, 780);
        Controls.Add(tabControl);
        Controls.Add(headerPanel);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(1050, 680);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Óptica Visión | Gestión";
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        tabControl.ResumeLayout(false);
        tabSummary.ResumeLayout(false);
        tabAppointments.ResumeLayout(false);
        tabAppointments.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)appointmentsGrid).EndInit();
        tabSales.ResumeLayout(false);
        tabSales.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)salesGrid).EndInit();
        tabPurchases.ResumeLayout(false);
        tabPurchases.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)purchasesGrid).EndInit();
        tabInventory.ResumeLayout(false);
        tabInventory.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)inventoryGrid).EndInit();
        tabCustomers.ResumeLayout(false);
        tabCustomers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)customersGrid).EndInit();
        tabSuppliers.ResumeLayout(false);
        tabSuppliers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)suppliersGrid).EndInit();
        ResumeLayout(false);
    }
}
