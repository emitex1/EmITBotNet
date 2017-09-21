namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class ElseAction : IAction
    {
        internal int actionValue;

        public ElseAction()
        {
            actionValue = -1;
        }

        public object getActionValue()
        {
            return actionValue;
        }

        public bool isAction(string action)
        {
            //return (actionValue.GetType() == typeof(int) && (int)actionValue == -1 && ac action == null);
            //return actionValue == action;
            return true;
        }

        public bool isLambdaAction()
        {
            return false;
        }

        /*
        public static bool operator ==(ElseAction elseAction, object action)
        {
            return true;
        }

        public static bool operator !=(ElseAction elseAction, object action)
        {
            return true;
        }*/
    }
}
