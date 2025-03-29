namespace BE_WebApi_Core.Models
{
    public class SiswaModel
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public int Kelas { get; set; }
        public string Jurusan { get; set; }
        public int Usia { get; set; }
        public string Alamat { get; set; } 
        public int IsActive { get; set; }
    }
}
