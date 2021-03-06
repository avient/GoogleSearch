﻿using System.Configuration;

namespace GoogleTest.Infrastructure
{
    public static class Configuration

    {
        private const string Timeout = "Timeout";
        private const string BaseUrl = "BaseUrl";
        private const string Browser = "Browser";
        private const string TestDataSet = "TestDataSet";


        private static string GetParameterValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        public static string GetTimeout()
        {
            return GetParameterValue(Timeout);
        }

        public static string GetBaseUrl()
        {
            return GetParameterValue(BaseUrl);
        }

        public static string GetBrowser()
        {
            return GetParameterValue(Browser);
        }

        public static string GetTestDataSet()
        {
            return GetParameterValue(TestDataSet);
        }
    }
}