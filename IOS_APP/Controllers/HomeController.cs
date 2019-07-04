using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IOS_APP.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                var github = new GitHubClient(new ProductHeaderValue("semantechs"));
                var user = await github.User.Get("semantechs");
                github.Credentials = new Credentials("e03e47135827655b75392f40b4c45f2a6ef41e1f");
                // github variables
                var owner = "semantechs";
                var repo = "iosTest";
                var filesha = "https://github.com/semantechs/iosTest/blob/master/path/file.txt";
                var branch = "master";
                var headMasterRef = "heads/master";
                // Get reference of master branch
                var masterReference = await github.Git.Reference.Get(owner, repo, headMasterRef);
                // Get the laster commit of this branch
                var latestCommit = await github.Git.Commit.Get(owner, repo, masterReference.Object.Sha);
                // create file

                var createChangeSet = await github.Repository.Content.GetAllContents(
                                                owner,
                                                repo,
                                                //"path/file.txt"
                                                "IOS_APP/Views/Home/Index.cshtml"
                                             );


                //// update file
                var updateChangeSet = await github.Repository.Content.UpdateFile(
                                                owner,
                                                repo,
                                                "IOS_APP/Views/Home/Index.cshtml",
                                                new UpdateFileRequest("File update",
                                                                      "Hello Usman!",
                                                                      createChangeSet[0].Sha,
                                                                      branch));
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}