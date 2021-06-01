using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirplaneSeating
{
    class Airplane
    {
        public List<Seat> seatList = new List<Seat>();

        private const String WindowSeat = "Window";
        private const String AisleSeat = "Aisle";
        private const String MiddleSeat = "Middle";

        public static String CABIN_FIRST = "First";
        public static String CABIN_ECONOMY = "Economy";

        private static Airplane instance = null;
        public static Airplane Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Airplane();
                }
                return instance;
            }
        }

        public Airplane()
        {
            // Initialise Seats

            // First Class Seats
            for (int i = 1; i < 6; i++)
            {
                seatList.Add(new Seat(i + "A", Seat.CabinClass.First, WindowSeat));
                seatList.Add(new Seat(i + "B", Seat.CabinClass.First, AisleSeat));

                seatList.Add(new Seat(i + "C", Seat.CabinClass.First, AisleSeat));
                seatList.Add(new Seat(i + "D", Seat.CabinClass.First, WindowSeat));
            }

            //Economy Class Seats
            for (int i = 6; i < 31; i++)
            {
                seatList.Add(new Seat(i + "A", Seat.CabinClass.Economy, WindowSeat));
                seatList.Add(new Seat(i + "B", Seat.CabinClass.Economy, MiddleSeat));
                seatList.Add(new Seat(i + "C", Seat.CabinClass.Economy, AisleSeat));

                seatList.Add(new Seat(i + "D", Seat.CabinClass.Economy, AisleSeat));
                seatList.Add(new Seat(i + "E", Seat.CabinClass.Economy, MiddleSeat));
                seatList.Add(new Seat(i + "F", Seat.CabinClass.Economy, WindowSeat));
            }
        }

        public static String[] GetSeatTypesByCabin(String cabin)
        {
            if (cabin == Airplane.CABIN_FIRST)
            {
                return new string[] { WindowSeat, AisleSeat };
            }
            return new string[] { WindowSeat, AisleSeat, MiddleSeat };
        }

        /// <summary>
        /// Adds and positions the seat buttons on the airplane seat model panel
        /// </summary>
        /// <param name="panel">Reference to the airplane seating panel</param>
        public void DisplaySeating(Panel panel)
        {
            int[] buttonSize = new int[] { 21, 21 };

            int spacing = 2;

            /* The airplane panel was adjusted, the background panel is taller and background layout is now stretched
             * original seating top/left position is below
             * int seatingLeftPos = 200;
             * int seatingTopPos = 28;
            */
            int seatingLeftPos = 180;
            int seatingTopPos = 28;

            int j = 0;
            for (int i = 0; i < seatList.Count(); i++)
            {             
                // First 20 seats separated by row
                if (i < 20)
                {
                    // Track row count
                    if (j >= 4)
                    {
                        j = 0;
                    }

                    // 
                    int col = j % 5;
                    int row = i / 4; 

                    int seatingTop = (col * (buttonSize[0] + spacing)) + seatingTopPos;
                    int seatingLeft = (row * (buttonSize[0] + spacing)) + seatingLeftPos;

                    //if (j >= 2) seatingTop += buttonSize[0] * 2; // Original spacing before panel adjustment

                    /* The following three lines will put an aisle between each of the the first class rows
                     * uncomment and comment the immediate line after.
                     * 
                     * if (j == 1) seatingTop += (buttonSize[0]) + 3; // Positioning adjustment
                     * if (j == 2) seatingTop += (buttonSize[0] * 2) + 3; // Positioning adjustment
                     * if (j > 2) seatingTop += (buttonSize[0] * 3) + 3;
                    */
                    if (j >= 2) seatingTop += (buttonSize[0] * 3) + 3; // Positioning adjustment

                    Button button = new Button();
                    button.Size = new System.Drawing.Size(buttonSize[0], buttonSize[1]);
                    button.Click += new EventHandler(SeatButton_Click);
                    button.Name = "btn" + seatList[i].SeatId;
                    button.Text = seatList[i].SeatId;
                    button.Location = new System.Drawing.Point(seatingLeft, seatingTop);
                    button.Visible = true;
                    button.Font = new System.Drawing.Font(button.Font.FontFamily, 4);

                    if (seatList[i].Reserved)
                    {
                        button.BackColor = System.Drawing.Color.Green;
                    }

                    panel.Controls.Add(button);
                    j++;
                    
                }

                if (i>=20)
                {
                    seatingTopPos = 54; // Added for the increased size of the panel for positioning
                    seatingLeftPos = 256; // 266
                    if (i <= 20)
                    {
                        j = 0;
                    }
                    if (j >= 6)
                    {
                        j = 0;
                    }
                    
                    int col = j % 30;
                    int row = i / 6;

                    int seatingTop = (col * (buttonSize[0] + spacing)) + (seatingTopPos/2);

                    // Fix for 6 rows
                    if (col >= 4)
                    {
                        row -= 1;
                    }

                    int seatingLeft = (row * (buttonSize[0] + spacing)) + seatingLeftPos;

                    if (j >= 3) seatingTop += buttonSize[0];

                    Button button = new Button();
                    button.Size = new System.Drawing.Size(buttonSize[0], buttonSize[1]);
                    button.Click += new EventHandler(SeatButton_Click);
                    button.Name = "btn" + seatList[i].SeatId;
                    button.Text = seatList[i].SeatId;
                    button.Location = new System.Drawing.Point(seatingLeft, seatingTop);
                    button.Visible = true;
                    button.Font = new System.Drawing.Font(button.Font.FontFamily, 4);

                    if (seatList[i].Reserved)
                    {
                        button.BackColor = System.Drawing.Color.Green;
                    }
                    
                    panel.Controls.Add(button);
                    j++;
                }
            }
        }

        /// <summary>
        /// Displays the reserve seat dialog or the current reservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String r = button.Name;
            
            int a = seatList.FindIndex(element => element.SeatId == r.Split(new String[] { "btn" }, StringSplitOptions.None)[1]);
            
            if (seatList[a].Reserved)
            {
                DialogResult dialogResult = MessageBox.Show("Reserved for: " + seatList[a].Passenger + "\nDo you want to remove this reservation?", "Reserved Seat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    seatList[a].Reserved = false;
                    seatList[a].Passenger = "";
                    ((MainForm)MainForm.ActiveForm).RefreshDataView(a);
                }
            }
            else
            {
                ReserveSeat(new int[] { a });
            }
        }

        /// <summary>
        /// Search for seat(s) availability with the specified criteria
        /// </summary>
        /// <returns>
        /// An array of integers
        /// </returns>
        /// <param name="cabin">The cabin class</param>
        /// <param name="seatType">The seat type</param>
        /// <param name="partySize">The size of the party</param>
        public static int[] SeatAvailability(String cabin, String seatType, int partySize)
        {
            // Reference the seatList
            List<Seat> temp = Airplane.Instance.seatList;
            
            // For first class cabin
            if (cabin == CABIN_FIRST)
            {
                if (partySize == 1)
                {
                    String exp = seatType == WindowSeat ? "[AD]$" : "[BC]$";
                    for (int i = 0; i < 20; i++)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, exp))
                        {
                            if (temp[i].Reserved == false)
                            {
                                return new int[] { i };
                            }
                        }
                    }
                }
                else if (partySize == 2)
                {
                    for (int i = 0; i < 20; i+=2)
                    {
                        if (!temp[i].Reserved && (temp[i + 1]!=null && !temp[i + 1].Reserved))
                        {
                            return new int[] { i, i + 1 };
                        }
                    }
                }  
            }
            else if (cabin == CABIN_ECONOMY)
            {
                String exp;

                /* No longer applies to multi seat
                 * Only used for single seat searching
                 */
                switch (seatType)
                {
                    case WindowSeat:
                        exp = "[AF]$";
                        break;
                    case AisleSeat:
                        exp = "[CD]$";
                        break;
                    case MiddleSeat:
                    default:
                        exp = "[BE]$";
                        break;
                }

                if (partySize == 1)
                {
                    for (int i = 20; i < Airplane.instance.seatList.Count()-1; i++)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, exp))
                        {
                            if (temp[i].Reserved == false)
                            {
                                return new int[] { i };
                            }
                        }
                    }
                }
                else if (partySize == 2)
                {
                    // Preference for a window seat
                    if (seatType == WindowSeat)
                    {
                        for (int i = 20; i < Airplane.instance.seatList.Count() - 1; i++)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, "[A]"))
                            {
                                if (!temp[i].Reserved && (temp[i + 1] != null && !temp[i + 1].Reserved))
                                {
                                    return new int[] { i, i + 1 };
                                }
                            }

                            if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, "[F]"))
                            {
                                if (!temp[i].Reserved && (temp[i - 1] != null && !temp[i - 1].Reserved))
                                {
                                    return new int[] { i - 1, i };
                                }
                            }
                        }
                    }
                    else if (seatType == AisleSeat)
                    {
                        for (int i = 20; i < Airplane.instance.seatList.Count() - 1; i++)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, "[C]"))
                            {
                                if (!temp[i].Reserved && (temp[i - 1] != null && !temp[i - 1].Reserved))
                                {
                                    return new int[] { i - 1, i };
                                }
                            }

                            if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, "[D]"))
                            {
                                if (!temp[i].Reserved && (temp[i + 1] != null && !temp[i + 1].Reserved))
                                {
                                    return new int[] { i, i + 1 };
                                }
                            }
                        }
                    }
                    else // Covers the middle seat
                    {
                        for (int i = 20; i < Airplane.instance.seatList.Count() - 1; i++)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(temp[i].SeatId, "[BE]"))
                            {
                                if (!temp[i].Reserved && (temp[i - 1] != null && !temp[i - 1].Reserved))
                                {
                                    return new int[] { i - 1, i };
                                }
                                else if (!temp[i].Reserved && (temp[i + 1] != null && !temp[i + 1].Reserved))
                                {
                                    return new int[] { i, i + 1 };
                                }
                            }
                        }
                    }
                }
                else if (partySize == 3)
                {
                    for (int i = 20; i < Airplane.instance.seatList.Count() - 1; i += 3)
                    {
                        if (!temp[i].Reserved && (temp[i + 1] != null && !temp[i + 1].Reserved) && (temp[i + 2] != null && !temp[i + 2].Reserved))
                        {
                            return new int[] { i, i + 1, i + 2 };
                        }
                    }
                }
            }
            // If we make it here no available seats were found
            // Return an empty array object
            return new int[] { };
        }

        /// <summary>
        /// Takes an array of indexes, highlights the seat(s) on the panel and prompts the user if they want to reserve the seat(s).
        /// The seats are reserved or cleared of the highlight.
        /// </summary>
        /// <param name="posId">The index position from the Seat list</param>
        public static void ReserveSeat(int[] posId)
        {
            // Check if we have an array
            if (posId.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                String SEPARATOR = "";
                String message = "Would you like to reserve seat {0}?";

                MainForm activeForm = ((MainForm)MainForm.ActiveForm);

                foreach (int id in posId)
                {
                    // Builds the selected string of seats
                    stringBuilder.Append(SEPARATOR);
                    stringBuilder.Append(Airplane.Instance.seatList[id].SeatId);
                    SEPARATOR = ", ";

                    // Highlight seat
                    if (activeForm.airplaneSeatPanel.Controls[id] is Button)
                    {
                        ((Button)activeForm.airplaneSeatPanel.Controls[id]).BackColor = System.Drawing.Color.LightSteelBlue;
                    }
                }

                if (posId.Length > 1)
                {
                    message = "Would you like to reserve seats {0}?";
                }

                // Display dialog
                DialogResult result = MessageBox.Show(MainForm.ActiveForm, String.Format(message, stringBuilder), "Reserve Seating", MessageBoxButtons.YesNo);

                // Reserve a seat if the response is Yes
                if (result == DialogResult.Yes)
                {
                    foreach (int id in posId)
                    {
                        Airplane.Instance.seatList[id].Passenger = "?";
                        Airplane.Instance.seatList[id].Reserved = true;
                    }
                    ((MainForm)MainForm.ActiveForm).RefreshDataView(posId[0]);
                }
                else
                {
                    // Remove seat highlight 
                    foreach (int id in posId)
                    {
                        if (activeForm.airplaneSeatPanel.Controls[id] is Button)
                        {
                            ((Button)((MainForm)MainForm.ActiveForm).airplaneSeatPanel.Controls[id]).BackColor = default(System.Drawing.Color);
                        }
                    }
                }
            }
            else
            {
                // No seats were available
                DisplaySeatNotAvailable();
            }
        }

        /// <summary>
        /// Displays a messagebox if seats aren't available
        /// </summary>
        public static void DisplaySeatNotAvailable()
        {
            MessageBox.Show("There are no seats available.", "Reserve Seating");
        }
    }
}
