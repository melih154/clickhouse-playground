using Clickhouse.Kata.API.Models;
using Clickhouse.Kata.API.Options;
using ClickHouse.Client;
using ClickHouse.Client.ADO;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Clickhouse.Kata.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitController(
        IClickHouseConnection clickHouseConnection,
        ILogger<GitController> logger) : ControllerBase
    {
        [HttpGet("/commits/days")]
        public async Task<ActionResult<IEnumerable<GitCommitWeekDay>>> GetCommitDays()
            => Ok(await clickHouseConnection.QueryAsync<GitCommitWeekDay>(GetCommitDaysQuery()));

        private static string GetCommitDaysQuery () => @"
            SELECT
                day_of_week as DayOfWeekNum,
                count() AS NumberOfCommits
            FROM git.commits
            GROUP BY dayOfWeek(time) AS day_of_week";
    }
}
