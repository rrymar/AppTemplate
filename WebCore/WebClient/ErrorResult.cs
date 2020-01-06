﻿using System;
using System.Collections.Generic;

namespace WebCore.WebClient
{
    public class ErrorResult
    {
        public string RequestId { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public ErrorResult(IEnumerable<string> errors, string requestId)
        {
            Errors = errors;
            RequestId = requestId;
        }

        public ErrorResult()
        {
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Errors);
        }
    }
}