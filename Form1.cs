using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ChicagoCrime
{
  public partial class Form1 : Form
  {
     public Form1()
    {
      InitializeComponent();
    }

    private bool doesFileExist(string filename)
    {
      if (!System.IO.File.Exists(filename))
      {
        string msg = string.Format("Input file not found: '{0}'",
          filename);

        MessageBox.Show(msg);
        return false;
      }

      // exists!
      return true;
    }

    private void clearForm()
    {
      // 
      // if a chart is being displayed currently, remove it:
      //
      if (this.graphPanel.Controls.Count > 0)
      {
        this.graphPanel.Controls.RemoveAt(0);
        this.graphPanel.Refresh();
      }
    }

    private void cmdByYear_Click(object sender, EventArgs e)
    {
      string filename = this.txtFilename.Text;

      if (!doesFileExist(filename))
        return;

      clearForm();

      //
      // Call over to F# code to analyze data and return a 
      // chart to display:
      //
      this.Cursor = Cursors.WaitCursor;

      var chart = FSAnalysis.CrimesByYear(filename);

      this.Cursor = Cursors.Default;

      //
      // we have chart, display it:
      //
      this.graphPanel.Controls.Add(chart);
      this.graphPanel.Refresh();
    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Arrest_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.ArrestByYear(filename);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

        private void ByCrime_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;
            string i = this.textBox1.Text;
            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.IUCR_des1(filename,i);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;
            string i = this.textBox2.Text;
            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.AreaCrime (filename, i);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;
            
            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.Chicago(filename);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

        private void SQLBUtton_Click(object sender, EventArgs e)
        {
            string filename,version, connectionInfo;
            SqlConnection db; version = "MSSQLLocalDB";
            filename = "CrimeDB.mdf";
            connectionInfo = string.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;",version, filename);
            db = new SqlConnection(connectionInfo);
            db.Open();
            //MessageBox.Show(db.State.ToString());
            string sql,msg;
            SqlCommand cmd;
            object result;
            // sql = @" SELECT Count(*)AS Total FROM Crimes WHERE Year=2015 AND (Beat =1213 OR Beat =1232);";
            //sql = @"SELECT Count (*) from information_schema.tables Where table_type='base table';";
            sql = @" Select Area From Areas Where AreaName = 'Uptown';";
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;
            result = cmd.ExecuteScalar();
            msg = String.Format("# ofcrimes:{0}", result);
            listBox1.Items.Add(msg);
            db.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}//namespace
