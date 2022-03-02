using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloEmpty.Pages
{
    public class IndexModel : PageModel
    {
        // Controller �κк��� �����
        // �� ���ε� ���� �Ͻ�
        [BindProperty]
        public HelloMessage HelloMsg { get; set; }

        public string Noti { get; set; }

        // ó���� �̰�
        // return view �����൵ �� - Index Model ��ü�� view�� ��������
        public void OnGet()
        {
            this.HelloMsg = new HelloMessage()
            { Message = "Hello Razor Pages" };
        }

        // ��ư Ŭ���ϸ� ����� ������
        public void OnPost()
        {
            this.Noti = "Message Changed";
        }
    }
}
