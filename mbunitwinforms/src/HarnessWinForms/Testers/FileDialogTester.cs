#region Copyright (c) 2006-2007, Luke T. Maxon (Authored by Anders Lillrank)

/********************************************************************************************************************
'
' Copyright (c) 2006-2007, Luke T. Maxon
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

using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MbUnitWinForms.Exceptions;

namespace MbUnitWinForms
{
    ///<summary>
    /// A form tester for the <see cref="FileDialog"/>.
    /// Use OpenFileDialogTester or SaveFileDialogTester
    ///</summary>
    public class FileDialogTester
    {
        #region Private/Protected attributes.

        /// <summary>
        /// Control ID for the Cancel button.
        /// </summary>
        protected const int CancelButton = 2;

        /// <summary>
        /// Control ID for the file name checkbox.
        /// </summary>
        protected const int FileNameCheckBox = 1148;

        /// <summary>
        /// Control ID for the Open or Save button.
        /// </summary>
        protected const int OpenButton = 1;

        /// <summary>
        /// The filename to use when simulate an open file operation
        /// </summary>
        protected string fileName = "";


        protected IntPtr handle = new IntPtr(0);

        /// <summary>
        /// Name/title of the OpenFileDialog 
        /// </summary>
        protected string name = "Open";

        protected IntPtr wParam;

        #endregion

        /// <summary>
        /// Default constructor...
        /// </summary>
        protected FileDialogTester(string title)
        {
            name = title;
        }

/*
    public void OpenSaveFile(string file)
    {
      _fileName = file;
      System.Threading.Thread thr = new System.Threading.Thread(new System.Threading.ThreadStart(OpenFileNameHandler));
      thr.Start();
    }
    */

        /// <summary>
        /// This handler will be called when the OpenFileDialog is shown and the 
        /// user have choose to open a file.
        /// </summary>
        protected void FileNameHandler()
        {
            SetFileName(fileName);
        }

        /// <summary>
        /// Simulates a click on Cancel.
        /// For some reason we need to spawn a new thread because the FileDialog Caption
        /// will not change to correct name if we just posts the message.
        /// If we Calls the ClickCancelHandler directly we need to set the title
        /// of the FileDialog to "Open". (Strange)
        /// </summary>
        public virtual void ClickCancel()
        {
            Thread thr = new Thread(ClickCancelHandler);
            thr.Start();
        }

        /// <summary>
        /// Clicks the cancel button of a OpenFiledialog.
        /// </summary>
        public void ClickCancelHandler()
        {
            IntPtr box = FindFileDialog();
            IntPtr cancel_btn = Win32.GetDlgItem(box, CancelButton);
            Win32.PostMessage(cancel_btn, Win32.BM_CLICK, (IntPtr) 0, IntPtr.Zero);
        }

        /// <summary>
        /// Click the first button, usually "Open" or "Save".
        /// </summary>
        protected void ClickOpenSaveButton()
        {
            IntPtr box = FindFileDialog();
            IntPtr open_btn = Win32.GetDlgItem(box, OpenButton);
            Win32.PostMessage(open_btn, Win32.BM_CLICK, (IntPtr) 0, IntPtr.Zero);
        }

        /// <summary>
        /// Sets the filename in the filename ComboBox and presses the OpenSave button.
        /// </summary>
        /// <param name="file_name"></param>
        protected void SetFileName(string file_name)
        {
            IntPtr box = FindFileDialog();
            StringBuilder setFileName = new StringBuilder(file_name.Length);

            int timeout = 1000000;

            while (!Win32.IsWindowVisible(box) || timeout == 0)
            {
                --timeout;
            }

            while (setFileName.ToString() != file_name)
            {
                Win32.SetDlgItemText(box, FileNameCheckBox, file_name);
                Win32.GetDlgItemText(box, FileNameCheckBox, setFileName, file_name.Length + 1);
            }

            IntPtr open_btn = Win32.GetDlgItem(box, OpenButton);
            Win32.PostMessage(open_btn, Win32.BM_CLICK, (IntPtr) 0, IntPtr.Zero);
        }


        /// <summary>
        /// Finds the OpenFileDialog.
        /// </summary>
        /// <returns></returns>
        protected IntPtr FindFileDialog()
        {
            if (handle != new IntPtr(0))
            {
                return handle;
            }

            lock (this)
            {
                IntPtr desktop = Win32.GetDesktopWindow();
                Win32.EnumChildWindows(desktop, OnEnumWindow, IntPtr.Zero);
                if (wParam == IntPtr.Zero)
                {
                    throw new ControlNotVisibleException("Open File Dialog is not visible");
                }
                return wParam;
            }
        }

        private int OnEnumWindow(IntPtr hwnd, IntPtr lParam)
        {
            if (WindowHandle.IsDialog(hwnd))
            {
                if (name == null || WindowHandle.GetCaption(hwnd) == name)
                {
                    wParam = hwnd;
                }
            }
            return 1;
        }
    }
}