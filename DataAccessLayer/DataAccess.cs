using Microsoft.Data.SqlClient;
using ProjectModels;

namespace DataAccessLayer
{
    // Data Access layer class

    public class DataAccess
    {
        //Windows Users
        string dataSourceWindows = "Example/Servername";
        string initialCatalogWindows = "SomeDatabase";

        //Mac Users
        string dataSourceMac = "localhost";
        string initialCatalogMac = "EaglesNestDatabase";
        string userID = "sa";
        string userPassword = "dockerStrongPwd123";

        SqlConnection conn = new SqlConnection();
    
        public DataAccess()
        {
            string sqlConnectionStringForWindows =
                "Data Source=" + dataSourceWindows +
                ";Initial Catalog=" + initialCatalogWindows +
                "Integrated Security = true;";

            string sqlConnectionStringForMac =
                "Data Source=" + dataSourceMac +
                ";Initial Catalog=" + initialCatalogMac +
                ";TrustServerCertificate=True" +
                ";User ID = " + userID +
                ";Password=" + userPassword;

            conn = new SqlConnection(sqlConnectionStringForMac);
        }

        public bool Register_DA(UserModel model)
        {
            conn.Open();

            string insertToRegistrationTable = "INSERT INTO SiteUsers (firstName, lastName, middleName, email, phone, dateOfBirth, street1, street2, city, state)" +
            " VALUES ('" + model.FirstName + "', '" + model.LastName + "', " +
            "'" + model.MiddleName + "', '" + model.Email + "', '" + model.Phone + "', '" + model.DateOfBirth
            + "', '" + model.Street1 + "', '" + model.Street2 + "', '" + model.City + "', '" + model.State + "')";

            SqlCommand cmd1 = new(insertToRegistrationTable, conn);


            string insertToLoginInfo = "INSERT INTO LoginInfo (email, username, password, isActive)" +
                " VALUES ('" + model.Email + "', '" + model.Username + "', '" + model.Password + "', '1')";

            SqlCommand cmd2 = new(insertToLoginInfo, conn);

            if ((cmd1.ExecuteNonQuery() > 0) && (cmd2.ExecuteNonQuery() > 0))
                return true;
            else
                return false;
        }


        public UserModel LogInUser_DA(UserModel model)
        {
            conn.Open();

            string sqlQuery = "SELECT " +
                "LoginInfo.email, username, password, firstName, lastName, middleName, phone, dateOfBirth, " +
                "street1, street2, city, state " +
                "FROM LoginInfo, SiteUsers " +
                "WHERE LoginInfo.email=Siteusers.email " +
                "AND LoginInfo.username='" + model.Username + "'";

            SqlCommand searchDatabase = new SqlCommand(sqlQuery, conn);

            SqlDataReader loginReader = searchDatabase.ExecuteReader();

            if (loginReader.Read())
            {
                UserModel searchedUser = new UserModel();

                searchedUser.Username = loginReader["username"].ToString();
                searchedUser.Password = loginReader["password"].ToString();

                if ((searchedUser.Username == model.Username) && (searchedUser.Password == model.Password))
                {
                    searchedUser.FirstName = loginReader["firstName"].ToString();
                    searchedUser.LastName = loginReader["lastName"].ToString();
                    searchedUser.MiddleName = loginReader["middleName"].ToString();
                    searchedUser.Phone = loginReader["phone"].ToString();
                    searchedUser.DateOfBirth = loginReader["dateOfBirth"].ToString();
                    searchedUser.Street1 = loginReader["street1"].ToString();
                    searchedUser.Street2 = loginReader["street2"].ToString();
                    searchedUser.City = loginReader["city"].ToString();
                    searchedUser.State = loginReader["state"].ToString();
                    searchedUser.IsActive = true;

                    return searchedUser;
                }
                else
                {
                    model.IsActive = false;
                    return model;
                }
            }

            model.IsActive = false;

            return model;
        }

    }
}