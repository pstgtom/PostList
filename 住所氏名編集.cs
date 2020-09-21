using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace 口酒井農業水利組合郵送会員住所録
{
    public partial class 住所氏名編集Form : Form
    {
        private string[] Values;
        public 住所録リストForm formMain;

        public 住所氏名編集Form()
        {
            InitializeComponent();
            分類セット();
            ValuesAttach();

        }


        private void 分類セット()
        {
            分類combo.Items.Add("入作関係");
            分類combo.Items.Add("企業協力金");
            分類combo.Items.Add("墓地管理");
            分類combo.Text = "入作関係";
        }

        private void ValuesAttach()
        {
            Values = new string[5];
            Values[0] = IDBox.Text;
            Values[1] = 氏名Box.Text;
            Values[2] = 郵便番号Box.Text;
            Values[3] = 住所Box.Text;
            Values[4] = 分類combo.Text;
        }


        public string[]  AddSet
        {
            set
            {
                Values = value;
                IDBox.Text = Values[0];
                氏名Box.Text = Values[1];
                郵便番号Box.Text = Values[2];
                住所Box.Text = Values[3];
                分類combo.Text = Values[4];
            }
            get
            {
                return Values;
            }

        }



        private void 住所氏名編集_Load(object sender, EventArgs e)
        {
        }

        private void 新規追加btn_Click(object sender, EventArgs e)
        {
            if (分類combo.SelectedIndex == -1)
            {
                MessageBox.Show("分類が選択されていません。");
                return;
            }


            ValuesAttach();

            //// セルの領域を選択
            //var TableRange = 口酒井名簿.Range["A2"].CurrentRegion;

            //// 選択した領域の値をメモリー上に格納
            //object[,] values = TableRange.Value;
            //string a = 口酒井名簿.range["A" + i].text;
            int b = int.Parse(a);
            int c = b + 1;

            //口酒井名簿.range["A" + (i + 1)] = c.ToString();          //ID
            //口酒井名簿.range["B" + (i + 1)] = (String)Values[1];   //氏名
            //口酒井名簿.range["C" + (i + 1)] = (String)Values[2];   //郵便番号
            //口酒井名簿.range["D" + (i + 1)] = (String)Values[3];   //住所
            //口酒井名簿.range["E" + (i + 1)] = (String)Values[4];   //分類

            IDBox.Text = c.ToString();          //IDを変更
            ValuesAttach();

 
            MessageBox.Show("追加しました");

            formMain.Lvflag = "追加";

            this.Close();
        }


        private void 修正btn_Click(object sender, EventArgs e)
        {

            ValuesAttach();

            //// セルの領域を選択
            //var TableRange = 口酒井名簿.Range["A2"].CurrentRegion;

            // 選択した領域の値をメモリー上に格納
            object[,] values = TableRange.Value;


            for (int i = 2; i <= values.GetLength(0); i++)
            {
                double セル値 = (double)values[i, 1];

                if (セル値 == double.Parse(Values[0]) )
                {
                    //口酒井名簿.range["B" + i] = (String)Values[1];   //氏名
                    //口酒井名簿.range["C" + i] = (String)Values[2];   //郵便番号
                    //口酒井名簿.range["D" + i] = (String)Values[3];   //住所
                    //口酒井名簿.range["E" + i] = (String)Values[4];   //分類

                    MessageBox.Show("修正しました");
                    break;
                }
            }

            formMain.Lvflag = "修正";
            this.Close();

        }

        private void 削除btn_Click(object sender, EventArgs e)
        {
            ValuesAttach();

            //// セルの領域を選択
            //var TableRange = 口酒井名簿.Range["A2"].CurrentRegion;

            // 選択した領域の値をメモリー上に格納
            object[,] values = TableRange.Value;


            for (int i = 2; i <= values.GetLength(0); i++)
            {
                double セル値 = (double)values[i, 1];

                if (セル値 == double.Parse(Values[0]))
                {
                    DialogResult result = MessageBox.Show("ID　"+ (String)Values[0] + "\n"
                        + "氏名　" + (String)Values[1] + "\n"   //氏名
                        + "郵便番号　" + (String)Values[2] + "\n"   //郵便番号
                        + "住所　" + (String)Values[3] + "\n"
                        + "分類　" + (String)Values[4] + "\n"
                        + "さんのアドレスを削除して良いですか？"
                        , "アドレス削除の確認"
                        , MessageBoxButtons.OKCancel
                        , MessageBoxIcon.Question
                        , MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("削除を中止します。");

                        this.Close();

                        return;
                    }

                    IDBox.Text = "";
                    氏名Box.Text = "";
                    郵便番号Box.Text = "";
                    住所Box.Text = "";
                    分類combo.Text = "";

                    ValuesAttach();
                    MessageBox.Show("削除しました");
                    break;
                }
            }

            formMain.Lvflag = "削除";

            this.Close();

        }

        private void 住所氏名編集Form_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


    }
}
