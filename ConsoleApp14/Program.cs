using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Xosh gelmishsiniz, xahish edirik login ve parolunuzu daxil edin: ");
            Console.Write("Login: ");
            var login = Console.ReadLine();
            Console.WriteLine(" ");
            Console.Write("Parol: ");
            var parol = Console.ReadLine();
            if (login == "admin" && parol == "admin")
            {
                Console.WriteLine("Admin idare etme paneline xosh gelmishsiniz");
                //Student.Create(); Student.Read(); Student.Update(); Student.Details(); Student.Exit();
                Student.Instructions();
            }
            if(login==Console.ReadLine()&& parol == Console.ReadLine())
            {
                Console.WriteLine("Daxil etdiyiniz login və ya parol sehvdir");
                Student.Exit();
            }
            if (login == "user" && parol == "user")
            {
                Student.Read(); Student.Exit();
            }
            Console.WriteLine("----------------------------------------------------------------------");
            //burdan asagi cevirme kkodlarini yazmisam, amma vaxtim catmadi davam etdirimeye
        }

        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes

            = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string[] decodeItems = new string[] { "&#252;", "&#246;", "&#231;", "&#220;", "&#199;", "&#214;" };

            string a
               = System.Convert.ToBase64String(toEncodeAsBytes);
            return a;
            
        }
           
        
    }
    class Student
    {
        public static List<Student> db = new List<Student>();
        public static int Count = 1;
        public int ID;
        public string Name;
        public string Surname;
        public int Age;
        public Student(string _name, string _surname, int _age)
        {
            Name = _name;
            Surname = _surname;
            Age = _age;
            db.Add(this);


        }
        
        
        public static void Instructions()
        {
            Console.WriteLine("1. Yeni telebe elave et");
            Console.WriteLine("2. Telebeleri gor");
            Console.WriteLine("3. Telebe melumatlarini deyis");
            Console.WriteLine("4. Telebeni sil");
            Console.WriteLine("5.Proqramdan cix");
            Console.WriteLine("***********************");
            Console.WriteLine("Emri sec qadam");
            var emr = Convert.ToInt32(Console.ReadLine());
            if (emr == 1)
            {
                Create();
            }
            else if (emr == 2)
            {
                Read();
            }
            else if (emr == 3)
            {
                Update();
            }
            else if (emr == 4)
            {
                Delete();
            }
            else if (emr == 5)
            {
                Details();
            }
            else if (emr == 6)
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Emr nomresi duzgun deyil");
            }
        }
        public static void Create()
        {

            Console.Write("Telebe adini daxil edin: ");
            var name = Console.ReadLine();
            Console.Write("Telebe soyadini daxil edin: ");
            var surname = Console.ReadLine();
            Console.Write("Telebe yasini daxil edin: ");
            var age = Convert.ToInt32(Console.ReadLine());
            Student telebe = new Student(name, surname, age);
            telebe.ID = Count;
            //db.Add(telebe);
            Count++;
            Instructions();


        }

        public static void Read()
        {
            foreach (var item in Student.db)
            {
                Console.WriteLine(item.ID + "-" + item.Name + "-" + item.Surname + "-" + item.Age);
            }

            Instructions();
        }

        public static void Update()
        {
            Console.WriteLine("Deyiwmek istediyiniz Elementin  ID - sini Yazin");

            foreach (var item in Student.db)
            {
                Console.WriteLine(item.ID + "-" + item.Name + "-" + item.Surname + "-" + item.Age);
            }

            var chooseId = Convert.ToInt32(Console.ReadLine());

            foreach (var item in db)
            {
                if (item.ID == chooseId)
                {
                    Console.WriteLine("Yeni Adi Daxil Edin");
                    var ad = Console.ReadLine();
                    Console.WriteLine("Yeni soyadi Daxil Edin");
                    var soyad = Console.ReadLine();
                    Console.WriteLine("Yeni Yawi Daxil Edin");
                    var yaw = Convert.ToInt32(Console.ReadLine());

                    item.Name = ad;
                    item.Surname = soyad;
                    item.Age = yaw;

                    Read();

                }
            }
        }

        public static void Delete()
        {
            Console.WriteLine("Silmek istediyiniz telebenin id deyerini daxil edin : ");
            var _id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in db)
            {
                if (item.ID == _id)
                {
                    db.Remove(item);
                    break;
                }
            }
            Instructions();
        }

        public static void Details()
        {
            Console.WriteLine("Detalli melumatini gormek istediyiniz telebenin id deyerini daxil edin : ");
            var _id = Convert.ToInt32(Console.ReadLine());

            foreach (var item in db)
            {
                if (item.ID == _id)
                {
                    Console.WriteLine("{0} nomreli Shexsin meumatlari", _id);
                    Console.WriteLine(" ");
                    Console.WriteLine("Shexsin adi: "+ item.Name);
                    
                    Console.WriteLine(" ");
                    Console.WriteLine("Shexsin soyadi: "+ item.Surname);
                    
                    Console.WriteLine(" ");
                    Console.WriteLine("Shexsin yashi: "+ item.Age);
                    
                }
            }
            Instructions();
        }
        
        public static void Exit()
        {
            Console.WriteLine("Exit");
            Environment.Exit(4);
            
        }
    }
}
