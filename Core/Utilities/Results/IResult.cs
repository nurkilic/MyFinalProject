using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç-data yok birşey döndürmüyor
    public interface IResult
    {
        bool Success { get; } //sadece okunabilir -başarılı mı başarısız mı
        string Message { get; } //başarılı -ürün eklendi (get return et) - okuma
    }
}
