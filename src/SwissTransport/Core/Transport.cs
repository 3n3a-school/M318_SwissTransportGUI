namespace SwissTransport.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SwissTransport.Models;

    public class Transport : ITransport, IDisposable
    {
        private const string WebApiHost = "https://transport.opendata.ch/v1/";
        private const string SearchCHApiHost = "https://timetable.search.ch/api/";

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


        /// <summary>
        /// Gets Locations (Stations) based on given Coordinates
        /// </summary>
        /// <param name="xCoord">The X-Coordinate</param>
        /// <param name="yCoord">The Y-Coordinate</param>
        /// <returns>List of Stations</returns>
        /// <exception cref="ArgumentOutOfRangeException">No valid coordinates provided</exception>
        public Stations GetStations(double xCoord, double yCoord)
        {
            if (xCoord <= 0 && yCoord <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(xCoord));
            }

            var uri = new Uri($"{SearchCHApiHost}completion.json?latlon={xCoord.ToString("G", CultureInfo.InvariantCulture)},{yCoord.ToString("G", CultureInfo.InvariantCulture)}&show_coordinates=1&accuracy=50"); // accuracy in meters

            List<SearchCHStation> stationList = this.GetObject<List<SearchCHStation>>(uri);
            List<Station> resultStations = new List<Station>();

            // Convert to list of Stations
            foreach (SearchCHStation sta in stationList)
            {
                Station station = new Station()
                {
                    Id = sta.Name,
                    Name = sta.Name,
                    Coordinate = new Coordinate()
                    {
                        Type = "coordinate",
                        XCoordinate = sta.XCoordinate,
                        YCoordinate = sta.YCoordinate,
                    },
                    Distance = sta.Distance,
                };
                resultStations.Add(station);
            }

            Stations result = new Stations()
            {
                StationList = resultStations,
            };

            return result;
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

        public Connections GetConnections(string fromStation, string toStation, int connectionLimit, DateTime departureDate, DateTime departureTime, string viaStation = null)
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

            if (viaStation != null && viaStation.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(viaStation));
            }

            // TODO: check departure time
            var uri = new Uri($"{WebApiHost}connections?from={fromStation}&to={toStation}&via={viaStation ?? string.Empty}&limit={connectionLimit}&date={departureDate.ToString("yyyy-MM-dd")}&time={departureTime.ToString("HH:mm")}");
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