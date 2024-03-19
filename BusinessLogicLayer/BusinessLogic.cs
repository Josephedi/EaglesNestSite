using DataAccessLayer;
using ProjectModels;

namespace BusinessLogicLayer
{
    public class BusinessLogic
    {
        // business Logic layer class

        public bool Register_BL(UserModel model)
        {
            DataAccess dataAccess = new();
            bool isSuccess = dataAccess.Register_DA(model);
            return isSuccess;
        }

        public UserModel LogInUser_BL(UserModel model)
        {
            DataAccess dataAccess = new();
            UserModel userFound = dataAccess.LogInUser_DA(model);
            return userFound;
        }
    }
}