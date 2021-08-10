using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(true,message) //Result(true,message) gönderiyoruz
        {

        }
        public SuccessResult():base(true) //Resultu çağırıp true gönderiyor ve Result(true) çalışıyor
        {

        }
    }
        
}
