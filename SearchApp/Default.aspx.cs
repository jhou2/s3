using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SearchApp
{
    public partial class _Default : Page
    {

        List<string> searchFiles;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisableButtons();
            }
        }


        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }
        //Searching for the keywords
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Getting the excluded words
            string fileName = MapPath("/App_Data/exclusion/exclusion.txt");
            string exContent = System.IO.File.ReadAllText(fileName);
            string[] excluded = exContent.Split('\n');

            //Getting the search terms
            string[] content = tbSearch.Text.Split(' ');
            List<string> notExcluded = new List<string>();

            //boolean test values for valid input
            bool toBeExcluded;
            bool found = false;

            //Starting/Resetting the file list
            searchFiles = new List<string>();

            //Taking out excluded search terms
            for (int i = 0; i < content.Length; i++)
            {
                toBeExcluded = false;
                for(int j = 0; j < excluded.Length; j++)
                {
                    if(content[i] == excluded[j])
                    {
                        toBeExcluded = true;
                    }
                }
                if(toBeExcluded == false)
                {
                    notExcluded.Add(content[i]);
                }
            }

            //Searching the files for the non excluded terms
            foreach (string file in Directory.EnumerateFiles(MapPath("/App_Data/files/"), "*.txt"))
            {

                //splitting all words into an array
                string contents = File.ReadAllText(file);
                string[] words = contents.Split(' ');

                //list of files already added
                List<string> filesAdded = new List<string>();

                //testing if the search terms are in the document
                foreach(string item in notExcluded)
                {
                    if(words.Contains(item))
                    {
                        for (int i = 0; i < filesAdded.Count; i++)
                        {
                            if (file != filesAdded[i])
                            {
                                searchFiles.Add(file);
                                found = true;
                                filesAdded.Add(file);
                            }
                        }
                        if (filesAdded.Count == 0)
                        {
                            searchFiles.Add(file);
                            found = true;
                            filesAdded.Add(file);
                        }
                    }
                }
            }

            //if at least one document was found
            if (found == true)
            {
                Utilities.fileList = searchFiles;
                tbFileText.Text = File.ReadAllText(searchFiles[0]);
                Session["index"] = 0;
                lblFileCount.Text = "Result 1 of " + searchFiles.Count;
                if (searchFiles.Count == 1)
                {
                    DisableNavigate();
                }
                else
                {
                    DisableBackwards();
                }
            }
            else
            {
                tbFileText.Text = "Sorry, no Results were found";
                lblFileCount.Text = "No results";
                DisableButtons();
            }

        }

        protected void btnRewind_Click(object sender, EventArgs e)
        {
            Session["index"] = 0;
            tbFileText.Text = File.ReadAllText(Utilities.fileList[0]);
            DisableBackwards();
            lblFileCount.Text = "Result 1 of " + Utilities.fileList.Count();
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            int newIndex = Convert.ToInt32(Session["index"]);
            newIndex--;
            Session["index"] = newIndex;
            tbFileText.Text = File.ReadAllText(Utilities.fileList[newIndex]);
            lblFileCount.Text = "Result " + (newIndex + 1) + " of "
                + Utilities.fileList.Count();
            if (newIndex == 0)
            {
                DisableBackwards();
            }
            else
            {
                EnableButtons();
            }
        }

        protected void btnForward_Click(object sender, ImageClickEventArgs e)
        {
            int newIndex = Convert.ToInt32(Session["index"]);
            newIndex++;
            Session["index"] = newIndex;
            tbFileText.Text = File.ReadAllText(Utilities.fileList[newIndex]);
            lblFileCount.Text = "Result " + (newIndex + 1) + " of "
                + Utilities.fileList.Count();
            if (newIndex == (Utilities.fileList.Count - 1))
            {
                DisableForward();
            }
            else
            {
                EnableButtons();
            }
        }

        protected void btnFastForward_Click(object sender, ImageClickEventArgs e)
        {
            Session["index"] = Utilities.fileList.Count - 1;
            tbFileText.Text = File.ReadAllText(Utilities.fileList[Utilities.fileList.Count - 1]);
            lblFileCount.Text = "Result " + Utilities.fileList.Count + " of "
                + Utilities.fileList.Count();
            DisableForward();
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

        }


        public void EnableButtons()
        {
            btnBack.Enabled = true;
            btnFastForward.Enabled = true;
            btnForward.Enabled = true;
            btnRewind.Enabled = true;
            btnSave.Enabled = true;
            btnPrint.Enabled = true;
        }

        public void DisableButtons()
        {
            btnBack.Enabled = false;
            btnFastForward.Enabled = false;
            btnForward.Enabled = false;
            btnRewind.Enabled = false;
            btnSave.Enabled = false;
            // btnPrint.Enabled = false;  // probably ok to leave this enabled.
        }

        public void DisableForward()
        {
            btnBack.Enabled = true;
            btnFastForward.Enabled = false;
            btnForward.Enabled = false;
            btnRewind.Enabled = true;
            btnSave.Enabled = true;
            btnPrint.Enabled = true;
        }

        public void DisableBackwards()
        {
            btnBack.Enabled = false;
            btnFastForward.Enabled = true;
            btnForward.Enabled = true;
            btnRewind.Enabled = false;
            btnSave.Enabled = true;
            btnPrint.Enabled = true;
        }

        public void DisableNavigate()
        {
            btnBack.Enabled = false;
            btnFastForward.Enabled = false;
            btnForward.Enabled = false;
            btnRewind.Enabled = false;
            btnSave.Enabled = true;
            btnPrint.Enabled = true;
        }


    }
}