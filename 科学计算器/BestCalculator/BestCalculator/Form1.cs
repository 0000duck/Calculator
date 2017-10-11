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
        const string brackets = "()";     //括号
        const string rootBrackets = "√()"; //根号
        OperateBoard board = new OperateBoard();        //主界面操作类
        ExpressionAndAnswer operate = new ExpressionAndAnswer();   //运算操作类
        public Calculator()
        {
            InitializeComponent();
        }
        /*
            数字按钮与运算符按钮操作类似  
            注释相同
            不重复注释
        */
        private void button1_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;        //临时变量作为操作函数的参数
            textAnswer.Text = board.OperateButtonNum(intermediateString, button1.Text); //每次对答案栏字符串更新
            if (button1.Focused)        //控制焦点位置
                buttonInvisible.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button2.Text);     
            if (button2.Focused)
                buttonInvisible.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button3.Text);
            if (button3.Focused)
                buttonInvisible.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button4.Text);
            if (button4.Focused)
                buttonInvisible.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button5.Text);
            if (button5.Focused)
                buttonInvisible.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button6.Text);
            if (button6.Focused)
                buttonInvisible.Focus();
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button7.Text);
            if (button7.Focused)
                buttonInvisible.Focus();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button8.Text);
            if (button8.Focused)
                buttonInvisible.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button9.Text);
            if (button9.Focused)
                buttonInvisible.Focus();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            string intermediateString = textAnswer.Text;
            textAnswer.Text = board.OperateButtonNum(intermediateString, button0.Text);
            if (button0.Focused)
                buttonInvisible.Focus();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string intermediateAnswerText = textAnswer.Text;        //答案栏中间变量
            string intermediateExpressionText = textExpression.Text;        //表达式栏中间变量
            board.OperateButtonChar(ref intermediateAnswerText, ref intermediateExpressionText, buttonAdd.Text);
            //运算操作
            textAnswer.Text = intermediateAnswerText;       //更新答案栏
            textExpression.Text = intermediateExpressionText;       //更新表达式栏
            if (buttonAdd.Focused)      //控制焦点位置
                buttonInvisible.Focus();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            string intermediateAnswerText = textAnswer.Text;
            string intermediateExpressionText = textExpression.Text;
            board.OperateButtonChar(ref intermediateAnswerText,ref intermediateExpressionText, buttonMinus.Text);
            textAnswer.Text = intermediateAnswerText;
            textExpression.Text = intermediateExpressionText;
            if (buttonMinus.Focused)
                buttonInvisible.Focus();
        }

        private void buttonMulti_Click(object sender, EventArgs e)
        {
            string intermediateAnswerText = textAnswer.Text;
            string intermediateExpressionText = textExpression.Text;
            board.OperateButtonChar(ref intermediateAnswerText, ref intermediateExpressionText, buttonMulti.Text);
            textAnswer.Text = intermediateAnswerText;
            textExpression.Text = intermediateExpressionText;
            if (buttonMulti.Focused)
                buttonInvisible.Focus();
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            string intermediateAnswerText = textAnswer.Text;
            string intermediateExpressionText = textExpression.Text;
            board.OperateButtonChar(ref intermediateAnswerText, ref intermediateExpressionText, buttonDivide.Text);
            textAnswer.Text = intermediateAnswerText;
            textExpression.Text = intermediateExpressionText;
            if (buttonDivide.Focused)
                buttonInvisible.Focus();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if(board.isLastOperate)
            {
                operate.expression = operate.expression + board.lastOperate;
                textAnswer.Text = operate.getAnswer();
                return;
            }
            string divideZeroCheck;
            if (!board.needClear)     //如果不需要清空下栏 则将下栏的数据加入表达式
             {
                if (board.hasRoot)//如果表达式有根号 则启用代理表达式
                {
                    if (board.needBrackets)       //如果需要加括号->给答案栏数据加括号->加入代理表达式
                        operate.expression = board.ExpressionProxy + brackets.Insert(1,textAnswer.Text);
                    else
                        operate.expression = board.ExpressionProxy + textAnswer.Text;
                }
                else
                {
                    if (board.needBrackets)       //如果需要括号
                        operate.expression = textExpression.Text + brackets.Insert(1, textAnswer.Text);
                    else
                        operate.expression = textExpression.Text + textAnswer.Text;
                }//表达式无根号 不启用代理表达式
            }
            else
            {
                if (board.hasRoot)        //如果有根号
                {
                    operate.expression = board.ExpressionProxy;       //代理表达式中的数据加入运算
                    board.hasRoot = false;
                }
                else
                    operate.expression = textExpression.Text;       //否则则不加入
            }  //else  答案栏需要清空  即答案栏数据无用
            //判断表达式
            operate.expression = operate.expression.Insert(0, "0");  //给表达式开头加一个0 防止开始为-错误
            //如果表达式最后一个不是数字 且不是右括号
            if (!Char.IsNumber(operate.expression[operate.expression.Length - 1]) && operate.expression[operate.expression.Length - 1]!=')') 
            {
                textAnswer.Text = "0";
                textExpression.Text = "";
                board.ClearUp();
            }  //非法表达式 不进行计算 直接归零
            else
            {
                if(board.isScienceNumExist)       //如果表达式中存在科学计数  分析计算器功能特点  科学计数必定在表达式第一个
                {
                    operate.expression = operate.expression.Remove(1, board.scienceNumRecorder.Length);        //移除表达式中的科学计数
                    board.scienceNumRecorder = operate.ChangeDataToD(board.scienceNumRecorder);     //转变成正常数
                    operate.expression = operate.expression.Insert(1, board.scienceNumRecorder);       //替换
                }
                try  //捕捉异常 防止未检测到的表达式使得程序崩溃
                {
                    divideZeroCheck = operate.getAnswer();  //计算得出结果
                    if (divideZeroCheck.Contains("∞"))      //结果检测
                    {
                        textAnswer.Text = "除数不能为0";
                        board.needClear = true;
                        board.divideZeroFlag = true;
                    }
                    else
                    {
                        textAnswer.Text = divideZeroCheck;      //显示结果
                        board.lastOperate = operate.getLastOperate();
                        board.isLastOperate = true;
                    }
                        
                }
                catch
                {
                    return;
                }
                if (textAnswer.Text.Contains("E"))
                {
                    board.isScienceNumExist = true;
                    board.scienceNumRecorder = textAnswer.Text;
                }
                board.hasRoot = false;
                board.needClear = true;
                board.ExpressionProxy = "";
                board.rootProxy = "";
                textExpression.Text = "";
                //multiRoot = 0;
            }
        }

        private void buttonToLeft_Click(object sender, EventArgs e)
        {
            if (board.needClear)    //不可删除
                return;
            else
            {
                if (textAnswer.Text.Length > 1)     //长度大于1 删除最后一位字符
                    textAnswer.Text = textAnswer.Text.Remove(textAnswer.Text.Length - 1);
                else if (textAnswer.Text.Length == 1)       //可删除且长度为1
                    textAnswer.Text = "0";
                else
                    return;
            }
            if (buttonToLeft.Focused)
                buttonInvisible.Focus();
            //移除最后一位字符
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (board.needClear)
            {
                textAnswer.Text = "0.";
                board.needClear = false;
            }
            else if (Char.IsNumber(textAnswer.Text[textAnswer.Text.Length - 1])) //如果表达式最后一个是数字
                textAnswer.Text += ".";
            if (buttonDot.Focused)
                buttonInvisible.Focus();
        }

        private void buttonPN_Click(object sender, EventArgs e)     //取表达式栏相反数
        {
            if(board.divideZeroFlag)
            {
                board.divideZeroFlag = false;
                board.needClear = false;
                textAnswer.Text = "0";
                return;
            }
            if (textAnswer.Text[0] == '-')
            {
                textAnswer.Text = textAnswer.Text.Remove(0, 1);
                board.needBrackets = false;
            }
            else
            {
                textAnswer.Text = textAnswer.Text.Insert(0, "-");
                board.needBrackets = true;
            }
            if (buttonPN.Focused)
                buttonInvisible.Focus();
        }

        private void buttonToZero_Click(object sender, EventArgs e)
        {
            textAnswer.Text = "0";
            textExpression.Text = "";
            board.ClearUp();
            if (buttonToZero.Focused)
                buttonInvisible.Focus();
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (board.divideZeroFlag)
            {
                board.divideZeroFlag = false;
                board.needClear = false;
                textAnswer.Text = "0";
                return;
            }
            string temp;
            board.hasRoot = true;     //表达式内是否有根号标记

            //多重根号显示
            if(board.multiRoot ==0)
                board.rootProxy = rootBrackets.Insert(2, textAnswer.Text);
            else
                board.rootProxy = rootBrackets.Insert(2, board.rootProxy);

            board.multiRoot++;

            if (textAnswer.Text.Contains("E"))      //如果表达式中有科学计数
            {
                if(board.hasRoot)
                {
                    temp = operate.ChangeDataToD(textAnswer.Text);  //将科学计数转换成正常数
                    textAnswer.Text = System.Math.Sqrt(double.Parse(temp)).ToString();
                }
                else
                {
                    board.ExpressionProxy = textExpression.Text;  //将求值表达式存入表达式代理
                    temp = operate.ChangeDataToD(textAnswer.Text);  //将科学计数转换成正常数
                    textAnswer.Text = System.Math.Sqrt(double.Parse(temp)).ToString();
                }
            }
            else
            {
                if(board.hasRoot)
                {
                    textAnswer.Text = System.Math.Sqrt(double.Parse(textAnswer.Text)).ToString();
                }
                else
                {
                    board.ExpressionProxy = textExpression.Text;  //将求值表达式存入表达式代理
                    textAnswer.Text = System.Math.Sqrt(double.Parse(textAnswer.Text)).ToString();
                }
            }

            if (!textAnswer.Text.Contains("E")) //更新科学计数的状态    
            {
                board.isScienceNumExist = false;
                board.scienceNumRecorder = "";
            }
            board.isLastOperate = false;
            board.lastOperate = "";
            //needClear = true;
            if (buttonRoot.Focused)
                buttonInvisible.Focus();
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        //      捕捉键盘操作
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
            }
        }

        private void buttonInvisible_Click(object sender, EventArgs e)      //隐藏按钮  用于控制焦点位置
        {
            buttonEqual.PerformClick();
        }
    }
}
