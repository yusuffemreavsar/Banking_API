using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_API.Application.Exceptions
{
    public class UserCreateFailedDetails : ProblemDetails
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
