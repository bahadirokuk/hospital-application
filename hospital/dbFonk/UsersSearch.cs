using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hastane
{
    class UsersSearch
    {
        public static void usersSearch(string username,string password)
        {
            using (SqlConnection connection = new(@"Data Source = BAHADIR; Initial Catalog = Hastane; Integrated Security = True"))
            {
                string query = "SELECT COUNT(*) FROM users WHERE Name = @Username AND Password = @Password";

                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Giriş Başarılı!");
                            FormPage newForm = new FormPage();
                            newForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                }
            }
        }
    }
}
