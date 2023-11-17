using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

class Program : Form
{
    private TextBox inputTextBox;
    private TextBox wordTextBox;
    private TextBox charactersAfterTextBox;
    private Button searchButton;
    private RichTextBox resultTextBox;

    public Program()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        inputTextBox = new TextBox();
        wordTextBox = new TextBox();
        charactersAfterTextBox = new TextBox();
        searchButton = new Button();
        resultTextBox = new RichTextBox();

        // Настройка на формата
        this.Text = "Търсене на дума и числа";
        this.Size = new System.Drawing.Size(400, 300);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Настройка на текстовите полета
        inputTextBox.Multiline = true;
        inputTextBox.Size = new System.Drawing.Size(350, 50);
        inputTextBox.Location = new System.Drawing.Point(20, 20);
        this.Controls.Add(inputTextBox);

        wordTextBox.Size = new System.Drawing.Size(150, 20);
        wordTextBox.Location = new System.Drawing.Point(20, 90);
        this.Controls.Add(wordTextBox);

        charactersAfterTextBox.Size = new System.Drawing.Size(50, 20);
        charactersAfterTextBox.Location = new System.Drawing.Point(180, 90);
        this.Controls.Add(charactersAfterTextBox);

        // Настройка на бутона
        searchButton.Text = "Търсене";
        searchButton.Size = new System.Drawing.Size(80, 30);
        searchButton.Location = new System.Drawing.Point(250, 85);
        searchButton.Click += SearchButtonClick;
        this.Controls.Add(searchButton);

        // Настройка на полето за резултати
        resultTextBox.Size = new System.Drawing.Size(350, 100);
        resultTextBox.Location = new System.Drawing.Point(20, 130);
        resultTextBox.ReadOnly = true;
        this.Controls.Add(resultTextBox);
    }

    private void SearchButtonClick(object sender, EventArgs e)
    {
        string inputText = inputTextBox.Text;
        string targetWord = wordTextBox.Text;
        int charactersAfter;

        if (int.TryParse(charactersAfterTextBox.Text, out charactersAfter) && charactersAfter >= 0)
        {
            PrintOccurrences(inputText, targetWord, charactersAfter);
        }
        else
        {
            resultTextBox.Text = "Невалиден брой символи след думата.";
        }
    }

    private void PrintOccurrences(string input, string targetWord, int charactersAfter)
    {
        string pattern = $@"{Regex.Escape(targetWord)}\s*(\d{{0,{charactersAfter}}})";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(input);

        if (matches.Count > 0)
        {
            resultTextBox.Text = "Резултати:\n";
            foreach (Match match in matches)
            {
                resultTextBox.AppendText($"{targetWord}{match.Groups[1].Value}\n");
            }
        }
        else
        {
            resultTextBox.Text = $"Думата '{targetWord}' не е намерена в текста.";
        }
    }

    static void Main()
    {
        Application.Run(new Program());
    }
}

