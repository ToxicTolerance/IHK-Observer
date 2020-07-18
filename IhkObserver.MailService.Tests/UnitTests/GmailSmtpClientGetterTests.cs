using IhkObserver.MailService.Classes;
using IhkObserver.MailService.Exceptions;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IhkObserver.MailService.Tests.UnitTests
{
    public class GmailSmtpClientGetterTests
    {
        [Fact]
        public async Task InitializeSmtpClient_ConnectFailed()
        {
            Exception originalEx = new Exception();

            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(originalEx);

            SmtpNotConnectedException ex =
                await Assert.ThrowsAsync<SmtpNotConnectedException>(async () =>
                    await storage.Create().InitializeSmtpClient());
            Assert.Same(originalEx, ex.InnerException);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task InitializeSmtpClient_AuthenticateFailed()
        {
            Exception originalEx = new Exception();

            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(originalEx);

            SmtpNotAuthenticatedException ex =
                await Assert.ThrowsAsync<SmtpNotAuthenticatedException>(async () =>
                    await storage.Create().InitializeSmtpClient());
            Assert.Same(originalEx, ex.InnerException);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.Verify(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task InitializeSmtpClient_Successful()
        {
            MockStorage storage = new MockStorage();
            GmailSmtpClientGetter getter = storage.Create();
            await getter.InitializeSmtpClient();

            Assert.Same(getter.Smtp, storage.SmtpClientMock.Object);

            storage.SmtpClientMock.Verify(a =>
                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.Verify(a =>
                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisposeAsync_NotConnected()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(false);

            GmailSmtpClientGetter smtpGetter = storage.Create();
            Assert.NotNull(smtpGetter.Smtp);

            await smtpGetter.DisposeAsync();
            Assert.Null(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisposeAsync_Connected_ConnectionDisposed()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

            storage.SmtpClientMock.Setup(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ObjectDisposedException(nameof(storage.SmtpClientMock.Object)));

            GmailSmtpClientGetter smtpGetter = storage.Create();
            Assert.NotNull(smtpGetter.Smtp);

            await smtpGetter.DisposeAsync();
            Assert.Null(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.Verify(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task DisposeAsync_Connected_Successful()
        {
            MockStorage storage = new MockStorage();
            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

            GmailSmtpClientGetter smtpGetter = storage.Create();
            Assert.NotNull(smtpGetter.Smtp);

            await smtpGetter.DisposeAsync();
            Assert.Null(smtpGetter.Smtp);

            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
            storage.SmtpClientMock.Verify(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()), Times.Once);
            storage.SmtpClientMock.VerifyNoOtherCalls();
        }

        private class MockStorage
        {
            public MockStorage()
            {
                SmtpClientMock = new Mock<ISmtpClient>();
            }

            public GmailSmtpClientGetter Create()
            {
                return new GmailSmtpClientGetter(SmtpClientMock.Object);
            }

            public Mock<ISmtpClient> SmtpClientMock { get; set; }
        }
    }
}