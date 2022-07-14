﻿using Abp.Application.Services;
using Abp.Extensions;
using MyTraining1121AngularDemo.ApiClient;

namespace MyTraining1121AngularDemo
{
    public abstract class ProxyAppServiceBase : IApplicationService
    {
        public AbpApiClient ApiClient { get; set; }

        public const string ApiBaseUrl = "api/services/app/";

        private readonly string _serviceUrlSegment;

        protected ProxyAppServiceBase()
        {
            _serviceUrlSegment = GetServiceUrlSegmentByConvention();
        }

        protected string GetEndpoint(string methodName)
        {
            return ApiBaseUrl + _serviceUrlSegment + "/" + methodName;
        }

        private string GetServiceUrlSegmentByConvention()
        {
            return GetType()
                .Name
                .RemovePreFix("Proxy")
                .RemovePostFix("AppServiceProxy", "AppService");
        }
    }
}