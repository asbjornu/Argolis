﻿using FluentAssertions;
using Hydra.Discovery.SupportedClasses;
using TestHydraApi;
using Xunit;

namespace Lernaean.Hydra.Tests.ApiDocumentation
{
    public class DefaultSupportedClassMetaProviderTests
    {
        private readonly DefaultSupportedClassMetaProvider metaProvider;

        public DefaultSupportedClassMetaProviderTests()
        {
            this.metaProvider = new DefaultSupportedClassMetaProvider();
        }

        [Fact]
        public void Should_provide_some_default_description()
        {
            // when
            var meta = this.metaProvider.GetMeta(typeof(Issue));

            // then
            meta.Description.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void Should_provide_some_default_title()
        {
            // when
            var meta = this.metaProvider.GetMeta(typeof(Issue));

            // then
            meta.Title.Should().NotBeNullOrWhiteSpace();
        }
    }
}