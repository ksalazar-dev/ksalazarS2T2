namespace ksalazarS2T2.Views;

public partial class login : ContentPage
{
    // Vectores de usuarios y contrase�as
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] contrase�as = { "carlos123", "ana123", "jose123" };

    public login()
	{
		InitializeComponent();
	}

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        string user = txtUsuario.Text?.Trim();
        string pass = txtPassword.Text?.Trim();

        // Validar que los campos no est�n vac�os
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            await DisplayAlert("Error", "Debe ingresar usuario y contrase�a", "Aceptar");
            return;
        }

        // Buscar usuario
        bool accesoPermitido = false;
        int indice = -1;

        for (int i = 0; i < usuarios.Length; i++)
        {
            if (user.Equals(usuarios[i], StringComparison.OrdinalIgnoreCase) && pass == contrase�as[i])
            {
                accesoPermitido = true;
                indice = i;
                break;
            }
        }

        if (accesoPermitido)
        {
            await DisplayAlert("Bienvenido", $"Hola {usuarios[indice]}, has iniciado sesi�n correctamente.", "Aceptar");

            // Ir a la ventana principal (ejemplo: sinicio)
            await Navigation.PushAsync(new sinicio());
        }
        else
        {
            await DisplayAlert("Acceso denegado", "Usuario o contrase�a incorrectos", "Reintentar");
        }
    }
}
