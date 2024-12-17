using Microsoft.AspNetCore.Identity;

namespace Artist.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Додаткові поля для користувача, якщо потрібно
        public string FullName { get; set; }
    }
}
