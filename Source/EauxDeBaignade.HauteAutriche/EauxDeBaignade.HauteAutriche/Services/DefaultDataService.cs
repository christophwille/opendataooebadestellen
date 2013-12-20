using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CsvHelper;
using CsvHelper.Configuration;
using EauxDeBaignade.HauteAutriche.Common;
using EauxDeBaignade.HauteAutriche.Model;

namespace EauxDeBaignade.HauteAutriche.Services
{
    public class DefaultDataService : IDataService
    {
        private const string CsvUrl = "http://data.ooe.gv.at/files/cms/Badestellen-Landesmessnetz.csv";

        public async Task<List<Badestelle>> RetrieveAsync()
        {
            var data = await RetrieveAllAsync().ConfigureAwait(false);

            var latest = from b in data 
                         group b by b.Name into g 
                         select g.OrderByDescending(b => b.Datum).First();

            return latest.ToList();
        }

        public async Task<List<Badestelle>> RetrieveAllAsync()
        {
            string data = await DownloadClient.GetAsStringAsync(CsvUrl).ConfigureAwait(false);
            var list = new List<Badestelle>();

            if (null != data)
            {
                var csvConfig = new CsvConfiguration()
                {
                    Delimiter = ";",
                    CultureInfo = new CultureInfo("de")
                };

                using (var reader = new CsvReader(new StringReader(data), csvConfig))
                {
                    while (reader.Read())
                    {
                        try
                        {
                            var b = new Badestelle()
                            {
                                Name = reader.GetField<string>((int)BadestellenCsvFields.Name).Trim(),
                                Datum = reader.GetField<DateTime>((int)BadestellenCsvFields.Datum),
                                EColi = reader.GetField<string>((int)BadestellenCsvFields.EColi).Trim(),
                                Enterokokken = reader.GetField<string>((int)BadestellenCsvFields.Enterokokken).Trim(),
                                Bakterien = reader.GetField<string>((int)BadestellenCsvFields.Bakterien).Trim(),
                                Lufttemperatur = reader.GetField<string>((int)BadestellenCsvFields.Lufttemperatur).Trim(),
                                WolkenAchtel = reader.GetField<string>((int)BadestellenCsvFields.WolkenAchtel).Trim(),
                                Oberflaeche = reader.GetField<string>((int)BadestellenCsvFields.Oberflaeche).Trim(),
                                Sichttiefe = reader.GetField<string>((int)BadestellenCsvFields.Sichttiefe).Trim(),
                                pH = reader.GetField<string>((int)BadestellenCsvFields.pH).Trim(),
                                Sauerstoffsaettigung = reader.GetField<string>((int)BadestellenCsvFields.Sauerstoffsaettigung).Trim(),
                                Wassertemperatur = reader.GetField<string>((int)BadestellenCsvFields.Wassertemperatur).Trim(),
                            };

                            list.Add(b);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(reader.GetField<string>((int)BadestellenCsvFields.Name));
                        }
                    }
                }

            }

            return list;
        }
    }
}
