using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal sealed class BranchListResponseConverter : JsonListResponseConverterBase<BranchResponse>
    {
        protected override string ItemsPath => "branch";
    }
}