using SocialMediaAPI.Data;
using SocialMediaAPI.Models;

namespace SocialMediaAPI
{
    public static class DbInitializer
    {
        public static void Initialize(Data.DbInitializer context)
        {
            if (!context.Accounts.Any())
            {
                var sampleAccounts = SampleData.GenerateSampleAccounts();
                var sampleComments = SampleCommentData.GenerateSampleComments(sampleAccounts);

                foreach (var account in sampleAccounts)
                {
                    context.Accounts.Add(account);
                }

                foreach (var comment in sampleComments)
                {
                    context.Comments.Add(comment);
                }

                context.SaveChanges();
            }
        }
    }

}