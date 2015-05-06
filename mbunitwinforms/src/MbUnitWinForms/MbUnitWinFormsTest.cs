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

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using MbUnit.Framework;
using MbUnitWinForms.Exceptions;
using MbUnitWinForms.Finders;
using MbUnitWinForms.SendKey;
using MbUnitWinForms.Win32Interop;

namespace MbUnitWinForms
{
    /// <summary>
    /// One of the base classes for your MbUnitWinForms tests.  This one can be
    /// used by people who do not need or want "built-in" Assert functionality.
    ///
    /// This is the recommended base class for all unit tests that use MbUnitWinForms.  
    /// </summary>
    /// <remarks>
    /// You should probably extend this class to create all of your test fixtures.  The benefit is that
    /// this class implements setup and teardown methods that clean up after your test.  Any forms that
    /// are created and displayed during your test are cleaned up by the tear down method.  This base
    /// class also provides easy access to keyboard and mouse controllers.  It has a method that allows
    /// you to set up a handler for modal dialog boxes.  It allows your tests to run on a separate 
    /// (usually hidden) desktop so that they are faster and do not interfere with your normal desktop
    /// activity.  If you want custom setup and teardown behavior, you should override the virtual 
    /// Setup and TearDown methods.  Do not use the setup and teardown attributes in your child class.
    /// </remarks>
    public class MbUnitWinFormsTest : HarnessWinFormsTest
    {
        /// <summary>
        /// This is the base classes setup method.  It will be called by MbUnit before each test.
        /// You should not have anything to do with it.
        /// </summary>
        [SetUp]
        public void MbUnitWinFormsInit()
        {
            base.HarnessInit();

        }

        /// <summary>
        /// This method is called by MbUnit after each test runs.  If you have custom
        /// behavior to run after each test, then override the TearDown method and do
        /// it there.  That method is called at the beginning of this one.
        /// You should not need to do anything with it.  Do not call it.
        /// If you do call it, call it as the last thing you do in your test.
        /// </summary>
        [TearDown]
        public void MbUnitWinFormsVerify()
        {
            base.HarnessVerify();

        }
    }
}