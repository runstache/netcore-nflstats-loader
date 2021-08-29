using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using Microsoft.Extensions.DependencyInjection;

namespace NflStats.Loader.Processors
{
    public interface IProcessor<T> where T : BasePlayerStatModel
    {
        void ProcessItems(List<T> models, ScheduleItem schedule);
    }
}
