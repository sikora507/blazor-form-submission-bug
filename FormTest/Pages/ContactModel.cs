using System.ComponentModel.DataAnnotations;

namespace FormTest.Pages;

public class ContactModel
{
    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Message is required")]
    public string Message { get; set; }
}
