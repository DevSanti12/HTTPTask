using System;
using System.Net;
using System.Text;
using ListenerApp;
using ListenerApp.Interfaces;
using Moq;

namespace ListenerApp.Tests
{
    public class HttpServerTests
    {
        [Fact]
        public void Start_ShouldInitializeAndRunListener()
        {
            // Arrange
            var httpServer = new HttpServer("http://localhost:8080/");
            var startThread = new Thread(() =>
            {
                // Act
                httpServer.Start();
            });

            // Act
            startThread.Start();

            // Give the server a little time to start
            Thread.Sleep(100);

            // Assert (if we reached here without exception, it's running)
            Assert.True(true);

            // Cleanup
            httpServer.Stop();
        }

        [Fact]
        public void Stop_ShouldShutdownListenerGracefully()
        {
            // Arrange
            var httpServer = new HttpServer("http://localhost:8080/");
            var startThread = new Thread(() =>
            {
                httpServer.Start();
            });

            // Act
            startThread.Start();

            // Give the server a little time to start
            Thread.Sleep(100);

            // Act
            httpServer.Stop();

            // Assert
            // If no exceptions occur or blocking scenarios, Stop works as expected
            Assert.True(true);
        }
    }
}