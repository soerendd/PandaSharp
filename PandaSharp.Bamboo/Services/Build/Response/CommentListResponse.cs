using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<CommentListResponse, CommentResponse>))]
    [JsonRootElementPath("comments")]
    [JsonListContentPath("comments.comment.[*]")]
    public sealed class CommentListResponse : ListResponseBase<CommentResponse>
    {
    }
}