using System;
using System.Collections.Generic;
using FluentAssertions;
using Hydra.Discovery.SupportedProperties;
using TestHydraApi;
using Xunit;

namespace Lernaean.Hydra.Tests.ApiDocumentation
{
    public class ConcatenatedClassIdAndPropertyNameTests
    {
        private readonly ConcatenatedClassIdAndPropertyName _policy;

        public ConcatenatedClassIdAndPropertyNameTests()
        {
            _policy = new ConcatenatedClassIdAndPropertyName();
        }

        [Theory]
        [InlineData("http://example.org/ontolgy#Issue", "http://example.org/ontolgy#Issue/titel")]
        [InlineData("http://example.org/ontolgy/Issue", "http://example.org/ontolgy/Issue#titel")]
        public void Should_concatenate_with_separator_depending_on_class_id(string issueClassStr, string expectedPropertyId)
        {
            // given
            Uri issueClassId = new Uri(issueClassStr);

            // when
            var propertyId = _policy.GetPropertyId(typeof(Issue).GetProperty("Title"), "titel", issueClassId);

            // then
            propertyId.Should().Be(expectedPropertyId);
        }   
    }
}