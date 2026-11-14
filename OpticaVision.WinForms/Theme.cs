namespace OpticaVision;

internal static class Theme
{
    public static readonly Color Navy = ColorTranslator.FromHtml("#163A5F");
    public static readonly Color Turquoise = ColorTranslator.FromHtml("#00A6A6");
    public static readonly Color LightBlue = ColorTranslator.FromHtml("#E8F4F8");
    public static readonly Color White = ColorTranslator.FromHtml("#FFFFFF");
    public static readonly Color Slate = ColorTranslator.FromHtml("#334155");
    private static readonly Color Border = ColorTranslator.FromHtml("#C9D8E2");
    private static readonly Color Danger = ColorTranslator.FromHtml("#B4232D");

    public static void ApplyTo(Form form)
    {
        form.BackColor = LightBlue;
        form.ForeColor = Slate;

        ApplyToControls(form.Controls);

        if (form.Controls.Find("tabControl", true).FirstOrDefault() is TabControl tabs)
        {
            tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabs.ItemSize = new Size(132, 38);
            tabs.SizeMode = TabSizeMode.Fixed;
            tabs.DrawItem -= DrawTab;
            tabs.DrawItem += DrawTab;
        }
    }

    private static void ApplyToControls(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            switch (control)
            {
                case DataGridView grid:
                    StyleGrid(grid);
                    break;
                case TabPage page:
                    page.BackColor = LightBlue;
                    page.ForeColor = Slate;
                    break;
                case Panel panel when panel.Name == "headerPanel":
                    panel.BackColor = Navy;
                    break;
                case Panel panel:
                    panel.BackColor = White;
                    break;
                case Button button:
                    StyleButton(button);
                    break;
                case TextBoxBase or ComboBox or NumericUpDown or DateTimePicker:
                    control.BackColor = White;
                    control.ForeColor = Slate;
                    break;
                case Label label when label.Name == "titleLabel":
                    label.ForeColor = White;
                    break;
                case Label label when label.Name == "subtitleLabel":
                    label.ForeColor = LightBlue;
                    break;
                case Label label:
                    label.ForeColor = Slate;
                    break;
                case TabControl tabs:
                    tabs.BackColor = LightBlue;
                    tabs.ForeColor = Slate;
                    break;
            }

            if (control.HasChildren)
                ApplyToControls(control.Controls);
        }
    }

    private static void StyleButton(Button button)
    {
        var key = $"{button.Name} {button.Text}".ToLowerInvariant();
        var primary = key.Contains("add") || key.Contains("nuevo") || key.Contains("guardar")
            || key.Contains("confirmar") || key.Contains("registrar");
        var danger = key.Contains("delete") || key.Contains("eliminar");

        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor = primary ? Turquoise : Border;
        button.FlatAppearance.MouseOverBackColor = primary ? Color.FromArgb(0, 135, 135) : LightBlue;
        button.FlatAppearance.MouseDownBackColor = primary ? Color.FromArgb(0, 125, 125) : Border;
        button.BackColor = primary ? Turquoise : White;
        button.ForeColor = primary ? White : danger ? Danger : Navy;
        button.Cursor = Cursors.Hand;
    }

    private static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = White;
        grid.BorderStyle = BorderStyle.None;
        grid.GridColor = Border;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Navy;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = White;
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Navy;
        grid.DefaultCellStyle.BackColor = White;
        grid.DefaultCellStyle.ForeColor = Slate;
        grid.DefaultCellStyle.SelectionBackColor = Turquoise;
        grid.DefaultCellStyle.SelectionForeColor = White;
        grid.AlternatingRowsDefaultCellStyle.BackColor = LightBlue;
        grid.RowHeadersVisible = false;
        grid.ColumnHeadersHeight = 38;
        grid.RowTemplate.Height = 32;
    }

    private static void DrawTab(object? sender, DrawItemEventArgs e)
    {
        if (sender is not TabControl tabs || e.Index < 0)
            return;

        var selected = e.Index == tabs.SelectedIndex;
        var background = selected ? Turquoise : Navy;
        var bounds = e.Bounds;
        using var brush = new SolidBrush(background);
        using var font = new Font(tabs.Font, FontStyle.Bold);
        e.Graphics.FillRectangle(brush, bounds);
        TextRenderer.DrawText(
            e.Graphics,
            tabs.TabPages[e.Index].Text,
            font,
            bounds,
            White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }
}
