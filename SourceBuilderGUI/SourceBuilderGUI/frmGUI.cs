using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SourceBuilderGUI
{
	public partial class frmGUI : Form
	{
		private string ProjectFileName;
		private string SourceFileName;

		public frmGUI(string args)
		{
			InitializeComponent();

			if (args != null)
			{
				if (Path.GetExtension(args) != ".pnut")
				{

					MessageBox.Show(args + " is not a valid Squirrel project file");
					btnBuild.Enabled = false;
					return;
				}
				ProjectFileName = args;
				SourceFileName = Path.ChangeExtension(ProjectFileName, "nut");
				lblProject.Text = args;
			}
			else
				btnBuild.Enabled = false;
		}

		private void btnBuild_Click(object sender, EventArgs e)
		{
			try
			{
				string[] IncludeStr = new string[1024];
				string[] InsertPath = null;
				string[] LibraryPath = null;
				string[] PathElements = null;
				string[] SrcPathElements = null;
				string[] InsertElements = null;
				string[] ReducedInsertElements = null;
				string InsertLineStr = null;
				string SrcPathStr;
				string InsertPathStr;
				string LibraryPathStr = "";
				string InsertFileName;
				bool Substitute_FileStr = false;
				bool Substitute_LibStr = false;
				int NrLevelsDown;
				int DoNotWrite = 0;

				// read all build lines
				using (StreamReader SrProject = new StreamReader(ProjectFileName))
				{
					int LinePos = 0;
					while ((IncludeStr[LinePos] = SrProject.ReadLine()) != null)
					{
						LinePos++;
					}

					using (StreamWriter SwDestSrc = new StreamWriter(SourceFileName))
					{
						if (chkDebug.Checked == true)
						{
							SwDestSrc.WriteLine("/*************************************************************************/");
							SwDestSrc.WriteLine("/************** DEBUG VERSION - DO NOT USE IN PRODUCTION *****************/");
							SwDestSrc.WriteLine("/*************************************************************************/");
						}
						foreach (string LineStr in IncludeStr)
						{
							if (LineStr.StartsWith("#define LIBRARYPATH"))
							{
								LibraryPath = LineStr.Split('"');
								LibraryPathStr = LibraryPath[1];
								lblPath.Text = Path.GetDirectoryName(LibraryPathStr);
								continue;
							}

							if (LineStr.StartsWith("#include"))
							{
								InsertPath = LineStr.Split('"');
								InsertElements = InsertPath[1].Split('\\');
								NrLevelsDown = 0;
								Substitute_FileStr = false;
								Substitute_LibStr = false;
								for (int i = 0; i < InsertElements.GetLength(0); i++)
								{
									if (InsertElements[i] == "..")
										{
											NrLevelsDown++;
											//Substitute_FileStr = true;
										}
									// replace LIBRARYPATH definition by the #define value
									if (InsertElements[i] == "LIBRARYPATH")
										{
											InsertElements[i] = LibraryPathStr;
											Substitute_LibStr = true;
										}
								}

								if (Substitute_LibStr == true)
								{
									PathElements = Path.GetFullPath(ProjectFileName).Split('\\');
									int NrElements = PathElements.GetLength(0);
									SrcPathElements = new string[NrElements - 3];
									for (int i = 0; i < NrElements -3; i++)
										SrcPathElements[i] = PathElements[i + 1]; // avoid volume label

									ReducedInsertElements = new string[InsertElements.GetLength(0) - NrLevelsDown];
									for (int i = NrLevelsDown; i < InsertElements.GetLength(0); i++)
										ReducedInsertElements[i - NrLevelsDown] = InsertElements[i];

									InsertFileName = Path.Combine(ReducedInsertElements);

								}

								else //if (Substitute_FileStr == true)
								{
									PathElements = Path.GetFullPath(ProjectFileName).Split('\\');
									int NrElements = PathElements.GetLength(0);
									SrcPathElements = new string[NrElements - NrLevelsDown - 2];
									for (int i = 0; i < NrElements - NrLevelsDown - 2; i++)
										SrcPathElements[i] = PathElements[i + 1]; // avoid volume label

									ReducedInsertElements = new string[InsertElements.GetLength(0) - NrLevelsDown];
									for (int i = NrLevelsDown; i < InsertElements.GetLength(0); i++)
										ReducedInsertElements[i - NrLevelsDown] = InsertElements[i];

									SrcPathStr = Path.Combine(SrcPathElements);
									InsertPathStr = Path.Combine(ReducedInsertElements);
									InsertFileName = Path.Combine(SrcPathStr, InsertPathStr);
									InsertFileName = Path.Combine(Path.GetPathRoot(ProjectFileName), InsertFileName);
								}
								//else
								//  InsertFileName = InsertPath[1];

								StreamReader InsertSr = new StreamReader(InsertFileName);
								while ((InsertLineStr = InsertSr.ReadLine()) != null)
								{
									if (chkDebug.Checked != true)
									{
										if (InsertLineStr.StartsWith("//#ifdef DEBUG"))
										{
											DoNotWrite = 1;
										}
										else if (InsertLineStr.StartsWith("//#endif"))
										{
											DoNotWrite = 2;
										}
										if (DoNotWrite == 0)
											SwDestSrc.WriteLine(InsertLineStr);
										if (DoNotWrite == 2) DoNotWrite = 0;
									}
									else
									{
										if (!(InsertLineStr.StartsWith("//#ifdef DEBUG") || (InsertLineStr.StartsWith("//#endif"))))
											SwDestSrc.WriteLine(InsertLineStr);
									}
								}
							}
							else
								SwDestSrc.WriteLine(LineStr);
						}
						SwDestSrc.Close();
						lblSource.Text = Path.GetFileName(SourceFileName);
					}
					SrProject.Close();
				}
			}
			
			catch (Exception Excp)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(Excp.Message);
			}
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			ofdProject.Title = "Specify Squirrel Project File";
			ofdProject.Filter = "Squirrel Project Files (*.pnut)|*.pnut";
			ofdProject.FilterIndex = 1;
			if (ofdProject.ShowDialog() != DialogResult.Cancel)
			{
				ProjectFileName = ofdProject.FileName;
				SourceFileName = Path.ChangeExtension(ProjectFileName, "nut");
				lblPath.Text = Path.GetDirectoryName(ProjectFileName);
				lblProject.Text = Path.GetFileName(ProjectFileName);
				lblSource.Text = Path.GetFileName(SourceFileName);

				btnBuild.Enabled = true;
			}
			else
				MessageBox.Show("No file selected");
		}

		private void frmGUI_Load(object sender, EventArgs e)
		{
			//btnBuild.Enabled = false;
		}

		private void btnOpenSrc_Click(object sender, EventArgs e)
		{
			Process p = new Process();
			p.StartInfo.FileName = "notepad++.exe";
			p.StartInfo.Arguments = ProjectFileName + " " + SourceFileName;
			p.Start();
		}
	}
}
