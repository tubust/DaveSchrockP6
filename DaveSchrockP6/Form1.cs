///
/// Dave Schrock                                                        DaveSchrockP6
/// 
/// Author                                                              Dave Schrock
/// Instructor                                                          Kathy Cupp
/// Due Date                                                            November 13, 2007
/// 
/// Program Description                                                 Windows version of Bookstore program
/// 

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DaveSchrockP6
{
    public partial class Form1 : Form
    {
        public static readonly DateTime today = DateTime.Today;
        BookInventory totalInventory = new BookInventory();
        /// <summary>
        /// The Arraylist saves BookSales until user is finished.
        /// </summary>
        ArrayList BookSalesList = new ArrayList(16);
        const double TAX_RATE = 0.08375;
        public Form1()
        {
            InitializeComponent();
            dateDisplayLabel.Text = today.ToShortDateString();
            ///
            /// Setting books to the same as program 5
            /// 
            totalInventory[0] = new Books("0345417623", "Programming for Fun", "Bill Gates", "Ballantine Books", 4.50, .45, 3);
            totalInventory[1] = new Books("0283524862","PC Antics", "Steven Jobs", "Ballantine Books", 4.50, .24,10);
            totalInventory[2] = new Books("0440211457", "Chipless in Seattle", "John Jones", "Island Books", 3.00, .29,20);
            totalInventory[3] = new Books("2423568239", "Java By The Cupp", "Kathy Cupp", "OReily", 21.00, .35,2);
            totalInventory[4] = new Books("1579549543", "CPlusSharp", "Ann Confucious", "Rodale", 16.00, .45,100);
            totalInventory[5] = new Books("6546765548", "The Notebook", "Dean Dell", "Warner", 1.00, .30,1);
            totalInventory[6] = new Books("0966862309", "Apple vs PC", "Henry Wozniak", "Black Apple Press", 10.95, .37,18);
            totalInventory[7] = new Books("8898771672", "C# For Sharp People", "Bob Knife", "McGrew", 55.00, .45, 3);
            EventListner[] listner = new EventListner[8];
            for (int f = 0; f < 8; f++)
            {
                listner[f] = new EventListner(totalInventory[f]);
            }
            ///
            /// these next lines I decided to load the labels manually instead of using the label properties
            /// 
            selection1RadioButton.Text = totalInventory[0].Title;
            selection2RadioButton.Text = totalInventory[1].Title;
            selection3RadioButton.Text = totalInventory[2].Title;
            selection4RadioButton.Text = totalInventory[3].Title;
            selection5RadioButton.Text = totalInventory[4].Title;
            selection6RadioButton.Text = totalInventory[5].Title;
            selection7RadioButton.Text = totalInventory[6].Title;
            selection8RadioButton.Text = totalInventory[7].Title;
            priceLabel1.Text = totalInventory[0].CalculateRetail.ToString("C");
            priceLabel2.Text = totalInventory[1].CalculateRetail.ToString("C");
            priceLabel3.Text = totalInventory[2].CalculateRetail.ToString("C");
            priceLabel4.Text = totalInventory[3].CalculateRetail.ToString("C");
            priceLabel5.Text = totalInventory[4].CalculateRetail.ToString("C");
            priceLabel6.Text = totalInventory[5].CalculateRetail.ToString("C");
            priceLabel7.Text = totalInventory[6].CalculateRetail.ToString("C");
            priceLabel8.Text = totalInventory[7].CalculateRetail.ToString("C");
            QOHDisplaylabel1.Text = totalInventory[0].BooksOnHand.ToString();
            QOHDisplaylabel2.Text = totalInventory[1].BooksOnHand.ToString();
            QOHDisplaylabel3.Text = totalInventory[2].BooksOnHand.ToString();
            QOHDisplaylabel4.Text = totalInventory[3].BooksOnHand.ToString();
            QOHDisplaylabel5.Text = totalInventory[4].BooksOnHand.ToString();
            QOHDisplaylabel6.Text = totalInventory[5].BooksOnHand.ToString();
            QOHDisplaylabel7.Text = totalInventory[6].BooksOnHand.ToString();
            QOHDisplaylabel8.Text = totalInventory[7].BooksOnHand.ToString();
            selection1QOH.Value = totalInventory[0].BooksOnHand;
            selection2QOH.Value = totalInventory[1].BooksOnHand;
            selection3QOH.Value = totalInventory[2].BooksOnHand;
            selection4QOH.Value = totalInventory[3].BooksOnHand;
            selection5QOH.Value = totalInventory[4].BooksOnHand;
            selection6QOH.Value = totalInventory[5].BooksOnHand;
            selection7QOH.Value = totalInventory[6].BooksOnHand;
            selection8QOH.Value = totalInventory[7].BooksOnHand;
            selection1RadioButton.Checked = true;   // sets default radio button
            
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            ///
            /// Adds and updates books as selected
            /// 
            if (selection1RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[0].Isbn,0));
                totalInventory[0].BooksOnHand = (totalInventory[0].BooksOnHand - 1);
                selection1QOH.Value = totalInventory[0].BooksOnHand;
                QOHDisplaylabel1.Text = totalInventory[0].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[0].Title.PadRight(32, ' ') + totalInventory[0].CalculateRetail.ToString("C"));
                if(totalInventory[0].BooksOnHand == 0)
                {
                    selection1RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel1.Enabled = false;
                    QOHDisplaylabel1.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[0].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel1.ForeColor = Color.Yellow;
                }
            }
            else if (selection2RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[1].Isbn, 0));
                totalInventory[1].BooksOnHand = (totalInventory[1].BooksOnHand - 1);
                selection2QOH.Value = totalInventory[1].BooksOnHand;
                QOHDisplaylabel2.Text = totalInventory[1].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[1].Title.PadRight(32, ' ') + totalInventory[1].CalculateRetail.ToString("C"));
                if (totalInventory[1].BooksOnHand == 0)
                {
                    selection2RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel2.Enabled = false;
                    QOHDisplaylabel2.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[1].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel2.ForeColor = Color.Yellow;
                }
            }
            else if (selection3RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[2].Isbn, 0));
                totalInventory[2].BooksOnHand = (totalInventory[2].BooksOnHand - 1);
                selection3QOH.Value = totalInventory[2].BooksOnHand;
                QOHDisplaylabel3.Text = totalInventory[2].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[2].Title.PadRight(32, ' ') + totalInventory[2].CalculateRetail.ToString("C"));
                if (totalInventory[2].BooksOnHand == 0)
                {
                    selection3RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel3.Enabled = false;
                    QOHDisplaylabel3.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[2].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel3.ForeColor = Color.Yellow;
                }
            }
            else if (selection4RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[3].Isbn, 0));
                totalInventory[3].BooksOnHand = (totalInventory[3].BooksOnHand - 1);
                selection4QOH.Value = totalInventory[3].BooksOnHand;
                QOHDisplaylabel4.Text = totalInventory[3].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[3].Title.PadRight(32, ' ') + totalInventory[3].CalculateRetail.ToString("C"));
                if (totalInventory[3].BooksOnHand == 0)
                {
                    selection4RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel4.Enabled = false;
                    QOHDisplaylabel4.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[3].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel4.ForeColor = Color.Yellow;
                }
            }
            else if (selection5RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[4].Isbn, 0));
                totalInventory[4].BooksOnHand = (totalInventory[4].BooksOnHand - 1);
                selection5QOH.Value = totalInventory[4].BooksOnHand;
                QOHDisplaylabel5.Text = totalInventory[4].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[4].Title.PadRight(32, ' ') + totalInventory[4].CalculateRetail.ToString("C"));
                if (totalInventory[4].BooksOnHand == 0)
                {
                    selection5RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel5.Enabled = false;
                    QOHDisplaylabel5.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[4].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel5.ForeColor = Color.Yellow;
                }
            }
            else if (selection6RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[5].Isbn, 0));
                totalInventory[5].BooksOnHand = (totalInventory[5].BooksOnHand - 1);
                selection6QOH.Value = totalInventory[5].BooksOnHand;
                QOHDisplaylabel6.Text = totalInventory[5].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[5].Title.PadRight(32, ' ') + totalInventory[5].CalculateRetail.ToString("C"));
                if (totalInventory[5].BooksOnHand == 0)
                {
                    selection6RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel6.Enabled = false;
                    QOHDisplaylabel6.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[5].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel6.ForeColor = Color.Yellow;
                }
            }
            else if (selection7RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[6].Isbn, 0));
                totalInventory[6].BooksOnHand = (totalInventory[6].BooksOnHand - 1);
                selection7QOH.Value = totalInventory[6].BooksOnHand;
                QOHDisplaylabel7.Text = totalInventory[6].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[6].Title.PadRight(32, ' ') + totalInventory[6].CalculateRetail.ToString("C"));
                if (totalInventory[6].BooksOnHand == 0)
                {
                    selection7RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel7.Enabled = false;
                    QOHDisplaylabel7.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[6].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel7.ForeColor = Color.Yellow;
                }
            }
            else if (selection8RadioButton.Checked == true)
            {
                BookSalesList.Add(new BookSales(totalInventory[7].Isbn, 0));
                totalInventory[7].BooksOnHand = (totalInventory[7].BooksOnHand - 1);
                selection8QOH.Value = totalInventory[7].BooksOnHand;
                QOHDisplaylabel8.Text = totalInventory[7].BooksOnHand.ToString();
                booksBoughtList.Items.Add(totalInventory[7].Title.PadRight(32,' ')+ totalInventory[7].CalculateRetail.ToString("C"));
                if (totalInventory[7].BooksOnHand == 0)
                {
                    selection8RadioButton.Enabled = false; //disables radio button if out of inventory
                    buyButton.Enabled = false;
                    priceLabel8.Enabled = false;
                    QOHDisplaylabel8.ForeColor = Color.Red;
                    warningLabel.Text = "This book is out of inventory. You need to reorder.";
                }
                else if (totalInventory[7].BooksOnHand < 4)
                {
                    warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
                    QOHDisplaylabel8.ForeColor = Color.Yellow;
                }
            }
            finishBuyButton.Enabled = true;
        }
/// <summary>
/// These checkchanged events restores the buy after it is disabled or display warning message
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void selection1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection1RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[0].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection2RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[1].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection3RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[2].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection4RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection4RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[3].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection5RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection5RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[4].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection6RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection6RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[5].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection7RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection7RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[6].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void selection8RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selection8RadioButton.Enabled)
            {
                buyButton.Enabled = true;
            }
            if (totalInventory[7].BooksOnHand < 4)
            {
                warningLabel.Text = "WARNING! This book is low on inventory. You need to reorder.";
            }
            else
            {
                warningLabel.Text = "";
            }
        }

        private void finishBuyButton_Click(object sender, EventArgs e)
        {
            ///
            /// This method clears the listbox and reads booksales from the arraylist
            /// 
            BookSales[] temp = new BookSales[BookSalesList.Count];
            double totalTemp = 0;
            for(int z=0; z<BookSalesList.Count; z++)
            {
                temp[z] = (BookSales)BookSalesList[z];
            }
            if (nameTextBox.Text != string.Empty)
            {
                booksBoughtList.Items.Clear();
                booksBoughtList.Items.Add(nameTextBox.Text + "'s Receipt  " + today.ToShortDateString());
                booksBoughtList.Items.Add("____________________________________________");
                booksBoughtList.Items.Add("Books Purchased");
                booksBoughtList.Items.Add("____________________________________________");
                for (int x = 0; x < BookSalesList.Count; x++)
                {
                    for (int y = 0; y < totalInventory[0].Counter; y++)
                    {
                        if (temp[x].Isbn == totalInventory[y].Isbn)
                        {
                            booksBoughtList.Items.Add(totalInventory[y].Title.PadRight(32,' ') + totalInventory[y].CalculateRetail.ToString("C"));
                            totalTemp = totalTemp + totalInventory[y].CalculateRetail;
                        }
                    }
                }
                booksBoughtList.Items.Add("____________________________________________");
                booksBoughtList.Items.Add("Tax:".PadRight(32,' ') + (totalTemp * TAX_RATE).ToString("C"));
                booksBoughtList.Items.Add("____________________________________________");
                booksBoughtList.Items.Add("Total:".PadRight(32, ' ') + (totalTemp + (totalTemp * TAX_RATE)).ToString("C"));
                booksBoughtList.Items.Add("____________________________________________");
                booksBoughtList.Items.Add("Thank you for shopping at");
                booksBoughtList.Items.Add("Dave's Bookstore.");
                finishDisable(false);
            }
            else
            {
                MessageBox.Show("Please enter your name in the name box");
                nameTextBox.Focus();
            }
        }
        public void finishDisable(bool s)
        {
            ///
            /// This method disables any more sales after clicking i'm finished where exit button
            /// is only enabled
            /// 
            selection1RadioButton.Enabled = s;
            selection2RadioButton.Enabled = s;
            selection3RadioButton.Enabled = s;
            selection4RadioButton.Enabled = s;
            selection5RadioButton.Enabled = s;
            selection6RadioButton.Enabled = s;
            selection7RadioButton.Enabled = s;
            selection8RadioButton.Enabled = s;
            buyButton.Enabled = s;
            finishBuyButton.Enabled = s;
            priceLabel1.Enabled = s;
            priceLabel2.Enabled = s;
            priceLabel3.Enabled = s;
            priceLabel4.Enabled = s;
            priceLabel5.Enabled = s;
            priceLabel6.Enabled = s;
            priceLabel7.Enabled = s;
            priceLabel8.Enabled = s;
            nameTextBox.Enabled = s;
            warningLabel.Text = "";
        }
        /// <summary>
        /// These events set up the text box in yellow when focused and returns white when focus is lost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            nameTextBox.BackColor = Color.White;
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            nameTextBox.BackColor = Color.Yellow;
        }//end of method
    }//end of class
}// end of program