using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            IDataTransformer service = new DataTransformer(config);
            /*
             * Тут использованы декораторы (Decorator), а точнее создаются тут.
             * Идея хорошая, т.к. объекту динамически
             * добавляются новые обязанности. Конкретно тут применяется т.к. происходит модификация
             * аргументов (отчёта) в зависимости от заданных параметров (config).
             * 
             * Кроме того сам процесс создания похож на... фабричный метод? Вроде как он.
             * Плюсы использования в том, что параметры создания задаются с помощью config.
             * Также сам процесс создания отделён от класса и задаётся "динамически".
             */
            if (config.WithData)
            {
                service = new WithDataReportTransformer(service);
            }

            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service);
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service);
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service);
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}