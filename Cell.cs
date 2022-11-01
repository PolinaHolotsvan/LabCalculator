using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabCalculator
{
    public class Cell : DataGridViewTextBoxCell
    {

        public string Name { get; set; }
        public string Value { get ; set ; }
        public string Formula { get; set; }

        public List<Cell> referenceTo = new List<Cell>();
        public List<Cell> referenceFrom = new List<Cell>();

        public Cell()
        {
            Value = "0";
            Formula = "";
        }

        public void AddReferences(Cell tempCell)
        {
            this.referenceTo.Add(tempCell);
            tempCell.referenceFrom.Add(this);
        }

        public void DeleteReferences()
        {
            foreach(Cell tempCell in referenceTo)
            {
                tempCell.referenceFrom.Remove(this);
            }
            referenceTo.Clear();
        }
        public bool RecurseReferenceCheck(Cell current, Cell dependsOn) //перевірка на рекурсію
        {
            if (current == dependsOn) return true;
            if (current.referenceFrom.Contains(dependsOn)) return true;
            else
            {
                bool result = false;
                foreach(Cell refer1 in dependsOn.referenceTo)
                {
                    result=RecurseReferenceCheck(current, refer1);
                }
                return result;
            }
        }



    }
}
