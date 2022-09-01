﻿using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Repositories
{

    public class AddressRepository : BaseRepository, IRepository<Addresses>
    {
        public void Create(Addresses entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Addresses(CustomerId, AddressLine1, AddressLine2, AddressType, City, PostalCode, AddrState, Country)" +
                    "VALUES (@CustomerId, @AddressLine1, @AddressLine2, @AddressType, @City, @PostalCode, @AddrState, @Country)",
                    connection);
                var addressCustomerIDParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var addressAddressLineParam = new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine1
                };
                var addressAddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 10)
                {
                    Value = entity.AddressType
                };
                var addressCityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStateNameParam = new SqlParameter("@AddrState", SqlDbType.NVarChar, 20)
                {
                    Value = entity.AddrState
                };
                var addressCountryNameParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressLineParam);
                command.Parameters.Add(addressAddressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateNameParam);
                command.Parameters.Add(addressCountryNameParam);
                command.ExecuteNonQuery();
            }

        }


        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Addresses WHERE AddressId = @AddressId", connection);
                var addressIDParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(addressIDParam);
                command.ExecuteNonQuery();
            }
        }

        public Addresses Read(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Addresses WHERE AddressId = @AddressId", connection);
                var addressIDParam = new SqlParameter("@AddressId", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(addressIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Addresses
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine1 = reader["AddressLine1"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            AddrState = reader["AddrState"].ToString(),
                            Country = reader["Country"].ToString()
                        };
                    }

                }
            }
            return null;
        }


        public void Update(Addresses entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Addresses SET CustomerId = @CustomerId, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, AddressType = @AddressType, City = @City, PostalCode = @PostalCode, AddrState = @AddrState, Country = @Country WHERE AddressId = @AddressId", connection);
                var addressCustomerIDParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };
                var addressAddressLineParam = new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine1
                };
                var addressAddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 10)
                {
                    Value = entity.AddressType
                };
                var addressCityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStateNameParam = new SqlParameter("@AddrState", SqlDbType.NVarChar, 20)
                {
                    Value = entity.AddrState
                };
                var addressCountryNameParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressLineParam);
                command.Parameters.Add(addressAddressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateNameParam);
                command.Parameters.Add(addressCountryNameParam);
                command.ExecuteNonQuery();
            }
        }


        public int GetCustomerId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT CustomerId FROM Customers", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["CustomerId"]);
                }
                return 0;
            }
        }


        public int GetId()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT AddressId FROM Addresses", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["AddressId"]);
                }
                return 0;
            }
        }


        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Addresses]", connection);
                command.ExecuteNonQuery();
            }
        }


        public List<Addresses> GetAll()
        {
            using (var connection = GetConnection())
            {
                var addresses = new List<Addresses>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Addresses]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Addresses
                        {
                            AddressId = Convert.ToInt32(reader["AddressId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            AddressLine1 = reader["AddressLine1"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            AddrState = reader["AddrState"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return addresses;
            }
        }


    }
}
