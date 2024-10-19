using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApp.Enums;

namespace DiaryApp.Models;
public class Diary
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Weather { get; set; }
    public string Emotion { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
