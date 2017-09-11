namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class StrAction : AbstractAction
    {
        public StrAction(string action)
        {
            base.actionValue = action;
        }

        public override bool isAction(object action)
        {
            return (actionValue.GetType() == typeof(string) && (string)actionValue == (string)action);
        }
    }
}
