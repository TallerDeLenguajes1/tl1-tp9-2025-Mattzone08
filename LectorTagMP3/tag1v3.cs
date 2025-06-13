namespace EspacioClases
{

    public class Id3v1Tag
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Anio { get; set; }
        
        public Id3v1Tag(byte[] tagData)
        {
            Titulo  = System.Text.Encoding.ASCII.GetString(tagData, 3, 30).TrimEnd('\0', ' ');
            Artista = System.Text.Encoding.ASCII.GetString(tagData, 33, 30).TrimEnd('\0', ' ');
            Album   = System.Text.Encoding.ASCII.GetString(tagData, 63, 30).TrimEnd('\0', ' ');
            Anio    = System.Text.Encoding.ASCII.GetString(tagData, 93, 4).TrimEnd('\0', ' ');
        }



    }




}