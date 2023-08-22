using exam_14slot14.demo1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_14slot14
{
    public class Program
    {

        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            Console.Title = "Doan Viet Anh - slot14";
            int chon;
            do
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------- Hay chon yeu cau mong muon ----------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1.Them sinh vien.");
                Console.WriteLine("2.Cap nhan sin vien qua ID.");
                Console.WriteLine("3.Xoa sinh vien qua ID.");
                Console.WriteLine("4.Search sinh vien qua ID.");
                Console.WriteLine("5.Sap xep sinh vien qua diem trung binh.");
                Console.WriteLine("6.Sap xep sinh vien qua ten.");
                Console.WriteLine("7.Sap xep sinh vien qua ID.");
                Console.WriteLine("8.Hien thi danh sach sinh vien.");
                Console.ForegroundColor = ConsoleColor.White;


                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------ Pleae choose number in 1-9 -----------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        UpdateStudent();
                        break;

                    case 3:
                        DeleteStudent();
                        break;

                    case 4:
                        SearchByName();
                        break;

                    case 5:
                        SortByGPA();
                        break;

                    case 6:
                        SortByName();
                        break;

                    case 7:
                        SortById();
                        break;

                    case 8:
                        DisplayStudents();
                        break;

                }
            } while (chon != 0);
        }

        static void AddStudent()
        {
            Student student = new Student();
            Console.Write("Nhap ID sinh vien: ");
            student.Id = int.Parse(Console.ReadLine());
            Console.Write("Nhap ten sinh vien: ");
            student.Name = Console.ReadLine();
            Console.Write("Nhap gender nam/nu: ");
            student.Gender = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter MathScore: ");
            double mathScore = ReadValidScore();
            student.Math = mathScore;
            student.Math = double.Parse(Console.ReadLine());

            Console.Write("Enter diem ly: ");
            student.Physics = double.Parse(Console.ReadLine());

            Console.Write("Nhap diem hoa: ");
            student.Chemistry = double.Parse(Console.ReadLine());

            students.Add(student);
            Console.WriteLine("Them sinh vien thanh cong!");

            ///

        }
        static double ReadValidScore()
        {
            double score;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 10)
                {
                    return score;
                }
                else
                {
                    Console.WriteLine("Nhap diem tu 1- 10");
                }
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Nhap ID sinh vien: ");
            int id = int.Parse(Console.ReadLine());
            Student student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                Console.Write("Nhap ten moi: ");
                student.Name = Console.ReadLine();
                Console.Write("Nhap gioi tinh: ");
                student.Gender = Console.ReadLine();
                Console.Write("Nhap tuoi moi: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Nhap diem Toan moi: ");
                student.Math = double.Parse(Console.ReadLine());
                Console.Write("Nhap diem ly moi: ");
                student.Physics = double.Parse(Console.ReadLine());
                Console.Write("Nhap diem Hoa: ");
                student.Chemistry = double.Parse(Console.ReadLine());

                Console.WriteLine("Cap nhap thong tin thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tin thay sinh vien.");
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Nhap ID sinh vien can xoa: ");
            int id = int.Parse(Console.ReadLine());
            Student student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Xoa SV thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay SV.");
            }
        }
        static void SearchByName()
        {
            Console.Write("Nhap ten SV can tim: ");
        string name = Console.ReadLine();
        List<Student> searchResults = students.Where(s => s.Name.Contains(name)).ToList();

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            DisplayStudentList(searchResults);
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có tên đã nhập.");
        }

        }

        static void SortByGPA()
        {
            List<Student> sortedStudents = students.OrderByDescending(s => s.DiemTrungBinh()).ToList();
            Console.WriteLine("Danh sach SV sau khi sap xep qua Diem TB la:");
            DisplayStudentList(sortedStudents);

        }

        static void SortByName()
        {
            List<Student> sortedStudents = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine("Danh sach SV sau khi sap xep qua Name la:");
            DisplayStudentList(sortedStudents);
        }

        static void SortById()
        {
            List<Student> sortedStudents = students.OrderBy(s => s.Id).ToList();
            Console.WriteLine("Danh sach SV sau khi sap xep qua ID la:");
            DisplayStudentList(sortedStudents);

        }

        static void DisplayStudents()
        {
            Console.WriteLine("Danh sách sinh viên:");
            DisplayStudentList(students);

        }

        static void DisplayStudentList(List<Student> studentList)
        {
           foreach (var student in studentList)
            {
                Console.WriteLine($"ID:{student.Id}, Name: {student.Name}, Gender: {student.Gender}, Age: {student.Age}, Diem TB: {student.DiemTrungBinh()}, Hoc Luc: {student.HocLucStudent()}");
            }
        }
    }
}
