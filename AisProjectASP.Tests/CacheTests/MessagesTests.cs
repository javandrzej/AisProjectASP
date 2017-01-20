using AisProjectASP.Models;
using AisProjectASP.Utils;
using NUnit.Framework;
using System;
using System.Linq;

namespace AisProjectASP.Tests.CacheTests
{
    [TestFixture]
    public class MessagesTests
    {
        IMessagesManager helper = new MessagesManager();

        [SetUp]
        public void Init()
        {
            helper.CreateMessages();
        }

        [Test]
        public void CheckFirstMessagesSize()
        {
            //given
            //when
            var listOfMessages = helper.GetMessages();
            //then
            Assert.AreEqual(Message.START_MESSAGE_SIZE, helper.GetMessages().Count);
            helper.ClearMessages();
        }

        [Test]
        public void CheckAddingOneMessages()
        {
            //given
            //when
            helper.SaveMessage(new Message(Guid.NewGuid(), "someTitle", "somebody", DateTime.Now));
            //then
            Assert.AreEqual(Message.START_MESSAGE_SIZE + 1, helper.GetMessages().Count);
            helper.ClearMessages();
        }

        [Test]
        public void ShouldDeleteMessage()
        {
            //given
            var message = helper.GetMessages().Take(1).ToList().FirstOrDefault();
            //when
            helper.DeleteMessage(message.Id);
            //then
            Assert.AreEqual(Message.START_MESSAGE_SIZE - 1, helper.GetMessages().Count);
            helper.ClearMessages();
        }

        [Test]
        public void ShouldUpdateMessage()
        {
            //given
            var message = helper.GetMessages().Take(1).ToList().FirstOrDefault();
            string newTitle = "newTitle123";
            string someBody = "someBody123";
            Guid initialId = message.Id;
            //when
            helper.UpdateMessage(new Message(initialId, newTitle, someBody, DateTime.Now));
            Message msg = helper.GetMessages().FirstOrDefault(m => m.Id == initialId);
            //then
            Assert.AreEqual(newTitle, msg.Title);
            Assert.AreEqual(someBody, msg.Body);
            helper.ClearMessages();
        }
    }
}
