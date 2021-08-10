using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //success ve mesajı IResulttan alıyoruz kendimizi tekrar etmiyoruz
    {
        T Data { get; } // ürün olur , ürünler olur
    }
}
