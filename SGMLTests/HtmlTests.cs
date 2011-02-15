/*
 * 
 * Copyright (c) 2007-2011 MindTouch. All rights reserved.
 * 
 */

using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace SGMLTests {

    [TestFixture]                    
    public class UnitTests {

        [Test]
        public void First() {
            Assert.Fail();
        }

        private string Read(string n) {
            var assembly = typeof(UnitTests).Assembly;
            var stream = assembly.GetManifestResourceStream(assembly.FullName.Split(',')[0] + "Resources." + n);
            using(var sr = new StreamReader(stream)) {
                return sr.ReadToEnd();
            }
        }
    }
}

