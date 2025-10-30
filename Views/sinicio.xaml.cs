namespace ksalazarS2T2.Views;

public partial class sinicio : ContentPage
{
    public sinicio()
    {
        InitializeComponent();

    }

         // Permitir solo números y punto decimal
        private void SoloNumeros(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null)
            return;

        string textoFiltrado = new string(entry.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());
        if (entry.Text != textoFiltrado)
            entry.Text = textoFiltrado;
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        // Validaciones básicas
        if (pickerEstudiante.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtSeg1.Text) ||
            string.IsNullOrWhiteSpace(txtExa1.Text) ||
            string.IsNullOrWhiteSpace(txtSeg2.Text) ||
            string.IsNullOrWhiteSpace(txtExa2.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }

        // Convertir a double y validar rangos
        if (!double.TryParse(txtSeg1.Text, out double seg1) || seg1 < 0 || seg1 > 10 ||
            !double.TryParse(txtExa1.Text, out double exa1) || exa1 < 0 || exa1 > 10 ||
            !double.TryParse(txtSeg2.Text, out double seg2) || seg2 < 0 || seg2 > 10 ||
            !double.TryParse(txtExa2.Text, out double exa2) || exa2 < 0 || exa2 > 10)
        {
            DisplayAlert("Error", "Las notas deben estar entre 0 y 10.", "OK");
            return;
        }

        // Cálculos
        double parcial1 = (seg1 * 0.3) + (exa1 * 0.2);
        double parcial2 = (seg2 * 0.3) + (exa2 * 0.2);
        double notaFinal = parcial1 + parcial2;

        // Determinar estado
        string estado;
        if (notaFinal >= 7)
            estado = "APROBADO";
        else if (notaFinal >= 5)
            estado = "COMPLEMENTARIO";
        else
            estado = "REPROBADO";

        // Mostrar resultados
        DisplayAlert("Resultado",
            $"Nombre: {pickerEstudiante.SelectedItem}\n" +
            $"Fecha: {dateFecha.Date:dd/MM/yyyy}\n\n" +
            $"Nota Parcial 1: {parcial1:F2}\n" +
            $"Nota Parcial 2: {parcial2:F2}\n" +
            $"Nota Final: {notaFinal:F2}\n" +
            $"Estado: {estado}",
            "Cerrar");
    }
}
