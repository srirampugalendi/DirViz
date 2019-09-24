using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TestApp1
{
    public partial class Form1 : Form
    {
        
        bool isExpanded = true;

        public Form1()
        {   
            InitializeComponent();
  
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SearchBox_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
        }

        private void ExpandOrCollapseButton_Click(object sender, EventArgs e)
        {
            

            if (isExpanded)
            {
                treeView.CollapseAll();
                isExpanded = false;
            }
            else
            {
                treeView.ExpandAll();
                isExpanded = true;
            }
            
        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.treeView.Nodes.Clear();
            this.treeView.Invalidate();
            
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            int result = -1;
            string fileName = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                result = checkType(openFileDialog1.FileName);
                fileName = openFileDialog1.FileName;

            }

            if (result == 1)
            {
                FILEITEM.ParseFileWindows(fileName, this);
            }
            if (result == 2)
            {
                StreamReader reading = File.OpenText(fileName);
                string str = reading.ReadLine();
                string text = File.ReadAllText(fileName);
                text = text.Replace("./", str+"/");
                fileName = fileName + "_tmp";
                File.WriteAllText(fileName, text);
                FILEITEM.ParseFileLinux(fileName, this);
            }
            this.treeView.Nodes.Clear();
            this.treeView.Invalidate();
            

            FILEITEM.MakeTree(FILEITEM.files, null, treeView, 0);

            treeView.ExpandAll();
            isExpanded = true;
        }

        private void DomainNameBox_Click(object sender, EventArgs e)
        {
            domainNameBox.Clear();
        }

        private int checkType(String textFile)
        {
            //Console.WriteLine(fileName); 123
            // Read file using StreamReader. Reads file line by line
            //Console.WriteLine(textFile);
            Console.WriteLine(textFile);
            int result = 0;                 // 1 - Win, 2 - Unix, 3 - Invalid file
            using (StreamReader file = new StreamReader(textFile))
                {
                    Console.WriteLine(textFile);
                    
                    string ln;

                    ln = file.ReadLine();
                    //Console.WriteLine(ln);
                    if (ln.Contains("Volume in drive"))
                    {
                    Console.WriteLine("Valid Windows directory structure detected ");
                    result = 1;
                    }
                    else if(ln.StartsWith("/") || ln.Contains(".:"))
                    {
                    Console.WriteLine("Valid Linux directory structure detected ");
                    result = 2;
                    }
                    else
                    {
                    Console.WriteLine("Invalid Directory Listing File");
                    result = 3;
                    }
                    
                }
         return result;
        }

    }

    public class FILEITEM
    {
        const string DIRECTORY_OF = "Directory of";
        const string REGEX_DATE_PATTERN = @"\d{2}/\d{2}/\d{4}\s\s\d{2}:\d{2}\s[AP]M";
        const string REGEX_FILENAME_PATTERN = @"[^\s]+";

        public static List<FILEITEM> files = new List<FILEITEM>();
        public string[] folder { get; set; }
        public string filename { get; set; }
        public DateTime time { get; set; }

        public static void ParseFileWindows(string filename, Form1 form1)
        {
            CultureInfo info = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(filename);
            files.Clear();
            string[] directory = null;

            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(DIRECTORY_OF))
                {
                    directory = line.Substring(line.IndexOf(DIRECTORY_OF) + DIRECTORY_OF.Length).Trim().Split(new char[] { '\\' }).ToArray();
                    Console.WriteLine(line);
                    Array.ForEach(directory, Console.WriteLine);
                }
                else
                {
                    Match dateMatch = Regex.Match(line, REGEX_DATE_PATTERN);
                    if (dateMatch.Success && !line.Contains("<DIR>"))
                    {
                        Match filenameMatch = Regex.Match(line.Trim(), REGEX_FILENAME_PATTERN, RegexOptions.RightToLeft);
                        FILEITEM newFileItem = new FILEITEM() { folder = directory, filename = filenameMatch.Value };
                        files.Add(newFileItem);
                    }
                }
            }
        }

        public static void ParseFileLinux(string filename, Form1 form1)
        {

            const string DIRECTORY_OF = "/";
            const string REGEX_DATE_PATTERN = @"[d][l,r,w,x,t,-]{9}\s";
            const string REGEX_IS_FILE = @"[-][l,r,w,x,t,-]{9}\s";
            const string REGEX_FILENAME_PATTERN = @"[^\s]+";

            CultureInfo info = CultureInfo.InvariantCulture;
            StreamReader reader = new StreamReader(filename);
            files.Clear();
            string[] directory = null;

            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                if (line.StartsWith(DIRECTORY_OF))
                {   
                    if (line.EndsWith(":"))
                    {
                        line = line.Substring(0, line.Length - 1);
                    }           
                    directory = line.Substring(line.IndexOf(DIRECTORY_OF) + DIRECTORY_OF.Length).Trim().Split(new char[] { '/' }).ToArray();
                    Console.WriteLine(line);
                    //Console.WriteLine(line.Substring(line.IndexOf(DIRECTORY_OF) + DIRECTORY_OF.Length).Trim().Split('/'));
                    Array.ForEach(directory, Console.WriteLine);
                }
                else
                {
                    Match dateMatch = Regex.Match(line, REGEX_IS_FILE);
                    if (dateMatch.Success)
                    {
                        //Console.WriteLine(line);
                        Match filenameMatch = Regex.Match(line.Trim(), REGEX_FILENAME_PATTERN, RegexOptions.RightToLeft);
                        //string fileNameStripped = filenameMatch.Value.Substring(6);
                        FILEITEM newFileItem = new FILEITEM() { folder = directory, filename = filenameMatch.Value };
                        files.Add(newFileItem);
                    }
                }
            }
        }
        public static void MakeTree(List<FILEITEM> files, TreeNode node, TreeView treeview1, int index)
        {
            TreeNode childNode = null;
            var groups = files.Where(x => x.folder.Length > index).GroupBy(x => x.folder[index]).ToList();
            foreach (var group in groups)
            {
                childNode = new TreeNode(group.Key);
                if (node == null)
                {
                    treeview1.Nodes.Add(childNode);
                }
                else
                {
                    node.Nodes.Add(childNode);
                }
                foreach (FILEITEM item in group)
                {
                    if (item.folder.Length - 1 == index)
                    {
                        TreeNode fileNode = new TreeNode(string.Join(",", new string[] { item.filename }));
                        childNode.Nodes.Add(fileNode);
                    }
                }
                MakeTree(group.ToList(), childNode, null, index + 1);
            }
        }
    }

}