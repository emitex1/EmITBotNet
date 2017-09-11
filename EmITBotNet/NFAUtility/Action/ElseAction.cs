using System;

namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    class ElseAction : AbstractAction
    {
        public ElseAction()
        {
            base.actionValue = -1;
        }

        public override bool isAction(object action)
        {
            //return (actionValue.GetType() == typeof(int) && (int)actionValue == -1 && ac action == null);
            return actionValue == action;
        }
    }
}
