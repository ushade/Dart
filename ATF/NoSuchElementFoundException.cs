﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF
{
    public class NoSuchElementFoundException : Exception
    {
        public NoSuchElementFoundException(string msg) : base(msg)
    {

        }
    }
}