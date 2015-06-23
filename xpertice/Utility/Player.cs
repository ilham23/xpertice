using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using xpertice.Common;

namespace xpertice.Utility
{
    class Player
    {
        public string GetName(HtmlNode htmlNode)
        {
            return htmlNode.ChildNodes[3].ChildNodes[3].InnerHtml;
        }

        public string GetSkill(HtmlNode htmlNode)
        {
            return htmlNode.ChildNodes[5].ChildNodes[1].Attributes[1].Value;
        }

        public string GetForm(HtmlNode htmlNode)
        {
            return htmlNode.ChildNodes[7].ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].Attributes[1].Value;
        }

        public string GetAverageForm(HtmlNode htmlNode)
        {
            return htmlNode.ChildNodes[7].ChildNodes[1].ChildNodes[0].ChildNodes[1].ChildNodes[0].ChildNodes[0].Attributes[0].Value;
        }

        public int GetFormTendency(HtmlNode htmlNode)
        {
            var strFT = htmlNode.ChildNodes[8].ChildNodes[1].Attributes[2].Value;
            int FT = 0;

            string[] keys =
            {
                FormTendency.ArrowUp, FormTendency.ArrowHalfUp, FormTendency.ArrowNeutral, FormTendency.ArrowHalfDown,
                FormTendency.ArrowDown
            };

            string sKeyResult = keys.FirstOrDefault<string>(strFT.Contains);

            switch (sKeyResult)
            {
                case FormTendency.ArrowUp:
                    FT = 4;
                    break;
                case FormTendency.ArrowHalfUp:
                    FT = 3;
                    break;
                case FormTendency.ArrowNeutral:
                    FT = 2;
                    break;
                case FormTendency.ArrowHalfDown:
                    FT = 1;
                    break;
                case FormTendency.ArrowDown:
                    FT = 0;
                    break;
            }

            return FT;
        }
    }
}
