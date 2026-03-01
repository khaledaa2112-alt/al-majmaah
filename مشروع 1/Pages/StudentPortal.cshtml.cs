using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace مشروع_1.Pages
{
    public class StudentPortalModel : PageModel
    {
        // قاعدة بيانات الطلاب مع قائمة المواد كاملة من الصورة المرفقة
        private readonly Dictionary<string, (string Password, List<string> Courses)> StudentDatabase = new Dictionary<string, (string, List<string>)>
        {
            {
                "461102138",
                ("123456", new List<string>
                {
                    "فيزياء 1 (PHY123)",
                    "حساب التفاضل والتكامل 1 (MH113)",
                    "أساسيات الحاسب (IT112)",
                    "لغة إنجليزية 1 (EN111)",
                    "الرياضيات المتقطعة (MH121)",
                    "حساب التفاضل والتكامل 2 (MH132)",
                    "الاحتمالات والإحصاء (STAT133)",
                    "برمجة الحاسب 1 (CS131)",
                    "لغة إنجليزية 2 (EN122)",
                    "الجبر الخطي (MH222)",
                    "أساسيات قواعد البيانات (IS213)",
                    "برمجة الحاسب 2 (CS211)",
                    "لغة إنجليزية تقنية 1 (EN212)",
                    "موضوعات مختارة (IT232)",
                    "نظم إدارة القواعد (IS233)",
                    "البرمجة المرئية (IT223)",
                    "هياكل البيانات (CS231)",
                    "لغة إنجليزية تقنية 2 (EN221)"
                })
            },
            {
                "441001234",
                ("123456", new List<string> { "برمجة الحاسب 1", "فيزياء 1" })
            }
        };

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // تنظيف الجلسة عند الدخول للصفحة
            try { HttpContext.Session.Clear(); } catch { }
        }

        public IActionResult OnPost()
        {
            // التحقق من الرقم الجامعي وكلمة المرور
            if (StudentDatabase.ContainsKey(Username) && StudentDatabase[Username].Password == Password)
            {
                // 1. حفظ الرقم الجامعي في الجلسة
                HttpContext.Session.SetString("UserStudentId", Username);

                // 2. تحويل قائمة المواد إلى نص واحد مفصول بفاصلة وتخزينه في الجلسة
                string allCourses = string.Join(",", StudentDatabase[Username].Courses);
                HttpContext.Session.SetString("StudentCourses", allCourses);

                // الانتقال لصفحة لوحة التحكم
                return RedirectToPage("/StudentDashboard");
            }

            // رسالة خطأ في حال البيانات غير صحيحة
            ErrorMessage = "عذراً، الرقم الجامعي أو كلمة المرور غير صحيحة.";
            return Page();
        }
    }
}