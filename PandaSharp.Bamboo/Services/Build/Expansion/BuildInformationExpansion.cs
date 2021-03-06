using System;
using System.Collections.Generic;
using PandaSharp.Bamboo.Services.Common.Expansion;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Build.Expansion
{
    internal sealed class BuildInformationExpansion : RequestExpansionBase, IBuildInformationExpansion
    {
        private PlanListInformationExpansion _planListInformationExpansion;

        public BuildInformationExpansion()
            : base(null)
        {
        }

        public void IncludingArtifacts()
        {
            AddExpansionLevel("artifacts");
        }

        public void IncludingComments()
        {
            AddExpansionLevel("comments");
        }

        public void IncludingLabels()
        {
            AddExpansionLevel("labels");
        }

        public void IncludingJiraIssues()
        {
            AddExpansionLevel("jiraIssues");
        }

        public void IncludingVariables()
        {
            AddExpansionLevel("variables");
        }

        public void IncludingStages()
        {
            AddExpansionLevel("stages");
        }

        public void IncludingChanges()
        {
            AddExpansionLevel("changes");
        }

        public void IncludingMetaData()
        {
            AddExpansionLevel("metadata");
        }

        public void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            _planListInformationExpansion = new PlanListInformationExpansion("plan");
            foreach (var expansion in expansions)
            {
                expansion(_planListInformationExpansion);
            }
        }

        protected override IEnumerable<RequestExpansionBase> GetSubExpansionLevel()
        {
            if (_planListInformationExpansion != null)
            {
                yield return _planListInformationExpansion;
            }
        }
    }
}