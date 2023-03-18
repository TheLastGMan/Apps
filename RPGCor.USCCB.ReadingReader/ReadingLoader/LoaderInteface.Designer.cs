
namespace ReadingLoader
{
    partial class LoaderInteface : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public LoaderInteface()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.USCCB = this.Factory.CreateRibbonTab();
            this.Readings = this.Factory.CreateRibbonGroup();
            this.Reading1 = this.Factory.CreateRibbonButton();
            this.ResponsorialPsalm = this.Factory.CreateRibbonButton();
            this.Reading2 = this.Factory.CreateRibbonButton();
            this.Alleluia = this.Factory.CreateRibbonButton();
            this.Gospel = this.Factory.CreateRibbonButton();
            this.DailyAutomation = this.Factory.CreateRibbonGroup();
            this.AutomateToday = this.Factory.CreateRibbonButton();
            this.AutomateToday1 = this.Factory.CreateRibbonButton();
            this.AutomateToday2 = this.Factory.CreateRibbonButton();
            this.AutomateToday3 = this.Factory.CreateRibbonButton();
            this.AutomateToday4 = this.Factory.CreateRibbonButton();
            this.AutomateToday5 = this.Factory.CreateRibbonButton();
            this.AutomateToday6 = this.Factory.CreateRibbonButton();
            this.AutomateToday7 = this.Factory.CreateRibbonButton();
            this.Notes = this.Factory.CreateRibbonGroup();
            this.label4 = this.Factory.CreateRibbonLabel();
            this.label5 = this.Factory.CreateRibbonLabel();
            this.label6 = this.Factory.CreateRibbonLabel();
            this.About = this.Factory.CreateRibbonGroup();
            this.label2 = this.Factory.CreateRibbonLabel();
            this.label3 = this.Factory.CreateRibbonLabel();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.USCCB.SuspendLayout();
            this.Readings.SuspendLayout();
            this.DailyAutomation.SuspendLayout();
            this.Notes.SuspendLayout();
            this.About.SuspendLayout();
            this.SuspendLayout();
            // 
            // USCCB
            // 
            this.USCCB.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.USCCB.Groups.Add(this.Readings);
            this.USCCB.Groups.Add(this.DailyAutomation);
            this.USCCB.Groups.Add(this.Notes);
            this.USCCB.Groups.Add(this.About);
            this.USCCB.Label = "Daily Readings";
            this.USCCB.Name = "USCCB";
            // 
            // Readings
            // 
            this.Readings.Items.Add(this.Reading1);
            this.Readings.Items.Add(this.ResponsorialPsalm);
            this.Readings.Items.Add(this.Reading2);
            this.Readings.Items.Add(this.Alleluia);
            this.Readings.Items.Add(this.Gospel);
            this.Readings.Label = "Today\'s Reading";
            this.Readings.Name = "Readings";
            // 
            // Reading1
            // 
            this.Reading1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Reading1.Image = global::ReadingLoader.Properties.Resources.Reading1;
            this.Reading1.Label = "Reading 1";
            this.Reading1.Name = "Reading1";
            this.Reading1.ShowImage = true;
            this.Reading1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Reading1_Click);
            // 
            // ResponsorialPsalm
            // 
            this.ResponsorialPsalm.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ResponsorialPsalm.Image = global::ReadingLoader.Properties.Resources.Response;
            this.ResponsorialPsalm.Label = "Response";
            this.ResponsorialPsalm.Name = "ResponsorialPsalm";
            this.ResponsorialPsalm.ShowImage = true;
            this.ResponsorialPsalm.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ResponsorialPsalm_Click);
            // 
            // Reading2
            // 
            this.Reading2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Reading2.Image = global::ReadingLoader.Properties.Resources.Reading2;
            this.Reading2.Label = "Reading 2";
            this.Reading2.Name = "Reading2";
            this.Reading2.ShowImage = true;
            this.Reading2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Reading2_Click);
            // 
            // Alleluia
            // 
            this.Alleluia.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Alleluia.Image = global::ReadingLoader.Properties.Resources.Alleluia;
            this.Alleluia.Label = "Alleluia";
            this.Alleluia.Name = "Alleluia";
            this.Alleluia.ShowImage = true;
            this.Alleluia.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Alleluia_Click);
            // 
            // Gospel
            // 
            this.Gospel.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Gospel.Image = global::ReadingLoader.Properties.Resources.Gospel;
            this.Gospel.Label = "Gospel";
            this.Gospel.Name = "Gospel";
            this.Gospel.ShowImage = true;
            this.Gospel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Gospel_Click);
            // 
            // DailyAutomation
            // 
            this.DailyAutomation.Items.Add(this.AutomateToday);
            this.DailyAutomation.Items.Add(this.AutomateToday1);
            this.DailyAutomation.Items.Add(this.AutomateToday2);
            this.DailyAutomation.Items.Add(this.AutomateToday3);
            this.DailyAutomation.Items.Add(this.AutomateToday4);
            this.DailyAutomation.Items.Add(this.AutomateToday5);
            this.DailyAutomation.Items.Add(this.AutomateToday6);
            this.DailyAutomation.Items.Add(this.AutomateToday7);
            this.DailyAutomation.Label = "Daily Automation";
            this.DailyAutomation.Name = "DailyAutomation";
            // 
            // AutomateToday
            // 
            this.AutomateToday.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AutomateToday.Image = global::ReadingLoader.Properties.Resources.T;
            this.AutomateToday.Label = "Today";
            this.AutomateToday.Name = "AutomateToday";
            this.AutomateToday.ShowImage = true;
            this.AutomateToday.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday_Click);
            // 
            // AutomateToday1
            // 
            this.AutomateToday1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AutomateToday1.Image = global::ReadingLoader.Properties.Resources.T1;
            this.AutomateToday1.Label = "Today +1";
            this.AutomateToday1.Name = "AutomateToday1";
            this.AutomateToday1.ShowImage = true;
            this.AutomateToday1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday1_Click);
            // 
            // AutomateToday2
            // 
            this.AutomateToday2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AutomateToday2.Image = global::ReadingLoader.Properties.Resources.T2;
            this.AutomateToday2.Label = "Today +2";
            this.AutomateToday2.Name = "AutomateToday2";
            this.AutomateToday2.ShowImage = true;
            this.AutomateToday2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday2_Click);
            // 
            // AutomateToday3
            // 
            this.AutomateToday3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AutomateToday3.Image = global::ReadingLoader.Properties.Resources.T3;
            this.AutomateToday3.Label = "Today +3";
            this.AutomateToday3.Name = "AutomateToday3";
            this.AutomateToday3.ShowImage = true;
            this.AutomateToday3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday3_Click);
            // 
            // AutomateToday4
            // 
            this.AutomateToday4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AutomateToday4.Image = global::ReadingLoader.Properties.Resources.T4;
            this.AutomateToday4.Label = "Today +4";
            this.AutomateToday4.Name = "AutomateToday4";
            this.AutomateToday4.ShowImage = true;
            this.AutomateToday4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday4_Click);
            // 
            // AutomateToday5
            // 
            this.AutomateToday5.Label = "Today +5";
            this.AutomateToday5.Name = "AutomateToday5";
            this.AutomateToday5.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday5_Click);
            // 
            // AutomateToday6
            // 
            this.AutomateToday6.Label = "Today +6";
            this.AutomateToday6.Name = "AutomateToday6";
            this.AutomateToday6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday6_Click);
            // 
            // AutomateToday7
            // 
            this.AutomateToday7.Label = "Today +7";
            this.AutomateToday7.Name = "AutomateToday7";
            this.AutomateToday7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AutomateToday7_Click);
            // 
            // Notes
            // 
            this.Notes.Items.Add(this.label4);
            this.Notes.Items.Add(this.label5);
            this.Notes.Items.Add(this.label6);
            this.Notes.Label = "Notes";
            this.Notes.Name = "Notes";
            // 
            // label4
            // 
            this.label4.Label = "Automation: Based on slides textbox names";
            this.label4.Name = "label4";
            // 
            // label5
            // 
            this.label5.Label = "Deletes excess reading slides";
            this.label5.Name = "label5";
            // 
            // label6
            // 
            this.label6.Label = "Add/Update/Split slides with indivdiual reading";
            this.label6.Name = "label6";
            // 
            // About
            // 
            this.About.Items.Add(this.label2);
            this.About.Items.Add(this.label3);
            this.About.Items.Add(this.label1);
            this.About.Label = "About";
            this.About.Name = "About";
            // 
            // label2
            // 
            this.label2.Label = "Idea: Load readings from USCCB website and apply basic formatting";
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.Label = "Note: Applies to current slide only";
            this.label3.Name = "label3";
            // 
            // label1
            // 
            this.label1.Label = "Created By: Ryan Gau (http://rpgcor.com)";
            this.label1.Name = "label1";
            // 
            // LoaderInteface
            // 
            this.Name = "LoaderInteface";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.USCCB);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.LoaderInteface_Load);
            this.USCCB.ResumeLayout(false);
            this.USCCB.PerformLayout();
            this.Readings.ResumeLayout(false);
            this.Readings.PerformLayout();
            this.DailyAutomation.ResumeLayout(false);
            this.DailyAutomation.PerformLayout();
            this.Notes.ResumeLayout(false);
            this.Notes.PerformLayout();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab USCCB;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Readings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Reading1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ResponsorialPsalm;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Gospel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Reading2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup About;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label2;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label3;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Alleluia;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup DailyAutomation;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Notes;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label5;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AutomateToday7;
    }

    partial class ThisRibbonCollection
    {
        internal LoaderInteface LoaderInteface
        {
            get { return this.GetRibbon<LoaderInteface>(); }
        }
    }
}
