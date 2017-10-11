using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
/*
textExpression.Text 表达式栏（上）
textAnswer.Text 答案栏（下）
*/
namespace BestCalculator
{
    public partial class Calculator : Form
    {
        internal int multiRoot = 0;     //多重求根
        internal int numCount = 0;      //expression中的操作数个数
        const string brackets = "()";     //括号
        const string rootBrackets = "√()"; //根号
        internal string rootProxy;       //根号代理
        internal string lastOperate = "";        //记录上次操作
        internal string expression = "";    //运算表达式
        internal bool hasEqual = false;     //求等标志
        internal bool divideZeroFlag = false;   //除零标志
        internal bool needClear = false;     //标志：当求值后，如果再输入数字 则更新答案栏
        internal bool hasRoot = false;       //表达式中是否有根号
        internal bool isLastOperate = false;    //记录上次操作标志
        ExpressionAndAnswer operate = new ExpressionAndAnswer();   //运算操作类
        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(divideZeroFlag)      //除零检测标志        解禁部分按钮
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')      
            {
                textAnswer.Text = "1";
                needClear = false;
            }
            else
                textAnswer.Text += '1';
            isLastOperate = false;
            if (button1.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "2";
                needClear = false;
            }
            else
                textAnswer.Text += '2';
            isLastOperate = false;
            if (button2.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "3";
                needClear = false;
            }
            else
                textAnswer.Text += '3';
            isLastOperate = false;
            if (button3.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "4";
                needClear = false;
            }
            else
                textAnswer.Text += '4';
            isLastOperate = false;
            if (button4.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "5";
                needClear = false;
            }
            else
                textAnswer.Text += '5';
            isLastOperate = false;
            if (button5.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "6";
                needClear = false;
            }
            else
                textAnswer.Text += '6';
            isLastOperate = false;
            if (button6.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "7";
                needClear = false;
            }
            else
                textAnswer.Text += '7';
            isLastOperate = false;
            if (button7.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "8";
                needClear = false;
            }
            else
                textAnswer.Text += '8';
            isLastOperate = false;
            if (button8.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "9";
                needClear = false;
            }
            else
                textAnswer.Text += '9';
            isLastOperate = false;
            if (button9.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
            }
            if (needClear || textAnswer.Text.Length == 1 && textAnswer.Text[0] == '0')
            {
                textAnswer.Text = "0";
                needClear = false;
            }
            else
                textAnswer.Text += '0';
            isLastOperate = false;
            if (button0.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(divideZeroFlag)      //表达式除零错误
            {
                return;
            }
            if(hasRoot) //根号操作
            {
                needClear = false;
                hasRoot = false;
            }
            if (needClear && textExpression.Text.Length >= 1 && !Char.IsNumber(textExpression.Text[textExpression.Text.Length - 1]))
            {
                textExpression.Text = textExpression.Text.Remove(textExpression.Text.Length - 1) + "+";
            }
            else if (hasEqual)
            {
                if (multiRoot > 0)      //已进行多次求根操作
                {
                    textExpression.Text += rootProxy + '+';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '+';
                expression += '+';
                hasEqual = false;
            }
            else
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '+';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '+';
                if (numCount==1)
                {
                    //expression += brackets.Insert(1, textAnswer.Text);
                    expression += brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    try
                    {
                        textAnswer.Text = operate.Calculate(expression);
                        if(textAnswer.Text.Contains('∞'))
                        {
                            textAnswer.Text = "除数不能为0";
                            textExpression.Text = "";
                            //除零错误 按钮禁用
                            buttonPN.Enabled = false;
                            buttonDivide.Enabled = false;
                            buttonMulti.Enabled = false;
                            buttonAdd.Enabled = false;
                            buttonMinus.Enabled = false;
                            buttonRoot.Enabled = false;
                            buttonEqual.Enabled = false;
                            buttonDot.Enabled = false;

                            divideZeroFlag = true;
                            return;
                        }
                    }
                    catch       //捕捉错误
                    {
                        expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                        expression += '+';
                        isLastOperate = false;
                        needClear = true;
                        if (buttonAdd.Focused)        //控制焦点位置
                            buttonInvisible.Focus();
                        return;
                    }
                    //expression = brackets.Insert(1, textAnswer.Text);
                    expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    expression += '+';
                }
                else
                {
                    //expression += textAnswer.Text + '+';
                    expression = operate.ChangeDataToD(textAnswer.Text) + '+';
                    numCount = 1;
                }
            }
            isLastOperate = false;
            needClear = true;
            if (buttonAdd.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            if (hasRoot)
            {
                needClear = false;
                hasRoot = false;
            }
            if (needClear && textExpression.Text.Length >= 1 && !Char.IsNumber(textExpression.Text[textExpression.Text.Length - 1]))
            {
                textExpression.Text = textExpression.Text.Remove(textExpression.Text.Length - 1) + "-";
            }
            else if (hasEqual)
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '-';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '-';
                expression += '-';
                hasEqual = false;
            }
            else
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '-';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '-';
                if (numCount == 1)
                {
                    expression += brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    try
                    {
                        textAnswer.Text = operate.Calculate(expression);
                        if (textAnswer.Text.Contains('∞'))
                        {
                            textAnswer.Text = "除数不能为0";
                            textExpression.Text = "";

                            buttonPN.Enabled = false;
                            buttonDivide.Enabled = false;
                            buttonMulti.Enabled = false;
                            buttonAdd.Enabled = false;
                            buttonMinus.Enabled = false;
                            buttonRoot.Enabled = false;
                            buttonEqual.Enabled = false;
                            buttonDot.Enabled = false;

                            divideZeroFlag = true;
                            return;
                        }
                    }
                    catch
                    {
                        expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                        expression += '-';
                        isLastOperate = false;
                        needClear = true;
                        if (buttonAdd.Focused)        //控制焦点位置
                            buttonInvisible.Focus();
                        return;
                    }
                    expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    expression += '-';
                }
                else
                {
                    expression = operate.ChangeDataToD(textAnswer.Text) + '-';
                    numCount = 1;
                }
            }
            isLastOperate = false;
            needClear = true;
            if (buttonMinus.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            if (hasRoot)
            {
                needClear = false;
                hasRoot = false;
            }
            if (needClear && textExpression.Text.Length >= 1 && !Char.IsNumber(textExpression.Text[textExpression.Text.Length - 1]))
            {
                textExpression.Text = textExpression.Text.Remove(textExpression.Text.Length - 1) + "*";
            }
            else if (hasEqual)
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '*';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '*';
                expression += '*';
                hasEqual = false;
            }
            else
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '*';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '*';
                if (numCount == 1)
                {
                    expression += brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    try
                    {
                        textAnswer.Text = operate.Calculate(expression);
                        if (textAnswer.Text.Contains('∞'))
                        {
                            textAnswer.Text = "除数不能为0";
                            textExpression.Text = "";

                            buttonPN.Enabled = false;
                            buttonDivide.Enabled = false;
                            buttonMulti.Enabled = false;
                            buttonAdd.Enabled = false;
                            buttonMinus.Enabled = false;
                            buttonRoot.Enabled = false;
                            buttonEqual.Enabled = false;
                            buttonDot.Enabled = false;

                            divideZeroFlag = true;
                            return;
                        }
                    }
                    catch
                    {
                        expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                        expression += '*';
                        isLastOperate = false;
                        needClear = true;
                        if (buttonAdd.Focused)        //控制焦点位置
                            buttonInvisible.Focus();
                        return;
                    }
                    expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    expression += '*';
                }
                else
                {
                    expression = operate.ChangeDataToD(textAnswer.Text) + '*';
                    numCount = 1;
                }
            }
            isLastOperate = false;
            needClear = true;
            if (buttonMulti.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            if (hasRoot)
            {
                needClear = false;
                hasRoot = false;
            }
            if (needClear && textExpression.Text.Length >= 1 && !Char.IsNumber(textExpression.Text[textExpression.Text.Length - 1]))
            {
                textExpression.Text = textExpression.Text.Remove(textExpression.Text.Length - 1) + "/";
            }
            else if (hasEqual)
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '/';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '/';
                expression += '/';
                hasEqual = false;
            }
            else
            {
                if (multiRoot > 0)
                {
                    textExpression.Text += rootProxy + '/';
                    multiRoot = 0;
                    rootProxy = "";
                }
                else
                    textExpression.Text += textAnswer.Text + '/';
                if (numCount == 1)
                {
                    expression += brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    try
                    {
                        textAnswer.Text = operate.Calculate(expression);
                        if (textAnswer.Text.Contains('∞'))
                        {
                            textAnswer.Text = "除数不能为0";
                            textExpression.Text = "";

                            buttonPN.Enabled = false;
                            buttonDivide.Enabled = false;
                            buttonMulti.Enabled = false;
                            buttonAdd.Enabled = false;
                            buttonMinus.Enabled = false;
                            buttonRoot.Enabled = false;
                            buttonEqual.Enabled = false;
                            buttonDot.Enabled = false;

                            divideZeroFlag = true;
                            return;
                        }
                    }
                    catch
                    {
                        expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                        expression += '/';
                        isLastOperate = false;
                        needClear = true;
                        if (buttonAdd.Focused)        //控制焦点位置
                            buttonInvisible.Focus();
                        return;
                    }
                    expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    expression += '/';
                }
                else
                {
                    expression = operate.ChangeDataToD(textAnswer.Text) + '/';
                    numCount = 1;
                }
            }
            isLastOperate = false;
            needClear = true;
            if (buttonDivide.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            string expressionProxy;
            if(isLastOperate)
            {
                expressionProxy = operate.ChangeDataToD(textAnswer.Text) + lastOperate;
                try
                {
                    textAnswer.Text = operate.Calculate(expressionProxy);
                    if (textAnswer.Text.Contains('∞'))
                    {
                        textAnswer.Text = "除数不能为0";
                        textExpression.Text = "";


                        buttonPN.Enabled = false;
                        buttonDivide.Enabled = false;
                        buttonMulti.Enabled = false;
                        buttonAdd.Enabled = false;
                        buttonMinus.Enabled = false;
                        buttonRoot.Enabled = false;
                        buttonEqual.Enabled = false;
                        buttonDot.Enabled = false;

                        divideZeroFlag = true;
                        return;
                    }
                }
                catch
                {
                    textExpression.Text = "";
                    expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    hasEqual = true;
                    needClear = true;
                    if (buttonEqual.Focused)        //控制焦点位置
                        buttonInvisible.Focus();
                    return;
                }
            }
            //brackets.Insert(1, )
            else
            {
                lastOperate = expression[expression.Length - 1].ToString() + brackets.Insert(1,textAnswer.Text);  //记录上次运算操作
                isLastOperate = true;   //标志
                expressionProxy = expression + brackets.Insert(1,operate.ChangeDataToD(textAnswer.Text));     //代理运算
                try
                {
                    textAnswer.Text = operate.Calculate(expressionProxy);   //更新运算结果
                    if (textAnswer.Text.Contains('∞'))
                    {
                        textAnswer.Text = "除数不能为0";
                        textExpression.Text = "";

                        buttonPN.Enabled = false;
                        buttonDivide.Enabled = false;
                        buttonMulti.Enabled = false;
                        buttonAdd.Enabled = false;
                        buttonMinus.Enabled = false;
                        buttonRoot.Enabled = false;
                        buttonEqual.Enabled = false;
                        buttonDot.Enabled = false;

                        divideZeroFlag = true;
                        return;
                    }
                }
                catch
                {
                    textExpression.Text = "";
                    expression = brackets.Insert(1, operate.ChangeDataToD(textAnswer.Text));
                    hasEqual = true;
                    needClear = true;
                    if (buttonEqual.Focused)        //控制焦点位置
                        buttonInvisible.Focus();
                    return;
                }
            }
            textExpression.Text = "";
            expression = brackets.Insert(1,operate.ChangeDataToD(textAnswer.Text));
            hasEqual = true;
            needClear = true;
            if (buttonEqual.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonToLeft_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                buttonToZero.PerformClick();
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
                divideZeroFlag = false;
                return;
            }
            if (needClear)
                return;
            else
            {
                if (textAnswer.Text.Length > 1)
                    textAnswer.Text = textAnswer.Text.Remove(textAnswer.Text.Length - 1);
                else if (textAnswer.Text.Length == 1)
                    textAnswer.Text = "0";
                else
                    return;
            }
            if (buttonToLeft.Focused)        //控制焦点位置
                buttonInvisible.Focus();
            //移除最后一位字符
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            if (needClear)
            {
                textAnswer.Text = "0.";
                needClear = false;
            }
            else if (Char.IsNumber(textAnswer.Text[textAnswer.Text.Length - 1]) && !textAnswer.Text.Contains('.')) //如果表达式最后一个是数字
                textAnswer.Text += ".";
            else
                return;
            if (buttonDot.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonPN_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            if (textAnswer.Text.Length==1 && textAnswer.Text[0]=='0')
            {
                return;
            }
            if(hasEqual)
            {
                if (textAnswer.Text[0] == '-')
                {
                    textAnswer.Text = textAnswer.Text.Remove(0, 1);
                }
                else
                {
                    textAnswer.Text = textAnswer.Text.Insert(0, "-");
                }
                expression = brackets.Insert(1, textAnswer.Text);
            }
            else
            {
                if (textAnswer.Text[0] == '-')
                {
                    textAnswer.Text = textAnswer.Text.Remove(0, 1);
                }
                else
                {
                    textAnswer.Text = textAnswer.Text.Insert(0, "-");
                }
            }
            
            if (buttonPN.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonToZero_Click(object sender, EventArgs e)
        {
            /*
            internal int multiRoot = 0;     //多重求根
            internal int numCount = 0;      //expression中的操作数个数
            internal string rootProxy;       //根号代理
            internal string lastOperate = "";        //记录上次操作
            internal string expression = "";    //运算表达式
            internal bool hasEqual = false;     //求等标志
            internal bool divideZeroFlag = false;   //除零标志
            internal bool needClear = false;     //标志：当求值后，如果再输入数字 则更新答案栏
            internal bool hasRoot = false;       //表达式中是否有根号
            internal bool isLastOperate = false;    //记录上次操作标志
            */
            if (divideZeroFlag)
            {
                buttonPN.Enabled = true;
                buttonDivide.Enabled = true;
                buttonMulti.Enabled = true;
                buttonAdd.Enabled = true;
                buttonMinus.Enabled = true;
                buttonRoot.Enabled = true;
                buttonEqual.Enabled = true;
                buttonDot.Enabled = true;
            }
            textAnswer.Text = "0";
            textExpression.Text = "";
            expression = "";
            rootProxy = "";
            lastOperate = "";
            multiRoot = 0;
            numCount = 0;
            needClear = false;
            hasRoot = false;
            hasEqual = false;
            divideZeroFlag = false;
            if (buttonToZero.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (divideZeroFlag)
            {
                return;
            }
            if (multiRoot==0)
            {
                rootProxy = rootBrackets.Insert(2, textAnswer.Text);
            }
            else
            {
                rootProxy = rootBrackets.Insert(2, rootProxy);
            }
            double rootNum = double.Parse(operate.ChangeDataToD(textAnswer.Text));      //求根
            textAnswer.Text = System.Math.Sqrt(rootNum).ToString();
            hasRoot = true;
            needClear = true;
            multiRoot++;
        }
        //键盘操作
        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Enter = (char)Keys.Enter;
            const char Esc = (char)27;
            switch (e.KeyChar)
            {
                case '1':
                    button1.PerformClick();
                    break;
                case '2':
                    button2.PerformClick();
                    break;
                case '3':
                    button3.PerformClick();
                    break;
                case '4':
                    button4.PerformClick();
                    break;
                case '5':
                    button5.PerformClick();
                    break;
                case '6':
                    button6.PerformClick();
                    break;
                case '7':
                    button7.PerformClick();
                    break;
                case '8':
                    button8.PerformClick();
                    break;
                case '9':
                    button9.PerformClick();
                    break;
                case '0':
                    button0.PerformClick();
                    break;
                case '\b':
                    buttonToLeft.PerformClick();
                    break;
                case '.':
                    buttonDot.PerformClick();
                    break;
                case '/':
                    buttonDivide.PerformClick();
                    break;
                case '*':
                    buttonMulti.PerformClick();
                    break;
                case '+':
                    buttonAdd.PerformClick();
                    break;
                case '-':
                    buttonMinus.PerformClick();
                    break;
                case Enter:
                case '=':
                    buttonEqual.PerformClick();
                    break;
                case Esc:
                    buttonToZero.PerformClick();
                    break;
                case '@':
                    buttonRoot.PerformClick();
                    break;
                default:
                    return;
            }
        }

        //焦点控制按钮 无具体作用
        private void buttonInvisible_Click(object sender, EventArgs e)
        {
            buttonEqual.PerformClick();
        }
    }
}
