using DiaryApp.Interfaces;
using DiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Services;

public class DiaryMemoryService : IDatabase<Diary>
{
    private readonly List<Diary> _diaryList = new List<Diary>();
    public int Create(Diary entity)
    {
        _diaryList.Add(entity);
        return 1;
    }

    public void Delete(int? id)
    {

    }

    public List<Diary>? Get()
    {
        return _diaryList;
    }

    public Diary? GetDetail(int? id)
    {
        Diary? diary = null;
        diary = _diaryList.FirstOrDefault(d => d.Id == id);
        
        return diary;
    }

    public Diary? GetDetail(DateTime date)
    {
        Diary? diary = null;
        diary = _diaryList.FirstOrDefault(d => d.Date == date);

        return diary;
    }

    public int Update(Diary entity)
    {
        Diary? diary = GetDetail(entity.Id);
        if (diary == null)
        {
            diary.Title = entity.Title;
            diary.Content = entity.Content;
            diary.Weather = entity.Weather;
            diary.Emotion = entity.Emotion;
        }

        return 1;
    }
}
