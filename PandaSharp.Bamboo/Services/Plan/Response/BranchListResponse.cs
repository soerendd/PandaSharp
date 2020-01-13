using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Plan.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(BranchListRootElementResponseConverter))]
    [JsonItems("branch")]
    public sealed class BranchListResponse : ListResponseBase<BranchResponse>
    {
    }
}