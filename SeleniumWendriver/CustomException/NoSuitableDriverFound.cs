﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.CustomException
{
    public class NoSuitableDriverFound: Exception
    {
      public NoSuitableDriverFound(string msg): base(msg)
        {
            
        }
    }
}
