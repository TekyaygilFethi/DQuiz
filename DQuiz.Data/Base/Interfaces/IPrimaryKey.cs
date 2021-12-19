using System;
namespace DQuiz.Data.Base.Interfaces
{
    public interface IPrimaryKey<T>
    {
        T Id { get; set; }
    }
}
