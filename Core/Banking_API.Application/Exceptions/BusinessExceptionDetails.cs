﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Banking_API.Application.Exceptions
{
    public class BusinessExceptionDetails : ProblemDetails
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
