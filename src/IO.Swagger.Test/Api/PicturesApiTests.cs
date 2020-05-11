/* 
 * DDStore API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing PicturesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class PicturesApiTests
    {
        private PicturesApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new PicturesApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of PicturesApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' PicturesApi
            //Assert.IsInstanceOfType(typeof(PicturesApi), instance, "instance is a PicturesApi");
        }

        
        /// <summary>
        /// Test GetPictureByRef
        /// </summary>
        [Test]
        public void GetPictureByRefTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string picref = null;
            //var response = instance.GetPictureByRef(picref);
            //Assert.IsInstanceOf<System.IO.Stream> (response, "response is System.IO.Stream");
        }
        
        /// <summary>
        /// Test GetThumb
        /// </summary>
        [Test]
        public void GetThumbTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string picref = null;
            //var response = instance.GetThumb(picref);
            //Assert.IsInstanceOf<System.IO.Stream> (response, "response is System.IO.Stream");
        }
        
    }

}
