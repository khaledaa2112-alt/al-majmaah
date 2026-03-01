using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace مشروع_1.Pages
{
    public class VisualProgrammingAttendanceModel : PageModel
    {
        // يمكنك إضافة متغيرات هنا إذا كنت تريد جلب البيانات من قاعدة بيانات مستقبلاً
        public void OnGet()
        {
            // يتم استدعاء هذه الدالة عند تحميل الصفحة
        }

        public IActionResult OnPost()
        {
            // هذه الدالة تُستخدم عند الضغط على زر "حفظ التحضير" 
            // إذا كنت تريد إرسال البيانات للسيرفر
            return Page();
        }
    }
}