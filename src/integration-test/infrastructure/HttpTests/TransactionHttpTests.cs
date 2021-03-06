﻿//
// Copyright 2018 NEM
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest.infrastructure.HttpTests
{
    [TestClass]
    public class TransactionHttpTests
    {
        readonly string host = "http://" + Config.Domain + ":3000";

       // [TestMethod, Timeout(20000)]
       // public async Task GetTransaction()
       // {
       //     var expected = "72B4DC358676BFED48DA63AF13727377E55DB5072FC6150D4A101367E93A78FA";
       //    
       //     var a = await new TransactionHttp(host).GetTransaction("5AFB147D88336A00015C7E0A");
       //
       //     Assert.AreEqual(expected, a.TransactionInfo.Hash);
       // }
       //
       // [TestMethod, Timeout(20000)]
       // public async Task GetTransactions()
       // {
       //     var expected = "72B4DC358676BFED48DA63AF13727377E55DB5072FC6150D4A101367E93A78FA";
       //
       //     var a = await new TransactionHttp(host).GetTransactions(new TransactionIds { transactionIds = new[] { "5AFB147D88336A00015C7E0A" } });
       //    
       //     Assert.AreEqual(expected, a[0].TransactionInfo.Hash);
       // }
       //
       // [TestMethod, Timeout(20000)]
       // public async Task GetTransactionStatus()
       // {
       //     var expected = "72B4DC358676BFED48DA63AF13727377E55DB5072FC6150D4A101367E93A78FA";
       //
       //     var a = await new TransactionHttp(host).GetTransactionStatus("72B4DC358676BFED48DA63AF13727377E55DB5072FC6150D4A101367E93A78FA");
       //
       //     Assert.AreEqual(expected, a.Hash);
       // }
       //
       // [TestMethod, Timeout(20000)]
       // public async Task GetTransactionStatuses()
       // {
       //     var expected = "72B4DC358676BFED48DA63AF13727377E55DB5072FC6150D4A101367E93A78FA";
       //
       //     var a = await new TransactionHttp(host).GetTransactionStatuses(new TransactionHashes { hashes = new[] { "72B4DC358676BFED48DA63AF13727377E55DB5072FC6150D4A101367E93A78FA" } });
       //
       //     Assert.AreEqual(expected, a[0].Hash);
       // }

       // [TestMethod, Timeout(20000)]
       // public async Task Map()
       // {
       //     var transactionHttp = new TransactionHttp(host);
       //     transactionHttp.GetTransaction("")
       //            .Select(ar => ar.Transaction.)
       // }

       // [TestMethod, Timeout(20000)]
       // public async Task AnnounceTransaction(TransactionPayload payload)
       // {
       //
       // }
       //
       // [TestMethod, Timeout(20000)]
       // public async Task AnnoucnePartialTransaction(TransactionPayload payload)
       // {
       //
       // }
       //
       // [TestMethod, Timeout(20000)]
       // public async Task AnnoucneCosignatureTransaction(TransactionPayload payload)
       // {
       //
       // }
    }
}
