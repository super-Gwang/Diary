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

    public int Create(Diary entity)
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

        int attectedRows = dbManager.ExecuteNonQuery(query, parameters);
        return attectedRows;
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
        }, parameters);
        return result.FirstOrDefault();
    }

    public Diary? GetDetail(DateTime date)
    {
        if (date == null) return null;

        string query = "SELECT * FROM tb_diary WHERE Date = @Date";

        var parameters = new Dictionary<string, object>
        {
            { "@Date", date.ToString("yyyy-MM-dd") }
        };

        var result = dbManager.ExecuteReader(query, reader => new Diary
        {
            Id = reader.GetInt32("Id"),
            Date = reader.GetDateTime("Date"),
            Weather = reader.GetString("Weather"),
            Emotion = reader.GetString("Emotion"),
            Title = reader.GetString("Title"),
            Content = reader.GetString("Content")
        }, parameters);
        return result.FirstOrDefault();
    }

    public int Update(Diary entity)
    {
        var existingDiary = GetDetail(entity.Id);
        if (existingDiary != null)
        {
            existingDiary.Weather = entity.Weather;
            existingDiary.Emotion = entity.Emotion;
            existingDiary.Title = entity.Title;
            existingDiary.Content = entity.Content;

            string query = @"UPDATE tb_diary 
                         SET Weather = @Weather, Emotion = @Emotion, Title = @Title, Content = @Content 
                         WHERE Id = @Id";

            var parameters = new Dictionary<string, object>
        {
            { "@Weather", existingDiary.Weather },
            { "@Emotion", existingDiary.Emotion },
            { "@Title", existingDiary.Title },
            { "@Content", existingDiary.Content },
            { "@Id", existingDiary.Id }
        };

            int affectedRows = dbManager.ExecuteNonQuery(query, parameters);
            return affectedRows;
        }
        return 0; // 일기가 존재하지 않으면 0 반환
    }
}
