﻿namespace SwissTransport.Core
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SwissTransport.Models;

    public class Transport : ITransport, IDisposable
    {
        private const string WebApiHost = "https://transport.opendata.ch/v1/";

        private readonly HttpClient httpClient = new HttpClient();

        public Stations GetStations(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            var uri = new Uri($"{WebApiHost}locations?query={query}&type=station");
            return this.GetObject<Stations>(uri);
        }

        public StationBoardRoot GetStationBoard(string station, string id)
        {
            if (string.IsNullOrEmpty(station))
            {
                throw new ArgumentNullException(nameof(station));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var uri = new Uri($"{WebApiHost}stationboard?station={station}&id={id}");
            return this.GetObject<StationBoardRoot>(uri);
        }

        public Connections GetConnections(string fromStation, string toStation, int connectionLimit, DateTime departureDate, DateTime departureTime)
        {
            if (string.IsNullOrEmpty(fromStation))
            {
                throw new ArgumentNullException(nameof(fromStation));
            }

            if (string.IsNullOrEmpty(toStation))
            {
                throw new ArgumentNullException(nameof(toStation));
            }

            if (connectionLimit < 1 || connectionLimit > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(connectionLimit));
            }

            // TODO: check departure time
            var uri = new Uri($"{WebApiHost}connections?from={fromStation}&to={toStation}&limit={connectionLimit}&date={departureDate.ToString("yyyy-MM-dd")}&time={departureTime.ToString("HH:mm")}");
            return this.GetObject<Connections>(uri);
        }

        public void Dispose()
        {
            this.httpClient?.Dispose();
        }

        private T GetObject<T>(Uri uri)
        {
            HttpResponseMessage response = this.httpClient
                .GetAsync(uri)
                .GetAwaiter()
                .GetResult();
            string content = response.Content
                .ReadAsStringAsync()
                .GetAwaiter()
                .GetResult();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}