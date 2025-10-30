namespace ksalazarS2T2.Views;

public partial class login : ContentPage
{
    // Vectores de usuarios y contraseñas
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] contraseñas = { "carlos123", "ana123", "jose123" };

    public login()
	{
		InitializeComponent();
	}

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        string user = txtUsuario.Text?.Trim();
        string pass = txtPassword.Text?.Trim();

        // Validar que los campos no estén vacíos
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            await DisplayAlert("Error", "Debe ingresar usuario y contraseña", "Aceptar");
            return;
        }

        // Buscar usuario
        bool accesoPermitido = false;
        int indice = -1;

        for (int i = 0; i < usuarios.Length; i++)
        {
            if (user.Equals(usuarios[i], StringComparison.OrdinalIgnoreCase) && pass == contraseñas[i])
            {
                accesoPermitido = true;
                indice = i;
                break;
            }
        }

        if (accesoPermitido)
        {
            await DisplayAlert("Bienvenido", $"Hola {usuarios[indice]}, has iniciado sesión correctamente.", "Aceptar");

            // Ir a la ventana principal (ejemplo: sinicio)
            await Navigation.PushAsync(new sinicio());
        }
        else
        {
            await DisplayAlert("Acceso denegado", "Usuario o contraseña incorrectos", "Reintentar");
        }
    }
}
