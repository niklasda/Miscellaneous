#region Copyright (c) 2003-2005, Luke T. Maxon

/********************************************************************************************************************
'
' Copyright (c) 2003-2005, Luke T. Maxon
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without modification, are permitted provided
' that the following conditions are met:
' 
' * Redistributions of source code must retain the above copyright notice, this list of conditions and the
' 	following disclaimer.
' 
' * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
' 	the following disclaimer in the documentation and/or other materials provided with the distribution.
' 
' * Neither the name of the author nor the names of its contributors may be used to endorse or 
' 	promote products derived from this software without specific prior written permission.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
' WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
' PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
' ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
' OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
' IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'*******************************************************************************************************************/

#endregion

using System.Windows.Forms;
using MbUnit.Framework;
using MbUnitWinForms.Exceptions;

namespace MbUnitWinForms.Tests
{
    [TestFixture]
    public class ModalDialogsTest : MbUnitWinFormsTest
    {
        public void MessageBoxOkHandler()
        {
            MessageBoxTester messageBox = new MessageBoxTester("caption");
            Assert.AreEqual("test string", messageBox.Text);
            Assert.AreEqual("caption", messageBox.Title);
            messageBox.ClickOk();
        }

        public void MessageBoxCancelHandler()
        {
            MessageBoxTester messageBox = new MessageBoxTester("caption");
            Assert.AreEqual("test string", messageBox.Text);
            Assert.AreEqual("caption", messageBox.Title);
            messageBox.ClickCancel();
        }

        public void SimpleOKHandler()
        {
            MessageBoxTester messageBox = new MessageBoxTester("JustOK");
            Assert.AreEqual("Just An OK Button", messageBox.Text);
            Assert.AreEqual("JustOK", messageBox.Title);
            messageBox.SendCommand(MessageBoxTester.Command.OK);
        }

        public void OKAndCancelHandler()
        {
            MessageBoxTester messageBox = new MessageBoxTester("OKAndCancel");
            messageBox.SendCommand(MessageBoxTester.Command.Cancel);
        }

        [Test]
        [ExpectedException(typeof (ControlNotVisibleException), Message = "Message Box not visible")]
        public void NoModalFound()
        {
            string text = new MessageBoxTester("NotFound").Text;
            Assert.Fail("Should not find: " + text);
        }

        [Test]
        public void TestMessageBoxCancel()
        {
            ExpectModal("caption", "MessageBoxCancelHandler");
            MessageBox.Show("test string", "caption", MessageBoxButtons.OKCancel);
        }

        [Test]
        public void TestMessageBoxOK()
        {
            ExpectModal("caption", "MessageBoxOkHandler");
            MessageBox.Show("test string", "caption");
        }

        [Test]
        public void TestOKCancelMessageBox()
        {
            ExpectModal("OKAndCancel", "OKAndCancelHandler");
            Assert.AreEqual(DialogResult.Cancel,
                            MessageBox.Show("Both OK and Cancel buttons", "OKAndCancel", MessageBoxButtons.OKCancel));
        }

        [Test]
        public void TestSimpleMessageBox()
        {
            ExpectModal("JustOK", "SimpleOKHandler");
            Assert.AreEqual(DialogResult.OK, MessageBox.Show("Just An OK Button", "JustOK", MessageBoxButtons.OK));
        }

        [Test]
        [ExpectedException(typeof (FormsTestAssertionException),
            Message = "expected 0 invocations of modal, but was invoked 1 times (Form Caption = blah)")]
        public void UnexpectedModalIsClosedAndFails()
        {
            MessageBox.Show("I didn't expect this!", "blah");
            MbUnitWinFormsVerify();
        }

        [Test]
        [ExpectedException(typeof (FormsTestAssertionException),
            Message = "expected 0 invocations of modal, but was invoked 1 times (Form Caption = Unnamed)")]
        public void UnexpectedModalIsClosedAndFailsNoTitle()
        {
            MessageBox.Show("I didn't expect this!"); // no title specified
            MbUnitWinFormsVerify();
        }

        [Test]
        [ExpectedException(typeof (FormsTestAssertionException),
            Message =
            "expected 0 invocations of modal, but was invoked 1 times (Form Caption = Error1)\r\nexpected 0 invocations of modal, but was invoked 1 times (Form Caption = Error2)\r\n"
            )]
        public void UnexpectedModalsEachReportErrors()
        {
            MessageBox.Show("I didn't expect this!", "Error1");
            MessageBox.Show("I didn't expect this!", "Error2");
            MbUnitWinFormsVerify();
        }

        [Test]
        [ExpectedException(typeof (FormsTestAssertionException),
            Message =
            "expected 0 invocations of modal, but was invoked 2 times (Form Caption = Error1)"
            )]
        public void UnexpectedModalWithSameTitleReportsErrorCount()
        {
            MessageBox.Show("I didn't expect this!", "Error1");
            MessageBox.Show("I didn't expect this!", "Error1");
            MbUnitWinFormsVerify();
        }
    }
}