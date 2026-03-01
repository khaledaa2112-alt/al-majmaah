using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace مشروع_1.Pages
{
    public class RegisteredCoursesModel : PageModel
    {
        // تعريف كلاس المادة لتنظيم البيانات
        public class Course
        {
            public string Name { get; set; }
            public string Doctor { get; set; }
            public string Hours { get; set; }
            public string Room { get; set; }
            public string Time { get; set; }
        }

        // قائمة المواد التي ستظهر في الصفحة
        public List<Course> MyCourses { get; set; } = new List<Course>();

        public void OnGet()
        {
            // جلب الرقم الجامعي للطالب الذي سجل دخوله حالياً من الجلسة (Session)
            var studentId = HttpContext.Session.GetString("UserStudentId");

            if (studentId == "441001234")
            {
                // مواد طالب الفيزياء حسب طلبك
                MyCourses = new List<Course>
                {
                    new Course { Name = "فيزياء بيئة", Doctor = "د. إبراهيم الفايز", Hours = "3", Room = "PH-101", Time = "08:00 - 10:00" },
                    new Course { Name = "الدوائر الكهربائية", Doctor = "د. صالح العمري", Hours = "3", Room = "Lab-Phys", Time = "10:00 - 01:00" },
                    new Course { Name = "الفيزياء الحديثة", Doctor = "د. منصور الحربي", Hours = "3", Room = "PH-105", Time = "01:00 - 03:00" },
                    new Course { Name = "الديناميكا الحرارية", Doctor = "د. وليد السيف", Hours = "3", Room = "G-200", Time = "04:00 - 06:00" }
                };
            }
            else if (studentId == "461102138" || studentId == "12345")
            {
                // مواد طالب تقنية المعلومات (المواد المذكورة سابقاً)
                MyCourses = new List<Course>
                {
                    new Course { Name = "برمجة مرئية", Doctor = "د. محمد الطوخي", Hours = "3", Room = "G-102", Time = "08:00 - 10:00" },
                    new Course { Name = "هياكل بيانات", Doctor = "د. عادل ثلجاوي", Hours = "3", Room = "B-201", Time = "10:00 - 12:00" },
                    new Course { Name = "نظم إدارة قواعد بيانات", Doctor = "د. عادل ثلجاوي", Hours = "3", Room = "G-105", Time = "08:00 - 11:00" },
                    new Course { Name = "ريادة أعمال", Doctor = "د. موسى القارزي", Hours = "2", Room = "Online", Time = "04:00 - 06:00" },
                    new Course { Name = "تحرير عربي", Doctor = "أ. علي الملحم", Hours = "2", Room = "A-05", Time = "01:00 - 02:00" },
                    new Course { Name = "لغة إنجليزية تقنية 2", Doctor = "Mr. James Wilson", Hours = "2", Room = "Lab-3", Time = "11:00 - 01:00" }
                };
            }
        }
    }
}