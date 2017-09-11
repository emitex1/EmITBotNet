using System;
using System.Text.RegularExpressions;

namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class RegexAction : AbstractAction
    {
        public RegexAction(string regexExpr)
        {
            base.actionValue = regexExpr;
        }

        public override bool isAction(object action)
        {
            return action.GetType() == typeof(string) && Regex.IsMatch(action.ToString(), base.actionValue.ToString());
        }
    }
}
