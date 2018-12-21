using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Model.Accounts;
using io.nem1.sdk.Model.Blockchain;
using io.nem1.sdk.Model.Mosaics;
using io.nem1.sdk.Model.Transactions;
using io.nem1.sdk.Model.Transactions.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace test.src.Model.Transactions
{
    [TestClass]
    public class SerializationTests
    {
        [DataTestMethod]
        [DataRow(NetworkType.Types.TEST_NET, 10, "nem:xem", 100UL, typeof(PlainMessage), "test")]
        [DataRow(NetworkType.Types.MAIN_NET, 99, "nem:xem", 256UL, typeof(PlainMessage), "testtesttest")]
        [DataRow(NetworkType.Types.MAIN_NET, 10, "tst:tst", 100UL, typeof(EmptyMessage), null)]
        public void ShouldSerializeDeserializeTransferTransaction(NetworkType.Types network, int deadline, string mosaicId, ulong amount, Type messageType, string message)
        {
            // Arrange

            var kp = Account.GenerateNewAccount(network);
            var tx = TransferTransaction.Create(
                network,
                new Deadline(deadline),
                kp.Address,
                new List<Mosaic> { Mosaic.CreateFromIdentifier(mosaicId, amount) },
                messageType
                    .GetMethod("Create", BindingFlags.Static | BindingFlags.Public)
                    .Invoke(null, !string.IsNullOrEmpty(message) ? new object[] { message } : null) as IMessage
            );

            // Act

            var json = tx.ToJson();
            var txFromJson = TransferTransaction.FromJson(json);

            // Assert

            Assert.AreEqual(tx.Address.Plain, txFromJson.Address.Plain);
            Assert.AreEqual(tx.Deadline.GetInstant(), txFromJson.Deadline.GetInstant());
            Assert.AreEqual(tx.Message.GetMessageType(), txFromJson.Message.GetMessageType());
            Assert.AreEqual(tx.Message.GetPayload().ToHexLower(), txFromJson.Message.GetPayload().ToHexLower());
            Assert.AreEqual(tx.Mosaics.Count, txFromJson.Mosaics.Count);
            Assert.AreEqual(tx.NetworkType, txFromJson.NetworkType);
            Assert.AreEqual(tx.TransactionType, txFromJson.TransactionType);
            Assert.AreEqual(tx.Version, txFromJson.Version);
        }

        [TestMethod]
        public void ShouldSerializeDeserializeSignedTransaction()
        {
            // Arrange
            var network = NetworkType.Types.MAIN_NET;
            var account1 = Account.GenerateNewAccount(network);
            var account2 = Account.GenerateNewAccount(network);
            var tx = TransferTransaction.Create(
                network,
                new Deadline(10),
                account2.Address,
                new List<Mosaic> { Xem.CreateAbsolute(100) },
                EmptyMessage.Create()
            );
            var signedTx = tx.SignWith(account1.KeyPair);

            // Act

            var json = signedTx.ToJson();
            var txFromJson = SignedTransaction.FromJson(json);

            // Assert

            Assert.AreEqual(signedTx.Hash, txFromJson.Hash);
            Assert.AreEqual(signedTx.Payload, txFromJson.Payload);
            Assert.AreEqual(signedTx.Signer, txFromJson.Signer);
            Assert.AreEqual(signedTx.TransactionPacket.ToString(), txFromJson.TransactionPacket.ToString());
            Assert.AreEqual(signedTx.TransactionType, txFromJson.TransactionType);
        }
    }
}