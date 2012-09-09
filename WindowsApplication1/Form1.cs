using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;


namespace WindowsApplication1
{

    public partial class Main : Form
    {
        Button[] Menu;
        string[] Configuration;
        ToolTip Info = new ToolTip();
        GroupBox CurrentConfig = null;
        GroupBox Configured = null;
        System.Drawing.Size original_size = new System.Drawing.Size();
        string ConfigFile = System.Environment.CurrentDirectory + "\\Osc.conf";

        [DllImport("user32.dll")]
        public static extern int SetMenuItemBitmaps(IntPtr hMenu, IntPtr nPosition, int wFlags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);
        public const int MF_BYPOSITION = 0x400;
       
        private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
            return result;
        }
        private int AddImageToMenuItem(MenuItem mi, IntPtr bitmap_file,bool transparency)
        {    
            Bitmap bmp = new Bitmap       (Bitmap.FromHicon(bitmap_file));
            if (transparency)
            {
                Color backColor = bmp.GetPixel(1, 1);
                bmp.MakeTransparent(backColor);
            }
            return AddImageToMenuItem(mi, bmp);
        }
        private int AddImageToMenuItem(MenuItem mi, Bitmap bmp)
        {
            IntPtr intp = bmp.GetHbitmap();
            return SetMenuItemBitmaps(mi.Parent .Handle, (IntPtr)mi.Index, MF_BYPOSITION, intp, intp);
        } 
        public Main()
        {
            InitializeComponent();
        }
        private void exelocation_Click_1(object sender, EventArgs e)
        {
            this.openfile.ShowDialog();
            this.location.Text = openfile.FileName;
        }
        private void Start(string id,int selected)
        {
            ProcessStartInfo Startinfo = new ProcessStartInfo();
            Startinfo.FileName = "Taskkill";
            Startinfo.Arguments = " /f /im explorer.exe";
            Process.Start(Startinfo);

            Process run = new Process();
            run.StartInfo.FileName = Configuration[selected];
            run.EnableRaisingEvents = true;
            run.Start();

            Process[] processes = Process.GetProcessesByName(id);
            
            while (processes.Length != 0)
            {
                Thread.Sleep(10);
                processes = Process.GetProcessesByName(id);
            }

            run_Exited();
        }
        private void run_Exited()
        {
            ProcessStartInfo restart = new ProcessStartInfo();
            restart.FileName = "explorer.exe";
            Process.Start(restart);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            openfile.Filter="Exe Files (*.exe)|*.exe";
            Info.ShowAlways = true;
            Loadconfig();    
        }
        private void Loadconfig()
        {
            try
            {
                if (File.Exists(ConfigFile))
                {
                    /////open configuration file
                    Configuration = File.ReadAllLines(ConfigFile);

                    if (Configuration.Length == 0)
                    {
                        settingsToolStripMenuItem_Click(this, EventArgs.Empty);
                        settings.BringToFront();
                        settings.Visible = true;
                    }
                    else { CreateMain(); }
                }
                else
                {
                    //// create new OSC.conf file
                    using (System.IO.FileStream fs = File.Create(ConfigFile))
                    {
                    }

                    /// show settings dialog
                    Loadconfig();
                }
            }
            catch
            {
                Loadconfig();
            }
        }
        private void CreateMain()
        {
            int x = 0;
          ////remove controls
            try
            {
                foreach (Button control in Configured.Controls )
                {
                        Configured.Controls.Remove (control);
                        control.Dispose();                   
                }

                _main.Controls.Remove(Configured);
                Configured.Dispose();

                Array.Clear(Menu, 0, Menu.Length);
            }
            catch
            {
                ///first run, ignore
            }
            Configured = new GroupBox();
            Configured.Name = "Configured";
            Configured.Location = new System.Drawing.Point(12, 27);
            Configured.Size = new System.Drawing.Size(483, 194);
            Configured.Text = "Found " + Configuration.Length + " Configurations";

            _main.Controls.Add(Configured);

            Array.Resize(ref Menu,Configuration.Length);

            x = 0;
            int ylocation = 0;
            foreach (string mnu in Configuration)
            {
                try
                {
                    string[] temp = mnu.Split(new char[] { '\\' });
                    string[] tmp = temp[temp.Length - 1].Split(new char[] { '.' });
                    string id = tmp[tmp.Length - 2];

                    Menu[x] = new Button();
                    Menu[x].Name = id;
                    Menu[x].Size = new System.Drawing.Size(50, 50);
                    Menu[x].BackgroundImageLayout = ImageLayout.Stretch;
                    Menu[x].BackgroundImage=new Bitmap(Icon.ExtractAssociatedIcon(Configuration[x]).ToBitmap());

                    Menu[x].Click+=new EventHandler(Menu_Click);
                    Menu[x].MouseHover+=new EventHandler(Menu_MouseHover);
                    Menu[x].MouseEnter+=new EventHandler(Menu_MouseEnter);
                    Menu[x].MouseLeave +=new EventHandler(Menu_MouseLeave);

                    if (ylocation< Configured.Size.Height  )
                    {
                    if (x > 0)
                    {
                        Menu[x].Location = new System.Drawing.Point(Menu[x - 1].Location.X, Menu[x - 1].Location.Y +50);
                        ylocation = Menu[x].Location.Y + 50 + Menu[x].Size.Height;
                    }
                    else
                    {
                        Menu[x].Location = new System.Drawing.Point(25, 25);
                    }
                    }
                    else
                    {
                            Menu[x].Location = new System.Drawing.Point(Menu[x - 1].Location.X+50, 25);
                            ylocation = Menu[x].Location.Y + 50 + Menu[x].Size.Height;
                    }

                    Configured.Controls.Add (Menu[x]);
                }
                catch { }
                x = x + 1;
            }

            this.Update();
            _main.Visible = true;
            _main.BringToFront();
        }
        private void Menu_MouseHover(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                foreach (Button current in  Configured.Controls )
                {
                    if (sender == current)
                    {
                        Info.SetToolTip(current, Menu[x].Name);
                    }
                    x = x + 1;
                }
            }
            catch
            {
                ///ignore , not a label
            }
        }
        private void Menu_Click( Object sender, EventArgs e)
        {
            int x =0;
            foreach (Button selected in Menu)
            {
                if (sender == selected)
                {
                    Start(selected.Name,x);
                    break;
                }
                x = x + 1;
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////remove controls
            int x = 0;
            
            try
            {
                foreach (Label control in CurrentConfig.Controls )
                {
                   CurrentConfig.Controls.Remove(control);
                   control.Dispose();
                    x++;
                }
                CurrentConfig.Dispose();
            }
            catch
            {
                ///first run, ignore
            }
        
            ////show current configuration
            CurrentConfig = new GroupBox();
            CurrentConfig.Text = "Current Configuration";
            CurrentConfig.Location = new System.Drawing.Point(31, 27);
            CurrentConfig.Size = new System.Drawing.Size(452, 114);
            CurrentConfig.Name="CurrentConfig";

            settings.Controls.Add(CurrentConfig);

            Label[] currentconfig=null;
            ContextMenu[] ConfigMenu = null;
           
            Array.Resize(ref ConfigMenu, Configuration.Length);
            Array.Resize(ref currentconfig, Configuration.Length);
              
            MenuItem Edit = new MenuItem();
            MenuItem Remove = new MenuItem();
            MenuItem Current = new MenuItem();
                      
            Edit.Text="Edit Item";
            Edit.Click+=new EventHandler(Edit_Click);

            Remove.Text="Remove";
            Remove.Click+=new EventHandler(Remove_Click);

            x = 0;
            int ylocation = 0;
            try
            {
                foreach (Button config in Menu)
                {
                    ///// create grid                    ///
                   
                    currentconfig[x] = new Label();
                    if (ylocation < CurrentConfig.Size.Height)
                    {
                        if (x > 0)
                        {
                            currentconfig[x].Location = new System.Drawing.Point(currentconfig[x - 1].Location.X, currentconfig[x - 1].Location.Y + 33);
                            ylocation = currentconfig[x].Location.Y + 30+ currentconfig[x].Size.Height ;
                        }
                        else
                        {
                            currentconfig[x].Location = new System.Drawing.Point(15, 15);
                        }
                    }
                    else
                    {
                        currentconfig[x].Location = new System.Drawing.Point(currentconfig[x - 1].Location.X+50,15);
                        ylocation = currentconfig[x].Location.Y + 30;
                    }
                    
                    ///// make new menu for each config

                    ConfigMenu[x] = new ContextMenu();
                    Current.Text = Menu[x].Name;

                    ConfigMenu[x].MenuItems.Add(0, Current.CloneMenu());
                    ConfigMenu[x].MenuItems.Add("-");
                    ConfigMenu[x].MenuItems.Add(2, Edit.CloneMenu());
                    ConfigMenu[x].MenuItems.Add(3, Remove.CloneMenu());

                    ConfigMenu[x].MenuItems[2].Name = "Edit" + x;
                    ConfigMenu[x].MenuItems[3].Name = "Remove" + x;

                    ///add images to menus
                    AddImageToMenuItem(ConfigMenu[x].MenuItems[3], SystemIcons.Error.Handle, true);
                    AddImageToMenuItem(ConfigMenu[x].MenuItems[2], SystemIcons.Asterisk.Handle, true);
                    AddImageToMenuItem(ConfigMenu[x].MenuItems[0], Icon.ExtractAssociatedIcon(Configuration[x]).Handle, false);

                    //// add images to configs

                    currentconfig[x].Image = new Bitmap(Icon.ExtractAssociatedIcon(Configuration[x]).ToBitmap());

                    currentconfig[x].BorderStyle = BorderStyle.Fixed3D;
                    currentconfig[x].Size = currentconfig[x].Image.Size;
                    currentconfig[x].Name = x.ToString();

                    currentconfig[x].ContextMenu = ConfigMenu[x];
                    currentconfig[x].MouseHover += new EventHandler(currentconfig_MouseHover);                

                    CurrentConfig.Controls.Add(currentconfig[x]);

                    x = x + 1;
                }

                settings.Visible = true;
                settings.BringToFront();

            }
            catch
            {
            }
            
            //// reload configuration
            _main.Visible = false;
        }
        private void Menu_MouseEnter(object sender, EventArgs e)
        {
               int x = 0;
            //// get calling button
            try
            {
                foreach (Button current in Configured.Controls)
                {
                    if (sender == current)
                    { //// is calling button
                       original_size   = current.Size;
                        System.Drawing.Size New_Size=new System.Drawing.Size(current.Size.Width *2,current.Size.Height*2);
                       current.Size = New_Size ;

                        break;
                       
                    }
                    x++;
                }
            }
            catch
            {
                ///ignore , not a button
            }       
        }
        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                foreach (Button current in Configured.Controls)
                {
                    if (sender == current)
                    {
                        current.Size = original_size ;

                        break;
                    }
                    x++;
                }
            }
            catch
            {
                ///ignore , not a label
            }        
        }
        private void currentconfig_MouseHover(object sender,EventArgs    e)
        {
            ////display location tool tip data on mouse hover
                       
            int x = 0;
            try
            {
                foreach (Label current in CurrentConfig.Controls)
                {
                    if (sender == current)
                    {
                        Info.SetToolTip(current,Menu[x].Name + " : "  + Configuration[x]);                       
                    }
                    x = x + 1;
                }
            }
            catch
            {
                ///ignore , not a label
            }
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            openfile.ShowDialog();
            int x = 0;
           
            /////find calling config
            try
            {
               
                foreach (Label menuparent in CurrentConfig.Controls)
                {

                    if (menuparent.ContextMenu.MenuItems[2] == sender)
                    {
                        ////found calling config , exit for

                        break;
                    }

                    x++;
                }

            }
            catch
            {
                ///ignore , not a label
            }

            Configuration[x] = openfile.FileName;
                      
            ///rewrite configuration
            File.Delete(ConfigFile);
            /// File.WriteAllLines (ConfigFile, Configuration);
            using (System.IO.FileStream fs = File.Create(ConfigFile))
            {
                fs.Close();
                File.WriteAllLines(ConfigFile, Configuration);
            }
         
            /// reload settings
            settingsToolStripMenuItem_Click(this, EventArgs.Empty);
        }
        private void Remove_Click(object sender, EventArgs e)
        {
            int x = 0;
            string[] temp = null;
           
            /////find calling config
            try
            {
                Array.Resize(ref temp, Configuration.Length - 1);

                foreach (Label menuparent in CurrentConfig.Controls )
                {
                    if (menuparent.ContextMenu.MenuItems[3] == sender)
                    {
                        ////found calling config , exit for

                        break;
                    }

                    x++;
                }
            }
                catch 
            {
                    ///ignore , not a label
            }
                int z = 0;
                int y = 0;
                do
                {
                    foreach (string keepit in Configuration)
                    {
                        try
                        {
                            if (z != x)
                            {
                                temp[y] = keepit;
                                y++;
                            }
                            z++;
                        }
                        catch
                        {
                        }
                    }
                } while (y < temp.Length);
                
                Array.Clear(Configuration, 0, Configuration.Length);
                Array.Resize(ref Configuration, temp.Length);

                Configuration = temp;

            ///rewrite configuration
                File.Delete(ConfigFile);
             
                using (System.IO.FileStream fs = File.Create (ConfigFile ))
                {
                    fs.Close();                    
                      
                   File.WriteAllLines(ConfigFile, Configuration);
                  
                }
                        
            /// reload settings
                settingsToolStripMenuItem_Click(this, EventArgs.Empty);
        }
        private void Add_Click(object sender, EventArgs e)
        {

            if (location.Text != "")
            {
                Array.Resize(ref Configuration, Configuration.Length + 1);
                Configuration[Configuration.Length - 1] = location.Text;
                File.Delete(ConfigFile);
                File.WriteAllLines(ConfigFile, Configuration);
                
            }
            //// show error message

            else
            {
                MessageBox.Show("Field Cannot Be Blank ,Please select an appropiate Title", "Error ,Invalid Selection", MessageBoxButtons.OK);
            }
            Loadconfig();
            settingsToolStripMenuItem_Click(this, EventArgs.Empty);
        }
        private void CloseSettings_Click(object sender, EventArgs e)
        {
            settings.Visible = false;
            _main.Visible=true;
            _main.BringToFront();
            Loadconfig();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void location_TextChanged(object sender, EventArgs e)
        {
            Info.SetToolTip(location, location.Text );
        }
    }
}