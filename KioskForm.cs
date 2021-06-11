using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NTCSAttendanceKiosk
{
    public partial class KioskForm : Form
    {
        // Unmanaged code to keep the window on top
        [DllImport("User32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        internal static readonly IntPtr InvalidHandleValue = IntPtr.Zero;
        internal const int SW_MAXIMIZE = 3;

        // Stores the list of messages
        private List<string> PublicMessages = new List<string>();
        private int CurrentPublicMessage;

        private enum DisplayType
        {
            SignIn,
            SignOut,
            Failure
        }

        public KioskForm()
        {
            InitializeComponent();
            LocationLabel.Text = SqlConnectionInfo.KioskLocation;
            Cursor.Hide();
            AdvancePublicMessage();
            SecurityTimer.Start();
        }

        // About 444 chars on average can fit inside the user message box.

        /// <summary>
        /// Sets the colours of the message to the success sign in (green) colour scheme.
        /// </summary>
        private void SetSuccessSignInColors()
        {
            HelloPanel.BackColor = Color.ForestGreen;
            UserMessagePanel.BackColor = Color.LimeGreen;
            UserMessageTextBox.BackColor = Color.LimeGreen;
            SuccesIndicatorPictureBox.Image = Properties.Resources.CheckSign;
        }

        /// <summary>
        /// Sets the colours of the message to the success sign out (yellow) colour scheme.
        /// </summary>
        private void SetSuccessSignOutColors()
        {
            HelloPanel.BackColor = Color.Orange;
            UserMessagePanel.BackColor = Color.Yellow;
            UserMessageTextBox.BackColor = Color.Yellow;
            SuccesIndicatorPictureBox.Image = Properties.Resources.YellowCheckSign;
        }

        /// <summary>
        /// Sets the colours of the message to the failed (red) colour scheme.
        /// </summary>
        private void SetFailColors()
        {
            HelloPanel.BackColor = Color.Red;
            UserMessagePanel.BackColor = Color.Salmon;
            UserMessageTextBox.BackColor = Color.Salmon;
            SuccesIndicatorPictureBox.Image = Properties.Resources.XSign;
        }

        private void ShowScanResultControls()
        {
            ClockLabel.Hide();
            UserMessagePanel.Show();
            SuccesIndicatorPictureBox.Show();
        }

        private void HideScanResultControls()
        {
            UserMessagePanel.Hide();
            SuccesIndicatorPictureBox.Hide();
            ClockLabel.Show();
        }
        
        // Timer that hides the results automatically
        private void HideUserMessageTimer_Tick(object sender, EventArgs e)
        {
            this.HideScanResultControls();
            HideUserMessageTimer.Stop();
        }

        private void DisplayScanResult(DisplayType type, string titleText, string userMessageText)
        {
            // Reset the hiding timer
            HideUserMessageTimer.Stop();

            // Switch the text
            HelloLabel.Text = titleText;
            UserMessageTextBox.Text = userMessageText;

            // Switch the colours depending on the display type
            switch (type)
            {
                case DisplayType.SignIn:
                    SetSuccessSignInColors();
                    break;
                case DisplayType.SignOut:
                    SetSuccessSignOutColors();
                    break;
                default:
                    SetFailColors();
                    break;
            }

            // Show it!
            this.ShowScanResultControls();

            // Play the sound
            switch (type)
            {
                case DisplayType.SignIn:
                    SoundPlayer sinsound = new SoundPlayer(Properties.Resources.SignIn);
                    sinsound.Play();
                    break;
                case DisplayType.SignOut:
                    SoundPlayer soutsound = new SoundPlayer(Properties.Resources.SignOut);
                    soutsound.Play();
                    break;
                default:
                    SoundPlayer failsound = new SoundPlayer(Properties.Resources.Fail);
                    failsound.Play();
                    break;
            }

            // Start the timer so that it hides automatically
            HideUserMessageTimer.Start();
        }

        // Keeps the form on top and the text box selected
        private void SecurityTimer_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
            Process currentProcess = Process.GetCurrentProcess();
            IntPtr hWnd = currentProcess.MainWindowHandle;
            if (hWnd != InvalidHandleValue)
            {
                SetForegroundWindow(hWnd);
                ShowWindow(hWnd, SW_MAXIMIZE);
            }
            CardTextBox.Focus();
        }

        // Refreshes the date and time display
        private void ClockUpdateTimer_Tick(object sender, EventArgs e)
        {
            ClockLabel.Text = DateTime.Now.ToString("yyyy-MM-dd") + "\r\n" + DateTime.Now.ToString("HH:mm:ss");
        }

        // Makes the messages scroll and reloads them
        private void PublicMessageMarqueeTimer_Tick(object sender, EventArgs e)
        {
            if (PublicMessageLabel.Left < 0 && (Math.Abs(PublicMessageLabel.Left) > PublicMessageLabel.Width))
            {
                AdvancePublicMessage();
            }

            PublicMessageLabel.Left -= 2;
        }

        /// <summary>
        /// Loads the public messages into the scrolling display.
        /// </summary>

        private void LoadPublicMessages()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = SqlConnectionInfo.ConnectionString;
                    conn.Open();

                    using (SqlCommand selectCmd = new SqlCommand())
                    {
                        selectCmd.Connection = conn;
                        selectCmd.CommandType = CommandType.Text;
                        selectCmd.CommandText = "SELECT DisplayMessage FROM KioskPublicMessages WHERE (StartDate < GETDATE() AND ExpiryDate > GETDATE()) ORDER BY DisplayOrder";

                        using (SqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            PublicMessages.Clear();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    PublicMessages.Add(reader[0].ToString());
                                }
                            }
                            else
                            {
                                PublicMessages.Add("");
                            }
                        }
                    }
                }
            }
            catch
            {
                PublicMessages.Clear();
                PublicMessages.Add("Failed to load messages.");
            }
        }

        /// <summary>
        /// Advances the public messages.
        /// </summary>
        private void AdvancePublicMessage()
        {
            CurrentPublicMessage++;
            if (CurrentPublicMessage >= PublicMessages.Count)
            {
                CurrentPublicMessage = 0;
                LoadPublicMessages();
            }

            PublicMessageLabel.Left = this.Width;
            PublicMessageLabel.Text = PublicMessages[CurrentPublicMessage];
        }

        // Code that runs when scan is complete/enter is pressed in the textbox
        private void CardTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Store the user input and clear the text box
                string userInput = CardTextBox.Text;
                CardTextBox.Text = "";

                string firstName = "";
                int toDoScanType = 0;
                string userMessage = "";

                // Lookup the student in the database
                try
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = SqlConnectionInfo.ConnectionString;
                        conn.Open();

                        // See if the ID is in the database
                        using (SqlCommand selectStudentCommand = new SqlCommand())
                        {
                            selectStudentCommand.Connection = conn;
                            selectStudentCommand.CommandType = CommandType.Text;
                            selectStudentCommand.CommandText = "SELECT TOP 1 (FirstName) FROM Students WHERE StudentID = @UserInID";
                            selectStudentCommand.Parameters.AddWithValue("@UserInID", userInput);

                            using (SqlDataReader nameReader = selectStudentCommand.ExecuteReader())
                            {
                                if (nameReader.HasRows)
                                {
                                    while (nameReader.Read())
                                    {
                                        firstName = nameReader[0].ToString();
                                    }
                                }
                                else
                                {
                                    DisplayScanResult(DisplayType.Failure, "Invalid Student ID", "The student ID is invalid. Please ask a staff member for assistance.");
                                    return;
                                }
                            }
                        }

                        // See if they signed in already today
                        using (SqlCommand selAtLogCmd = new SqlCommand())
                        {
                            selAtLogCmd.Connection = conn;
                            selAtLogCmd.CommandType = CommandType.Text;
                            selAtLogCmd.CommandText = "SELECT TOP 1 (ScanType) FROM AttendanceLog WHERE (StudentID = @UserInID AND LogTime < GETDATE() AND LogTime > CONVERT(DATE, GETDATE())) ORDER BY LogTime DESC";
                            selAtLogCmd.Parameters.AddWithValue("@UserInID", userInput);

                            using (SqlDataReader atLogReader = selAtLogCmd.ExecuteReader())
                            {
                                if (atLogReader.HasRows)
                                {
                                    while (atLogReader.Read())
                                    {
                                        if (Convert.ToInt32(atLogReader[0]) == 0)
                                        {
                                            toDoScanType = 1;
                                        }
                                    }
                                }
                            }
                        }

                        // Make the log
                        using (SqlCommand insertCmd = new SqlCommand())
                        {
                            insertCmd.Connection = conn;
                            insertCmd.CommandType = CommandType.Text;
                            insertCmd.CommandText = "INSERT INTO AttendanceLog (LogTime, StudentID, ScanLocation, ScanType) VALUES (GETDATE(), @UserInID, @Loc, @Type)";
                            insertCmd.Parameters.AddWithValue("@UserInID", userInput);
                            insertCmd.Parameters.AddWithValue("@Loc", SqlConnectionInfo.KioskLocation);
                            insertCmd.Parameters.AddWithValue("@Type", toDoScanType);

                            insertCmd.ExecuteNonQuery();
                        }

                        // Select the kiosk message, if any
                        using (SqlCommand selMsgCmd = new SqlCommand())
                        {
                            selMsgCmd.Connection = conn;
                            selMsgCmd.CommandType = CommandType.Text;
                            selMsgCmd.CommandText = "SELECT TOP 1 (KioskPersonalMessage) FROM Students WHERE (StudentID = @UserInID AND KioskMessageStartDate < GETDATE() AND KioskMessageExpiryDate > GETDATE())";
                            selMsgCmd.Parameters.AddWithValue("@UserInID", userInput);

                            using (SqlDataReader msgCmdReader = selMsgCmd.ExecuteReader())
                            {
                                if (msgCmdReader.HasRows)
                                {
                                    while (msgCmdReader.Read())
                                    {
                                        userMessage = msgCmdReader[0].ToString();
                                    }
                                }
                            }
                        }

                        // Show the result
                        switch (toDoScanType)
                        {
                            case 1:
                                DisplayScanResult(DisplayType.SignOut, "Goodbye " + firstName, userMessage);
                                break;
                            default:
                                DisplayScanResult(DisplayType.SignIn, "Hello " + firstName, userMessage);
                                break;
                        }
                    }
                }
                catch (SqlException se)
                {
                    // Display the error code and the error
                    DisplayScanResult(DisplayType.Failure, "System Error - " + se.Number.ToString(), se.Message);
                }
                catch (Exception ex)
                {
                    DisplayScanResult(DisplayType.Failure, "System Error", ex.Message);
                }
            }
        }
    }
}
