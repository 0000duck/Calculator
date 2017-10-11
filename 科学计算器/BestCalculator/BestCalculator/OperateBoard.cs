using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestCalculator
{
    class OperateBoard
    {
        const string brackets = "()";     //括号
        const string rootBrackets = "√()"; //根号
        internal bool needClear;     //标志：当求值后，如果再输入数字 则更新答案栏
        internal bool needBrackets;  //标志：当取负值时，向表达式加入括号
        internal bool isScienceNumExist;     //表达式中是否存在科学计数
        internal bool hasRoot;       //表达式中是否有根号
        internal string scienceNumRecorder;  //记录科学计数
        internal string ExpressionProxy;     //表达式有根号时 表达式代理
        internal string rootProxy;       //根号代理
        internal int multiRoot;
        internal bool divideZeroFlag;       //检测除零   用于答案栏清空
        internal bool isLastOperate;
        internal string lastOperate;        //记录上次操作

        public OperateBoard()      //构造函数
        {
            needClear = false;     //标志：当求值后，如果再输入数字 则更新答案栏
            needBrackets = false;  //标志：当取负值时，向表达式加入括号
            isScienceNumExist = false;     //表达式中是否存在科学计数
            hasRoot = false;       //表达式中是否有根号
            scienceNumRecorder = "";  //记录科学计数
            ExpressionProxy = "";     //表达式有根号时 表达式代理
            rootProxy = "";       //根号代理
            multiRoot = 0;
            divideZeroFlag = false;       //检测除零   用于答案栏清空
            isLastOperate = false;
            lastOperate = "";        //记录上次操作
        }
        public string OperateButtonNum(string text, string num)
        {
            if (isLastOperate)
            {
                isLastOperate = false;
                lastOperate = "";
            }
            if (divideZeroFlag)
                divideZeroFlag = false;
            if (needClear || text.Length == 1 && text[0] == '0')
            {
                text = num;
                needClear = false;
            }
            else if (hasRoot)
            {
                text += num;
                ExpressionProxy += num;
            }
            else
                text += num;
            return text;
        }

        public void OperateButtonChar(ref string text, ref string expression, string operateKind)
        {
            if (isLastOperate)
            {
                isLastOperate = false;
                lastOperate = "";
            }
            if (divideZeroFlag)
            {
                divideZeroFlag = false;
                needClear = false;
                text = "0";
                return;
            }
            //如果表达式末尾是运算符但不是右括号时再次输入运算符，则将末尾运算符删除并更新为新运算符
            if (needClear && expression.Length >= 1 && expression[expression.Length - 1] != ')' && !Char.IsNumber(expression[expression.Length - 1]))
            {
                if (hasRoot) //如果表达式有根号  代理表达式做同样处理
                {
                    ExpressionProxy = ExpressionProxy.Remove(ExpressionProxy.Length - 1) + operateKind;
                }
                expression = expression.Remove(expression.Length - 1) + operateKind;
            }
            else
            {
                if (multiRoot > 0)     //如果有重根号
                {
                    if (needBrackets)
                    {
                        expression += brackets.Insert(1, rootProxy) + operateKind;
                        ExpressionProxy += brackets.Insert(1, text) + operateKind;
                    }
                    else
                    {
                        expression += rootProxy + operateKind;     //把根号的数据放到表达式栏
                        ExpressionProxy += text + operateKind;         //已计算好的数据加入代理表达式
                    }
                }
                else
                {
                    if (needBrackets)
                    {
                        expression += brackets.Insert(1, text) + operateKind;
                    }
                    else
                    {
                        expression += text + operateKind;
                    }

                }
                needClear = true;
                multiRoot = 0;
            }
        }

        public void ClearUp()
        {
            rootProxy = "";
            multiRoot = 0;
            needClear = false;
            needBrackets = false;
            isScienceNumExist = false;
            hasRoot = false;
        }
    }
}
