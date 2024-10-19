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
    private List<Diary> diaryEntries = new List<Diary>();

    public DiaryService()
    {
        dbManager = new MySqlConnectionManager();
    }

    public void Create(Diary entity)
    {
        string query = @"INSERT INTO diaries (Date, Weather, Emotion, Title, Content) 
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
        //diaryEntries.Add(entity); 
    }

    public void Delete(int? id)
    {
    }

    public List<Diary>? Get()
    {
        string query = "SELECT * FROM diaries";
        return dbManager.ExecuteReader(query, reader => new Diary
        {
            Id = reader.GetInt32("Id"),
            Date = reader.GetDateTime("Date"),
            Weather = reader.GetString("Weather"),
            Emotion = reader.GetString("Emotion"),
            Title = reader.GetString("Title"),
            Content = reader.GetString("Content")
        });
        //return diaryEntries;
    }

    public Diary? GetDetail(int? id)
    {
        if (id == null) return null;
        string query = "SELECT * FROM diaries WHERE Id = @Id";

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

        return result.FirstOrDefault();  // 하나의 Diary 반환, 없으면 null
        //return diaryEntries.FirstOrDefault(e => e.Id == id);
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
