using CzlonkowieZespoluBackend.Domain.Entities;
using CzlonkowieZespoluBackend.Domain.Interfaces;
using Newtonsoft.Json.Linq;

namespace CzlonkowieZespoluBackend.Infrastucture.Services
{
    public class RandomUserService : IRandomUserService
    {
        private const string BASE_URL = "https://randomuser.me/api/?results=";

        public async Task<List<TeamMember>> GetRandomTeamMembers(int num)
        {
            var url = BASE_URL + num.ToString();
            var memberList = new List<TeamMember>();

            using (var client = new HttpClient()) 
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(content);

                    foreach (var item in jsonObject["results"]!)
                    {
                        var member = new TeamMember()
                        {
                            Name = (string)item["name"]!["first"]! + " " + (string)item["name"]!["last"]!,
                            Email = (string)item["email"]!,
                            PhoneNumber = (string)item["phone"]!,
                            PhotoUrl = (string)item["picture"]!["large"]!,
                            IsActive = true,
                            CreatedDate = DateTime.UtcNow,
                        };
                        memberList.Add(member);
                    }
                }
            }
            return memberList;
        }
    }
}
