namespace WatchDog
{
  partial class MPWatchDog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.settingsGroup = new System.Windows.Forms.GroupBox();
      this.btnZipFileReset = new System.Windows.Forms.Button();
      this.btnZipFile = new System.Windows.Forms.Button();
      this.tbZipFile = new System.Windows.Forms.TextBox();
      this.logDirLabel = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.ExportLogsRadioButton = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.SafeModeRadioButton = new System.Windows.Forms.RadioButton();
      this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.menuItem8 = new System.Windows.Forms.MenuItem();
      this.menuItem5 = new System.Windows.Forms.MenuItem();
      this.menuItem9 = new System.Windows.Forms.MenuItem();
      this.menuItem13 = new System.Windows.Forms.MenuItem();
      this.menuItem10 = new System.Windows.Forms.MenuItem();
      this.menuItem11 = new System.Windows.Forms.MenuItem();
      this.miCleanMPCLog = new System.Windows.Forms.MenuItem();
      this.miCleanMpCEvents = new System.Windows.Forms.MenuItem();
      this.miCleanMpClogAndEvent = new System.Windows.Forms.MenuItem();
      this.menuItem12 = new System.Windows.Forms.MenuItem();
      this.miCleanTVsLog = new System.Windows.Forms.MenuItem();
      this.miCleanLogBoth = new System.Windows.Forms.MenuItem();
      this.menuItem14 = new System.Windows.Forms.MenuItem();
      this.miStopTvService = new System.Windows.Forms.MenuItem();
      this.miStartTvService = new System.Windows.Forms.MenuItem();
      this.menuItem32 = new System.Windows.Forms.MenuItem();
      this.menuItem33 = new System.Windows.Forms.MenuItem();
      this.menuItem15 = new System.Windows.Forms.MenuItem();
      this.menuItem16 = new System.Windows.Forms.MenuItem();
      this.menuItem18 = new System.Windows.Forms.MenuItem();
      this.menuItem19 = new System.Windows.Forms.MenuItem();
      this.menuItem20 = new System.Windows.Forms.MenuItem();
      this.menuItem17 = new System.Windows.Forms.MenuItem();
      this.menuItem31 = new System.Windows.Forms.MenuItem();
      this.menuItem30 = new System.Windows.Forms.MenuItem();
      this.menuItem22 = new System.Windows.Forms.MenuItem();
      this.menuItem21 = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.menuItem7 = new System.Windows.Forms.MenuItem();
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.tmrUnAttended = new System.Windows.Forms.Timer(this.components);
      this.tmrMPWatcher = new System.Windows.Forms.Timer(this.components);
      this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
      this.NormalModeRadioButton = new System.Windows.Forms.RadioButton();
      this.ProceedButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.settingsGroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // settingsGroup
      // 
      this.settingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.settingsGroup.Controls.Add(this.btnZipFileReset);
      this.settingsGroup.Controls.Add(this.btnZipFile);
      this.settingsGroup.Controls.Add(this.tbZipFile);
      this.settingsGroup.Controls.Add(this.logDirLabel);
      this.settingsGroup.Location = new System.Drawing.Point(12, 12);
      this.settingsGroup.Name = "settingsGroup";
      this.settingsGroup.Size = new System.Drawing.Size(403, 86);
      this.settingsGroup.TabIndex = 2;
      this.settingsGroup.TabStop = false;
      this.settingsGroup.Text = "Settings";
      // 
      // btnZipFileReset
      // 
      this.btnZipFileReset.Location = new System.Drawing.Point(333, 57);
      this.btnZipFileReset.Name = "btnZipFileReset";
      this.btnZipFileReset.Size = new System.Drawing.Size(64, 23);
      this.btnZipFileReset.TabIndex = 4;
      this.btnZipFileReset.Text = "Reset";
      this.btnZipFileReset.UseVisualStyleBackColor = true;
      this.btnZipFileReset.Click += new System.EventHandler(this.btnZipFileReset_Click);
      // 
      // btnZipFile
      // 
      this.btnZipFile.Location = new System.Drawing.Point(333, 32);
      this.btnZipFile.Name = "btnZipFile";
      this.btnZipFile.Size = new System.Drawing.Size(64, 23);
      this.btnZipFile.TabIndex = 3;
      this.btnZipFile.Text = "Browse";
      this.btnZipFile.Click += new System.EventHandler(this.btnZipFile_Click);
      // 
      // tbZipFile
      // 
      this.tbZipFile.Location = new System.Drawing.Point(6, 34);
      this.tbZipFile.Name = "tbZipFile";
      this.tbZipFile.Size = new System.Drawing.Size(321, 20);
      this.tbZipFile.TabIndex = 2;
      this.tbZipFile.TextChanged += new System.EventHandler(this.tbZipFile_TextChanged);
      // 
      // logDirLabel
      // 
      this.logDirLabel.Location = new System.Drawing.Point(6, 16);
      this.logDirLabel.Name = "logDirLabel";
      this.logDirLabel.Size = new System.Drawing.Size(152, 15);
      this.logDirLabel.TabIndex = 2;
      this.logDirLabel.Text = "Resulting ZIP of logs";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.Location = new System.Drawing.Point(12, 288);
      this.label3.Name = "label3";
      this.label3.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
      this.label3.Size = new System.Drawing.Size(403, 38);
      this.label3.TabIndex = 9;
      this.label3.Text = "If MediaPortal crashes unexpectedly, or if you can not reproduce an issue nicely," +
    " then this option will simply export all the currently available log files.";
      // 
      // ExportLogsRadioButton
      // 
      this.ExportLogsRadioButton.AutoSize = true;
      this.ExportLogsRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.ExportLogsRadioButton.Location = new System.Drawing.Point(12, 268);
      this.ExportLogsRadioButton.Name = "ExportLogsRadioButton";
      this.ExportLogsRadioButton.Size = new System.Drawing.Size(204, 17);
      this.ExportLogsRadioButton.TabIndex = 8;
      this.ExportLogsRadioButton.TabStop = true;
      this.ExportLogsRadioButton.Text = "Export all currently present logs";
      this.ExportLogsRadioButton.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(12, 124);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
      this.label1.Size = new System.Drawing.Size(403, 59);
      this.label1.TabIndex = 1;
      this.label1.Text = "This will start MediaPortal using the default skin, and only plugins which were p" +
    "art of the release version you installed. No extensions will be loaded.";
      // 
      // SafeModeRadioButton
      // 
      this.SafeModeRadioButton.AutoSize = true;
      this.SafeModeRadioButton.Checked = true;
      this.SafeModeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.SafeModeRadioButton.Location = new System.Drawing.Point(12, 104);
      this.SafeModeRadioButton.Name = "SafeModeRadioButton";
      this.SafeModeRadioButton.Size = new System.Drawing.Size(221, 17);
      this.SafeModeRadioButton.TabIndex = 0;
      this.SafeModeRadioButton.TabStop = true;
      this.SafeModeRadioButton.Text = "Report a Bug to Team MediaPortal";
      this.SafeModeRadioButton.UseVisualStyleBackColor = true;
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem9,
            this.menuItem6});
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
      this.menuItem1.Text = "File";
      // 
      // menuItem2
      // 
      this.menuItem2.Checked = true;
      this.menuItem2.Index = 0;
      this.menuItem2.Text = "Exit";
      this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
      // 
      // menuItem3
      // 
      this.menuItem3.Index = 1;
      this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem8,
            this.menuItem5});
      this.menuItem3.Text = "Action";
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 0;
      this.menuItem4.Text = "1. Perform pre-test actions";
      // 
      // menuItem8
      // 
      this.menuItem8.Index = 1;
      this.menuItem8.Text = "2. Launch MediaPortal";
      // 
      // menuItem5
      // 
      this.menuItem5.Index = 2;
      this.menuItem5.Text = "3. Perform post-test actions";
      // 
      // menuItem9
      // 
      this.menuItem9.Index = 2;
      this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem13,
            this.menuItem32,
            this.menuItem33,
            this.menuItem15,
            this.menuItem17});
      this.menuItem9.Text = "Advanced Control";
      // 
      // menuItem13
      // 
      this.menuItem13.Index = 0;
      this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem14});
      this.menuItem13.Text = "Single-Seat";
      // 
      // menuItem10
      // 
      this.menuItem10.Index = 0;
      this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem12,
            this.miCleanLogBoth});
      this.menuItem10.Text = "Clean Log";
      // 
      // menuItem11
      // 
      this.menuItem11.Index = 0;
      this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miCleanMPCLog,
            this.miCleanMpCEvents,
            this.miCleanMpClogAndEvent});
      this.menuItem11.Text = "MediaPortal Client";
      // 
      // miCleanMPCLog
      // 
      this.miCleanMPCLog.Index = 0;
      this.miCleanMPCLog.Text = "Log Files";
      this.miCleanMPCLog.Click += new System.EventHandler(this.miCleanMPCLog_Click);
      // 
      // miCleanMpCEvents
      // 
      this.miCleanMpCEvents.Index = 1;
      this.miCleanMpCEvents.Text = "Events";
      this.miCleanMpCEvents.Click += new System.EventHandler(this.miCleanMpCEvents_Click);
      // 
      // miCleanMpClogAndEvent
      // 
      this.miCleanMpClogAndEvent.Index = 2;
      this.miCleanMpClogAndEvent.Text = "Both";
      this.miCleanMpClogAndEvent.Click += new System.EventHandler(this.miCleanMpClogAndEvent_Click);
      // 
      // menuItem12
      // 
      this.menuItem12.Index = 1;
      this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miCleanTVsLog});
      this.menuItem12.Text = "TV server";
      this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
      // 
      // miCleanTVsLog
      // 
      this.miCleanTVsLog.Enabled = false;
      this.miCleanTVsLog.Index = 0;
      this.miCleanTVsLog.Text = "Log files";
      // 
      // miCleanLogBoth
      // 
      this.miCleanLogBoth.Enabled = false;
      this.miCleanLogBoth.Index = 2;
      this.miCleanLogBoth.Text = "Both";
      this.miCleanLogBoth.Click += new System.EventHandler(this.miCleanLogBoth_Click);
      // 
      // menuItem14
      // 
      this.menuItem14.Index = 1;
      this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miStopTvService,
            this.miStartTvService});
      this.menuItem14.Text = "Tv Service";
      // 
      // miStopTvService
      // 
      this.miStopTvService.Index = 0;
      this.miStopTvService.Text = "Stop Tv Service";
      this.miStopTvService.Click += new System.EventHandler(this.miStopTvService_Click);
      // 
      // miStartTvService
      // 
      this.miStartTvService.Index = 1;
      this.miStartTvService.Text = "Start Tv Service";
      this.miStartTvService.Click += new System.EventHandler(this.miStartTvService_Click);
      // 
      // menuItem32
      // 
      this.menuItem32.Index = 1;
      this.menuItem32.Text = "-";
      // 
      // menuItem33
      // 
      this.menuItem33.Enabled = false;
      this.menuItem33.Index = 2;
      this.menuItem33.Text = "Multi-seat";
      // 
      // menuItem15
      // 
      this.menuItem15.Index = 3;
      this.menuItem15.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem16});
      this.menuItem15.Text = "Client";
      // 
      // menuItem16
      // 
      this.menuItem16.Index = 0;
      this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18,
            this.menuItem19,
            this.menuItem20});
      this.menuItem16.Text = "Clean Log";
      // 
      // menuItem18
      // 
      this.menuItem18.Index = 0;
      this.menuItem18.Text = "Log Files";
      // 
      // menuItem19
      // 
      this.menuItem19.Index = 1;
      this.menuItem19.Text = "Events";
      // 
      // menuItem20
      // 
      this.menuItem20.Index = 2;
      this.menuItem20.Text = "Both";
      // 
      // menuItem17
      // 
      this.menuItem17.Index = 4;
      this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem31,
            this.menuItem30,
            this.menuItem22,
            this.menuItem21});
      this.menuItem17.Text = "TV Server";
      // 
      // menuItem31
      // 
      this.menuItem31.Index = 0;
      this.menuItem31.Text = "Start Tv Service";
      // 
      // menuItem30
      // 
      this.menuItem30.Index = 1;
      this.menuItem30.Text = "Stop Tv Service";
      // 
      // menuItem22
      // 
      this.menuItem22.Index = 2;
      this.menuItem22.Text = "-";
      // 
      // menuItem21
      // 
      this.menuItem21.Index = 3;
      this.menuItem21.Text = "Clean Log";
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 3;
      this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7});
      this.menuItem6.Text = "Help";
      // 
      // menuItem7
      // 
      this.menuItem7.Index = 0;
      this.menuItem7.Text = "About";
      this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 403);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(427, 20);
      this.statusBar.TabIndex = 6;
      this.statusBar.Text = "Status: Idle";
      // 
      // tmrUnAttended
      // 
      this.tmrUnAttended.Interval = 1000;
      this.tmrUnAttended.Tick += new System.EventHandler(this.tmrUnAttended_Tick);
      // 
      // tmrMPWatcher
      // 
      this.tmrMPWatcher.Interval = 5000;
      this.tmrMPWatcher.Tick += new System.EventHandler(this.tmrMPWatcher_Tick);
      // 
      // tmrWatchdog
      // 
      this.tmrWatchdog.Interval = 1000;
      this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_Tick);
      // 
      // NormalModeRadioButton
      // 
      this.NormalModeRadioButton.AutoSize = true;
      this.NormalModeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.NormalModeRadioButton.Location = new System.Drawing.Point(12, 186);
      this.NormalModeRadioButton.Name = "NormalModeRadioButton";
      this.NormalModeRadioButton.Size = new System.Drawing.Size(325, 17);
      this.NormalModeRadioButton.TabIndex = 1;
      this.NormalModeRadioButton.TabStop = true;
      this.NormalModeRadioButton.Text = "Report a Bug to a Plugin Developer or Skin Designer";
      this.NormalModeRadioButton.UseVisualStyleBackColor = true;
      // 
      // ProceedButton
      // 
      this.ProceedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ProceedButton.Location = new System.Drawing.Point(339, 374);
      this.ProceedButton.Name = "ProceedButton";
      this.ProceedButton.Size = new System.Drawing.Size(75, 23);
      this.ProceedButton.TabIndex = 8;
      this.ProceedButton.Text = "Proceed";
      this.ProceedButton.UseVisualStyleBackColor = true;
      this.ProceedButton.Click += new System.EventHandler(this.ProceedButton_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Location = new System.Drawing.Point(12, 206);
      this.label2.Name = "label2";
      this.label2.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
      this.label2.Size = new System.Drawing.Size(391, 59);
      this.label2.TabIndex = 2;
      this.label2.Text = "Besides setting the log level to \"debug\", this option will start MediaPortal as c" +
    "onfigured, using all extensions you have installed.";
      // 
      // MPWatchDog
      // 
      this.AcceptButton = this.ProceedButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(427, 423);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.ExportLogsRadioButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.SafeModeRadioButton);
      this.Controls.Add(this.NormalModeRadioButton);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ProceedButton);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.settingsGroup);
      this.Menu = this.mainMenu;
      this.Name = "MPWatchDog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "MediaPortal Watchdog";
      this.settingsGroup.ResumeLayout(false);
      this.settingsGroup.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox settingsGroup;
    private System.Windows.Forms.Button btnZipFile;
    private System.Windows.Forms.TextBox tbZipFile;
    private System.Windows.Forms.Label logDirLabel;
    private System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.Windows.Forms.MenuItem menuItem5;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem menuItem7;
    private System.Windows.Forms.StatusBar statusBar;
    private System.Windows.Forms.MenuItem menuItem8;
    private System.Windows.Forms.Timer tmrUnAttended;
    private System.Windows.Forms.Timer tmrMPWatcher;
    private System.Windows.Forms.Timer tmrWatchdog;
    private System.Windows.Forms.RadioButton SafeModeRadioButton;
    private System.Windows.Forms.RadioButton ExportLogsRadioButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton NormalModeRadioButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button ProceedButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.MenuItem menuItem9;
    private System.Windows.Forms.MenuItem menuItem10;
    private System.Windows.Forms.MenuItem menuItem11;
    private System.Windows.Forms.MenuItem menuItem12;
    private System.Windows.Forms.MenuItem miCleanLogBoth;
    private System.Windows.Forms.MenuItem menuItem14;
    private System.Windows.Forms.MenuItem miStopTvService;
    private System.Windows.Forms.MenuItem miStartTvService;
    private System.Windows.Forms.MenuItem miCleanMPCLog;
    private System.Windows.Forms.MenuItem miCleanMpCEvents;
    private System.Windows.Forms.MenuItem miCleanMpClogAndEvent;
    private System.Windows.Forms.Button btnZipFileReset;
    private System.Windows.Forms.MenuItem miCleanTVsLog;
    private System.Windows.Forms.MenuItem menuItem13;
    private System.Windows.Forms.MenuItem menuItem15;
    private System.Windows.Forms.MenuItem menuItem16;
    private System.Windows.Forms.MenuItem menuItem18;
    private System.Windows.Forms.MenuItem menuItem19;
    private System.Windows.Forms.MenuItem menuItem20;
    private System.Windows.Forms.MenuItem menuItem32;
    private System.Windows.Forms.MenuItem menuItem17;
    private System.Windows.Forms.MenuItem menuItem31;
    private System.Windows.Forms.MenuItem menuItem30;
    private System.Windows.Forms.MenuItem menuItem22;
    private System.Windows.Forms.MenuItem menuItem21;
    private System.Windows.Forms.MenuItem menuItem33;
  }
}