namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class LambdaAction : IAction
    {
        internal object actionValue;

        public LambdaAction()
        {
            this.actionValue = null;
        }

        public object getActionValue()
        {
            return actionValue;
        }

        public bool isAction(string action)
        {
            return (action == null || action.Equals(""));
        }

        /*
        public static bool operator ==(LambdaAction lambdaAction, object action)
        {
            return (lambdaAction.actionValue == null && (action == null || action.ToString() == ""));
        }

        public static bool operator !=(LambdaAction lambdaAction, object action)
        {
            return (lambdaAction.actionValue != null || (action != null && !action.ToString().Equals("")));
        }*/
    }
}
