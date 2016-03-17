﻿using System;
using Hydra.Annotations;

namespace TestHydraApi
{
    [SupportedClass("http://example.api/o#Issue")]
    public class Issue
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int LikesCount { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsResolved { get; set; }
    }
}