using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetamp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static long DatetimeToUnixTimestamp(DateTime dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = dateTime.ToUniversalTime() - epoch;
            return (long)timeSpan.TotalSeconds;
        }

        public static DateTime UnixTimestampToDatetime(long timestamp)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTime = epoch.AddSeconds(timestamp);
            return dateTime.ToLocalTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = dateTimePicker1.Value;
            long timestamp = DatetimeToUnixTimestamp(now);
            textBox1.Text = timestamp.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 方法1：
            //long timestampInput = Convert.ToInt32(textBox1.Text);
            //DateTime datetime = UnixTimestampToDatetime(timestampInput);
            //dateTimePicker2.Value = datetime;
            //textBox2.Text = datetime.ToString();

            // 方法2：
            long timestamp = Convert.ToInt32(textBox1.Text);
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);

            TimeSpan offset = TimeSpan.FromHours(8);
            DateTimeOffset convertdateoffset = dateTimeOffset.ToOffset(offset);
            DateTime convertime = convertdateoffset.DateTime;

            //DateTime dateTime = dateTimeOffset.DateTime;
            dateTimePicker2.Text = convertime.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
