﻿namespace Twitter.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string msg) : base(msg) { }
    }
}
