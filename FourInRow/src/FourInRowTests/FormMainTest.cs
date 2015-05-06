#region Copyright (c) 2003-2004, Niklas Dahlman, dahlman-group.com
/************************************************************************************
'
' Copyright © 2003-2004 Niklas Dahlman
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright © 2004 Niklas Dahlman
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using NUnit.Framework;

using NUnit.Extensions.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for FormFourInRowTable.
	/// </summary>
	public class FormMainTest : NUnitFormTest
	{
		

	


		[TestFixtureSetUp] public void Init()
		{
		//	Application.EnableVisualStyles();
		
			FormFourInRowTable oForm;
			oForm = new FormFourInRowTable();
			oForm.Show();
			
		}

		[Test]
		public void ButtonLabelShouldBeValue()
		{
			ButtonTester button = new ButtonTester("btnNewGame");
			Assert.AreEqual("&New Game [7:6:4]", button.Text);
		}

		[Test]
		public void ButtonNewGameClick()
		{
			ButtonTester button = new ButtonTester("btnNewGame");
			button.Click();

			CheckBoxTester cb1 = new CheckBoxTester("cbComputer1");
			cb1.Check();

			CheckBoxTester cb2 = new CheckBoxTester("cbComputer2");
			cb2.Check();

			MessageBox.Show("wait");

		}

	}
}
