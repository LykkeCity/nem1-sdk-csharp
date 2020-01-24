using System.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using io.nem1.sdk.Core.Crypto.Chaso.NaCl;
using io.nem1.sdk.Infrastructure.Mapping;
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

        [TestMethod]
        public void ShouldDeserializeTransactionWithoutMosaics()
        {
            var txJson = "{\"meta\":{\"innerHash\":{},\"id\":4615908,\"hash\":{\"data\":\"58e557bb0a429d0e91417e7ac542e08b1a77254449c917c73b270a34e64e6068\"},\"height\":2103441},\"transaction\":{\"timeStamp\":127315793,\"amount\":5000000,\"signature\":\"ed00652085f8b96b4f77c920656ac3d75822586028e7739889f3ed1e8701a23f5b0a683a8007047adcd5d8217ccdd6b1de8e53501edfa8514fe7779126d94606\",\"fee\":150000,\"recipient\":\"NAFSSJLNTIEI5ISMWKEY2BJFH5LAUSHP7JVQLWGT\",\"mosaics\":[],\"type\":257,\"deadline\":127398593,\"message\":{\"payload\":\"3462383335343365373632613462633762356232613833616232323237333565\",\"type\":1},\"version\":1744830466,\"signer\":\"ffb0f5cadcf0a1beda2f5a92d62d1655675a7b2b7141f51ab7d3bbf67d2c8f67\"}}";

            var tx = new TransactionMapping().Apply(txJson) as TransferTransaction;

            Assert.IsNotNull(tx);
            Assert.AreEqual((tx.Message as PlainMessage)?.GetStringPayload().Trim(), "4b83543e762a4bc7b5b2a83ab222735e");
            Assert.IsTrue(tx.Mosaics.Any());
            Assert.IsTrue(tx.Mosaics.Single().Amount == 5000000);
            Assert.IsTrue(tx.Mosaics.Single().MosaicName == "xem" && tx.Mosaics.Single().NamespaceName == "nem");
        }

        [TestMethod]
        public void ShouldDeserializeMultisigTransaction()
        {
            var txJson = "{\"meta\":{\"innerHash\":{\"data\":\"7dfa8689ffb75dec36ccdc066e8e45e275fbce7e30873b06918d87189701a950\"},\"id\":8025346,\"hash\":{\"data\":\"356c351c9b46f701f937b569c3e243f5b6d94f9e8ac3e0f87339bd27833b5e3a\"},\"height\":2511999},\"transaction\":{\"timeStamp\":152027035,\"signature\":\"65b3e03bc0a0f1a250292fa508ea806de96789977c1a9e9559f29e22e3f629d5b67e469d0688ba933862ee865c66ce9ec562e60cf51026eff216f07efe9adf05\",\"fee\":150000,\"type\":4100,\"deadline\":152113435,\"version\":1744830465,\"signatures\":[{\"timeStamp\":152027244,\"otherHash\":{\"data\":\"7dfa8689ffb75dec36ccdc066e8e45e275fbce7e30873b06918d87189701a950\"},\"otherAccount\":\"NA6DFWCPCTHRQN3KVLGF2OV23LOEMCJN4FSFUFJW\",\"signature\":\"3855232a6abb41fb2805aae32d8cb7736c602012073710755ee9e8067b939fe8dec5edc8241bcae78a9e44472b2f8dfd96558148eab627719052db9dc627be0a\",\"fee\":150000,\"type\":4098,\"deadline\":152048844,\"version\":1744830465,\"signer\":\"1d917dbdf339e92c7817b593e6c20109304797632f1bd3b0e08b279fa8617547\"}],\"signer\":\"791d204aa1a8ae6a06853e21ab54fbcc34abd454ad9fbb1303f5950ab8935e04\",\"otherTrans\":{\"timeStamp\":152027035,\"amount\":10000000000,\"fee\":150000,\"recipient\":\"NAFSSJLNTIEI5ISMWKEY2BJFH5LAUSHP7JVQLWGT\",\"type\":257,\"deadline\":152113435,\"message\":{\"payload\":\"3761393265376235323961633461313762623434356362613736363166633137\",\"type\":1},\"version\":1744830465,\"signer\":\"2401cd24fca5daacdd507cc51354efdf439fccbdd2a1cdc020ab08df70d294a7\"}}}";

            var tx = new TransactionMapping().Apply(txJson) as MultisigTransaction;
            var transfer = tx.InnerTransaction as TransferTransaction;

            Assert.IsNotNull(tx);
            Assert.IsNotNull(transfer);
            Assert.AreEqual((transfer.Message as PlainMessage)?.GetStringPayload().Trim(), "7a92e7b529ac4a17bb445cba7661fc17");
            Assert.IsTrue(transfer.Mosaics.Any());
            Assert.IsTrue(transfer.Mosaics.Single().Amount == 10000000000);
            Assert.IsTrue(transfer.Mosaics.Single().MosaicName == "xem" && transfer.Mosaics.Single().NamespaceName == "nem");
        }
    }
}