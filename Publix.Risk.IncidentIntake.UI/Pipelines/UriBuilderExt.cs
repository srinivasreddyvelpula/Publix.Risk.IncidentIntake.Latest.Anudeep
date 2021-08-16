﻿using System;
using System.Collections.Specialized;

namespace Publix.Risk.IncidentIntake.UI.Pipelines
{
    public class UriBuilderExt
    {
        private readonly NameValueCollection collection;
        private readonly UriBuilder builder;

        public UriBuilderExt(string uri)
        {
            builder = new UriBuilder(uri);
            collection = System.Web.HttpUtility.ParseQueryString(string.Empty);
        }

        public void AddParameter(string key, string value)
        {
            collection.Add(key, value);
        }

        public Uri Uri
        {
            get
            {
                builder.Query = collection.ToString();
                return builder.Uri;
            }
        }

    }
}