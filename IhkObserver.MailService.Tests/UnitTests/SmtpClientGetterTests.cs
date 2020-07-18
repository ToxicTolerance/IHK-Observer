//using IhkObserver.MailService.Classes;
//using IhkObserver.MailService.Exceptions;
//using IhkObserver.MailService.Interfaces;
//using MailKit.Net.Smtp;
//using MailKit.Security;
//using Moq;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace IhkObserver.MailService.Tests.UnitTests
//{
//    public class SmtpClientGetterTests
//    {
//        [Fact]
//        public async Task InitializeSmtpClientAsync_ConfigUnreadableException()
//        {
//            ConfigUnreadableException originalEx = new ConfigUnreadableException();
//            MockStorage storage = new MockStorage();
//            storage.ConfigReaderMock.Setup(a => a.ReadAsync()).ThrowsAsync(originalEx);

//            ConfigUnreadableException ex = await Assert.ThrowsAsync<ConfigUnreadableException>(async () =>
//                await storage.Create().InitializeSmtpClientAsync());

//            Assert.Same(originalEx, ex);
//        }

//        [Fact]
//        public async Task InitializeSmtpClientAsync_ConfigUnparsableException()
//        {
//            ConfigUnparsableException originalEx = new ConfigUnparsableException();
//            MockStorage storage = new MockStorage();
//            storage.ConfigReaderMock.Setup(a => a.ReadAsync()).ThrowsAsync(originalEx);

//            ConfigUnparsableException ex = await Assert.ThrowsAsync<ConfigUnparsableException>(async () =>
//                await storage.Create().InitializeSmtpClientAsync());

//            Assert.Same(originalEx, ex);
//        }

//        [Fact]
//        public async Task InitializeSmtpClientAsync_ConnectFailed()
//        {
//            MockStorage storage = new MockStorage();

//            Task<ISmtpConfig> getConfigTask = new Task<ISmtpConfig>(() => storage.ConfigMock.Object);
//            getConfigTask.Start();
//            storage.ConfigReaderMock.Setup(a => a.ReadAsync()).Returns(getConfigTask);

//            Exception originalEx = new Exception();
//            storage.SmtpClientMock.Setup(a =>
//                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()))
//                .ThrowsAsync(originalEx);

//            SmtpNotConnectedException ex =
//                await Assert.ThrowsAsync<SmtpNotConnectedException>(async () =>
//                    await storage.Create().InitializeSmtpClientAsync());
//            Assert.Same(originalEx, ex.InnerException);

//            storage.SmtpClientMock.Verify(a =>
//                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.VerifyNoOtherCalls();
//        }

//        [Fact]
//        public async Task InitializeSmtpClientAsync_AuthenticateFailed()
//        {
//            MockStorage storage = new MockStorage();

//            Task<ISmtpConfig> getConfigTask = new Task<ISmtpConfig>(() => storage.ConfigMock.Object);
//            getConfigTask.Start();
//            storage.ConfigReaderMock.Setup(a => a.ReadAsync()).Returns(getConfigTask);

//            Exception originalEx = new Exception();
//            storage.SmtpClientMock.Setup(a =>
//                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
//                .ThrowsAsync(originalEx);

//            SmtpNotAuthenticatedException ex =
//                await Assert.ThrowsAsync<SmtpNotAuthenticatedException>(async () =>
//                    await storage.Create().InitializeSmtpClientAsync());
//            Assert.Same(originalEx, ex.InnerException);

//            storage.SmtpClientMock.Verify(a =>
//                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.Verify(a =>
//                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.VerifyNoOtherCalls();
//        }

//        [Fact]
//        public async Task InitializeSmtpClientAsync_Successful()
//        {
//            MockStorage storage = new MockStorage();
//            Task<ISmtpConfig> getConfigTask = new Task<ISmtpConfig>(() => storage.ConfigMock.Object);
//            getConfigTask.Start();
//            storage.ConfigReaderMock.Setup(a => a.ReadAsync()).Returns(getConfigTask);

//            SmtpClientGetter getter = storage.Create();
//            await getter.InitializeSmtpClientAsync();

//            Assert.Same(getter.Smtp, storage.SmtpClientMock.Object);

//            storage.SmtpClientMock.Verify(a =>
//                a.ConnectAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<SecureSocketOptions>(), It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.Verify(a =>
//                a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.VerifyNoOtherCalls();
//        }

//        [Fact]
//        public async Task DisposeAsync_NotConnected()
//        {
//            MockStorage storage = new MockStorage();
//            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(false);

//            SmtpClientGetter smtpGetter = storage.Create();
//            Assert.NotNull(smtpGetter.Smtp);

//            await smtpGetter.DisposeAsync();
//            Assert.Null(smtpGetter.Smtp);

//            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
//            storage.SmtpClientMock.VerifyNoOtherCalls();
//        }

//        [Fact]
//        public async Task DisposeAsync_Connected_ConnectionDisposed()
//        {
//            MockStorage storage = new MockStorage();
//            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

//            storage.SmtpClientMock.Setup(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()))
//                .ThrowsAsync(new ObjectDisposedException(nameof(storage.SmtpClientMock.Object)));

//            SmtpClientGetter smtpGetter = storage.Create();
//            Assert.NotNull(smtpGetter.Smtp);

//            await smtpGetter.DisposeAsync();
//            Assert.Null(smtpGetter.Smtp);

//            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
//            storage.SmtpClientMock.Verify(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.VerifyNoOtherCalls();
//        }

//        [Fact]
//        public async Task DisposeAsync_Connected_Successful()
//        {
//            MockStorage storage = new MockStorage();
//            storage.SmtpClientMock.Setup(a => a.IsConnected).Returns(true);

//            SmtpClientGetter smtpGetter = storage.Create();
//            Assert.NotNull(smtpGetter.Smtp);

//            await smtpGetter.DisposeAsync();
//            Assert.Null(smtpGetter.Smtp);

//            storage.SmtpClientMock.VerifyGet(a => a.IsConnected, Times.Once);
//            storage.SmtpClientMock.Verify(a => a.DisconnectAsync(true, It.IsAny<CancellationToken>()), Times.Once);
//            storage.SmtpClientMock.VerifyNoOtherCalls();
//        }

//        private class MockStorage
//        {
//            public MockStorage()
//            {
//                SmtpClientMock = new Mock<ISmtpClient>();
//                ConfigReaderMock = new Mock<ISmtpConfigReader>();
//                ConfigMock = new Mock<ISmtpConfig>();
//            }

//            public SmtpClientGetter Create()
//            {
//                return new SmtpClientGetter(SmtpClientMock.Object, ConfigReaderMock.Object);
//            }

//            public void SetupConfigMock()
//            {
//                ConfigMock.SetupGet(a => a.Host).Returns("smtp.host.com");
//                ConfigMock.SetupGet(a => a.Port).Returns(-1337);
//                ConfigMock.SetupGet(a => a.User).Returns("user@example.com");
//                ConfigMock.SetupGet(a => a.SenderPassword).Returns("My super secret mega password!");
//            }

//            public Mock<ISmtpClient> SmtpClientMock { get; set; }
//            public Mock<ISmtpConfigReader> ConfigReaderMock { get; set; }
//            public Mock<ISmtpConfig> ConfigMock { get; set; }
//        }
//    }
//}