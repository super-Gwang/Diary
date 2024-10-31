using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp.Interfaces;

public interface IDatabase<T>
{
    List<T>? Get();

    T? GetDetail(int? id);

    T? GetDetail(DateTime date);

    int Create(T entity);

    int Update(T entity);

    void Delete(int? id);
}
