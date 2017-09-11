namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class LambdaAction : AbstractAction
    {
        public LambdaAction()
        {
            base.actionValue = null;
        }

        public override bool isAction(object action)
        {
            return (actionValue == null && (action == null || action.ToString() == ""));
        }
    }
}
