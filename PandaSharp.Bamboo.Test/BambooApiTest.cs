using NUnit.Framework;
using Shouldly;

namespace PandaSharp.Bamboo.Test
{
    [TestFixture]
    public sealed class BambooApiTest
    {
        [Test]
        public void BambooApiConstructionTest()
        {
            var bambooApi = BambooApi.CreateWithBasicAuthentication("http://test.bamboo.com", "TestBob", "admin01");

            bambooApi.BuildRequest.ShouldNotBeNull();
            bambooApi.PlanRequest.ShouldNotBeNull();
            bambooApi.SearchRequest.ShouldNotBeNull();
            bambooApi.UsersRequest.ShouldNotBeNull();
            bambooApi.ProjectRequest.ShouldNotBeNull();
        }
    }
}