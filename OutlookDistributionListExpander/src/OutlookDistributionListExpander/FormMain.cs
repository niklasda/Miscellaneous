using System;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Outlook;

namespace WindowsApplication1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private const string messageBoxTitle = "Strange things occur!";
        private NameSpace oNS;
        private Microsoft.Office.Interop.Outlook.Application oApp;

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                connectToOutlook();
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
        }

        private void connectToOutlook()
        {
            oApp = new Microsoft.Office.Interop.Outlook.Application();
            oNS = oApp.GetNamespace("mapi");
            oNS.Logon(null, null, true, true);

            listAddressBooks();
        }

        private void bGetBooks_Click(object sender, EventArgs e)
        {
            listAddressBooks();
        }

        private void listAddressBooks()
        {
            try
            {
                lbBooks.Items.Clear();
                AddressLists oDLs = oNS.AddressLists;

                foreach (AddressList oGal in oDLs)
                {
                    lbBooks.Items.Add(oGal.Name);
                }

                if (lbBooks.Items.Count > 0)
                {
                    lbBooks.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No Address books found", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
        }

        private void bGetLists_Click(object sender, EventArgs e)
        {
            try
            {
                listDistributionLists();
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
        }

        private void listDistributionLists()
        {
            if (lbBooks.SelectedItem != null)
            {
                string bookName = (string)lbBooks.SelectedItem;

                AddressLists oDLs = oNS.AddressLists;

                lbLists.Items.Clear();
                AddressList oGal = oDLs[bookName];

                foreach (AddressEntry oDL in oGal.AddressEntries)
                {
                    if (oDL.Type.Equals("MAPIPDL"))
                    {
                        lbLists.Items.Add(oDL.Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Address book selected", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bExtract_Click(object sender, EventArgs e)
        {
            try
            {
                listEmailAddresses();
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
        }

        private void listEmailAddresses()
        {
            if (lbLists.SelectedItem != null)
            {
                string bookName = (string)lbBooks.SelectedItem;
                string dlname = (string)lbLists.SelectedItem;

                AddressList oGal = oNS.AddressLists[bookName];
                AddressEntry oDL = oGal.AddressEntries[dlname];

                lbEmailAdresses.Items.Clear();

                foreach (AddressEntry oEntry in oDL.Members)
                {
                    lbEmailAdresses.Items.Add(oEntry.Name + "-" + oEntry.Address);
                }
                if (lbEmailAdresses.Items.Count == 0)
                {
                    MessageBox.Show("No addresses found in distribution list", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No distribution list selected", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bGetDrafts_Click(object sender, EventArgs e)
        {
            try
            {
                listDrafts();
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
        }

        private void listDrafts()
        {
            MAPIFolder draftFolder = oNS.GetDefaultFolder(OlDefaultFolders.olFolderDrafts);
            lbDrafts.Items.Clear();

            foreach (MailItem it in draftFolder.Items)
            {
                lbDrafts.Items.Add(it.Subject);
            }
            if (lbDrafts.Items.Count == 0)
            {
                MessageBox.Show("No drafts found", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bProcessDraft_Click(object sender, EventArgs e)
        {
            try
            {
                processDraft();
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
        }

        private void processDraft()
        {
            if (lbDrafts.SelectedItem != null && lbLists.SelectedItem != null)
            {
                string draftSubject = (string)lbDrafts.SelectedItem;
                string dlname = (string)lbLists.SelectedItem;

                MAPIFolder draftFolder = oNS.GetDefaultFolder(OlDefaultFolders.olFolderDrafts);
                bool anyMatch = false;

                foreach (MailItem it in draftFolder.Items)
                {
                    if (it.Subject.Equals(draftSubject) && it.To.Equals(dlname))
                    {
                        anyMatch = true;
                        expandDistributionList(it);

                        break;
                    }
                }
                if (anyMatch)
                {
                    listDrafts();
                }
                else
                {
                    MessageBox.Show("Selected draft did not use selected distribution list", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must select both a draft and a distribution list", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void expandDistributionList(MailItem it)
        {
            if (lbLists.SelectedItem != null && lbBooks.SelectedItem != null)
            {
                string bookName = (string)lbBooks.SelectedItem;
                string dlname = (string)lbLists.SelectedItem;

                AddressList oGal = oNS.AddressLists[bookName];
                AddressEntry oDL = oGal.AddressEntries[dlname];

                // MAPIFolder outboxFolder = oNS.GetDefaultFolder(OlDefaultFolders.olFolderOutbox);
                MAPIFolder draftFolder = oNS.GetDefaultFolder(OlDefaultFolders.olFolderDrafts);
                MAPIFolder deletedItemsFolder = oNS.GetDefaultFolder(OlDefaultFolders.olFolderDeletedItems);

                lbNewDrafts.Items.Clear();
                foreach (AddressEntry oEntry in oDL.Members)
                {
                    MailItem mi = (MailItem)it.Copy();

                    mi.To = oEntry.Address;
                    mi.Subject += ".";
                    mi.SaveSentMessageFolder = draftFolder;
                    mi.Save();
                    //     mi.Send(); //does not execute where the web page just stalls

                    lbNewDrafts.Items.Add(oEntry.Name + "-" + oEntry.Address);
                }
                if (lbNewDrafts.Items.Count == 0)
                {
                    MessageBox.Show("No addresses found in distribution list", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    it.Move(deletedItemsFolder);
                    MessageBox.Show(string.Format("{0} new messages created, original deleted", lbNewDrafts.Items.Count), messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No distribution list selected", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                oNS.Logoff();
            }
            catch (System.Exception ex)
            {
                tbError.Text = ex.ToString();
            }
         }
    }
}
