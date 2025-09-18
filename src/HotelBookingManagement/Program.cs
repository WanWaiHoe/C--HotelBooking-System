using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelBookingManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection dbcon = new DatabaseConnection();
            String query;

            while (true)
            {
                Console.WriteLine("Trivago Hotel Booking System\n");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register\n");
                Console.Write("Your Choice: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Login\n");
                    Console.Write("Staff ID: ");
                    string staffId = Console.ReadLine();
                    Console.Write("Password: ");
                    string staffPassword = Console.ReadLine();
                    query = "select * from Staffs where STAFF_ID ='" + staffId + "'AND PASSWORD ='" + staffPassword + "'";
                    DataTable dt = dbcon.ExecuteTableQuery(query);

                    if (dbcon != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Console.Clear();
                            while (true)
                            {
                                Console.WriteLine("Trivago Hotel Booking System");
                                Console.WriteLine("Welcome, " + dt.Rows[0]["STAFF_ID"] + "\n");
                                Console.WriteLine("1. New Customer");
                                Console.WriteLine("2. Customer Detail");
                                Console.WriteLine("3. New Booking");
                                Console.WriteLine("4. Booking Detail");
                                Console.WriteLine("5. Logout\n");
                                Console.Write("Your Choice: ");
                                string menuChoice = Console.ReadLine();
                                if (menuChoice == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine("New Customer\n");
                                    Console.Write("Customer Name: ");
                                    string custName = Console.ReadLine();
                                    Console.Write("Contact: ");
                                    string custContact = Console.ReadLine();

                                    if (custName.Equals("") || custContact.Equals(""))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please fill in all the blank");
                                    }
                                    else
                                    {
                                        query = "insert into Customers values('" + custName + "', '" + custContact + "')";
                                        int result = dbcon.ExecuteNonTableQuery(query);
                                        if (result == 1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Customer Added Successfull");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Customer Added Fail, Please Contact Admin");
                                        }
                                    }
                                }
                                else if (menuChoice == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Customer Detail\n");
                                    Console.WriteLine("1. Search by name");
                                    Console.WriteLine("2. Search in List");
                                    Console.WriteLine("3. Print All");
                                    Console.WriteLine("4. Remove Customer\n");
                                    Console.Write("Your Choice: ");
                                    string custChoice = Console.ReadLine();
                                    if (custChoice == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Search customer by name\n");
                                        Console.Write("Customer Name: ");
                                        string custName = Console.ReadLine();
                                        query = "select * from Customers where CUSTOMER_NAME like'%" + custName + "%'";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                Console.Clear();
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine("=============================================\n");
                                                    Console.WriteLine("Customer ID: " + dt2.Rows[i]["CUSTOMER_ID"]);
                                                    Console.WriteLine("Customer Name: " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                                    Console.WriteLine("Customer Contact: " + dt2.Rows[i]["CONTACT"]);
                                                    Console.WriteLine("\n=============================================");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Customer Not Found!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Customer Not Found!!");
                                        }
                                    }
                                    else if (custChoice == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Customer List\n");
                                        query = "select * from Customers";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine((dt2.Rows[i]["CUSTOMER_ID"]) + ". " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                                }
                                                Console.Write("\nCustomer ID: ");
                                                int custIdChocice = Convert.ToInt32(Console.ReadLine());

                                                query = "select * from Customers where CUSTOMER_ID = '" + custIdChocice + "'";
                                                DataTable dt3 = dbcon.ExecuteTableQuery(query);
                                                Console.Clear();
                                                if (dt3.Rows.Count > 0)
                                                {
                                                    Console.WriteLine("=============================================\n");
                                                    Console.WriteLine("Customer ID: " + dt3.Rows[0]["CUSTOMER_ID"]);
                                                    Console.WriteLine("Customer Name: " + dt3.Rows[0]["CUSTOMER_NAME"]);
                                                    Console.WriteLine("Customer Contact: " + dt3.Rows[0]["CONTACT"]);
                                                    Console.WriteLine("\n=============================================");
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Customet Not Found, please try again with a valid value");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Customer Not Found, please contact to the admin!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Customer Not Found!!");
                                        }
                                    }
                                    else if (custChoice == "3")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Customer Detail\n");
                                        query = "select * from Customers";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine("=============================================\n");
                                                    Console.WriteLine("Customer ID: " + dt2.Rows[i]["CUSTOMER_ID"]);
                                                    Console.WriteLine("Customer Name: " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                                    Console.WriteLine("Customer Contact: " + dt2.Rows[i]["CONTACT"]);
                                                    Console.WriteLine("\n=============================================");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Customer Not Found!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Customer Not Found!!");
                                        }
                                    }
                                    else if (custChoice == "4")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Customer List\n");
                                        query = "select * from Customers";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine((dt2.Rows[i]["CUSTOMER_ID"]) + ". " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                                }
                                                Console.Write("\nDelete Customer ID: ");
                                                int custIdChocice = Convert.ToInt32(Console.ReadLine());
                                                query = "delete from Customers where CUSTOMER_ID = '" + custIdChocice + "'";
                                                int result = dbcon.ExecuteNonTableQuery(query);
                                                if (result == 1)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Delete Successfully!!");
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Deletion Fail, please try again with a valid value!!");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Deletion fail, please contact admin");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Deletion fail, please contact admin");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid Choice, please insert a valid value!!!");
                                    }
                                }
                                else if (menuChoice == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine("New Booking\n");
                                    query = "select * from Customers";
                                    DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                    if (dbcon != null)
                                    {
                                        if (dt2.Rows.Count > 0)
                                        {
                                            for (int i = 0; i < dt2.Rows.Count; i++)
                                            {
                                                Console.WriteLine((i + 1) + ". " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                            }
                                            Console.Write("\nAdd booking to Customer: ");
                                            int custIdChocice = Convert.ToInt32(Console.ReadLine());

                                            Console.Write("\nRoom ID: ");
                                            string roomId = Console.ReadLine();
                                            Console.Write("Check In Date(YYYY-MM-DD): ");
                                            DateTime checkIn = Convert.ToDateTime(Console.ReadLine());
                                            Console.Write("Check Out Date(YYYY-MM-DD): ");
                                            DateTime checkOut = Convert.ToDateTime(Console.ReadLine());

                                            query = "insert into Bookings values('" + dt2.Rows[custIdChocice - 1]["CUSTOMER_NAME"] + "', 'Reserve', '" + roomId + "', '" + checkIn + "', '" + checkOut + "')";
                                            int result = dbcon.ExecuteNonTableQuery(query);

                                            if (result == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Booking Added Successfully!!");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Booking Added Fail, please contact admin!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("No Customer Found!!");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Customer Not Found");
                                    }
                                }
                                else if (menuChoice == "4")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Booking Detail\n");
                                    Console.WriteLine("1. Search by customer name");
                                    Console.WriteLine("2. Print All");
                                    Console.WriteLine("3. Cancel Booking\n");
                                    Console.Write("Your Choice: ");
                                    string bookingChoice = Console.ReadLine();
                                    if (bookingChoice == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Search Booking Detail By Customer Name\n");
                                        Console.Write("Customer Name: ");
                                        string custName = Console.ReadLine();
                                        query = "select * from Bookings where CUSTOMER_NAME LIKE '%" + custName + "%'";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                Console.Clear();
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine("=============================================\n");
                                                    Console.WriteLine("Booking ID: "+ dt2.Rows[i]["BOOKING_ID"]);
                                                    Console.WriteLine("Customer Name: " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                                    Console.WriteLine("Status: " + dt2.Rows[i]["STATUS"]);
                                                    Console.WriteLine("Room ID: " + dt2.Rows[i]["ROOM_ID"]);
                                                    Console.WriteLine("Check In Date: " + dt2.Rows[i]["CHECK_IN"]);
                                                    Console.WriteLine("Check Out Date: " + dt2.Rows[i]["CHECK_OUT"]);
                                                    Console.WriteLine("\n=============================================");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Booking Detail Not Found!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Booking Detail Not Found!!");
                                        }
                                    }
                                    else if (bookingChoice == "2")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("All Booking Detail\n");
                                        query = "select * from Bookings";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine("=============================================\n");
                                                    Console.WriteLine("Booking ID: " + dt2.Rows[i]["BOOKING_ID"]);
                                                    Console.WriteLine("Customer Name: " + dt2.Rows[i]["CUSTOMER_NAME"]);
                                                    Console.WriteLine("Status: " + dt2.Rows[i]["STATUS"]);
                                                    Console.WriteLine("Room ID: " + dt2.Rows[i]["ROOM_ID"]);
                                                    Console.WriteLine("Check In Date: " + dt2.Rows[i]["CHECK_IN"]);
                                                    Console.WriteLine("Check Out Date: " + dt2.Rows[i]["CHECK_OUT"]);
                                                    Console.WriteLine("\n=============================================");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Customer Not Found!!");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Customer Not Found!!");
                                        }
                                    }
                                    else if (bookingChoice == "3")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Cancel Booking\n");
                                        query = "select * from Bookings";
                                        DataTable dt2 = dbcon.ExecuteTableQuery(query);

                                        if (dbcon != null)
                                        {
                                            if (dt2.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dt2.Rows.Count; i++)
                                                {
                                                    Console.WriteLine((dt2.Rows[i]["BOOKING_ID"]) + ". " + dt2.Rows[i]["CUSTOMER_NAME"] + " Room: " + dt2.Rows[i]["ROOM_ID"]);
                                                }
                                                Console.Write("\nCancel Booking ID: ");
                                                int cancelIdChoice = Convert.ToInt32(Console.ReadLine());
                                                query = "update Bookings set STATUS = 'Canceled' where BOOKING_ID = "+ cancelIdChoice +"";
                                                int result = dbcon.ExecuteNonTableQuery(query);
                                                if (result == 1)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Booking Canceled Successfully!!");
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Booking cancel fail, please try again with a valid value!!");
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Booking cancel fail, please contact admin");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Booking calcel fail, please contact admin");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid Choice, please insert a valid value!!!");
                                    }
                                }
                                else if (menuChoice == "5")
                                {
                                    Console.WriteLine("Do you sure you want to log out?\n");
                                    Console.WriteLine("1. Yes");
                                    Console.WriteLine("2. No\n");
                                    Console.Write("Your choice: ");
                                    string logoutChoice = Console.ReadLine();
                                    if (logoutChoice == "1")
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    else if (logoutChoice == "2")
                                    {
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please insert a valid value!!");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Choice!!");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Login fail, invalid staff id or password");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Login Fail, Please contact admin");
                    }
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Register\n");
                    Console.Write("Staff ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Contact: ");
                    string contact = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Comfirm Password: ");
                    string cPassword = Console.ReadLine();

                    if (id.Equals("") || contact.Equals("") || email.Equals("") || password.Equals("") || cPassword.Equals(""))
                    {
                        Console.Clear();
                        Console.WriteLine("Please fill in all the blank");
                    }
                    else if (cPassword == password)
                    {
                        query = "insert into Staffs values('" + id + "', '" + password + "', '" + contact + "', '" + email + "')";
                        int result = dbcon.ExecuteNonTableQuery(query);
                        if (result == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Register Successfull");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Register Fail, Please Contact Admin");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Register fail, password and comfirm password must be same!!!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid choice, please insert a valid value!!!");
                }
            }
        }
    }
}
