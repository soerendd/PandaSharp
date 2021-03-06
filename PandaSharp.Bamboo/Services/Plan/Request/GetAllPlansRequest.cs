﻿using System;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Bamboo.Services.Plan.Response;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    [SupportsParameterAspect(typeof(IResultCountParameterAspect))]
    [SupportsParameterAspect(typeof(IGetAllPlansParameterAspect))]
    internal sealed class GetAllPlansRequest : PlanRequestBase<PlanListResponse>, IGetAllPlansRequest
    {
        public GetAllPlansRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public IGetAllPlansRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            GetAspect<IGetAllPlansParameterAspect>().IncludePlanInformation(expansions);
            return this;
        }

        public IGetAllPlansRequest WithMaxResult(int maxResult)
        {
            GetAspect<IResultCountParameterAspect>().MaxResults = maxResult;
            return this;
        }

        public IGetAllPlansRequest StartAtIndex(int startIndex)
        {
            GetAspect<IResultCountParameterAspect>().StartIndex = startIndex;
            return this;
        }

        protected override string GetResourcePath()
        {
            return "plan";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}
