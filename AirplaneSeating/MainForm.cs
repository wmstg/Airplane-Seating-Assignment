using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AirplaneSeating
{
    public partial class MainForm : Form
    {
        // Filename to save the reservation data to
        private String file = "AirlineBooking.dat";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Airplane.Instance.ConsoleSeating();
            dataGridView1.DataSource = Airplane.Instance.seatList;
            dataGridView1.ReadOnly = false;

            dataGridView1.Columns[3].ReadOnly = false;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Set initial seat assigment cabin to first class - We try to upsell
            radioBtnFirstClass.Checked = true;

            Airplane.Instance.DisplaySeating(airplaneSeatPanel);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnFirstClass.Checked)
            {
                // Clear party size
                partySizeCBox.Items.Clear();

                // Add the new range. We need to convert to a string object
                partySizeCBox.Items.AddRange(Enumerable.Range(1, 2).Select(n => n.ToString()).ToArray());

                // Select first entry
                partySizeCBox.SelectedIndex = 0;

                // Clear seat types
                cBoxSeatType.Items.Clear();

                // Get the seats for this cabin type
                cBoxSeatType.Items.AddRange(Airplane.GetSeatTypesByCabin(Airplane.CABIN_FIRST));

                // Select first entry
                cBoxSeatType.SelectedIndex = 0;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    Seat data = dataGridView1.Rows[e.RowIndex].DataBoundItem as Seat;

                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = data.Passenger;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // This should not occur
                }
                catch (NullReferenceException)
                {
                    // A null reference once occured when Passenger.Name was not initialised. It is always set to a string value now.
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                String name = (String)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                name = name ?? ""; // prevents a null exception notice
                Airplane.Instance.seatList[e.RowIndex].Passenger = name;

                // The name can only contain letters, hypen or a space
                if (System.Text.RegularExpressions.Regex.IsMatch(name, "^([a-zA-Z-]+[\\s]?)+$"))
                {
                    dataGridView1.Refresh();
                    if (!String.IsNullOrEmpty(Airplane.Instance.seatList[e.RowIndex].Passenger))
                    {
                        Airplane.Instance.seatList[e.RowIndex].Reserved = true;
                        airplaneSeatPanel.Controls["btn" + Airplane.Instance.seatList[e.RowIndex].SeatId].BackColor = Color.Green;
                    }
                    else
                    {
                        Airplane.Instance.seatList[e.RowIndex].Reserved = false;
                        airplaneSeatPanel.Controls["btn" + Airplane.Instance.seatList[e.RowIndex].SeatId].BackColor = default(Color);
                    }
                }
                else
                {
                    MessageBox.Show("A name can only contain letters, hyphen or spaces.", "Passenger Name");
                    Airplane.Instance.seatList[e.RowIndex].Passenger = "?";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioBtnEconomyClass_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnEconomyClass.Checked)
            {
                // Clear party size
                partySizeCBox.Items.Clear();

                // Add the new range. We need to convert to a string object
                partySizeCBox.Items.AddRange(Enumerable.Range(1, 3).Select(n => n.ToString()).ToArray());

                // Select first entry
                partySizeCBox.SelectedIndex = 0;

                // Clear seat types
                cBoxSeatType.Items.Clear();

                // Get the seats for this cabin type
                cBoxSeatType.Items.AddRange(Airplane.GetSeatTypesByCabin(Airplane.CABIN_ECONOMY));

                // Select first entry
                cBoxSeatType.SelectedIndex = 0;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Writes the booking information to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerialize_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Serialize?", "Serialize: Saving Booking Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Stream stream = File.Open(file, FileMode.Create);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, Airplane.Instance.seatList);
                    stream.Close();
                    MessageBox.Show("Airline Booking Data saved to file", "Serialize: Saving Booking Data");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "There was an error whilst writing to file.");
                }
            }
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Deserialize?", "Deserialize: Loading Booking Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();

                    //Open the file written above and read values from it.
                    Stream stream = File.Open(file, FileMode.Open);

                    BinaryFormatter binaryformatter = new BinaryFormatter();

                    // Clear the seating List and re-populate
                    Airplane.Instance.seatList.Clear();
                    Airplane.Instance.seatList = (List<Seat>)binaryformatter.Deserialize(stream);
                    stream.Close();

                    dataGridView1.DataSource = Airplane.Instance.seatList;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.Columns[3].ReadOnly = false;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // Refresh Grid
                    dataGridView1.Refresh();

                    // Reset panel controls
                    airplaneSeatPanel.Controls.Clear();
                    // "Refresh" seating display panel
                    Airplane.Instance.DisplaySeating(airplaneSeatPanel);

                    // Display dialog confirmation
                    MessageBox.Show("Airline Booking Data retrieved from file", "Deserialize: Loading Booking Data");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "There was an error whilst trying to read the file!");
                }
            }
        }

        /// <summary>
        /// Sort the List by passenger name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortByPassenger_Click(object sender, EventArgs e)
        {
            Airplane.Instance.seatList.Sort((x, y) => string.Compare(x.Passenger, y.Passenger));

            dataGridView1.DataSource = Airplane.Instance.seatList;
            dataGridView1.Refresh();
        }

        /// <summary>
        /// Sort the List by seat number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortBySeat_Click(object sender, EventArgs e)
        {
            // Sorting with string values requires same length values
            Airplane.Instance.seatList.Sort(
                (x, y) => string.Compare(x.SeatId.PadLeft(3, '0'), y.SeatId.PadLeft(3, '0'))
                );
            dataGridView1.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String cabinClass = null;

            if (radioBtnFirstClass.Checked)
            {
                cabinClass = Airplane.CABIN_FIRST;
            }
            else if (radioBtnEconomyClass.Checked)
            {
                cabinClass = Airplane.CABIN_ECONOMY;
            }

            // Check seat availability
            Airplane.ReserveSeat(Airplane.SeatAvailability(cabinClass,
                cBoxSeatType.SelectedItem.ToString(),
                int.Parse(partySizeCBox.SelectedItem.ToString())
                ));
        }

        /// <summary>
        /// Helper function to refresh seating display and select the associated datagridview row
        /// </summary>
        /// <param name="rowId">Id of the row to be selected</param>
        public void RefreshDataView(int rowId)
        {
            dataGridView1.Refresh();
            dataGridView1.FirstDisplayedScrollingRowIndex = rowId;
            dataGridView1.Rows[rowId].Selected = true;

            airplaneSeatPanel.Controls.Clear();
            Airplane.Instance.DisplaySeating(airplaneSeatPanel);
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
