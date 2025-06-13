using EspacioClases;

string path;
int banderaMensaje = 0;

do
{

    if (banderaMensaje == 0)
    {

        Console.Write("Ingrese el Directorio del archivo MP3 al que desea acceder: ");
        path = Console.ReadLine();

    }
    else
    {

        Console.Write("Error, el directorio del MP3 ingresado no existe, ingrese un directorio valido: ");
        path = Console.ReadLine();

    }

    banderaMensaje = 1;

} while (!File.Exists(path));



using (FileStream Archivo = new FileStream(path, FileMode.Open, FileAccess.Read))
using (BinaryReader binario = new BinaryReader(Archivo))
{
    // Nos posicionamos en los últimos 128 bytes
    Archivo.Seek(-128, SeekOrigin.End);

    // Leemos esos 128 bytes
    byte[] tagData = binario.ReadBytes(128);

    // Validamos que empiece con "TAG"
    string tagHeader = System.Text.Encoding.ASCII.GetString(tagData, 0, 3);

    if (tagHeader != "TAG")
    {
        Console.WriteLine("El archivo no contiene una etiqueta ID3v1 válida.");
        return;
    }

    // A partir de acá, podrías continuar con la extracción de campos (paso 4)

    Id3v1Tag etiqueta = new Id3v1Tag(tagData);

    Console.WriteLine($"Informacion del MP3\n\n Titulo: {etiqueta.Titulo} ---\n Artista: {etiqueta.Artista} ---\n Album: {etiqueta.Album} ---\n Año: {etiqueta.Anio} ---");

}