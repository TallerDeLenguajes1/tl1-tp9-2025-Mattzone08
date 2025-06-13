using System.Text;

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

string [] Carpetas = Directory.GetDirectories(path); // Directory.GetDirectories(path) obtiene todas las carpetas dentro de la rutaArgumento en este caso la variable path y las guarda en un arreglo string
string[] Archivos = Directory.GetFiles(path); // Directory.GetDirectories(path) obtiene todas los archivos dentro de la rutaArgumento en este caso la variable path y las guarda en un arreglo string

foreach (var DentroCarpetas in Carpetas)
{
    Console.WriteLine($" Nombre de Carpetas: {Path.GetFileName(DentroCarpetas)}"); // Path.GetFilesName() Muestra solo el nombre de la carpeta/archivo, no el path completo

}
    
foreach (var Archivitos in Archivos)
{
    FileInfo info = new FileInfo(Archivitos);
    double peso = info.Length / 1024.0;
    Console.WriteLine($" Nombre del Archivo: {Path.GetFileName(Archivitos)} Peso en KB: {peso:F2}" );
}

//finaliza la lectura, Hora de .....*redoble de tambores*.....La Escritura :)

string RutaCsv = Path.Combine(path, "reporte_archivos.csv");

using (StreamWriter escribir = new StreamWriter(RutaCsv, false, new UTF8Encoding(true))) // lo del utf es para que sea lejible en el EXCEL
{
    escribir.WriteLine("Nombre del Archivo;Tamaño (KB);Fecha de Última Modificación");

    foreach (var Archivitos in Archivos)
    {
        FileInfo info = new FileInfo(Archivitos);
        double peso = Math.Round(info.Length / 1024.0, 2);
        string fecha = info.LastWriteTime.ToString("dd/MM/yyyy-HH:mm");
        escribir.WriteLine($"{info.Name};{peso};{fecha}");
    }

}





