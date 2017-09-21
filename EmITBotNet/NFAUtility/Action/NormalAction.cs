namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class NormalAction : IAction
    {
        internal string actionValue;

        public NormalAction(string action)
        {
            actionValue = action;
        }

        public object getActionValue()
        {
            return actionValue;
        }

        public bool isAction(string action)
        {
            //return (actionValue.GetType() == typeof(string) && actionValue.Equals(action.ToString()));
            return actionValue.Equals(action);
        }

        public bool isLambdaAction()
        {
            return false;
        }


        /*
        public static bool operator ==(StrAction strAction, object action)
        {
            return (strAction.actionValue.GetType() == typeof(string) && strAction.actionValue.ToString().Equals(action.ToString()));
        }

        public static bool operator !=(StrAction strAction, object action)
        {
            return (strAction.actionValue.GetType() != typeof(string) || !strAction.actionValue.ToString().Equals(action.ToString()));
        }*/
    }
}
