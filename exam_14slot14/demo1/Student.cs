using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_14slot14.demo1
{
    public class Student
    {
        public int Id {
            get ; set;
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double Math { get; set; }
        public double Physics { get; set; }
        public double Chemistry{ get; set; }



        
        public double DiemTrungBinh()
        {
            return (Math + Physics + Chemistry) / 3;
        }


        public string HocLucStudent()
        {
            double DTB = DiemTrungBinh();

            if (DTB >= 8)
                return "Hoc Luc Gioi";
            else if (DTB >= 6.5)
                return "Hoc Luc Kha";
            else if (DTB >= 5)
                return "Hoc Luc Trung Binh";
            else
                return "Hoc Luc Yeu";

        }
    }
}
