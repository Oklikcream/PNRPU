namespace Determ_con_comp_of_a_graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            DeleteTable();

            if (int.TryParse(textBox.Text, out int size) && size >= 1 && size <= 10)
            {
                ClearLabels();
                CreateTable(size);
            }
            else
            {
                errorLabel.Text = "Введите целое число от 1 до 10!";
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (!(int.TryParse(textBox.Text, out int size) && size >= 1 && size <= 10))
            {
                return;
            }

            ClearLabels();

            int[,] matrix = ReadFromTable(size);
            if (matrix.GetLength(0) == 0)
                return;

            matrix = StrongMatrix(matrix);

            labelResult.Text = DetermConnectyComp(matrix);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClearLabels();

            string table = "";
            bool isCorrectData = true;
            foreach (Control control in tablePanel.Controls)
            {
                if (control is TextBox box)
                {
                    if (box.Text != "1" && box.Text != "0" && box.Text != "")
                        isCorrectData = false;
                    table += box.Text == "" ? 0 : box.Text;
                }
            }

            if (string.IsNullOrEmpty(textBox.Text) || !(int.TryParse(textBox.Text, out int n) && n >= 1 && n <= 10) || !isCorrectData)
            {
                errorLabel.Text = "Файл не сохраннён из-за неверных данных!";
                return;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog.Title = "Сохранить файл";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, textBox.Text.PadLeft(2, '0') + table);
                messageLabel.Text = "Файл успешно сохранён!";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ClearLabels();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Title = "Открыть файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string allText = File.ReadAllText(filePath);
                if (!(allText.Length >= 2))
                {
                    errorLabel.Text = "Файл не удалось прочитать";
                    return;
                }
                string size = allText.Substring(0, 2);

                if (!(int.TryParse(size, out int n) && n >= 1 && n <= 10))
                {
                    errorLabel.Text = "Файл не удалось прочитать";
                    return;
                }

                if (allText.Length != n * n + 2)
                {
                    errorLabel.Text = "Файл не удалось прочитать";
                    return;
                }

                for (int i = 2; i < n * n + 2; i++)
                {
                    char ch = allText[i];
                    if (ch != '1' && ch != '0')
                    {
                        errorLabel.Text = "Файл не удалось прочитать";
                        return;
                    }
                }

                textBox.Text = size.ToString();

                int j = 2;
                foreach (Control control in tablePanel.Controls)
                {
                    if (control is TextBox box)
                    {
                        box.Text = allText[j].ToString();
                        j++;
                    }
                }

                messageLabel.Text = "Файл успешно загружен!";
            }
        }

        private void CreateTable(int size)
        {
            int cellSize = 30;

            tablePanel.Size = new Size(cellSize * (size + 1), cellSize * (size + 1));

            for (int row = 0; row < size + 1; row++)
            {
                for (int col = 0; col < size + 1; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        Label label = new Label
                        {
                            Text = "",
                            Width = cellSize,
                            Height = cellSize - 3,
                            Margin = new Padding(0),
                            BorderStyle = BorderStyle.FixedSingle,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tablePanel.Controls.Add(label);
                    }
                    else if (row == 0 || col == 0)
                    {
                        Label label = new Label
                        {
                            Text = ((char)(96 + Math.Max(row, col))).ToString(),
                            Width = cellSize,
                            Height = cellSize - 3,
                            Margin = new Padding(0),
                            BorderStyle = BorderStyle.FixedSingle,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tablePanel.Controls.Add(label);
                    }
                    else
                    {
                        TextBox textBox = new TextBox
                        {
                            Width = cellSize,
                            Height = cellSize,
                            Margin = new Padding(0),
                            BorderStyle = BorderStyle.FixedSingle,
                            TextAlign = HorizontalAlignment.Center,
                            MaxLength = 1
                        };
                        tablePanel.Controls.Add(textBox);
                    }
                }
            }
        }

        private void DeleteTable()
        {
            tablePanel.Controls.Clear();
        }

        void ClearLabels()
        {
            errorLabel.Text = "";
            messageLabel.Text = "";
            labelResult.Text = "";
        }

        private int[,] ReadFromTable(int size)
        {
            int[,] matrix = new int[size, size];
            int row = 0;
            int col = 0;

            foreach (Control control in tablePanel.Controls)
            {
                if (control is TextBox box)
                {
                    if ((int.TryParse(box.Text, out int n) && (n == 1 || n == 0) || box.Text == ""))
                    {
                        if (box.Text == "")
                        {
                            matrix[row, col] = 0;
                        }

                        matrix[row, col] = n;
                    }
                    else
                    {
                        errorLabel.Text = "В таблице должны быть только 0 и 1!";
                        return new int[0, 0];
                    }

                    col++;
                    if (col == size)
                    {
                        row++;
                        col = 0;
                    }
                }
            }
            return matrix;
        }

        static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            int size = A.GetLength(0);
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; (k < size) && result[i, j] == 0; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return result;
        }

        static int[,] IdentityMatrix(int size)
        {
            int[,] identity = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                identity[i, i] = 1;
            }
            return identity;
        }

        static int[,] MatrixSum(int[,] A, int[,] B)
        {
            int size = A.GetLength(0);
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = Math.Max(A[i, j], B[i, j]);
                }
            }
            return result;
        }

        static int[,] ReachabilityMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            int[,] result = IdentityMatrix(size);
            int[,] currentMatrix = result;

            for (int i = 0; i < size; i++)
            {
                currentMatrix = MultiplyMatrices(currentMatrix, matrix);
                result = MatrixSum(result, currentMatrix);
            }

            return result;
        }

        static int[,] StrongMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            matrix = ReachabilityMatrix(matrix);

            int[,] strongMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    strongMatrix[i, j] = Math.Min(matrix[i, j], matrix[j, i]);
                }
            }

            return strongMatrix;
        }

        static string DetermConnectyComp(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            HashSet<int> blocked = new HashSet<int>();
            string result = "";

            for (int i = 0; i < size; i++)
            {
                if (blocked.Contains(i))
                    continue;
                result += "{";
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        result += (char)(97 + j);
                        blocked.Add(j);
                    }
                }
                result += "}";
            }
            return result;
        }
    }
}
