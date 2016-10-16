using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace WpfApplication3.Repository
{
    public class UserRepository
    {
        public string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();

                str.DataSource = @"(local)\SQLEXPRESS";
                str.InitialCatalog = "UniversityLibraryDb";
                str.IntegratedSecurity = true;

                return str.ConnectionString;
            }
        }

        public void UpdateUserPhoto(string userId, byte[] photo)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand showUserInfo = new SqlCommand("UPDATE [dbo].[tblStudents] SET Photo = @Photo WHERE Id = @UserId", connection);
                    showUserInfo.Parameters.Add(new SqlParameter("@UserId", userId));
                    showUserInfo.Parameters.Add(new SqlParameter("@Photo", photo));

                    connection.Open();

                    var result = showUserInfo.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public UserModel LoadUserDetails(string userId)
        {
            UserModel model = null;
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand showUserInfo = new SqlCommand("SELECT * FROM [dbo].[tblStudents] WHERE Id = @UserId", connection);
                    showUserInfo.Parameters.Add(new SqlParameter("@UserId", userId));
                    connection.Open();

                    using (SqlDataReader reader = showUserInfo.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new UserModel
                            {
                                Name = reader.GetValue(reader.GetOrdinal("Name")) as string,
                                LastName = reader.GetValue(reader.GetOrdinal("LastName")) as string,
								Photo = reader.GetValue(reader.GetOrdinal("Photo")) as byte[],						
								Id = (int)(reader.GetValue(reader.GetOrdinal("Id")))
                            };
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }

            return model;
        }
    }
}
