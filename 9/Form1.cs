using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string costInput = textBox1.Text;
            decimal cost;
            string moneyInput = textBox2.Text;
            decimal money;

            if (!Decimal.TryParse(costInput, out cost) & !Decimal.TryParse(moneyInput, out money))
            {
                MessageBox.Show("Некорректный ввод. Пожалуйста, введите стоимость в формате 20.00.");
            }
            else
            {
                if (money < cost)
                {
                    MessageBox.Show("Количество денег недостаточно для оплаты товара.");
                }

                ChangeCalculator calculator = new ChangeCalculator();
                Change change = calculator.CalculateChange(cost, money);

                textBox3.Text = $"Рублей: {change.Rubles}, копеек: {change.Kopecks}";
                foreach (Coin coin in change.Coins)
                {
                    MessageBox.Show($"Мелкая сдача: {coin.Value} копеек: {coin.Count} штук");
                }
            }
        }
    }
}
