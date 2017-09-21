using System.Collections.Generic;
using System.Linq;
using ir.EmIT.EmITBotNet.NFAUtility.Action;
using Telegram.Bot.Types;

namespace ir.EmIT.EmITBotNet.NFAUtility
{
    //todo گذاشتن کامنت و region

    public class EmITNFA
    {
        private List<RuleNextAction> ruleNextActions;
        private List<RulePostFunction> rulePostFunctions;


        public EmITNFA()
        {
            ruleNextActions = new List<RuleNextAction>();
            rulePostFunctions = new List<RulePostFunction>();
        }

        public void addRule(BotState srcState, string action, BotState dstState)
        {
            addRuleNextAction(srcState, new NormalAction(action), dstState);
        }

        public void addRule(BotState srcState, int action, BotState dstState)
        {
            addRuleNextAction(srcState, new NormalAction(action.ToString()), dstState);
        }

        public void addRule(BotState srcState, int fromAction, int toAction, BotState dstState)
        {
            for (int i = fromAction; i <= toAction; i++)
            {
                addRuleNextAction(srcState, new NormalAction(i.ToString()), dstState);
            }            
        }

        public void addRule(BotState srcState, BotState dstState)
        {
            addRuleNextAction(srcState, new LambdaAction(), dstState);
        }

        public void addRegexRule(BotState srcState, string regexExpr, BotState dstState)
        {
            addRuleNextAction(srcState, new RegexAction(regexExpr), dstState);
        }

        public void addElseRule(BotState srcState, BotState dstState)
        {
            addRuleNextAction(srcState, new ElseAction(), dstState);
        }


        private void addRuleNextAction(BotState srcState, IAction action, BotState dstState)
        {
            ruleNextActions.Add(new RuleNextAction(srcState, action, dstState));
        }

        public void addRulePostFunction(BotState newState, BotState preState, PostFunction function)
        {
            rulePostFunctions.Add(new RulePostFunction(newState, preState, function));
        }

        public void addRulePostFunction(BotState newState, PostFunction function)
        {
            rulePostFunctions.Add(new RulePostFunction(newState, BotStates.Invalid, function));
        }

        /*
        private int getNextState(int srcState, int action)
        {
            var matchedRules = rules.Where(r => r.srcState == srcState && r.action == action);
            if (matchedRules.Count() > 0)
                return matchedRules.First().dstState;
            else
                return -1;
        }*/

        public BotState getNextState(BotState srcState, string action)
        {
            var matchedRules = ruleNextActions.Where(r => r.srcState == srcState && r.action.isAction(action));
            if (matchedRules.Count() > 0)
                return matchedRules.First().dstState;
            else
            {
                var elseRule = ruleNextActions.Where(r => r.srcState == srcState && r.action.GetType() == typeof(ElseAction));
                if (elseRule.Count() > 0)
                    return elseRule.First().dstState;
                else
                    return BotStates.Invalid;
            }
        }

        public BotState getNextState(BotState srcState)
        {
            var matchedRules = ruleNextActions.Where(r => r.srcState == srcState && r.action.isAction(null));
            if (matchedRules.Count() > 0)
                return matchedRules.First().dstState;
            else
                return BotStates.Invalid;
        }

        //public void move(int srcState, string action)
        public void move(Message m, SessionData currentBotData)
        {
            //int nextState = getNextState(srcState, action);
            //var spfList = statePostFunctions.Where(spf => spf.preState == srcState && spf.nextState == nextState);
            //if (spfList.Count() > 0)
            //    return spfList.First().function;
            //else
            //{
            //    spfList = statePostFunctions.Where(spf => spf.preState == -1 && spf.nextState == nextState);
            //    if (spfList.Count() > 0)
            //        return spfList.First().function;
            //    else
            //        return (PostFunctionData pfd) => { };
            //}

            string action = m.Text;
            // بدست آوردن وضعیت بعدی، با توجه به وضعیت فعلی و حرکت انجام شده
            BotState nextState = getNextState(currentBotData.botState, action);
            // ذخیره کردن وضعیت فعلی ، در متغیر وضعیت قبلی
            currentBotData.preBotState = currentBotData.botState;
            // به روز رسانی وضعیت فعلی به وضعیت بعدی
            currentBotData.botState = nextState;
            // گرفتن کار مشخص شده پس از رسیدن به وضعیت جدید
            PostFunction postFunction = getPostFunction(currentBotData.preBotState, nextState);
            // انجام کار مشخص شده برای وضعیت جدید
            postFunction(new PostFunctionData(m, currentBotData));
        }

        public bool currentStateHasLambdaAction(SessionData currentBotData)
        {
            return ruleNextActions.Where(r => r.srcState == currentBotData.botState && r.action.isLambdaAction()).Count() > 0;
        }

        public PostFunction getPostFunction(BotState preState, BotState nextState)
        {
            var spfList = rulePostFunctions.Where(spf => spf.preState == preState && spf.nextState == nextState);
            if (spfList.Count() > 0)
                return spfList.First().function;
            else
            {
                spfList = rulePostFunctions.Where(spf => spf.preState == -1 && spf.nextState == nextState);
                if (spfList.Count() > 0)
                    return spfList.First().function;
                else
                    return (PostFunctionData pfd) => { };
            }
        }

    }
}
