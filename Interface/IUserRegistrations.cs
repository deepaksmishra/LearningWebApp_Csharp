using LWAJWTLOG.Models;

namespace LWAJWTLOG.Interface
{
    public interface IUserRegistrations 
    {
        public List<UserRegistration> GetUserRegistrationDetails();
        public UserRegistration GetUserRegistrationDetails(int id);
        public void AddUserRegistration(UserRegistration UserRegistration);
        public void UpdateUserRegistration(UserRegistration UserRegistration);
        public UserRegistration DeleteUserRegistration(int id);
        public bool CheckUserRegistration(int id);
    }
}
