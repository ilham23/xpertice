using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;


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
                    var htmlPlayers = htmlDoc.GetElementbyId("ctl00_cphMain_dgPlayers");

                    if (htmlPlayers != null)
                    {
                        var players = htmlPlayers.ChildNodes[1].ChildNodes;

                        int counter = 0;
                        foreach (var player in players)
                        {
                            counter++; 
                            if (counter == 1 || counter == players.Count)
                            {
                                continue;
                            }
                            var playerName = player.ChildNodes[3].ChildNodes[3].InnerHtml;
                            var playerSkill = player.ChildNodes[5].ChildNodes[1].;
                            Console.WriteLine(playerName + ": " + playerSkill);
                        }

                    }
                }
            }

            Console.ReadKey();
        }
    }
}
