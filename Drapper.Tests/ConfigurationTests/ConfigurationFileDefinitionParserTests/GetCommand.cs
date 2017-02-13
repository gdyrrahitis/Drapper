﻿// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2015.12.23
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// =============================================================================================================================
using Drapper.Configuration.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using Drapper.Tests.ConfigurationTests.Fully.Qualified.NamespaceA.With.Many.Different.Parts;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Drapper.Tests.ConfigurationTests.ConfigurationFileDefinitionParserTests
{
    [TestClass]
    public class GetCommand
    {
        [TestMethod]
        public void FallsBackToNamespaceForTypeSettings()
        {
            //var settings = GetFromFile();
            var parser = new ConfigurationFileCommandReader();
            var result = parser.GetCommand(typeof(TypeA), "FallsBackToNamespace");
            

            IsNotNull(result);
            AreEqual("select 'TypeA';", result.CommandText);
        }


        [TestMethod]
        public void Successfully()
        {
            var parser = new ConfigurationFileCommandReader();
            var result = parser.GetCommand(typeof(GetCommand), "ExplicitKey");

            // assert values 
            AreEqual("select @Id [Result]", result.CommandText);
            AreEqual("TestId", result.Split);
            AreEqual(IsolationLevel.ReadCommitted, result.IsolationLevel);
             
            IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullTypeArgumentThrowsArgumentException()
        {
            var parser = new ConfigurationFileCommandReader();
            var result = parser.GetCommand(null, "ExplicitKey");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnknownTypeThrowsArgumentException()
        {
            var parser = new ConfigurationFileCommandReader();
            var result = parser.GetCommand(typeof(ConfigurationFileCommandReader), "ExplicitKey");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullKeyArgumentThrowsArgumentException()
        {
            var parser = new ConfigurationFileCommandReader();
            var result = parser.GetCommand(typeof(GetCommand), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnknownKeyThrowsArgumentException()
        {
            var parser = new ConfigurationFileCommandReader();
            var result = parser.GetCommand(typeof(GetCommand), "Unknown");
        }
    }
}
