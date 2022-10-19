
using System.Text.RegularExpressions;

namespace LabCalculator
{
    public partial class Form1 : Form
    {
        private string path = "";
        public string mode = "value";
        public string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Dictionary<string, Cell> cells = new Dictionary<string, Cell>();
        const string refPatern = @"[A-Z][0-9]+";

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            CreateTable(5, 5);
            dataGridView1.ReadOnly = true;
        }
        
        private void CreateTable(int col, int row)
        {
            for (int i = 0; i < col; i++) AddColumn();
            for (int i = 0; i < row; i++) AddRow();
            CellNameLabel.Text = "A0";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void AddColumn()
        {
            DataGridViewColumn column = new DataGridViewColumn();
            Cell cell = new Cell();
            column.CellTemplate = cell;
            try
            {
                column.HeaderText = alphabet[dataGridView1.ColumnCount].ToString();
                dataGridView1.Columns.Add(column);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    Cell cell2 = new Cell();
                    cell2.Name = SetName(i, column.HeaderText);
                    cells.Add(cell2.Name, cell2);
                }
            }
            catch (Exception ex) 
            { MessageBox.Show("��������� ����������� ������� ���������!"); }
        }
        

        private void AddColBtn_Click(object sender, EventArgs e)
        {
            AddColumn();
        }

        public void AddRow()
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                Cell cell = new Cell();
                int rowCount = dataGridView1.RowCount;
                row.HeaderCell.Value = rowCount.ToString();
                dataGridView1.Rows.Add(row);
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    Cell cell2 = new Cell();
                    cell2.Name = SetName(dataGridView1.RowCount-1, dataGridView1.Columns[i].HeaderText);
                    cells.Add(cell2.Name, cell2);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("�������� ����� ������ ��������");
            }
            

        }
        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void DeleteRowBtn_Click(object sender, EventArgs e)
        {
            bool canDelete = true;
            List<string> names = new List<string>();
            for(int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                string nameTemp = SetName(dataGridView1.RowCount - 1, alphabet[i].ToString());
                if (cells[nameTemp].referenceFrom.Any())
                {
                    canDelete = false;
                    MessageBox.Show("�� �� ������ �������� ��� �����, �������� ������ ������� �������������� � ��������!");
                } 
                else names.Add(nameTemp);
            }
            if (canDelete)
            {
                try
                {
                    int rowNumber = dataGridView1.RowCount;
                    dataGridView1.Rows.RemoveAt(rowNumber-1);
                
                    foreach(string name in names)
                    {
                       cells[name].DeleteReferences();
                       cells.Remove(name);
                    }
                    CellNameLabel.Text = SetName(dataGridView1.SelectedCells[0].RowIndex, dataGridView1.SelectedCells[0].OwningColumn.HeaderText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�����, ������� �������...");
                }
            }
        }
            

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "File|*.txt";
                openFileDialog.Title = "������ ����";
            
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("�� �� ������ ����!");
                    return;
                }
                path = openFileDialog.FileName;
                label5.Text = path;
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                DeleteTable();
                Int32.TryParse(streamReader.ReadLine(), out int row);
                Int32.TryParse(streamReader.ReadLine(), out int col);
                CreateTable(col, row);
                OpenFile(row, col, streamReader);
                streamReader.Close();
                }
            catch (Exception ex) { MessageBox.Show("������� �� ��� �������� �����!"); }

        }

        private void OpenFile(int row, int col, StreamReader streamreader)
        {
            for(int i=0; i<row; i++)
                for(int j=0; j<col; j++)
                {
                    string name = streamreader.ReadLine();
                    string formula = streamreader.ReadLine();
                    cells[name].Formula= formula;
                    string form = FormulaToExpression(formula, name);
                    var res = Calculator.Evaluate(form);
                    AddReferences(formula, name);

                    cells[name].Value = res.ToString();
                    RefreshValueTable();
                }
        }
        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != "")
                {
                    FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
                    Saving(fileStream);
                    fileStream.Close();
                }
                else MessageBox.Show("���� �� �� ���������!");
            }
            catch (Exception ex) { MessageBox.Show("������� �� ��� ����������!"); }
            
        }

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "File|*.txt";
                saveFileDialog.Title = "Save as";
                saveFileDialog.ShowDialog();
                path = saveFileDialog.FileName;

                if (path != "")
                {
                    FileStream fileStream = (FileStream)saveFileDialog.OpenFile();
                    Saving(fileStream);
                    fileStream.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("������� �� ��� ����������!"); }

        }

        private void Saving(FileStream fileStream) //����������
        {
            label5.Text = path;
            StreamWriter streamWriter = new StreamWriter(fileStream);
            SaveFile(streamWriter);
            streamWriter.Close();
        }
        private void SaveFile(StreamWriter streamWriter) //����� ���������� � ����
        {
            streamWriter.WriteLine(dataGridView1.RowCount);
            streamWriter.WriteLine(dataGridView1.ColumnCount);
            for(int i = 0; i < dataGridView1.RowCount; i++)
                for(int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    string tempName = SetName(i, alphabet[j].ToString());
                    Cell tempCell = cells[tempName];
                    streamWriter.WriteLine(tempCell.Name);
                    streamWriter.WriteLine(tempCell.Formula);
                }
            
        }

        private void DeleteCol_Click(object sender, EventArgs e)
        {
            bool canDelete = true;
            List<string> names = new List<string>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string nameTemp = SetName(i, alphabet[dataGridView1.ColumnCount-1].ToString());
                if (cells[nameTemp].referenceFrom.Any())
                {
                    canDelete = false;
                    MessageBox.Show("�� �� ������ �������� ��� ��������, �������� ������ ������� �������������� � ��������");
                }
                else names.Add(nameTemp);
            }
            if (canDelete)
            {
                try
                {
                    int colNumber = dataGridView1.ColumnCount;
                    dataGridView1.Columns.RemoveAt(colNumber - 1);

                    foreach (string name in names)
                    {
                        cells[name].DeleteReferences();
                        cells.Remove(name);
                    }
                    CellNameLabel.Text = SetName(dataGridView1.SelectedCells[0].RowIndex, dataGridView1.SelectedCells[0].OwningColumn.HeaderText);
                }
                catch(Exception ex) { MessageBox.Show("�����, ������� �������..."); }

            }
        }

        private void RefreshCells(string name) //��������� ������� �������, �������� �� �������
        {
            foreach (Cell cell in cells[name].referenceFrom)
            {
                string form = FormulaToExpression(cell.Formula, cell.Name);
                var res = Calculator.Evaluate(form);
                cell.Value = res.ToString();
                RefreshCells(cell.Name);
            }
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("���� �������!");
                return;
            }
            else if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBox.Show("������ 1 �������!");
                return;
            }
            try
                {
                string temp = SetName(dataGridView1.SelectedCells[0].RowIndex, dataGridView1.SelectedCells[0].OwningColumn.HeaderText);
                if (CanConvertRefFormula(FormulaTextBox.Text, temp))
                {
                    cells[temp].DeleteReferences();
                    string form = FormulaToExpression(FormulaTextBox.Text, temp);
                    var res = Calculator.Evaluate(form);
                    AddReferences(FormulaTextBox.Text, temp);
            
                    cells[temp].Value = res.ToString();
                    cells[temp].Formula = FormulaTextBox.Text;
                    RefreshCells(temp);
                    int c = dataGridView1.SelectedCells[0].ColumnIndex;
                    int r = dataGridView1.SelectedCells[0].RowIndex;
                    if (mode == "value") RefreshValueTable();
                    else dataGridView1.Rows[r].Cells[c].Value = FormulaTextBox.Text;
                }
            }
            catch (ArgumentException ex) { MessageBox.Show("���������� �������!"); }
            catch (DivideByZeroException ex2) { MessageBox.Show("�� ����� ����� �� 0!"); }
            
            FormulaTextBox.Clear();

        }

        private string SetName(int row, string col)
        {
            return col + (row.ToString());
        }

        private string FormulaToExpression(string formula, string name) //������������ ������� �� ������������ �����
        {
            Regex regex = new Regex(refPatern, RegexOptions.IgnoreCase);
            MatchEvaluator matchEvaluator = new MatchEvaluator(ReferenceConvertation);
            string finFormula=regex.Replace(formula, matchEvaluator);
            return finFormula;
        }

        private void AddReferences(string formula, string name)
        {
            Regex regex = new Regex(refPatern, RegexOptions.IgnoreCase);
            foreach (Match match in regex.Matches(formula))
            {
                if (cells.ContainsKey(match.Value))
                {
                    cells[name].AddReferences(cells[match.Value]);
                }
            }
        }
        private string ReferenceConvertation(Match match)
        {
            return cells[match.Value].Value;
        }

        private bool CanConvertRefFormula(string formula, string name)
        {
            Regex regex = new Regex(refPatern, RegexOptions.IgnoreCase);
            bool canConvert = true;
            foreach (Match match in regex.Matches(formula))
            {
                if (!cells.ContainsKey(match.Value))
                {
                    MessageBox.Show("������� � ��������, �� �� ����");
                    canConvert = false;
                }
                else if (cells[name].RecurseReferenceCheck(cells[name], cells[match.Value]))
                { 
                    MessageBox.Show("�������");
                    canConvert = false;
                }
            }
            return canConvert;
        }
       
        private void HelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"�������� ����� �-27 ������ 7{Environment.NewLine}" +
                $"������� ������� ���������� �������� +, -, *, /, mod, d�v, ^(��������� � ������), mmax(x1, x2, ..., xN), mm�n(x1, x2, ..., xN)(N >= 1). ��� ������ ����������, ������� ������ ��������� �������, �������� ����� � textBox, ��������� ������ ����������.{Environment.NewLine}" +
                $"������ �����: ³���������� ���������� � ������� ������� ��� ������: ����� / ��������. ���������� �� ������ ����� ������ ����� �����������{Environment.NewLine}" +
                $"�������� �������: ������� �������, ������� ���� �������� 5x5.{Environment.NewLine}" +
                $"����������� ��������� ������� ��������� 26.{Environment.NewLine}" +
                $"��������: �� ����� �������� ����, ���� �� ����� �� �� ��� ���������� ��.");
        }


        private void RefreshValueTable()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    string tempColName = dataGridView1.Columns[j].HeaderText;
                    if (cells[SetName(i, tempColName)].Formula != "") dataGridView1.Rows[i].Cells[j].Value = cells[SetName(i, tempColName)].Value;
                }
        }

        private void RefreshFormulaTable()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    dataGridView1.Rows[i].Cells[j].Value = cells[SetName(i, dataGridView1.Columns[j].HeaderText)].Formula;
        }

        private void ChangeModeBtn_Click(object sender, EventArgs e)
        {
            if (mode == "value")
            {
                mode = "formula";
                RefreshFormulaTable();
;           }
            else
            if (mode == "formula")
            {
                mode = "value";
                RefreshValueTable();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CellNameLabel.Text = SetName(dataGridView1.SelectedCells[0].RowIndex, dataGridView1.SelectedCells[0].OwningColumn.HeaderText);
            }
            catch (Exception ex) { MessageBox.Show("���� �����!"); }
            
        }

        private void DeleteTable()
        {
            cells.Clear();
            dataGridView1.Columns.Clear();
        }
        private void RefreshTableBtn_Click(object sender, EventArgs e)
        {
            DeleteTable();
            CreateTable(5, 5);
            mode = "value";
        }
    }
    }