namespace PandaSharp.Bamboo.Services.Common.Contract
{
    internal interface IResultCountParameterAspect
    {
        int? StartIndex { get; set; }

        int? MaxResults { get; set; }
    }
}