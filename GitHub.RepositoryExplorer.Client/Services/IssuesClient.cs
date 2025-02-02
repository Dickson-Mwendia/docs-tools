﻿using System.Net.Http.Json;
using System.Web;

namespace GitHub.RepositoryExplorer.Client.Services;

public sealed class IssuesClient
{
    private readonly HttpClient _httpClient;
    private readonly Func<DateOnly, string> _encode =
        static string (DateOnly date) => HttpUtility.UrlEncode($"{date:o}");

    public IssuesClient(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient(HttpClientNames.IssuesApi);
    }

    public async Task<DailyRecord?> GetIssuesForDateAsync(
        Repository state, DateOnly date)
    {
        var (org, repo) = (state.Org, state.Repo);
        var route =  _encode(date);
        var dailyRecord =
            await _httpClient.GetFromJsonAsync<DailyRecord>(
                $"api/issues/{org}/{repo}/{route}");

        return dailyRecord;
    }

    public async Task<IEnumerable<DailyRecord>?> GetIssuesForDateRangeAsync(
        Repository state, DateOnly from, DateOnly to)
    {
        var (org, repo) = (state.Org, state.Repo);
        var queryString =
            $"from={_encode(from)}&to={_encode(to)}";

        var dailyRecords =
            await _httpClient.GetFromJsonAsync<IEnumerable<DailyRecord>>(
                $"api/issues/{org}/{repo}?{queryString}");

        return dailyRecords;
    }
}
