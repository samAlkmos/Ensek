using Ensek.BLL.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Ensek.Entity.Entities;
using System.Linq;
using System;
using Ensek.DTO.DTOs;
using Ensek.DAL.Repositories.IRepositories;
using System.Text.RegularExpressions;

namespace Ensek.BLL.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        private IAccountService _accountService;
        private IMeterReadingRepository _meterReadingRepository;

        public MeterReadingService(IAccountService accountService, IMeterReadingRepository meterReadingRepository)
        {
            _accountService = accountService;
            _meterReadingRepository = meterReadingRepository;
        }

        private Task<MeterReadingModel?> GetReading(int accountId, string ReadingDate)
        {
            return _meterReadingRepository.Get(r => r.AccountId == accountId && r.MeterReadingDateTime == ReadingDate);
        }

        private async Task SaveReading(MeterReadingModel meterReadingDTO)
        {
            await _meterReadingRepository.Add(meterReadingDTO);
        }

        public async Task<SummaryDTO> UploadReadings(string fileName)
        {

            var accounts = await _accountService.GetAccounts();
            var readings = GetReadingsFromCsv(fileName);
            var validReadings = readings.Where(r => Regex.IsMatch(r.MeterReadValue, @"^\d{1,5}$")).ToList();

            var savedCounts = 0;
            var existingCounts = 0;
            var notValidRecords = readings.Count - validReadings.Count;

            foreach (var reading in validReadings)
            {
                var exisitngReading = await GetReading(reading.AccountId, reading.MeterReadingDateTime);
               
                if (exisitngReading == null)
                {
                    reading.Id = Guid.NewGuid();
                    await SaveReading(reading);
                    savedCounts++;
                }
                else
                {
                    existingCounts++;
                }

            }

            return new SummaryDTO()
            {
                ExisitngNo = existingCounts,
                InvalidNo = notValidRecords,
                TotalReading = readings.Count,
                ValidNo = validReadings.Count,
                NewReading = savedCounts

            };


        }

        private List<MeterReadingModel> GetReadingsFromCsv(string fileName)
        {

            using var streamReader = File.OpenText(fileName);
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            var MeterReadings = csvReader.GetRecords<MeterReadingModel>();

            return MeterReadings.ToList();
        }
    }
}
