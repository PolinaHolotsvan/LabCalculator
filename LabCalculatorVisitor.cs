using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabCalculator
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
{

        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }
        
        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            
            if (tableIdentifier.TryGetValue(result.ToString(), out value))
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }
        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitExponentialExpr(LabCalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (right <=0 && left==0) throw new DivideByZeroException();
            else
            {
                Debug.WriteLine("{0}^{1}", left, right);
                return System.Math.Pow(left, right);
            }
            
        }
        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0}+{1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0}-{1}", left, right);
                return left - right;
            }
        }
        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0}*{1}", left, right);
                return left * right;
            }
            else //LabCalculatorLexer.DIVIDE
            {
                if (right == 0) throw new DivideByZeroException();
                Debug.WriteLine("{0}/{1}", left, right);
                return left / right;
            }
        }

        public override double VisitModDivExpr(LabCalculatorParser.ModDivExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (right == 0) throw new DivideByZeroException();
            return context.operatorToken.Type == LabCalculatorLexer.MOD
                ? left % right
                : (int)left/(int)right;
        }

        public override double VisitMminExpr(LabCalculatorParser.MminExprContext context)
        {
            double minValue = Double.PositiveInfinity;
            foreach (var child in context.paramlist.children.OfType<LabCalculatorParser.ExpressionContext>())
            {
                double childValue = this.Visit(child);
                if (childValue < minValue)
                {
                    minValue = childValue;
                } 
            }
            return minValue;
        }

        public override double VisitMmaxExpr([NotNull] LabCalculatorParser.MmaxExprContext context)
        {
            double maxValue = Double.NegativeInfinity;
            foreach (var child in context.paramlist.children.OfType<LabCalculatorParser.ExpressionContext>())
            {
                double childValue = this.Visit(child);
                if (childValue > maxValue)
                {
                    maxValue = childValue;
                }
            }
            return maxValue;
        }
        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext <LabCalculatorParser.ExpressionContext>(0));
        }
        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {   
            return Visit(context.GetRuleContext <LabCalculatorParser.ExpressionContext>(1));
        }
    }
}