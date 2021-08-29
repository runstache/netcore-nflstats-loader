using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using System.Collections.Generic;

namespace NflStats.Loader.Processors
{
    public class ReceivingProcessor : BasePlayerStatProcessor, IProcessor<ReceivingModel>
    {
        private readonly IRepository repo;

        public ReceivingProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }
        
        public void ProcessItems(List<ReceivingModel> models, ScheduleItem schedule)
        {
            ITransformer<ReceivingModel, ReceivingStat> transformer = new ReceivingTransformer();
            foreach (ReceivingModel model in models)
            {
                var player = ProcessPlayer(model.Player);
                var stat = transformer.Transform(model);
                AddCommonInfo(stat, player.Id, schedule);
                AddOriginalId(stat);
                repo.Save(stat);
            }
        }
    }
}
