﻿using System;
using _04Telephony.Core;
using _04Telephony.Exceptions;
using _04Telephony.Interfaces;

namespace _04Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
