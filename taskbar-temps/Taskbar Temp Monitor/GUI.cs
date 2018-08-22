﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.WMI;
using OpenHardwareMonitor.Utilities;

namespace Taskbar_Temp_Monitor
{
    public partial class GUI : Form
    {
        NotifyIcon notify;
        ContextMenu context;
        MenuItem menu;
        Computer myComputer;
        
        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                value = false;
                CreateHandle();

            }
            base.SetVisibleCore(value);
        }

        public GUI()
        {
            InitializeComponent();
            this.components = new Container();
            this.context = new ContextMenu();
            this.menu = new MenuItem();

            this.context.MenuItems.AddRange(
                        new MenuItem[] { this.menu });

            this.menu.Index = 0;
            this.menu.Text = "E&xit";
            this.menu.Click += new EventHandler(this.menu_Click);

            this.notify = new NotifyIcon(this.components);


            notify.Icon = Properties.Resources.icon_template;
            notify.ContextMenu = this.context;
            notify.Text = "Form 1 Example";
            notify.Visible = true;

            notify.DoubleClick += new EventHandler(this.notify_DoubleClick);
            runMainLogicLoop();


        }


        private void runMainLogicLoop()
        {
            myComputer = new Computer
            {
                CPUEnabled = true
            };
        
            myComputer.Open();
            
        }



        private void menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notify_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
            
        }


    }



}
