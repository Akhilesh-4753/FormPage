using FormPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FormPage.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginForm() => View();
        public IActionResult SignUp() => View();

        private readonly string connectionString =
            "Server=localhost\\SQLEXPRESS02;Database=USERS_DB;Integrated Security=SSPI;TrustServerCertificate=True;";

        [HttpPost("register")]
        public IActionResult Register([FromBody] Register bodyData)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO USERS (USERNAME, PASSWORD, EMAIL) VALUES (@Name, @Password, @Email)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Name", bodyData.Name);
                    cmd.Parameters.AddWithValue("@Password", bodyData.Password);
                    cmd.Parameters.AddWithValue("@Email", bodyData.Email);

                    int rows = cmd.ExecuteNonQuery(); // returns number of inserted rows
                    if (rows > 0)
                        return Ok(new { message = "User registered successfully!", isSuccess = true });
                    else
                        return BadRequest(new { message = "Registration failed.", isSuccess = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login1")]
        public IActionResult Login([FromBody] Login bodyData)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM USERS WHERE EMAIL = @Email AND PASSWORD = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", bodyData.Email);
                    cmd.Parameters.AddWithValue("@Password", bodyData.Password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                        return Ok(new { message = "User login successful!", isSuccess = true });
                    else
                        return BadRequest(new { message = "Invalid email or password", isSuccess = false });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
