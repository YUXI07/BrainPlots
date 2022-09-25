using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Chart.xaml 的交互逻辑
    /// </summary>
    public partial class Chart : Window
    {
        private Queue<double> dataQueue = new Queue<double>(100);

        private Queue<double> dataQueueSin = new Queue<double>(100);
        public Chart()
        {
            InitializeComponent();
        }
        private void InitBtn_Click(object sender, RoutedEventArgs e)
        {
            InitChart();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateQueueValue();
            this.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
            this.chart1.Series[1].Points.Clear();
            for (int i = 0; i < dataQueueSin.Count; i++)
            {
                this.chart1.Series[1].Points.AddXY((i + 1), dataQueueSin.ElementAt(i));
            }
        }

        private void UpdateQueueValue()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                //对象添加到 System.Collections.Generic.Queue<T> 的结尾处。
                dataQueue.Enqueue(r.Next(0, 100));
            }

            int curValue = 0;
            for (int i = 0; i < 100; i++)
            {
                curValue = curValue % 360;
                dataQueueSin.Enqueue(50 * Math.Sin(curValue * Math.PI / 180) + 50);
                curValue += 10;
            }
        }

        private void InitChart()
        {
            //定义图标区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);

            ChartArea chartArea2 = new ChartArea("C2");
            this.chart1.ChartAreas.Add(chartArea2);

            //定义储存和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("S1");
            series1.ChartArea = "C1";
            this.chart1.Series.Add(series1);

            Series series2 = new Series("S2");
            series2.ChartArea = "C2";
            this.chart1.Series.Add(series2);

            //设置图标显示样式
            foreach (var item in this.chart1.ChartAreas)
            {
                item.AxisX.Minimum = 0;
                item.AxisX.Maximum = 100;
                item.AxisX.Interval = 5;
                item.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
                item.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            }
            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S1");
            this.chart1.Titles[0].Text = "图形绘制展示";
            this.chart1.Titles[0].ForeColor = System.Drawing.Color.RoyalBlue;
            this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图标显示样式
            this.chart1.Series[0].Color = System.Drawing.Color.Red;
            this.chart1.Series[1].Color = System.Drawing.Color.Red;

            this.chart1.Series[0].ChartType = SeriesChartType.Line;

            this.chart1.Series[1].ChartType = SeriesChartType.Spline;

            this.chart1.Series[0].Points.Clear();

            // 清除dataQueue中所有数据
            dataQueue.Clear();
            dataQueueSin.Clear();
        }

    }
}
