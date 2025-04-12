using System;
using System.Text.RegularExpressions;

namespace SistemManajemenKaryawan
{
    class Karyawan
    {
        private string nama;
        private string id;
        private double gaji_pokok;

        public Karyawan(string nama, string id, double gaji_pokok)
        {
            this.nama = nama;
            this.id = id;
            this.gaji_pokok = gaji_pokok;
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double Gaji_Pokok
        {
            get { return gaji_pokok; }
            set { gaji_pokok = value; }
        }

        public virtual double Hitung_Gaji()
        {
            return gaji_pokok;
        }
    }

    class KaryawanTetap : Karyawan
    {
        public KaryawanTetap(string nama, string id, double gaji_pokok)
            : base(nama, id, gaji_pokok) { }

        public override double Hitung_Gaji()
        {
            return Gaji_Pokok + 500000;
        }
    }

    class KaryawanKontrak : Karyawan
    {
        public KaryawanKontrak(string nama, string id, double gaji_pokok)
            : base(nama, id, gaji_pokok) { }

        public override double Hitung_Gaji()
        {
            return Gaji_Pokok - 200000;
        }
    }

    class KaryawanMagang : Karyawan
    {
        public KaryawanMagang(string nama, string id, double gaji_pokok)
            : base(nama, id, gaji_pokok) { }

        public override double Hitung_Gaji()
        {
            return Gaji_Pokok;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("     SISTEM MANAJEMEN KARYAWAN      ");
            Console.WriteLine("====================================\n");

            string pilihan;
            while (true)
            {
                Console.WriteLine("Pilih Jenis Karyawan:");
                Console.WriteLine("1. Karyawan Tetap");
                Console.WriteLine("2. Karyawan Kontrak");
                Console.WriteLine("3. Karyawan Magang");
                Console.Write("Masukkan pilihan (1-3): ");
                pilihan = Console.ReadLine();

                if (pilihan == "1" || pilihan == "2" || pilihan == "3")
                    break;
                else
                    Console.WriteLine("\nPilihan tidak valid. Silakan masukkan angka 1, 2, atau 3.\n");
            }

            string nama;
            while (true)
            {
                Console.Write("\nMasukkan Nama Karyawan : ");
                nama = Console.ReadLine();

                if (Regex.IsMatch(nama, @"^[a-zA-Z\s]+$"))
                    break;
                else
                    Console.WriteLine("Nama tidak valid. Nama hanya boleh mengandung huruf dan spasi.");
            }

            string id;
            while (true)
            {
                Console.Write("Masukkan ID Karyawan   : ");
                id = Console.ReadLine();

                if (Regex.IsMatch(id, @"^\d+$"))
                    break;
                else
                    Console.WriteLine("ID tidak valid. ID hanya boleh angka.");
            }

            double gaji_pokok;
            while (true)
            {
                Console.Write("Masukkan Gaji Pokok    : ");
                string inputGaji = Console.ReadLine();

                if (double.TryParse(inputGaji, out gaji_pokok))
                    break;
                else
                    Console.WriteLine("Gaji Pokok tidak valid. Gaji Pokok harus berupa angka.");
            }

            Karyawan karyawan;

            switch (pilihan)
            {
                case "1":
                    karyawan = new KaryawanTetap(nama, id, gaji_pokok);
                    break;
                case "2":
                    karyawan = new KaryawanKontrak(nama, id, gaji_pokok);
                    break;
                case "3":
                    karyawan = new KaryawanMagang(nama, id, gaji_pokok);
                    break;
                default:
                    return;
            }

            Console.WriteLine("\n---------- RINCIAN ----------");
            Console.WriteLine($"Nama       : {karyawan.Nama}");
            Console.WriteLine($"ID         : {karyawan.ID}");
            Console.WriteLine($"Gaji Akhir : Rp {karyawan.Hitung_Gaji():N0}");
            Console.WriteLine("---------------------------\n");
        }
    }
}

