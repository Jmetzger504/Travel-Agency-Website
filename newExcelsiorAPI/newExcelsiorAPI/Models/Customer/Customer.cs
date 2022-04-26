using System.Data.SqlClient;

namespace newExcelsiorAPI.Models
{
  

  public class Customer
  {
    public Customer()
    {
      CruiseTickets = new List<CruiseTicket>();
    }
    #region Properties
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public int? ZipCode { get; set; }
    public decimal? Balance { get; set; }

    public List<CruiseTicket>? CruiseTickets { get; set; }
    #endregion

    SqlConnection con = new SqlConnection("server=p2project.database.windows.net ;database=excelsiorDb; User Id = project2; Password=Password@4567");

    public bool attemptLogin(string email,string password)
    {
      SqlCommand check = new SqlCommand("select Count(email) from Customer where email = @email and password = @password",con);
      check.Parameters.AddWithValue("@email", email);
      check.Parameters.AddWithValue("@password", password);
      SqlDataReader reader;
      int count;
      bool authenticate = true;
      try
      {
        con.Open();
        reader = check.ExecuteReader();

        reader.Read();
        count = Convert.ToInt32(reader[0]);

        if(count == 0)
          authenticate = false;

        return authenticate;
        
      }
      catch(Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }
      
    }

    public Customer login(string email, string password)
    {
      SqlCommand login = new SqlCommand("select * from Customer where email = @email and password = @password", con);
      login.Parameters.AddWithValue("@email", email);
      login.Parameters.AddWithValue("@password", password);
      SqlDataReader reader;
      Customer customer = new Customer();
      try
      {
        con.Open();
        reader = login.ExecuteReader();

        reader.Read();
        
        customer.Id = Convert.ToInt32(reader[0]);
        customer.Email = Convert.ToString(reader[1]);
        customer.Password = Convert.ToString(reader[2]);
        customer.FirstName = Convert.ToString(reader[3]);
        customer.LastName = Convert.ToString(reader[4]);
        customer.StreetAddress = Convert.ToString(reader[5]);
        customer.City = Convert.ToString(reader[6]);
        customer.State = Convert.ToString(reader[7]);
        customer.ZipCode = Convert.ToInt32(reader[8]);
        customer.Balance = Convert.ToDecimal(reader[9]);

        return customer;

      }
      catch (Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }
    }

    public void register()
    {
      SqlCommand getId = new SqlCommand("select Max(Id) from Customer", con);
      SqlDataReader reader;

      try
      {
        con.Open();
        reader = getId.ExecuteReader();

        reader.Read();
        this.Id = Convert.ToInt32(reader[0]) + 1;
      }
      catch(Exception ex) { throw new Exception(ex.Message); }
      finally { con.Close(); }

      SqlCommand register = new SqlCommand("insert into Customer values (@Id,@email,@password,@firstName,@lastName,@streetAddress,@city,@state,@zipCode,@balance)", con);
      register.Parameters.AddWithValue("@Id",this.Id);
      register.Parameters.AddWithValue("@email",this.Email);
      register.Parameters.AddWithValue("@password",this.Password);
      register.Parameters.AddWithValue("@firstName",this.FirstName);
      register.Parameters.AddWithValue("@lastName",this.LastName);
      register.Parameters.AddWithValue("@streetAddress",this.StreetAddress);
      register.Parameters.AddWithValue("@city",this.City);
      register.Parameters.AddWithValue("@state",this.State);
      register.Parameters.AddWithValue("@zipCode",this.ZipCode);
      register.Parameters.AddWithValue("@balance",this.Balance);

      try
      {
        con.Open();
        register.ExecuteNonQuery();
        
      }
      catch (Exception ex) { throw new Exception(); }
      finally { con.Close(); } 

    }

  }
}
