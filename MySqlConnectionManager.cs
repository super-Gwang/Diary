﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp;

public class MySqlConnectionManager
{
    private string connectionString;

    public MySqlConnectionManager()
    {
        connectionString = $"Server=localhost;Database=diarydb;User ID=root;Password=1234;";
    }

    public string ConnectionString => connectionString;

    public List<T> ExecuteReader<T>(string query, Func<MySqlDataReader, T> mapFunction)
    {
        var results = new List<T>();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(mapFunction(reader));
                    }
                }
            }
        }

        return results;
    }

    public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new MySqlCommand(query, connection))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                return command.ExecuteNonQuery();
            }
        }
    }
}