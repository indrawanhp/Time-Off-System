namespace Api.ViewModels
{
    public class ChangePasswordVM
    {
        public int EmployeeId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
