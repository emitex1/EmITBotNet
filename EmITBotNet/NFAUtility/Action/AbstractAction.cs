namespace ir.EmIT.EmITBotNet.NFAUtility.Action
{
    internal abstract class AbstractAction
    {
        internal object actionValue;

        public abstract bool isAction(object action);

        public override string ToString()
        {
            return actionValue.ToString();
        }

        //todo نوشتن عملگر مساوی برای اکشن ها
    }
}
