﻿using Hydra.Core;
using Newtonsoft.Json.Linq;
using Xunit;
using Vocab = Hydra.Hydra;

namespace Lernaean.Hydra.Tests.Serialization
{
    public class ClassSerializationTests : SerializationTestsBase
    {
        [Fact]
        public void Should_serialize_hydraClass_title()
        {
            // given
            var collection = new Class("http://example.api/Class") { Title = "Some class" };

            // when
            dynamic jsonLd = Serialize(collection);

            // then
            Assert.Equal("Some class", jsonLd[Vocab.title].ToString());
        }
    }
}