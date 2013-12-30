namespace SourceBuilderGUI
{
	partial class frmGUI
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
			this.btnOpen = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.btnBuild = new System.Windows.Forms.Button();
			this.ofdProject = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblSource = new System.Windows.Forms.Label();
			this.lblProject = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.btnOpenSrc = new System.Windows.Forms.Button();
			this.chkDebug = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(16, 24);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(136, 40);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open Project File";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "Library Path";
			// 
			// btnBuild
			// 
			this.btnBuild.Location = new System.Drawing.Point(158, 24);
			this.btnBuild.Name = "btnBuild";
			this.btnBuild.Size = new System.Drawing.Size(125, 40);
			this.btnBuild.TabIndex = 3;
			this.btnBuild.Text = "Build Source";
			this.btnBuild.UseVisualStyleBackColor = true;
			this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
			// 
			// ofdProject
			// 
			this.ofdProject.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Project";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Source";
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(77, 121);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(0, 13);
			this.lblSource.TabIndex = 8;
			// 
			// lblProject
			// 
			this.lblProject.AutoSize = true;
			this.lblProject.Location = new System.Drawing.Point(77, 96);
			this.lblProject.Name = "lblProject";
			this.lblProject.Size = new System.Drawing.Size(0, 13);
			this.lblProject.TabIndex = 7;
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(77, 72);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(0, 13);
			this.lblPath.TabIndex = 6;
			// 
			// btnOpenSrc
			// 
			this.btnOpenSrc.Location = new System.Drawing.Point(373, 24);
			this.btnOpenSrc.Name = "btnOpenSrc";
			this.btnOpenSrc.Size = new System.Drawing.Size(131, 40);
			this.btnOpenSrc.TabIndex = 9;
			this.btnOpenSrc.Text = "Open Source";
			this.btnOpenSrc.UseVisualStyleBackColor = true;
			this.btnOpenSrc.Click += new System.EventHandler(this.btnOpenSrc_Click);
			// 
			// chkDebug
			// 
			this.chkDebug.AutoSize = true;
			this.chkDebug.Checked = true;
			this.chkDebug.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDebug.Location = new System.Drawing.Point(225, 117);
			this.chkDebug.Name = "chkDebug";
			this.chkDebug.Size = new System.Drawing.Size(58, 17);
			this.chkDebug.TabIndex = 10;
			this.chkDebug.Text = "Debug";
			this.chkDebug.UseVisualStyleBackColor = true;
			// 
			// frmGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(530, 154);
			this.Controls.Add(this.chkDebug);
			this.Controls.Add(this.btnOpenSrc);
			this.Controls.Add(this.lblSource);
			this.Controls.Add(this.lblProject);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnBuild);
			this.Controls.Add(this.btnOpen);
			this.Name = "frmGUI";
			this.Text = "Squirrel Project Builder";
			this.Load += new System.EventHandler(this.frmGUI_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnBuild;
		private System.Windows.Forms.OpenFileDialog ofdProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.Label lblProject;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Button btnOpenSrc;
		private System.Windows.Forms.CheckBox chkDebug;
	}
}

