using PandaSharp.Services.Build.Response;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Services.Build.Contract
{
    public interface IBuildRequest : IRequestBase<BuildResponse>
    {
        IBuildRequest IncludingArtifacts();

        IBuildRequest IncludingComments();

        IBuildRequest IncludingLabels();

        IBuildRequest IncludingJiraIssues();

        IBuildRequest IncludingVariables();

        IBuildRequest IncludingStages();

        IBuildRequest IncludingChanges();

        IBuildRequest IncludingMetaData();
    }
}