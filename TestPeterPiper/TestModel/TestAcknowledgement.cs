﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PeterPiper.Hl7.V2.Model;
using PeterPiper.Hl7.V2.Support.Standard;

namespace TestPeterPiper.TestModel
{
  [TestFixture]
  public class TestAcknowledgement
  {

    /// <summary>
    ///A test for Acknowledgement Constructor
    ///</summary>
    [Test]
    public void AcknowledgementConstructorTest()
    {
      Acknowledgement target = new Acknowledgement();
      Assert.AreEqual(true, target != null, "A test for Acknowledgement Constructor");
    }

    /// <summary>
    ///A test for GenerateAcknowledgementMessage
    ///</summary>
    [Test]
    public void GenerateAcknowledgementMessageTest()
    {
      System.Text.StringBuilder oMsg = new System.Text.StringBuilder();
      oMsg.Append("MSH|^~\\&|AUSLAB|TRAIN|EGATE-Atomic^prjAuslabIn|ieMR|20140527095657||ORU^R01^ORU_R01|0000000000000000010D|P|2.3.1|||||||en"); oMsg.Append("\r");
      oMsg.Append("PID|1|PA30000004|PA30000004^^^^MR~22222221111^^^AUSHIC^MC||QHMILLAR^AM201405191155||19730930|M||9^Not Stated|16 ULVA STREET^^BALD HILLS (4036)^^4036||0893412041||||||22222221111"); oMsg.Append("\r");
      oMsg.Append("PV1|1|I|4BT\\R\\PAH&4B Transplant (PAH)&AUSLAB^^^PAH&Princess Alexandra Hospital&AUSLAB||||BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital||BONR\\R\\PAH^Bond, Robert (PAH)^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~0362233F^^^^^^^^AUSHIC^^^^PRN|MED1\\R\\PAH^Medical 1 (PAH)|||||||||PA2711|G P Eligible|GPE|||||||||||||||||||||||201405191211"); oMsg.Append("\r");
      oMsg.Append("ORC|RE|141470000018|1202^AUSLAB||IP||^^^20140527|||||BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital"); oMsg.Append("\r");
      oMsg.Append("OBR|1|141470000018|1202^AUSLAB|URINE^Urine M/C/S^AUSLAB||20140527|201405270900|||4BT\\R\\PAH^4B Transplant (PAH)^^^^^^^AUSLAB^^^^CWARD^PAH&Princess Alexandra Hospital~PAH^Princess Alexandra Hospital^^^^^^^AUSLAB^^^^CCENT^PAH&Princess Alexandra Hospital||||201405270901|URINE&Urine&AUSLAB|BONR1\\R\\PAH^Robert Bond^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital~460?PAH^^^^^^^^AUSLAB^^^^DN^PAH&Princess Alexandra Hospital||||||201405270956||MB|F||^^^20140527"); oMsg.Append("\r");
      oMsg.Append("OBX|1|CE|MSTAT^Micro Report Status^AUSLAB||COM^COMPLETE^AUSLAB|||H|||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|2|CE|UCENT^Urine Centrifuged^AUSLAB||CENT^Centrifuged^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|3|CE|UCRY3^Urine Crystals 3^AUSLAB||UNID^Unidentified ^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");
      oMsg.Append("OBX|4|CE|UCRY2^Urine Crystals 2^AUSLAB||UNID^Unidentified ^AUSLAB||||||F|||201405270956|RB^PATH QLD Central^AUSLAB"); oMsg.Append("\r");

      System.Text.StringBuilder oAck = new System.Text.StringBuilder();
      oAck.Append("MSH|^~\\&|EGATE-Atomic^prjAuslabIn|ieMR|AUSLAB|TRAIN|20140527095657||ACK|0000000000000000010D|P|2.3.1"); oAck.Append("\r");
      oAck.Append("MSA|AA|0000000000000000010D|HL7 Acknowledgment"); oAck.Append("\r");

      Acknowledgement target = new Acknowledgement();
      var oReceivedMessage = Creator.Message(oMsg.ToString());
      var expected = Creator.Message(oAck.ToString());      
      var actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.ApplicationAccept);

      Assert.AreEqual(expected.Segment(1).Field(3).AsStringRaw, actual.Segment(1).Field(3).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(4).AsStringRaw, actual.Segment(1).Field(4).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(5).AsStringRaw, actual.Segment(1).Field(5).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(6).AsStringRaw, actual.Segment(1).Field(6).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(9).AsStringRaw, actual.Segment(1).Field(9).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(10).AsStringRaw, actual.Segment(1).Field(10).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(11).AsStringRaw, actual.Segment(1).Field(11).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(1).Field(12).AsStringRaw, actual.Segment(1).Field(12).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");
      Assert.AreEqual(expected.Segment(2).AsStringRaw, actual.Segment(2).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

      actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.ApplicationAccept);
      Assert.AreEqual(PeterPiper.Hl7.V2.Support.Standard.Hl7Table.Table_0008.ApplicationAccept, actual.Segment(2).Field(1).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

      actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.ApplicationError);
      Assert.AreEqual(PeterPiper.Hl7.V2.Support.Standard.Hl7Table.Table_0008.ApplicationError, actual.Segment(2).Field(1).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

      actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.ApplicationReject);
      Assert.AreEqual(PeterPiper.Hl7.V2.Support.Standard.Hl7Table.Table_0008.ApplicationReject, actual.Segment(2).Field(1).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

      actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.CommitAccept);
      Assert.AreEqual(PeterPiper.Hl7.V2.Support.Standard.Hl7Table.Table_0008.CommitAccept, actual.Segment(2).Field(1).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

      actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.CommitError);
      Assert.AreEqual(PeterPiper.Hl7.V2.Support.Standard.Hl7Table.Table_0008.CommitError, actual.Segment(2).Field(1).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

      actual = target.GenerateAcknowledgementMessage(oReceivedMessage, Hl7Table.Table_0008.AcknowledgmentCodeType.CommitReject);
      Assert.AreEqual(PeterPiper.Hl7.V2.Support.Standard.Hl7Table.Table_0008.CommitReject, actual.Segment(2).Field(1).AsStringRaw, "A test for GenerateEnhancedModeAcknowledgementMessage");

    }

  }
}
