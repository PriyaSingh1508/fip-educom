﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.DAL.Exceptions
{
    public class DALException:Exception
    {
        public DALException(string message) : base(message)
        {
        }

        public DALException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
