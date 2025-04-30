
string path;
int banderaMensaje = 0;

do
{
    
    if (banderaMensaje == 0)
    {

        Console.Write("Ingrese el Directorio de la carpeta a la que desea acceder: ");
        path = Console.ReadLine();

    }
    else
    {

        Console.Write("Error, el directorio ingresado no existe, ingrese un directorio valido: ");
        path = Console.ReadLine();        

    }

    banderaMensaje = 1;

} while (!Directory.Exists(path));

string [] Carpetas = Directory.GetDirectories(path);
 
foreach (var DentroCarpetas in Carpetas)
{
    Console.WriteLine($" Nombre de Carpetas: {Path.GetFileName(DentroCarpetas)}");
}

