using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HomeworkApp
{
    public partial class Form1 : Form
    {
        //インスタンスを作る
        public Form1()
        {
            InitializeComponent();
        }

        //Form1が表示されるときに一度だけ実行、第一引数には関数を引き起こしたオブジェクトが入る。第二は形式的に
        private void Form1_Load(object sender, EventArgs e)
        {
            //行数の設定
            dataGridView1.RowCount = 18;
            //改行を許可
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //セルの高さの設定
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 35;
            }
            for (int i = 0; i < 6; i++)
            {
                int row = i * 3;

                // 左端に「1限」など(三の倍数以外は課題書かれるところ)
                dataGridView1[0, row].Value = $"{i + 1}限";

                // 色付け
                dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.LightGray;
            }
            //データをロード
            LoadData();
            //タイマースタート
            timer1.Start();
        }

        //セルをダブルクリックしたときに。第二引数はクリックしたセルの位置
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //教科名が書かれるセルをクリックしたとき
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1 && e.RowIndex % 3 == 0)
            {
                //Form2はクラス名、formが変数名、new Form2()でインスタンスをつくる
                Form2 form = new Form2();
                //入力してボタン押されたら
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // データ保存
                    dataGridView1[e.ColumnIndex, e.RowIndex].Tag = form;

                    // 教科名を時限行に表示
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = form.Subject;
                }
            }
        }

        //参照をみたらわかるけど、Timer１にある、Tickがされたらこれが呼ばれるようになってる
        private void timer1_Tick(object sender, EventArgs e)
        {
            //nowに現在時刻を代入
            DateTime now = DateTime.Now;
            //全行を繰り返す
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //全列を繰り返す
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // 時限行かつタグにForm2オブジェクトがはいってるならfに変換
                    if (row.Index % 3 == 0 && cell.Tag is Form2 f)
                    {
                        //時間が書かれる行の変数
                        int row1 = row.Index + 1;
                        int row2 = row.Index + 2;

                        // 課題①
                        //上のfでとってきた時間を下の関数に代入して残り時間を製作
                        int minute1 = GetRemainingMinutes(f.Task1, f.Day1, f.Time1, now);
                        //デフォルトでfalse完了したときにtrue
                        if (minute1 <= 1)
                        {
                            f.Task1Completed = false;
                        }
                        // 課題②
                        int minute2 = GetRemainingMinutes(f.Task2, f.Day2, f.Time2, now);
                        if (minute2 <= 1)
                        {
                            f.Task2Completed = false;
                        }

                        //課題１
                        //Form2のTask1が空じゃないなら
                        if (!string.IsNullOrWhiteSpace(f.Task1))
                        {
                            //Task1Completedがtrueなら
                            if (f.Task1Completed)
                            {
                                //課題名と完了を表示
                                dataGridView1[cell.ColumnIndex, row1].Value = $"{f.Task1}\n完了";
                                //背景を変色
                                dataGridView1[cell.ColumnIndex, row1].Style.BackColor =
                                    Color.LightGreen;
                                //文字の色を白に
                                dataGridView1[cell.ColumnIndex, row1].Style.ForeColor = Color.White;
                            }
                            //そうでないなら
                            else
                            {
                                //分を時間に変換して名前と時間を表示
                                TimeSpan remain1 = TimeSpan.FromMinutes(minute1);
                                dataGridView1[cell.ColumnIndex, row1].Value =
                                    $"{f.Task1}\nあと {remain1.Days}日 {remain1.Hours}時間 {remain1.Minutes}分";
                                //時間から背景の色を下の関数をつかって作る
                                dataGridView1[cell.ColumnIndex, row1].Style.BackColor = GetDeadlineColor(minute1);
                                //文字の色を白に
                                dataGridView1[cell.ColumnIndex, row1].Style.ForeColor = Color.White;
                            }

                        }
                        //課題を削除するときに
                        else
                        {
                            dataGridView1[cell.ColumnIndex, row1].Value = "";
                            dataGridView1[cell.ColumnIndex, row1]
                                .Style.BackColor = Color.White;
                        }
                        //課題２
                        if (!string.IsNullOrWhiteSpace(f.Task2))
                        {
                            if (f.Task2Completed)
                            {
                                dataGridView1[cell.ColumnIndex, row2].Value = $"{f.Task2}\n完了";
                                dataGridView1[cell.ColumnIndex, row2].Style.BackColor =
                                    Color.LightGreen;
                                dataGridView1[cell.ColumnIndex, row2].Style.ForeColor = Color.White;
                            }
                            else
                            {
                                TimeSpan remain2 = TimeSpan.FromMinutes(minute2);
                                dataGridView1[cell.ColumnIndex, row2].Value =
                                    $"{f.Task2}\nあと {remain2.Days}日 {remain2.Hours}時間 {remain2.Minutes}分";
                                dataGridView1[cell.ColumnIndex, row2].Style.BackColor = GetDeadlineColor(minute2);
                                dataGridView1[cell.ColumnIndex, row2].Style.ForeColor = Color.White;
                            }

                        }
                        else
                        {
                            dataGridView1[cell.ColumnIndex, row2].Value = "";
                            dataGridView1[cell.ColumnIndex, row2]
                                .Style.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        //ダブルクリックしたときに
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ヘッダーとかのクリック対策
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
                return;

            //課題の残り時間が表示されてるセルなら
            if (e.RowIndex % 3 != 0)
            {
                //クリックしたセルの情報が入ってる上のセルの行の位置を入手
                int topRow = e.RowIndex - (e.RowIndex % 3);
                //特定したセルを代入
                DataGridViewCell topCell = dataGridView1[e.ColumnIndex, topRow];
                //topcellのtagがFoem２型ならfとして使う
                if (topCell.Tag is Form2 f)
                {
                    //メッセージボックスを表示して結果をresultに
                    DialogResult reslut = MessageBox.Show("課題を完了しましたか？", "確認", MessageBoxButtons.OKCancel);
                    //resultがOKなら
                    if (reslut == DialogResult.OK)
                    {
                        //クリックしたセルの位置によってどのboolをtrueにするか
                        if (e.RowIndex % 3 == 1)
                        {
                            f.Task1Completed = true;
                        }
                        else
                        {
                            f.Task2Completed = true;
                        }
                    }
                }
            }
        }

        // 残り時間計算
        private int GetRemainingMinutes(string task, DayOfWeek day, TimeSpan time, DateTime now)
        {
            //締め切りの曜日から今の曜日を引く、この時今の曜日のほうが値が大きいとマイナスになるので+7をして7以上を防ぐために%
            int diff = ((int)day - (int)now.DayOfWeek + 7) % 7;
            //今日の日付から締め切りの日を計算
            DateTime deadline = now.Date.AddDays(diff).Add(time);
            //当日の過ぎた時間だと狂う
            if (diff == 0 && now.TimeOfDay > time)
            {
                deadline = deadline.AddDays(7);
            }

            TimeSpan remain = deadline - now;
            return (int)remain.TotalMinutes;
        }

        //時間に合わせてセルの色を調整
        private Color GetDeadlineColor(int minutes)
        {
            int maxMinutes = 7 * 24 * 60;

            double ratio = Math.Min((double)minutes / maxMinutes, 1.0);

            int red = (int)(255 * (1 - ratio));

            int blue = (int)(255 * ratio);

            return Color.FromArgb(red, 50, blue);
        }

        //データを保存するための関数
        private void SaveData()
        {
            //保存する場所のパスを作成
            string path =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + "\\homework.csv";

            //パスのファイルを開いて下記の内容を書き込む
            using (StreamWriter sw = new StreamWriter(path))
            {
                //ある行をすべて
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //列をすべて
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //タグがあるならfに入れて
                        if (cell.Tag is Form2 f)
                        {
                            //情報を保存
                            sw.WriteLine(
                                $"{cell.ColumnIndex}," +
                                $"{row.Index}," +
                                $"{f.Subject}," +
                                $"{f.Task1}," +
                                $"{f.Day1}," +
                                $"{f.Time1}," +
                                $"{f.Task1Completed}," +
                                $"{f.Task2}," +
                                $"{f.Day2}," +
                                $"{f.Time2}," +
                                $"{f.Task2Completed}"
                            );
                        }
                    }
                }
            }
        }

        private void LoadData()
        {
            //パスの取得
            string path =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                + "\\homework.csv";
            //パスの位置に何もないなら終了
            if (!File.Exists(path))
                return;
            //全行を繰り返して読む
            foreach (string line in File.ReadAllLines(path))
            {
                //,で分割して配列に格納
                string[] data = line.Split(',');

                Form2 f = new Form2();
                //位置を復元
                int col = int.Parse(data[0]);
                int row = int.Parse(data[1]);

                //科目名を復元
                f.Subject = data[2];

                //課題内容を復元
                f.Task1 = data[3];
                f.Day1 = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), data[4]);
                f.Time1 = TimeSpan.Parse(data[5]);
                f.Task1Completed = bool.Parse(data[6]);

                f.Task2 = data[7];
                f.Day2 = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), data[8]);
                f.Time2 = TimeSpan.Parse(data[9]);
                f.Task2Completed = bool.Parse(data[10]);

                //タグへ戻す
                dataGridView1[col, row].Tag = f;
                dataGridView1[col, row].Value = f.Subject;
            }
        }

        //終了時に
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}