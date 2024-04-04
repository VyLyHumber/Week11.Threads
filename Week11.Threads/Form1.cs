using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11.Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            // Clear previous results
            listBoxResult.Items.Clear();
            // Validate input
            if (!int.TryParse(textBoxSearch.Text, out int input) || input <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer.");
                return;
            }

            // Start generating Fibonacci numbers in a background thread
            Task search = Task.Run(() => SearchFibonacci(input));
            // Wait for all tasks to complete
            await Task.WhenAll(search);
        }
        private void SearchFibonacci(int input)
        {
            for (int i = 0; i < input; i++)
            {
                // Calculate Fibonacci number
                int fib = Fibonacci(i);

                // Update UI with the generated Fibonacci number
                BeginInvoke((Action)(() =>
                {
                    listBoxResult.Items.Add(fib);
                }));
            }
        }

        // Method to calculate Fibonacci numbers
        private int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
