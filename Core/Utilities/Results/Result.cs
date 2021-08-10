using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
      

        public Result(bool success, string message):this(success)//burası çalıştığında tek paremetreli ctor da çalışsın
        {                                                        //successi alttaki ctora yolla set olup gelsin
            Message = message; //set ettik
            
        }
        public Result(bool success) //overloading=aşırı yükleme
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }  //Get, read onlydir. contsracterda set edilebilir.
                                        //contracter dışında set etmeyeceğiz
    }
}
