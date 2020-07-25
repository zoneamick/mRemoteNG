﻿using mRemoteNG.UI.Forms;
using NUnit.Framework;

namespace mRemoteNGTests.UI.Forms
{
    [TestFixture]
    public class PasswordFormTests
    {
        FrmPassword _passwordForm;

        [SetUp]
        public void Setup()
        {
            _passwordForm = new FrmPassword();
            _passwordForm.Show();
        }

        [TearDown]
        public void Teardown()
        {
            _passwordForm.Dispose();
            while (_passwordForm.Disposing)
            {
            }
            _passwordForm = null;
        }

        [Test]
		[SetUICulture("en-US")]
        public void PasswordFormText()
        {
            var formTester = new FormTester("PasswordForm");
            Assert.That(formTester.Text, Does.Match("mRemoteNG password"));
        }

        [Test]
        public void ClickingCancelClosesPasswordForm()
        {
            bool eventFired = false;
            _passwordForm.FormClosed += (o, e) => eventFired = true;
            ButtonTester cancelButton = new ButtonTester("btnCancel", _passwordForm);
            cancelButton.Click();
            Assert.That(eventFired, Is.True);
        }
    }
}