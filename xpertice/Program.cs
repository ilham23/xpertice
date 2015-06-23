using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;
using xpertice.Utility;


namespace xpertice
{
    class Program
    {
        private static string filename = System.IO.File.ReadAllText("D:\\Xpert Eleven - A.F.C. JDT..html");
        
        static void Main(string[] args)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
        
            htmlDoc.DetectEncodingAndLoad("D:\\Xpert Eleven - A.F.C. JDT..html");
            //htmlDoc.DetectEncodingAndLoad("http://xperteleven.com/players.aspx?dh=1&TeamID=92562&Boost=1");

            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                // Handle any parse errors as required

            }
            else
            {
                if (htmlDoc.DocumentNode != null)
                {
                    var htmlTablePlayers = htmlDoc.GetElementbyId("ctl00_cphMain_dgPlayers");

                    if (htmlTablePlayers != null)
                    {
                        var htmlPlayers = htmlTablePlayers.ChildNodes[1].ChildNodes;

                        int counter = 0;

                        Player player = new Player();
                        foreach (var htmlPlayer in htmlPlayers)
                        {
                            counter++; 
                            if (counter == 1 || counter == htmlPlayers.Count)
                            {
                                continue;
                            }

                            var playerName = player.GetName(htmlPlayer);
                            var playerSkill = player.GetSkill(htmlPlayer);
                            var playerForm = player.GetForm(htmlPlayer);
                            var playerAvgForm = player.GetAverageForm(htmlPlayer);
                            var playerFT = player.GetFormTendency(htmlPlayer);

                            Console.WriteLine(playerName + ": " + playerSkill + " - " + playerForm + " - " + playerAvgForm + " - " + playerFT);
                        }

                    }
                }
            }

            Console.ReadKey();
        }
    }
}
