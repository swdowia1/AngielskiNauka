using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AngielskiNauka.Pages
{
    public class DeployModel : PageModel
    {
        public Root gitBaza;
        public async void OnGet()
        {
            string myJsonResponse = Git().Result;
            gitBaza = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        }
        private async Task<string> Git()
        {
            string url = "https://api.github.com/repos/swdowia1/AngielskiNauka/actions/runs";
            string token = ""; // Pamiętaj o bezpieczeństwie tokena!

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("CSharpApp");

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                    // GitHubActionsResponse result = JsonSerializer.Deserialize<GitHubActionsResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });




                }
                else
                    return null;

            }
        }
    }

    public class Actor
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public string user_view_type { get; set; }
        public bool site_admin { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Base
    {
        public string @ref { get; set; }
        public string sha { get; set; }
        public Repo repo { get; set; }
    }

    public class Committer
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Head
    {
        public string @ref { get; set; }
        public string sha { get; set; }
        public Repo repo { get; set; }
    }

    public class HeadCommit
    {
        public string id { get; set; }
        public string tree_id { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
    }

    public class HeadRepository
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool @private { get; set; }
        public Owner owner { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public string forks_url { get; set; }
        public string keys_url { get; set; }
        public string collaborators_url { get; set; }
        public string teams_url { get; set; }
        public string hooks_url { get; set; }
        public string issue_events_url { get; set; }
        public string events_url { get; set; }
        public string assignees_url { get; set; }
        public string branches_url { get; set; }
        public string tags_url { get; set; }
        public string blobs_url { get; set; }
        public string git_tags_url { get; set; }
        public string git_refs_url { get; set; }
        public string trees_url { get; set; }
        public string statuses_url { get; set; }
        public string languages_url { get; set; }
        public string stargazers_url { get; set; }
        public string contributors_url { get; set; }
        public string subscribers_url { get; set; }
        public string subscription_url { get; set; }
        public string commits_url { get; set; }
        public string git_commits_url { get; set; }
        public string comments_url { get; set; }
        public string issue_comment_url { get; set; }
        public string contents_url { get; set; }
        public string compare_url { get; set; }
        public string merges_url { get; set; }
        public string archive_url { get; set; }
        public string downloads_url { get; set; }
        public string issues_url { get; set; }
        public string pulls_url { get; set; }
        public string milestones_url { get; set; }
        public string notifications_url { get; set; }
        public string labels_url { get; set; }
        public string releases_url { get; set; }
        public string deployments_url { get; set; }
    }

    public class Owner
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public string user_view_type { get; set; }
        public bool site_admin { get; set; }
    }

    public class PullRequest
    {
        public string url { get; set; }
        public long id { get; set; }
        public int number { get; set; }
        public Head head { get; set; }
        public Base @base { get; set; }
    }

    public class Repo
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Repository
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool @private { get; set; }
        public Owner owner { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public string forks_url { get; set; }
        public string keys_url { get; set; }
        public string collaborators_url { get; set; }
        public string teams_url { get; set; }
        public string hooks_url { get; set; }
        public string issue_events_url { get; set; }
        public string events_url { get; set; }
        public string assignees_url { get; set; }
        public string branches_url { get; set; }
        public string tags_url { get; set; }
        public string blobs_url { get; set; }
        public string git_tags_url { get; set; }
        public string git_refs_url { get; set; }
        public string trees_url { get; set; }
        public string statuses_url { get; set; }
        public string languages_url { get; set; }
        public string stargazers_url { get; set; }
        public string contributors_url { get; set; }
        public string subscribers_url { get; set; }
        public string subscription_url { get; set; }
        public string commits_url { get; set; }
        public string git_commits_url { get; set; }
        public string comments_url { get; set; }
        public string issue_comment_url { get; set; }
        public string contents_url { get; set; }
        public string compare_url { get; set; }
        public string merges_url { get; set; }
        public string archive_url { get; set; }
        public string downloads_url { get; set; }
        public string issues_url { get; set; }
        public string pulls_url { get; set; }
        public string milestones_url { get; set; }
        public string notifications_url { get; set; }
        public string labels_url { get; set; }
        public string releases_url { get; set; }
        public string deployments_url { get; set; }
    }

    public class Root
    {
        public int total_count { get; set; }
        public List<WorkflowRun> workflow_runs { get; set; }
    }

    public class TriggeringActor
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public string user_view_type { get; set; }
        public bool site_admin { get; set; }
    }

    public class WorkflowRun
    {
        public long id { get; set; }
        public string name { get; set; }
        public string node_id { get; set; }
        public string head_branch { get; set; }
        public string head_sha { get; set; }
        public string path { get; set; }
        public string display_title { get; set; }
        public int run_number { get; set; }
        public string @event { get; set; }
        public string status { get; set; }
        public string conclusion { get; set; }
        public int workflow_id { get; set; }
        public long check_suite_id { get; set; }
        public string check_suite_node_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public List<PullRequest> pull_requests { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Actor actor { get; set; }
        public int run_attempt { get; set; }
        public List<object> referenced_workflows { get; set; }
        public DateTime run_started_at { get; set; }
        public TriggeringActor triggering_actor { get; set; }
        public string jobs_url { get; set; }
        public string logs_url { get; set; }
        public string check_suite_url { get; set; }
        public string artifacts_url { get; set; }
        public string cancel_url { get; set; }
        public string rerun_url { get; set; }
        public object previous_attempt_url { get; set; }
        public string workflow_url { get; set; }
        public HeadCommit head_commit { get; set; }
        public Repository repository { get; set; }
        public HeadRepository head_repository { get; set; }
    }
}
