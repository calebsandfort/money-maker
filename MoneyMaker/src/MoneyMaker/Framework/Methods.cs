using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyMaker.Framework
{
    public static class Methods
    {
        #region Public - DownloadPageStringAsync
        public async static Task<String> DownloadPageStringAsync(String url)
        {
            using (WebClient wc = new WebClient())
            {
                bool failed = false;

                try
                {
                    return await wc.DownloadStringTaskAsync(url);
                }
                catch (WebException)
                {
                    failed = true;
                }

                if (failed)
                {
                    try
                    {
                        Thread.Sleep(2500);
                        return await wc.DownloadStringTaskAsync(url);
                    }
                    catch (WebException)
                    {
                        return String.Empty;
                    }
                }

                return String.Empty;
            }
        }
        #endregion

        #region GetNumber
        public static int GetNumber(this String val)
        {
            int ret = -1;

            if (!String.IsNullOrEmpty(val) && (val.Contains("st") || val.Contains("nd") || val.Contains("th")))
            {
                if (val.Contains("("))
                {
                    ret = Int32.Parse(val.Substring(val.IndexOf("(")).Replace("(", String.Empty).Replace(")", String.Empty).Replace("st", String.Empty).Replace("nd", String.Empty).Replace("th", String.Empty).Replace("rd", String.Empty));
                }
                else
                {
                    ret = Int32.Parse(val.Replace("st", String.Empty).Replace("nd", String.Empty).Replace("th", String.Empty).Replace("rd", String.Empty));
                }
            }

            return ret;
        }
        #endregion

        #region StripDay
        public static String StripDay(this String val)
        {
            return val.Replace("Sun ", String.Empty).Replace("Mon ", String.Empty).Replace("Thu ", String.Empty).Replace("Sat ", String.Empty);
        }
        #endregion
    }
}
