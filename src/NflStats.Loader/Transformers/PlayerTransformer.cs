using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class PlayerTransformer : ITransformer<PlayerModel, Player>
    {
        public Player Transform(PlayerModel item)
        {
            var result = new Player()
            {
                Url = item.Url,
                Name = item.Name
            };

            if (item.Bio.Any(c => c.Key.ToLower() == "position"))
            {
                result.Position = item.Bio.Where(c => c.Key.ToLower() == "position").FirstOrDefault().Value;
            }

            if (item.Bio.Any(c => c.Key.ToLower() == "dob"))
            {
                string value = item.Bio.Where(c => c.Key.ToLower() == "dob").FirstOrDefault().Value;
                string[] parts = value.Split(" ");
                if (parts.Length > 1)
                {
                    result.Dob = DataHelper.ParseDateTime(parts[0], "MM/dd/yyyy");
                }
                else
                {
                    result.Dob = DataHelper.ParseDateTime(value, "MM/dd/yyyy");
                }
            }
            return result;
        }
    }
}
