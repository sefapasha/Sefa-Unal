using System.Text.RegularExpressions;
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BilgisayarMimarisi_HammingCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputData = textBox1.Text.Trim(); // Bo�luklar� temizle

            // Kabul edilen uzunluklar
            int[] gecerliUzunluklar = { 8, 16, 32 };

            // Girdi kontrol�
            if (GirdiKontrolu(inputData, gecerliUzunluklar))
            {
                // Ge�erli giri� mesaj olarak g�sterilir
                MessageBox.Show($"Girilen veri: {inputData}", "Ge�erli Veri", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hamming kodu hesaplan�r ve g�sterilir
                string hammingCode = HammingCodeFonk(inputData);
                textBox2.Text = hammingCode;
            }
            else
            {
                // Hatal� giri� i�in uyar� verilir
                MessageBox.Show(
                    $"L�tfen sadece 8, 16 veya 32bit uzunlu�unda '0' ve '1' i�eren bir veri girin.\n\nGirdi�iniz veri: {inputData}",
                    "Ge�ersiz Veri",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool GirdiKontrolu(string input, int[] validLengths)
        {
            // Girdi sadece 0 ve 1'lerden olu�mal�
            bool isBinary = Regex.IsMatch(input, "^[01]+$");

            // Girdi uzunlu�u validLengths dizisinde olmal�
            bool isValidLength = Array.Exists(validLengths, length => length == input.Length);

            // �kisi de do�ru ise true d�ner
            return isBinary && isValidLength;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hammingCode = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(hammingCode))
            {
                MessageBox.Show("L�tfen �nce bir Hamming kodu �retin.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bit pozisyonu kullan�c�dan al�n�r
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "L�tfen de�i�tirmek istedi�iniz bit i�in pozisyon giriniz: ",
                "Bit De�i�tirme",
                "1"
            );

            if (int.TryParse(input, out int bitPosition) && bitPosition >= 1 && bitPosition <= hammingCode.Length)
            {
                // Bit terslenir (0 -> 1, 1 -> 0)
                char[] codeArray = hammingCode.ToCharArray();
                int index = bitPosition - 1; // 1 tabanl�dan 0 tabanl�ya

                codeArray[index] = codeArray[index] == '0' ? '1' : '0';
                string corruptedCode = new string(codeArray);

                textBox3.Text = corruptedCode;

                // Sendrom ve overall parity hesaplan�r
                var result = SendromFonk(corruptedCode);

                textBox4.Text = result.SyndromeBinary;

                if (result.SyndromeValue == 0 && result.OverallParity == 0)
                {
                    textBox5.Text = "Hata bulunamad� (veri do�ru).";
                }
                else if (result.SyndromeValue != 0 && result.OverallParity == 1)
                {
                    textBox5.Text = $"Tek bit hatas� bulundu! Hatal� bit pozisyonu: {result.SyndromeValue}";

                    // Hatal� biti d�zelt
                    char[] correctedCodeArray = corruptedCode.ToCharArray();
                    int errorIndex = result.SyndromeValue - 1; // 1 tabanl�dan 0 tabanl�ya
                    correctedCodeArray[errorIndex] = correctedCodeArray[errorIndex] == '0' ? '1' : '0';
                    string correctedCode = new string(correctedCodeArray);
                    textBox6.Text = correctedCode; // D�zeltmi� kodu g�stermek i�in ek bir TextBox (textBox6)
                }
                else if (result.SyndromeValue == 0 && result.OverallParity == 1)
                {
                    textBox5.Text = "�ift bit hatas� tespit edildi (d�zeltilemez).";
                    textBox6.Text = "";
                }
                else
                {
                    textBox5.Text = "Bilinmeyen hata durumu.";
                    textBox6.Text = "";
                }
            }
            else
            {
                MessageBox.Show("L�tfen 1 ile " + hammingCode.Length + " aras�nda ge�erli bir pozisyon girin.", "Ge�ersiz Giri�", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (int SyndromeValue, string SyndromeBinary, int OverallParity) SendromFonk(string corruptedCode)
        {
            int n = corruptedCode.Length;

            // Parity bit say�s�n� hesapla (r), �yle ki 2^r >= n - r -1 olmal� (overall parity var)
            int r = 0;
            while ((1 << r) < n)
                r++;

            int syndromeValue = 0;

            for (int i = 0; i < r; i++)
            {
                int parityIndex = (1 << i) - 1;
                int parityCheck = 0;

                for (int j = parityIndex; j < n - 1; j += 2 * (parityIndex + 1))
                {
                    for (int k = j; k < j + parityIndex + 1 && k < n - 1; k++)
                    {
                        parityCheck ^= (corruptedCode[k] - '0');
                    }
                }

                if (parityCheck == 1)
                {
                    syndromeValue += (1 << i);
                }
            }

            // Overall parity hesapla (son bit overall parity bit)
            int overallParity = 0;
            for (int i = 0; i < n; i++)
            {
                overallParity ^= (corruptedCode[i] - '0');
            }

            string syndromeBinary = Convert.ToString(syndromeValue, 2).PadLeft(r, '0');

            return (syndromeValue, syndromeBinary, overallParity);
        }

        private string HammingCodeFonk(string data)
        {
            int m = data.Length;

            // Parity bit say�s�n� hesapla: 2^r >= m + r + 1
            int r = 0;
            while ((1 << r) < m + r + 1)
            {
                r++;
            }

            int n = m + r + 1; // overall parity i�in +1 bit
            char[] hammingCode = new char[n];

            // Parity bit pozisyonlar�na 'P', veri bitlerine data'y� yerle�tir
            int dataIndex = 0;
            for (int i = 0; i < n - 1; i++)  // Son bit overall parity olacak
            {
                if (IsPowerOfTwo(i + 1))
                    hammingCode[i] = 'P';
                else
                    hammingCode[i] = data[dataIndex++];
            }

            // Parity bitlerini hesapla ve yerle�tir
            for (int i = 0; i < r; i++)
            {
                int parityPos = 1 << i;
                int parity = 0;

                for (int j = parityPos - 1; j < n - 1; j += 2 * parityPos)
                {
                    for (int k = j; k < j + parityPos && k < n - 1; k++)
                    {
                        if (hammingCode[k] != 'P')
                            parity ^= (hammingCode[k] - '0');
                    }
                }

                hammingCode[parityPos - 1] = (char)(parity + '0');
            }

            // Overall parity bit hesapla (t�m kodun parity'si)
            int overallParity = 0;
            for (int i = 0; i < n - 1; i++)
            {
                overallParity ^= (hammingCode[i] - '0');
            }
            hammingCode[n - 1] = (char)(overallParity + '0');

            return new string(hammingCode);
        }

        private bool IsPowerOfTwo(int x)
        {
            if (x <= 0)
                return false;

            return (x & (x - 1)) == 0;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
