using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BranchListResponse, BranchResponse>))]
    [JsonItems("branch")]
    [JsonRootElement("branches")]
    public sealed class BranchListResponse : ListResponseBase<BranchResponse>
    {
    }
}