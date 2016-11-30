using System.Collections.Generic;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    class DataTransformer : IDataTransformer
    {
        private readonly ReportConfig _config;

        /*
         * Адаптер (Object Adapter). Расширяем функционал какого то не известного мне класса
         * ReportConfig, добавляя метод TransformData. ITarget = IDataTransformer
         */

        public DataTransformer(ReportConfig config)
        {
            _config = config;    
        }

        public Report TransformData(DataRow[] data)
        {
            return new Report
            {
                Config = _config,
                Data = new DataRow[0],
                Rows = new List<ReportRow>()
            };
        }
    }
}
