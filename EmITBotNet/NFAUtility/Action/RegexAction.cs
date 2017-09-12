using System;
using System.Text.RegularExpressions;

namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class RegexAction : IAction
    {
        internal string actionValue;

        public RegexAction(string regexExpr)
        {
            actionValue = regexExpr;
        }

        public object getActionValue()
        {
            return actionValue;
        }

        public bool isAction(string action)
        {
            //return action.GetType() == typeof(string) && Regex.IsMatch(action.ToString(), actionValue);
            return Regex.IsMatch(action, actionValue);
        }

        /*
        public static bool operator ==(RegexAction regexAction, object action)
        {
            return action.GetType() == typeof(string) && Regex.IsMatch(action.ToString(), regexAction.actionValue.ToString());
        }

        public static bool operator !=(RegexAction regexAction, object action)
        {
            return action.GetType() != typeof(string) || !Regex.IsMatch(action.ToString(), regexAction.actionValue.ToString());
        }*/

        /*public static bool operator ==(RegexAction ra1, RegexAction ra2)
        {
            return ra1.actionValue == ra2.actionValue;
        }

        public static bool operator !=(RegexAction ra1, RegexAction ra2)
        {
            return ra1.actionValue != ra2.actionValue;
        }*/
    }
}
