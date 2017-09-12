namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    internal interface IAction
    {
        //internal object actionValue;
        object getActionValue();
        
        bool isAction(string action);

        //public string ToString();

        /*
        public static bool operator ==(IAction strAction, object action)
        {
            return true;
        }

        public static bool operator !=(IAction strAction, object action)
        {
            return false;
        }*/
    }
}
