using Basket.Framework.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;

namespace Basket.Api.Framework.Tests
{
    [TestClass]
    public class ApiResponseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotFound_EmptyMessage_ThrowsException()
        {
            //// Arrange
            //// Act
            var errorResponse = (ObjectResult)ApiResponse.NotFound("");
        }

        [TestMethod]
        public void NotFound_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.NotFound(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        [TestMethod]
        public void BadRequest_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.BadRequest(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        [TestMethod]
        public void Forbidden_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.Forbidden(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.Forbidden, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        [TestMethod]
        public void NoContent_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.NoContent(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.NoContent, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        [TestMethod]
        public void Unauthorized_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.Unauthorized(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.Unauthorized, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        [TestMethod]
        public void Conflict_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.Conflict(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.Conflict, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        [TestMethod]
        public void InternalServerError_Valid_ResponseWithCodeAndMessage()
        {
            //// Arrange
            var metadata = new Dictionary<string, object>
            {
                { "Key1", new TestMetadata{ Prop1 = 1, Prop2 = "PropValue2" } },
                { "Key2", "Value2" }
            };

            var sampleException = new InvalidOperationException("TestException");

            //// Act
            var errorResponse = (ObjectResult)ApiResponse.InternalServerError(
                "Test",
                "TestDescription",
                metadata,
                sampleException);

            var errorDetail = errorResponse.Value as ErrorDetail;

            //// Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, errorDetail.StatusCode);
            Assert.AreEqual("Test", errorDetail.Message);
            Assert.AreEqual("TestDescription", errorDetail.Description);
            Assert.AreEqual(1, (errorDetail.Metadata["Key1"] as TestMetadata).Prop1);
            Assert.AreEqual("PropValue2", (errorDetail.Metadata["Key1"] as TestMetadata).Prop2);
            Assert.AreEqual("Value2", errorDetail.Metadata["Key2"].ToString());
            Assert.AreEqual("TestException", errorDetail.Exception.Message);
        }

        private class TestMetadata
        {
            public int Prop1 { get; set; }
            public string Prop2 { get; set; }
        }
    }
}
