using DiaryApp.Interfaces;
using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace DiaryApp.Service;

public class DiaryService : IDatabase<Diary>
{
    private MySqlConnectionManager dbManager;

    public DiaryService()
    {
        dbManager = new MySqlConnectionManager();
    }

    public void Create(Diary entity)
    {
        string query = @"INSERT INTO tb_diary (Date, Weather, Emotion, Title, Content) 
                         VALUES (@Date, @Weather, @Emotion, @Title, @Content)";

        var parameters = new Dictionary<string, object>
        {
            { "@Date", entity.Date },
            { "@Weather", entity.Weather },
            { "@Emotion", entity.Emotion },
            { "@Title", entity.Title },
            { "@Content", entity.Content }
        };

        dbManager.ExecuteNonQuery(query, parameters);
    }

    public void Delete(int? id)
    {
    }

    public List<Diary>? Get()
    {
        string query = "SELECT * FROM tb_diary";
        return dbManager.ExecuteReader(query, reader => new Diary
        {
            Id = reader.GetInt32("Id"),
            Date = reader.GetDateTime("Date"),
            Weather = reader.GetString("Weather"),
            Emotion = reader.GetString("Emotion"),
            Title = reader.GetString("Title"),
            Content = reader.GetString("Content")
        });
    }

    public Diary? GetDetail(int? id)
    {
        if (id == null) return null;
        string query = "SELECT * FROM tb_diary WHERE Id = @Id";

        var parameters = new Dictionary<string, object>
        {
            { "@Id", id }
        };

        var result = dbManager.ExecuteReader(query, reader => new Diary
        {
            Id = reader.GetInt32("Id"),
            Date = reader.GetDateTime("Date"),
            Weather = reader.GetString("Weather"),
            Emotion = reader.GetString("Emotion"),
            Title = reader.GetString("Title"),
            Content = reader.GetString("Content")
        });
        return result.FirstOrDefault();
    }

    public void Update(Diary entity)
    {
        var existingDiary = GetDetail(entity.Id);
        if (existingDiary != null)
        {
            existingDiary.Weather = entity.Weather;
            existingDiary.Emotion = entity.Emotion;
            existingDiary.Title = entity.Title;
            existingDiary.Content = entity.Content;
        }
    }
}
