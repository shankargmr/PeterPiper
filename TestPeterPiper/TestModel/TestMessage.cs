﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PeterPiper.Hl7.V2.Model;
using PeterPiper.Hl7.V2.Support;
using NUnit.Framework;

namespace TestHl7V2
{
  [TestFixture]
  public class TestMessage
  {
    public System.Text.StringBuilder oMsg;
    public string sMSH;

    [SetUp]
    public void MyTestInitialize()
    {
      sMSH = "MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01|0000000000000000010D|P|2.3.1|||||||en";

      oMsg = new System.Text.StringBuilder();
      oMsg.Append("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1^AUS&&ISO^AS4700.2&&L|||||||en"); oMsg.Append("\r");
      oMsg.Append("PID|1|PA30000004|PA3000\\R\\0004^^^^MR~22222221111^^^AUSHIC^MC||QHMILLAR^AM201405191155||19730930|M||9^Not Stated|16 ULVA STREET^^BALD HILLS (4036)^^4036||0893412041||||||22222221111"); oMsg.Append("\r");
      oMsg.Append("PV1|1|I|4BT\\R\\PAH&4B Transplant (PAH)&AUSLAB^^^PAH&Princess Alexandra Hospital&AUSLAB||||BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital||BONR\\R\\PAH^Bond, Robert (PAH)^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~0362233F^^^^^^^^AUSHIC^^^^PRN|MED1\\R\\PAH^Medical 1 (PAH)|||||||||PA2711|G P Eligible|GPE|||||||||||||||||||||||201405191211"); oMsg.Append("\r");
      oMsg.Append("ORC|RE|141470000018|1202^AUSLAB||IP||^^^20140527|||||BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital"); oMsg.Append("\r");
      oMsg.Append("OBR|1|141470000018|1202^AUSLAB|URINE^Urine M/C/S^AUSLAB||20140527|201405270900|||4BT\\R\\PAH^4B Transplant (PAH)^^^^^^^AUSLAB^^^^CWARD^PAH&Princess Alexandra Hospital~PAH^Princess Alexandra Hospital^^^^^^^AUSLAB^^^^CCENT^PAH&Princess Alexandra Hospital||||201405270901|URINE&Urine&AUSLAB|BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital||||||201405270956||MB|F||^^^20140527"); oMsg.Append("\r");
      oMsg.Append("OBX|1|CE|MSTAT^Micro Report Status^AUSLAB||COM^COMPLETE^AUSLAB|||H|||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|2|CE|UCENT^Urine Centrifuged^AUSLAB||CENT^Centrifuged^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|3|CE|UCRY3^Urine Crystals 3^AUSLAB||UNID^Unidentified ^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|4|CE|UCRY2^Urine Crystals 2^AUSLAB||UNID^Unidentified ^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|5|CE|UCRY1^Urine Crystals 1^AUSLAB||NCRYS^No Crystals Seen^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|6|NM|UWBCC^Urine WBC Casts^AUSLAB||0|/lpf|||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|7|NM|UHYC^Urine Hyaline Casts^AUSLAB||0|/lpf|||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|8|NM|UGRANC^Urine Granular Casts^AUSLAB||0|/lpf|||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|9|NM|URBCC^Urine RBC Casts^AUSLAB||0|/lpf|||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|10|CE|UEPI^Urine Micro Epi's^AUSLAB||G50^> 50^AUSLAB|x10\\S\\6/L|||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|11|NM|URBC^Urine Micro RBC^AUSLAB||<  10|x10\\S\\6/L|< 10|N|||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|12|ST|UWBC^Urine Micro WBC^AUSLAB||<  10|x10\\S\\6/L|< 10|N|||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|13|CE|CULT1^Culture Comment Line 1^AUSLAB||MSF^Mixed skin flora^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|14|TX|MICCOM^Comment ^AUSLAB||this is a ieMR test comment 1~this is a ieMR test commment 2||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|15|CE|UAMA^Ur Antimicrobial Activity^AUSLAB||ND^Not Detected^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|16|CE|ORG^Organism^AUSLAB|1|ESCCES^E. coli (ESBL Producer)^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|17|ST|QUANT^Quantifier^AUSLAB|1|2+||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBR|2|141470000018|1202^AUSLAB|SENS^Sensitivity Panel^AUSLAB||20140527|201405270900|||4BT\\R\\PAH^4B Transplant (PAH)^^^^^^^AUSLAB^^^^CWARD^PAH&Princess Alexandra Hospital~PAH^Princess Alexandra Hospital^^^^^^^AUSLAB^^^^CCENT^PAH&Princess Alexandra Hospital||||201405270901|URINE&Urine&AUSLAB|BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital||||||201405270954||MB|P||^^^20140527"); oMsg.Append("\r");
      oMsg.Append("OBX|1|TX|CULCOM^Culture Comment^AUSLAB||Sens ieMR test comment 1~Sens ieMR comment line 2||||||R|||201405270954|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
    }



    /// <summary>
    ///A test for Message Constructor
    ///</summary>
    [Test]
    public void MessageConstructorTest()
    {

      string StringRaw = oMsg.ToString();
      bool ParseMSHSegmentOnly = false;
      var target = Creator.Message(StringRaw, ParseMSHSegmentOnly);
      Assert.AreEqual(StringRaw, target.AsStringRaw, "A test for Message Constructor");

      ParseMSHSegmentOnly = true;
      target = Creator.Message(StringRaw, ParseMSHSegmentOnly);
      Assert.AreEqual(oMsg.ToString().Split('\r')[0] + '\r', target.AsStringRaw, "A test for Message Constructor");
      Assert.AreEqual("0000000000000000010D", target.MessageControlID, "A test for Message Constructor");
      Assert.AreEqual("ORU", target.MessageType, "A test for Message Constructor");
      Assert.AreEqual("R01", target.MessageTrigger, "A test for Message Constructor");
      Assert.AreEqual("ORU_R01", target.MessageStructure, "A test for Message Constructor");
      Assert.AreEqual("2.3.1", target.MessageVersion, "A test for Message Constructor");
      //Get the time zone for where we are running now
      TimeZone zone = TimeZone.CurrentTimeZone;
      TimeSpan TimeSpan = zone.GetUtcOffset(DateTime.Now);
      var date = new DateTimeOffset(2014, 05, 27, 9, 56, 57, TimeSpan);
      target.Segment("MSH").Field(7).AsString = PeterPiper.Hl7.V2.Support.Tools.DateTimeSupportTools.AsString(date, true, PeterPiper.Hl7.V2.Support.Tools.DateTimeSupportTools.DateTimePrecision.DateHourMinSecMilli);
      Assert.AreEqual(new DateTimeOffset(2014, 05, 27, 9, 56, 57, TimeSpan), target.MessageCreationDateTime, "A test for Message Constructor");      
      Assert.AreEqual(1, target.SegmentCount(), "A test for Message Constructor");
      Assert.AreEqual(true, target.IsParseMSHSegmentOnly, "A test for Message Constructor");
    }

    /// <summary>
    ///A test for Message Constructor
    ///</summary>
    [Test]
    public void MessageConstructorTest1()
    {
      string[] MsgList = oMsg.ToString().Split('\r');
      List<string> collection = new List<string>();
      foreach (var Line in MsgList)
      {
        collection.Add(Line);
      }
      bool ParseMSHSegmentOnly = false;
      var target = Creator.Message(collection, ParseMSHSegmentOnly);
      Assert.AreEqual(oMsg.ToString(), target.AsStringRaw, "A test for Message Constructor 1");
      Assert.AreEqual(24, target.SegmentCount(), "A test for Message Constructor 1");
      Assert.AreEqual(false, target.IsParseMSHSegmentOnly, "A test for Message Constructor 1");
    }

    /// <summary>
    ///A test for Message Constructor
    ///</summary>
    [Test]
    public void MessageConstructorTest2()
    {
      string MessageVersion = "2.7";
      string MessageType = "ORU";
      string MessageTrigger = "R01";
      string MessageControlID = "1234567890";
      string MessageStructure = "ORU_R01";
      var target = Creator.Message(MessageVersion, MessageType, MessageTrigger, MessageControlID, MessageStructure);
      target.Segment(1).Field(7).ClearAll();
      Assert.AreEqual("MSH|^~\\&|||||||ORU^R01^ORU_R01|1234567890|P|2.7|||AL|NE\r", target.AsStringRaw, "A test for Message Constructor 1");
    }

    /// <summary>
    ///A test for Message Constructor
    ///</summary>
    [Test]
    public void MessageConstructorTest3()
    {
      var item = Creator.Segment("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1^AUS&&ISO^AS4700.2&&L|||||||en");
      var target = Creator.Message(item);      
      
      Assert.AreEqual(oMsg.ToString().Split('\r')[0] + '\r', target.AsStringRaw, "A test for Message Constructor");
      Assert.AreEqual("0000000000000000010D", target.MessageControlID, "A test for Message Constructor");
      Assert.AreEqual("ORU", target.MessageType, "A test for Message Constructor");
      Assert.AreEqual("R01", target.MessageTrigger, "A test for Message Constructor");
      Assert.AreEqual("ORU_R01", target.MessageStructure, "A test for Message Constructor");
      Assert.AreEqual("2.3.1", target.MessageVersion, "A test for Message Constructor");
      //Get the time zone for where we are running now
      TimeZone zone = TimeZone.CurrentTimeZone;
      TimeSpan TimeSpan = zone.GetUtcOffset(DateTime.Now);
      var date = new DateTimeOffset(2014,05,27,9,56,57,TimeSpan);
      target.Segment("MSH").Field(7).Convert.DateTime.SetDateTimeOffset(date);
      Assert.AreEqual(new DateTimeOffset(2014, 05, 27, 9, 56, 57, TimeSpan), target.MessageCreationDateTime, "A test for Message Constructor");
      Assert.AreEqual(1, target.SegmentCount(), "A test for Message Constructor");
      Assert.AreEqual(false, target.IsParseMSHSegmentOnly, "A test for Message Constructor");
    }

    /// <summary>
    ///A test for Add
    ///</summary>
    [Test]
    public void AddTest1()
    {
      var item = Creator.Segment("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1|||||||en");
      var target = Creator.Message(item);
      var item1 = Creator.Segment("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1|||||||en");
      try
      {
        target.Add(item1);
        Assert.Fail("An exception should have been thrown");
      }
      catch (PeterPiper.Hl7.V2.CustomException.PeterPiperArgumentException ae)
      {
        Assert.AreEqual("An MSH Segment can not be added to a Message instance, it must be provided on Message instance creation / instantiation", ae.Message, "Exception should have been thrown due to CustomDelimiters not matching");
      }

      item1 = Creator.Segment("OBX|1|TX|CULCOM^Culture Comment^AUSLAB||Sens ieMR test comment 1~Sens ieMR comment line 2||||||R|||201405270954|RB^PATH QLD Central^AUSLAB");
      target.Add(item1);
      Assert.AreEqual("Culture Comment", target.Segment(2).Field(3).Component(2).AsString, "A test for Add");
      Assert.AreEqual(2, target.SegmentCount(), "A test for Add");
    }

    /// <summary>
    ///A test for ClearAll
    ///</summary>
    [Test]
    public void ClearAllTest()
    {
      IMessage target;
      var itemOBX = Creator.Segment("OBX|1|TX|CULCOM^Culture Comment^AUSLAB||Sens ieMR test comment 1~Sens ieMR comment line 2||||||R|||201405270954|RB^PATH QLD Central^AUSLAB");
      try
      {
        target = Creator.Message(itemOBX);
        Assert.Fail("An exception should have been thrown");
      }
      catch (PeterPiper.Hl7.V2.CustomException.PeterPiperArgumentException ae)
      {
        Assert.AreEqual("The Segment instance passed in is not a MSH Segment, only a MSH Segment can be passed in on creation / instantiation of a Message", ae.Message, "Exception should have been thrown due to CustomDelimiters not matching");
      }
      var itemMSH = Creator.Segment("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1|||||||en");
      target = Creator.Message(itemMSH);
      target.ClearAll();
      Assert.AreEqual(2, target.Segment(1).ElementCount, "A test for ClearAll");
      Assert.AreEqual(2, target.Segment(1).FieldCount, "A test for ClearAll");
      Assert.AreEqual("MSH|^~\\&|", target.Segment(1).AsStringRaw, "A test for ClearAll");
      Assert.AreEqual("MSH|^~\\&|", target.Segment(1).AsString, "A test for ClearAll");

      target.Add(itemOBX);
      Assert.AreEqual(2, target.SegmentCount(), "A test for ClearAll");
      Assert.AreEqual("MSH", target.Segment(1).Code, "A test for ClearAll");
      Assert.AreEqual("OBX", target.Segment(2).Code, "A test for ClearAll");
      Assert.AreEqual(2, target.Segment(1).ElementCount, "A test for ClearAll");
      Assert.AreEqual(2, target.Segment(1).FieldCount, "A test for ClearAll");
      Assert.AreEqual("MSH|^~\\&|", target.Segment(1).AsStringRaw, "A test for ClearAll");
      Assert.AreEqual("MSH|^~\\&|", target.Segment(1).AsString, "A test for ClearAll");
      Assert.AreEqual("OBX|1|TX|CULCOM^Culture Comment^AUSLAB||Sens ieMR test comment 1~Sens ieMR comment line 2||||||R|||201405270954|RB^PATH QLD Central^AUSLAB", target.Segment(2).AsStringRaw, "A test for ClearAll");

    }

    /// <summary>
    ///A test for Clone
    ///</summary>
    [Test]
    public void CloneTest()
    {
      var target = Creator.Message(oMsg.ToString());
      var expected = Creator.Message(oMsg.ToString());      
      var actual = target.Clone();
      Assert.AreEqual(expected.AsStringRaw, actual.AsStringRaw, "A test for Clone");
    }

    /// <summary>
    ///A test for Insert
    ///</summary>
    [Test]
    public void InsertTest()
    {
      var target = Creator.Message(oMsg.ToString());
      int index = 2;
      var itemOBX = Creator.Segment("OBX|99|TX|CULCOM^Culture Comment^AUSLAB||Sens ieMR test comment 1~Sens ieMR comment line 2||||||R|||201405270954|RB^PATH QLD Central^AUSLAB");
      target.Insert(index, itemOBX);
      Assert.AreEqual("OBX|99|TX|CULCOM^Culture Comment^AUSLAB||Sens ieMR test comment 1~Sens ieMR comment line 2||||||R|||201405270954|RB^PATH QLD Central^AUSLAB", target.Segment(2).AsStringRaw, "A test for Insert");

      var itemMSH = Creator.Segment("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1|||||||en");
      try
      {
        target.Insert(index, itemMSH);
        Assert.Fail("An exception should have been thrown");
      }
      catch (PeterPiper.Hl7.V2.CustomException.PeterPiperArgumentException ae)
      {
        Assert.AreEqual("An MSH Segment can not be added to a Message instance, it must be provided on Message instance creation / instantiation", ae.Message, "Exception should have been thrown due to CustomDelimiters not matching");
      }
    }

    /// <summary>
    ///A test for RemoveSegmentAt
    ///</summary>
    [Test]
    public void RemoveSegmentAtTest()
    {
      var target = Creator.Message(oMsg.ToString());
      int SegCount = target.SegmentCount();
      int index = 10;
      bool actual;
      actual = target.RemoveSegmentAt(index);
      Assert.AreEqual(SegCount - 1, target.SegmentCount(), "A test for RemoveSegmentAt");
      Assert.AreEqual("4", target.Segment(9).Field(1).AsString, "A test for RemoveSegmentAt");
      Assert.AreEqual("6", target.Segment(10).Field(1).AsString, "A test for RemoveSegmentAt");
    }

    /// <summary>
    ///A test for Segment
    ///</summary>
    [Test]
    public void SegmentTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string Code = "OBX";
      var expected = Creator.Segment(Code);      
      var actual = target.Segment(Code);
      Assert.AreEqual("OBX|1|CE|MSTAT^Micro Report Status^AUSLAB||COM^COMPLETE^AUSLAB|||H|||F|||201405270956|RB^PATH QLD Central^AUSLAB", actual.AsStringRaw, "A test for Segment");
    }

    /// <summary>
    ///A test for Segment
    ///</summary>
    [Test]
    public void SegmentTest1()
    {
      var target = Creator.Message(oMsg.ToString());
      int index = 6; // TODO: Initialize to an appropriate value
      var expected = Creator.Segment("OBX|1|CE|MSTAT^Micro Report Status^AUSLAB||COM^COMPLETE^AUSLAB|||H|||F|||201405270956|RB^PATH QLD Central^AUSLAB");      
      var actual = target.Segment(index);
      Assert.AreEqual(expected.AsStringRaw, actual.AsStringRaw, "A test for Segment");
    }

    /// <summary>
    ///A test for SegmentList
    ///</summary>
    [Test]
    public void SegmentListTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string Code = "OBX";
      ReadOnlyCollection<ISegment> actual;
      actual = target.SegmentList(Code);
      Assert.AreEqual(18, actual.Count, "A test for SegmentList");
      Assert.AreEqual("OBX|5|CE|UCRY1^Urine Crystals 1^AUSLAB||NCRYS^No Crystals Seen^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB", actual[4].AsStringRaw, "A test for SegmentList");
    }

    /// <summary>
    ///A test for SegmentList
    ///</summary>
    [Test]
    public void SegmentListTest1()
    {
      var target = Creator.Message(oMsg.ToString());
      ReadOnlyCollection<ISegment> actual;
      actual = target.SegmentList();
      Assert.AreEqual(24, actual.Count, "A test for SegmentList");
      Assert.AreEqual("OBX|5|CE|UCRY1^Urine Crystals 1^AUSLAB||NCRYS^No Crystals Seen^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB", actual[9].AsStringRaw, "A test for SegmentList 2");
    }

    /// <summary>
    ///A test for ToString
    ///</summary>
    [Test]
    public void ToStringTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string expected = oMsg.ToString();
      string actual;
      actual = target.ToString();
      //Hard to test need to hand craft a message with no escapes?
      //Assert.AreEqual(expected, actual, "A test for ToString");


    }

    /// <summary>
    ///A test for AsString
    ///</summary>
    [Test]
    public void AsStringTest()
    {
      //Message target = Creator.Message(oMsg.ToString());
      //string expected = oMsg.ToString();
      //string actual;
      //target.AsString = expected;
      //actual = target.AsString;
      //Hard to test need to hand craft a message with no escapes?
      //Assert.AreEqual(expected, actual);

    }

    /// <summary>
    ///A test for AsStringRaw
    ///</summary>
    [Test]
    public void AsStringRawTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string expected = oMsg.ToString();
      string actual;
      target.AsStringRaw = expected;
      actual = target.AsStringRaw;
      Assert.AreEqual(expected, actual, "A test for AsStringRaw");
    }

    /// <summary>
    ///A test for EscapeSequence
    ///</summary>
    [Test]
    public void EscapeSequenceTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.EscapeSequence;
      Assert.AreEqual("^~\\&", actual, "A test for EscapeSequence");
    }

    /// <summary>
    ///A test for MainSeparator
    ///</summary>
    [Test]
    public void MainSeparatorTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.MainSeparator;
      Assert.AreEqual("|", actual, "A test for MainSeparator");
    }

    /// <summary>
    ///A test for MessageControlID
    ///</summary>
    [Test]
    public void MessageControlIDTest()
    {
      var target = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.MessageControlID;
      Assert.AreEqual("0000000000000000010D", actual, "A test for MessageControlID");
    }

    /// <summary>
    ///A test for MessageDelimiters
    ///</summary>
    [Test]
    public void MessageDelimitersTest()
    {
      var target = Creator.Message(oMsg.ToString());
      var expected = Creator.MessageDelimiters('|', '~', '^', '&', '\\');      
      var actual = target.MessageDelimiters;
      Assert.AreEqual(expected.Field, actual.Field, " test for MessageDelimiters");
      Assert.AreEqual(expected.Repeat, actual.Repeat, "test for MessageDelimiters");
      Assert.AreEqual(expected.Component, actual.Component, " test for MessageDelimiters");
      Assert.AreEqual(expected.SubComponent, actual.SubComponent, " test for MessageDelimiters");
      Assert.AreEqual(expected.Escape, actual.Escape, " test for MessageDelimiters");
    }

    /// <summary>
    ///A test for MessageStructure
    ///</summary>
    [Test]
    public void MessageStructureTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.MessageStructure;
      Assert.AreEqual("ORU_R01", actual, "A test for MessageStructure");
    }

    /// <summary>
    ///A test for MessageTrigger
    ///</summary>
    [Test]
    public void MessageTriggerTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.MessageTrigger;
      Assert.AreEqual("R01", actual, "A test for MessageTrigger");
    }

    /// <summary>
    ///A test for MessageType
    ///</summary>
    [Test]
    public void MessageTypeTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.MessageType;
      Assert.AreEqual("ORU", actual, "A test for MessageType");
    }

    /// <summary>
    ///A test for MessageVersion
    ///</summary>
    [Test]
    public void MessageVersionTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      string actual;
      actual = target.MessageVersion;
      Assert.AreEqual("2.3.1", actual, "A test for MessageVersion");
    }

    /// <summary>
    ///A test for SegmentCount
    ///</summary>
    [Test]
    public void SegmentCountTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      int actual;
      actual = target.SegmentCount();
      Assert.AreEqual(24, actual, "A test for SegmentCount");

    }

    /// <summary>
    ///A test for PathInformation
    ///</summary>
    [Test]
    public void PathInformationTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      
      var actual = target.PathDetail;

      Assert.AreEqual("ORU", actual.MessageType, "A test for MessageEvent");
      Assert.AreEqual("R01", actual.MessageEvent, "A test for MessageEvent");

      Assert.AreEqual("<unk>-?", actual.PathBrief, "A test for MessageEvent");
      Assert.AreEqual("", actual.PathVerbos, "A test for MessageEvent");

    }

    [Test]
    public void MessageSchemaTest()
    {
      var target  = Creator.Message(oMsg.ToString());
      PeterPiper.Hl7.V2.Schema.Support.SchemaSupport oSchemaSupport = new PeterPiper.Hl7.V2.Schema.Support.SchemaSupport();
      oSchemaSupport.LoadSchema(target);
      target.Segment("MSH").Field(9).Component(1).AsString = "ORM";
      target.Segment("MSH").Field(9).Component(2).AsString = "O01";
      oSchemaSupport.LoadSchema(target);
      target.Segment("MSH").Field(12).AsString = "2.4";
      oSchemaSupport.LoadSchema(target);
    }

  }
}
