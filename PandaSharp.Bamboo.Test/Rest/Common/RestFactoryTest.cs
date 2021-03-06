using System;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Rest.Common;
using PandaSharp.Bamboo.Rest.Contract;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Rest.Common
{
    [TestFixture]
    public sealed class RestFactoryTest
    {
        [Test]
        public void CreateRequestTest()
        {
            var factory = new RestFactory(
                new Mock<IBambooOptions>().Object,
                new Mock<IRestSerializer>().Object);

            var request = factory.CreateRequest("TestResource", Method.PUT);

            request.ShouldNotBeNull();
            request.Resource.ShouldBe("TestResource");
            request.Method.ShouldBe(Method.PUT);
        }

        [Test]
        public void CreateClientTest()
        {
            var bambooOptions = new Mock<IBambooOptions>();
            bambooOptions
                .SetupGet(i => i.BaseUrl)
                .Returns("http://test.bamboo.com");

            var authentication = new Mock<IBambooAuthentication>();
            authentication
                .Setup(i => i.CreateAuthenticator())
                .Returns(new HttpBasicAuthenticator("TestUser", "TestPassword"));

            bambooOptions
                .Setup(i => i.Authentication)
                .Returns(authentication.Object);

            var serializer = new Mock<IRestSerializer>();
            serializer
                .SetupGet(i => i.DataFormat)
                .Returns(DataFormat.Json)
                .Verifiable();

            serializer
                .SetupGet(i => i.SupportedContentTypes)
                .Returns(new[] { "application/json" })
                .Verifiable();

            var factory = new RestFactory(bambooOptions.Object, serializer.Object);

            var client = factory.CreateClient();

            client.ShouldNotBeNull();
            client.Authenticator.ShouldNotBeNull();
            client.Authenticator.ShouldBeOfType<HttpBasicAuthenticator>();
            client.BaseUrl.ShouldBe(new Uri("http://test.bamboo.com"));

            serializer.Verify();
        }
    }
}