using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }

        public SuccessDataResult(T data):base(data,true)
        {

        }

        //Datayı default haliyle dönmek istersek bir data parametresi göndermeden aşağıdaki şekillerde kullanabiliriz.
        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
