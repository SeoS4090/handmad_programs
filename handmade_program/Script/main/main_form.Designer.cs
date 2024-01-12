namespace handmade_program
{
    partial class main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            toolbar = new MenuStrip();
            toolbar_File = new ToolStripMenuItem();
            Toolbar_Option = new ToolStripMenuItem();
            toolbar_fuction = new ToolStripMenuItem();
            TermBuild = new ToolStripMenuItem();
            toolbar_help = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            notification = new NotifyIcon(components);
            notification_menu = new ContextMenuStrip(components);
            Exit = new ToolStripMenuItem();
            test_panel = new Panel();
            toolbar.SuspendLayout();
            notification_menu.SuspendLayout();
            SuspendLayout();
            // 
            // toolbar
            // 
            resources.ApplyResources(toolbar, "toolbar");
            toolbar.GripMargin = new Padding(0);
            toolbar.Items.AddRange(new ToolStripItem[] { toolbar_File, toolbar_fuction, toolbar_help });
            toolbar.Name = "toolbar";
            // 
            // toolbar_File
            // 
            resources.ApplyResources(toolbar_File, "toolbar_File");
            toolbar_File.DropDownItems.AddRange(new ToolStripItem[] { Toolbar_Option });
            toolbar_File.Name = "toolbar_File";
            // 
            // Toolbar_Option
            // 
            resources.ApplyResources(Toolbar_Option, "Toolbar_Option");
            Toolbar_Option.Name = "Toolbar_Option";
            Toolbar_Option.Click += Toolbar_Option_Click;
            // 
            // toolbar_fuction
            // 
            resources.ApplyResources(toolbar_fuction, "toolbar_fuction");
            toolbar_fuction.DropDownItems.AddRange(new ToolStripItem[] { TermBuild });
            toolbar_fuction.Name = "toolbar_fuction";
            // 
            // TermBuild
            // 
            resources.ApplyResources(TermBuild, "TermBuild");
            TermBuild.Name = "TermBuild";
            TermBuild.Click += TermBuild_Click;
            // 
            // toolbar_help
            // 
            resources.ApplyResources(toolbar_help, "toolbar_help");
            toolbar_help.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            toolbar_help.Name = "toolbar_help";
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Click += Onclick_ToolBar_Menu;
            // 
            // notification
            // 
            resources.ApplyResources(notification, "notification");
            notification.ContextMenuStrip = notification_menu;
            notification.MouseDoubleClick += notification_MouseDoubleClick;
            // 
            // notification_menu
            // 
            resources.ApplyResources(notification_menu, "notification_menu");
            notification_menu.Items.AddRange(new ToolStripItem[] { Exit });
            notification_menu.Name = "notification_menu";
            // 
            // Exit
            // 
            resources.ApplyResources(Exit, "Exit");
            Exit.Name = "Exit";
            Exit.Click += Exit_Click;
            // 
            // test_panel
            // 
            resources.ApplyResources(test_panel, "test_panel");
            test_panel.Name = "test_panel";
            // 
            // main_form
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(test_panel);
            Controls.Add(toolbar);
            MainMenuStrip = toolbar;
            Name = "main_form";
            FormClosing += Main_form_Close;
            toolbar.ResumeLayout(false);
            toolbar.PerformLayout();
            notification_menu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip toolbar;
        private ToolStripMenuItem toolbar_help;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private NotifyIcon notification;
        private Panel test_panel;
        private ContextMenuStrip notification_menu;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem toolbar_File;
        private ToolStripMenuItem Toolbar_Option;
        private ToolStripMenuItem toolbar_fuction;
        private ToolStripMenuItem TermBuild;
    }
}