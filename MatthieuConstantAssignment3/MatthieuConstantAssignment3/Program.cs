using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace MatthieuConstantAssignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManagement carManagement = new CarManagement();
            carManagement.Init();
        }

       
    }




    public class CarManagement
    {

        static string GetConnectionString(string connectionStringName)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("config.json");
            IConfiguration config = configurationBuilder.Build();
            
            return config["ConnectionStrings:" + connectionStringName];
        }

        public void Init()
        {
            
            int option = 0;
            int repeat = 1;
            
            while (repeat == 1)
            {
                while (option > 4 || option <= 0)
                {
                    Console.WriteLine("Car Manager");
                    Console.WriteLine("Please Chose an option");
                    Console.WriteLine("Enter 1 for Vehicle menu");
                    Console.WriteLine("Enter 2 for Inventory menu");
                    Console.WriteLine("Enter 3 for Repair menu");
                    option = int.Parse(Console.ReadLine());
                    if (option > 3 || option <= 0)
                    {
                        Console.WriteLine("Number out of range");
                    }
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("Vehicle Menu");
                        Console.WriteLine("Please Chose an option");
                        Console.WriteLine("Enter 1 to list all vehicles");
                        Console.WriteLine("Enter 2 to add a vehicle");
                        Console.WriteLine("Enter 3 to update a vehicle");
                        Console.WriteLine("Enter 4 to delete a vehicle");
                        Console.WriteLine("Enter 5 to return to main menu");
                        option = int.Parse(Console.ReadLine());
                        if (option > 5 || option <= 0)
                        {
                            Console.WriteLine("Number out of range");
                        }
                        //-------------Functions for Vehicle Menu------------------
                        switch (option)
                        {
                            case 1:
                                listAll();
                                break;
                            case 2:
                                addVehicle();
                                break;
                            case 3:
                                updateVehicle();
                                break;
                            case 4:
                                deleteVehicle();
                                break;

                        }
                        //---------------------------------------------------------
                        break;

                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Inventory Menu");
                        Console.WriteLine("Enter 1 to insert a new inventory");
                        Console.WriteLine("Enter 2 to view inventory for a vehicle");
                        Console.WriteLine("Enter 3 to delete an inventory");
                        Console.WriteLine("Enter 4 to update an inventory");
                        Console.WriteLine("Enter 5 to return to main menu");
                        option = int.Parse(Console.ReadLine());
                        if (option > 5 || option <= 0)
                        {
                            Console.WriteLine("Number out of range");
                        }
                        //-------------Functions for Inventory Menu----------------
                        switch (option)
                        {
                            case 1:
                                addInventory();
                                break;
                            case 2:
                                viewInventory();
                                break;
                            case 3:
                                deleteInventory();
                                break;
                            case 4:
                                updateInventory();
                                break;

                        }
                        //---------------------------------------------------------

                        break;

                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Repair Menu");
                        Console.WriteLine("Enter 1 to insert a new repair");
                        Console.WriteLine("Enter 2 to view all repairs");
                        Console.WriteLine("Enter 3 to update a repair");
                        Console.WriteLine("Enter 4 to delete a repair");
                        Console.WriteLine("Enter 5 to return to main menu");
                        option = int.Parse(Console.ReadLine());
                        if (option > 5 || option <= 0)
                        {
                            Console.WriteLine("Number out of range");
                        }
                        //-------------Functions for Repair Menu-------------------
                        switch (option)
                        {
                            case 1:
                                addRepair();
                                break;
                            case 2:
                                viewRepairs();
                                break;
                            case 3:
                                updateRepair();
                                break;
                            case 4:
                                deleteRepair();
                                break;

                        }
                        //---------------------------------------------------------

                        break;

                   


                }

            }

            //-----------------Vehicle Functions-----------------

            void listAll()
            {
                try
                {
                    string cs = GetConnectionString("CarDBMdf");
                    SqlConnection conn = new SqlConnection(cs);

                    string query = "Select Id, make, model, year, newUsed from Vehicles";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string make = (string)reader["make"];
                        string model = (string)reader["model"];
                        string year = (string)reader["year"];
                        string newUsed = (string)reader["newUsed"];
                        Console.WriteLine($"{id,2} {make,-5} {model,-5} {year,4} {newUsed,4}");
                    }

                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            void addVehicle()
            {
                //add a new vehicles to the database
                
                try
                {
                    
                    string cs = GetConnectionString("CarDBMdf");
                    Random rnd = new Random();
                    int newId = rnd.Next(11, 99);
                    Console.WriteLine("Enter the make of the vehicle");
                    string make = Console.ReadLine();
                    Console.WriteLine("Enter the model of the vehicle");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter the year of the vehicle");
                    string year = Console.ReadLine();
                    Console.WriteLine("Enter if the vehicle is new or used");
                    string newUsed = Console.ReadLine();
                    string query = "Insert into Vehicles (id, make, model, year, newUsed) values (@id, @make, @model, @year, @newUsed)";
                    
                   
                    using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("make", make);
                        cmd.Parameters.AddWithValue("model", model);
                        cmd.Parameters.AddWithValue("year", year);
                        cmd.Parameters.AddWithValue("newUsed", newUsed);
                        cmd.Parameters.AddWithValue("id", newId);


                        conn.Open();
                int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result == 1)
                    Console.WriteLine("Employee inserted");
                else
                    Console.WriteLine("Employee not inserted");
                       
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }

            void updateVehicle()
            {

            }

            void deleteVehicle()
            {

            }
            //-----------------Inventory Functions-----------------

            void addInventory()
            {

            }

            void viewInventory()
            {

            }
            
            void deleteInventory()
            {

            }

            void updateInventory()
            {

            }
            //------------------Repair Functions-------------------
            
            void viewRepairs()
            {

            }

            void addRepair()
            {

            }

            void updateRepair()
            {

            }

            void deleteRepair()
            {

            }


        }

    }
}

