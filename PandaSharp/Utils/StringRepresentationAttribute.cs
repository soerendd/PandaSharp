﻿using System;

namespace PandaSharp.Utils
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class StringRepresentationAttribute : Attribute
    {
        public string AsString { get; }

        public StringRepresentationAttribute(string stringRepresentation)
        {
            AsString = stringRepresentation;
        }
    }
}