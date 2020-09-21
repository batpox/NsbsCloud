using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoilStore
{
    class LegacyCode
    {
    }

// Note: this is the legacy vb6 code in the MainForm.frm

//'------------------------------------------------------------------------------------
//' Quality Track Handler main form
//'
//' Processes quality-related events and computes quality accordingly.
//' The NewSection event is the event which triggers the quality calculation.
//'
//Option Explicit

//Public grdQuality As New ClassGrid
  
//Private BoundaryWeight    ' Where boundary occurs

//Private MssgStopWeight  ' When same grade mixed steel ends
//Private MsdgStopWeight  ' Where different but similar mixing ends
//Private MsrgStopWeight  ' Where different but radical mixing ends

//Private cs As New ClassClockSnap
//'' 012103 daw
//' Snapshots and calculations from them
//Private TundishWeightAtClose ' Weight in tundish when ladle closes
//Private LanceWeight          ' above times TopTundishFactor for LDLLAN Event
//Private TundishWeightAtOpen  '
//Private MixWeight            '
//Private CounterAtOpen

//' Running totals...
//Private WeightCastSinceClose
//Private WeightCastSinceOpen
//''
//Private FlowDeviations As New Collection ' daw

//'-----------------------------------------------------------------------
//Private Sub cmdClearPractices_Click()
//  practices.Clear
//End Sub

//'-----------------------------------------------------------------------
//Private Sub cmdComputeMixedSteel_Click()
//  Dim vOpenName
  
//  If Not comtab.GetField("CasterStatus", "1", "OpenHeatName", vOpenName) Then
//    Exit Sub
//  End If
  
//  Call ComputeMixedSteel(vOpenName)

//End Sub

//'-----------------------------------------------------------------------
//Private Sub cmdEndSequence_Click()
//  Call ProcessEndSequence
//End Sub

//'-----------------------------------------------------------------------
//' Load the main form
//' Set up the Event Control
//'
//Private Sub Form_Load()
//  Dim ss&
//  Dim qd As ClassQualityDef
//  Dim qe As ClassQualityEvent
  
//  Dim msg$
  
//  On Error GoTo ModuleError
  
//' Put the event client in action
//  With ieEvent
//    .ServerIP = gEventManagerIP
//    .ServerPort = gEventManagerPort
//    .timeout = 30
//    .id = "QualityTrack"
//    .Port = gEventClientPort
//    .HelloSeconds = 15
//    .Bind
//  End With

//' Setup the Quality Grid
//  Set grdQuality = New ClassGrid
//  Call grdQuality.Initialize(log, cp.ccConnectString)
  
//  With grdQuality
//    Call .AddColumn("ID", Width:=10, CellType:="Text")
//    Call .AddColumn("Name", Width:=20, CellType:="Text")
//    Call .AddColumn("Value", Width:=10, CellType:="Text")
//    Call .AddColumn("Time", Width:=20, CellType:="Text")
    
//    Call .Prepare(fpQuality)
//  End With
  
//  lblStrand = "1"
//  updnStrand.max = cp.ccMaxStrands

//' Need a clocksnap for computing metal mixing
//  Set cs = New ClassClockSnap
//  Call cs.Initialize(cp.ccConnectString, log)
  
//' Put some info on the screen to make the human feel better
//  lblEventManagerIP = gEventManagerIP
//  lblOutPort = gEventManagerPort
//  lblInPort = ieEvent.Port
  
//  Call GetFlowDeviations ' daw
//' Issue a request to the Quality Server for all quality info
//  msg$ = "Change" & vbTab & "QualityEvents" & vbTab & CStr(ss&) & vbTab & "?"
//  Call ieEvent.DeclareEvent(msg$)
//' Initialize interval, do not yet enable
//  tmrLadleLance.Enabled = False
//  tmrLadleLance.Interval = 20000

//If False Then
//ModuleError:
//  Call LogIt("Load:" & Err.Description)
//End If
  
//End Sub

//Private Sub GetFlowDeviations()
//    Dim sql As String
//    Dim rs As ADODB.recordset
//    Dim vDev
    
//    On Error GoTo GotError
    
//    While FlowDeviations.Count
//        FlowDeviations.Remove 1
//    Wend
//    sql = "SELECT * FROM " & cp.GetTable("LoopDescription") & " ORDER BY LoopID"
//    Set rs = mDb.GetReadSet(cp.ccConnectString, sql)
//    While Not rs.EOF
//        FlowDeviations.Add CStr(rs!FlowHighDeviation), Key:=CStr(rs!LoopID)
//        rs.MoveNext
//    Wend
//    rs.Close
    
//    vDev = Val(FlowDeviations.Item(CStr(1)))
    
//    Exit Sub
    
//GotError:
//    Call LogIt("GetLoopDescriptions: error = " & Err.Description)
//    Exit Sub
//End Sub

//' Given the loop id, determine if the difference between the
//' setpoint and actual flow exceeds the LoopDescription.MaxFlowDeviation value
//'
//Private Function GetFlowDev(rvLoopID As Variant, strandid As Variant) As Boolean
//    Dim vDev As Variant
//    Dim vv, v1, v2
    
//    On Error GoTo GotError
    
//    vDev = Val(FlowDeviations.Item(CStr(rvLoopID)))
//    If Not IsNullOrEmpty(vDev) Then
//      Call comtab.GetField("L1Strand", CStr(strandid), "SprayWaterFlowL" & CStr(rvLoopID), v1)
//      Call comtab.GetField("L1Strand", CStr(strandid), "SprayWaterSetL" & CStr(rvLoopID), v2)
//      vv = Abs(v1 - v2)
//      GetFlowDev = vv > vDev
//    Else
//      GetFlowDev = False
//    End If
//    Exit Function
//GotError:
//    Call LogIt("GetFlowDev: error = " & Err.Description)
//    Exit Function
//End Function

//'-----------------------------------------------------------------------------------------------
//Private Function SetQualityEvents(ByVal strandid)
//  Dim q&
//  Dim qe As ClassQualityEvent
//  Dim qd As ClassQualityDef
//  Dim sql$
//  Dim rs As ADODB.recordset
  
//  Dim prc As ClassPractice
//  Dim Value As Variant
  
//  Dim Prefix$
//  Dim Key$
//  Dim r1 As Double
//  Dim b1 As Boolean, b2 As Boolean
//  Dim vv, v1, v2
//  Dim vCastingName
//  Dim vTundishTemperature
//  Dim vTundishWeight
//  Dim vCastSpeed
//  Dim vMoldWaterDeltaT
//  Dim vDeltaTNorth
//  Dim vDeltaTSouth
//  Dim vDeltaTBack
//  Dim vDeltaTFront
//  Dim vLiquidus
//  Dim vPracticeName
//  Dim qs As ClassQStrand
//  Dim s As String
//  Dim vDev, vN
  
//  On Error GoTo ModuleError
   
//' Set the prefix to be used for messages.
//  Prefix$ = "SetQualityEvents(" & CStr(strandid) & "):"
  
//' Check each quality event, ignoring those missing or disabled.

//' Note that the string is zeroed on section creation.. once an event
//' for the section is set it cannot be cleared.
    
//  If Not comtab.GetField("CasterStatus", "1", "CastingHeatName", vCastingName) Then
//    Exit Function
//  End If

//  Set qs = QStrands(CStr(strandid))

//' Find a practice for the heat
//  sql$ = "SELECT LiquidusTemperature, PracticeName FROM " & cp.GetTable("Heat") _
//    & " WHERE HeatName=" & mDb.Delimit(vCastingName)
//  Set rs = mDb.GetReadSet(cp.ccConnectString, sql$)
//  If Not rs.EOF Then
//    vLiquidus = rs!LiquidusTemperature
//    vPracticeName = rs!PracticeName
//    Set prc = FindPractice(vPracticeName)
//  End If
//  rs.Close
  
//  Call comtab.GetField("L1Strand", CStr(strandid), "CastSpeed", vCastSpeed)
//'nth++ - don't think the following field exists anymore - broken up into B,F,N,S
//'  Call comtab.GetField("L1Strand", CStr(StrandID), "MoldWaterDeltaT", vMoldWaterDeltaT)
//  Call comtab.GetField("L1Strand", CStr(strandid), "MoldWaterDeltaTempN", vDeltaTNorth)
//  Call comtab.GetField("L1Strand", CStr(strandid), "MoldWaterDeltaTempS", vDeltaTSouth)
//  Call comtab.GetField("L1Strand", CStr(strandid), "MoldWaterDeltaTempB", vDeltaTBack)
//  Call comtab.GetField("L1Strand", CStr(strandid), "MoldWaterDeltaTempF", vDeltaTFront)
  
//  Call comtab.GetField("L1General", "1", "TundishWeight", vTundishWeight)
//  Call comtab.GetField("L1General", "1", "TundishTemperature", vTundishTemperature)
  
//' Do for each quality definition
//  For Each qd In QDefinitions.qdefs
      
//' Build a key so we can look for the qualityevent
//    Key$ = QEvents(strandid).BuildQualityKey(strandid, qd.EventID)
    
//    Set qe = QEvents(strandid).qevts.Find(Key$)
//    If qe Is Nothing Then
//      Call LogIt("SetQualityEvents:No event found for key=" & Key$)
//      Exit Function
//    End If
    
//' Compute the calculation based upon the name.
//    Select Case qd.Name
//    Case "LCS"  ' Low Casting Speed. Check against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.CastSpeedMin) And Not IsNullOrEmpty(vCastSpeed) Then
//          vv = vCastSpeed * cp.cfCounterToLength
//          qe.Active = vv < prc.CastSpeedMin
//        Else
//          qe.Active = False
//        End If
//      Else
//        qe.Active = False
//      End If
      
//    Case "LCS32"    '   check for casting speed below 32 inches / minute   res 10/18/02
//        vv = vCastSpeed * cp.cfCounterToLength
//        qe.Active = vv < 31.8   ' per Vince was 32 changed res 10/28/02
            
//    Case "LCS20"    '   check for casting speed below 20 inches / minute   res 07/24/06
//        ' Changes were lost, re-entered 20070503-RTMintus
//        vv = vCastSpeed * cp.cfCounterToLength
//        qe.Active = vv < 20#
            
//    Case "HCS"  ' High Casting Speed. Check against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.CastSpeedMax) And Not IsNullOrEmpty(vCastSpeed) Then
//          vv = vCastSpeed * cp.cfCounterToLength
//          qe.Active = vv > prc.CastSpeedMax
//        Else
//          qe.Active = False
//        End If
//      Else
//        qe.Active = False
//      End If
       
//    Case "STSS" ' Strand at standstill. Check against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.StrandStandstillSpeed) And Not IsNullOrEmpty(vCastSpeed) Then
//          vv = vCastSpeed * cp.cfCounterToLength
//          qe.Active = vv < prc.StrandStandstillSpeed
//        Else
//          qe.Active = False
//        End If
//      Else
//        qe.Active = False
//      End If
        
//    Case "LTL" ' Low tundish level. Check against defaults
//      If Not (prc Is Nothing) Then
//        qe.Active = vTundishWeight < prc.TundishWeightLowLimit ' cp.ccLowTundishWeight
//      End If
//    Case "HTL" ' High tundish level. Check against defaults
//      qe.Active = vTundishWeight > cp.ccHighTundishWeight
    
//    Case "VORTEX" ' Excessive vortex. Check weight against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.TundishWeightVortexLimit) Then
//          qe.Active = vTundishWeight < prc.TundishWeightVortexLimit
//        Else
//          qe.Active = False
//        End If
//      Else
//        qe.Active = False
//      End If
    
//    Case "LDLSHD"
//'      vv = str.fmL1.FieldValue("LadleShroudChange")
//'      qe.Active = (vv <> 0)
    
//    Case "LDLLAN"
//'      Call comtab.GetField("L1General", "1", "LadleBurnOpen", vv)
//'      qe.Active = False ' (vv <> 0)
//        If qe.Active Then
//            If WeightCastSinceOpen <= LanceWeight Then
//                qe.Active = True
//            Else
//                Call LogIt("end of LDLLAN")
//                qe.Active = False
//            End If
//        End If
     
//    Case "LTT"  ' Low tundish temperature. Check superheat against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.SuperHeatMin) And Not IsNullOrEmpty(vLiquidus) Then
//          vv = vTundishTemperature - vLiquidus
//          If vv < 0 Then    ' must be a test of IP res 10/25/02
//             qe.Active = False
//          Else
//             qe.Active = vv < prc.SuperHeatMin
//          End If
//        Else
//          qe.Active = False
//        End If
//      Else
//        qe.Active = False
//      End If
    
    
//    Case "VLTT"  ' Very Low tundish temperature. Check superheat against practice - 10
//                    ' if true need to grind added res 1/15/03
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.SuperHeatMin) And Not IsNullOrEmpty(vLiquidus) Then
//          vv = vTundishTemperature - vLiquidus
//          If vv < 0 Then    ' must be a test of IP res 10/25/02
//             qe.Active = False
//          Else
//             qe.Active = vv < prc.SuperHeatMin - 10
//          End If
//        Else
//          qe.Active = False
//          Call LogIt("SetQualityEvents:    ******************* SuperHeatMin/vLiquidus are " _
//            & Val("" & prc.SuperHeatMin) & " / " & Val("" & vLiquidus))              '  reshulik added 3/19/04
//        End If
//      Else
//        qe.Active = False
//        Call LogIt("SetQualityEvents:    ******************* practice is nothing.") '  reshulik added 3/19/04
//      End If
    
//    Case "VVLTT"  ' Very Very Low tundish temperature. Check superheat against practice - 20
//                    ' Code added res 1/15/03 / re-entered 20070503-RTMintus
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.SuperHeatMin) And Not IsNullOrEmpty(vLiquidus) Then
//          vv = vTundishTemperature - vLiquidus
//          If vv < 0 Then    ' must be a test of IP
//             qe.Active = False
//          Else
//             qe.Active = vv < prc.SuperHeatMin - 20
//          End If
//        Else
//          qe.Active = False
//          Call LogIt("SetQualityEvents:    ******************* SuperHeatMin/vLiquidus are " _
//            & Val("" & prc.SuperHeatMin) & " / " & Val("" & vLiquidus))
//        End If
//      Else
//        qe.Active = False
//        Call LogIt("SetQualityEvents:    ******************* practice is nothing.")
//      End If
    
//    Case "MIX"  ' generic transition steel mix
//        If qe.Active Then
//            If WeightCastSinceOpen <= MixWeight Then
//                qe.Active = True
//            Else
//                Call LogIt("end of MIX")
//                qe.Active = False
//            End If
//        End If
    
//    Case "HTT"   ' High tundish temperature. Check superheat against practice
//      If Not (prc Is Nothing) Then
//'''        If Not IsNull(prc.SuperHeatMin) And Not IsNull(vLiquidus) Then   'nth++ (03.20.00)
//        If Not IsNullOrEmpty(prc.SuperHeatMax) And Not IsNullOrEmpty(vLiquidus) Then
//          vv = vTundishTemperature - vLiquidus
//          qe.Active = vv > prc.SuperHeatMax
//        End If
//      End If
       
//' Setting the heat boundary. Reset when a new section arrives
//    Case "HB" ' this heat boundary may be modified by an artificial capoff
      
//      If qs.HeatBoundary Then
      
//        qe.Active = True
//        qe.ResetValue = DateAdd("s", 5, Now)  ' When to reset
//        Call LogIt("SetQualityEvents:Boundary. Strand=" & strandid)
//        qs.HeatBoundary = False
//      End If
       
//    Case "CHB" ' this is the 'normally' calculated heat boundary, not affected by art-caps
    
//        If qs.CalculatedBoundary Then
//            If WeightCastSinceClose > TundishWeightAtClose Then
//                qe.Active = True
//                qe.ResetValue = DateAdd("s", 5, Now)  ' When to reset
//                Call LogIt("SetQualityEvents: Calculated Boundary. Strand = " & strandid)
//                qs.CalculatedBoundary = False
//            End If
//        End If
        
//''    Case "MSSG"
//''    Case "MSDG"
//''    Case "MSRG"
       
//''    Case "TE"
//''       qe.Active = Str.bTundishExchange
       
//    Case "MLSWING" ' Excessive mold travel. Check against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.MoldTravelHighLimit) Then
//          Call comtab.GetField("L1Strand", CStr(strandid), "MoldLevelTravel", vv)
//          txtML1 = vv
//          txtML2 = prc.MoldTravelHighLimit
//          qe.Active = vv > prc.MoldTravelHighLimit
//          txtPractice.Text = prc.PracticeName
//        Else
//          txtML1 = ""
//          txtML2 = "Null"
//          qe.Active = False
//        End If
//      Else
//        qe.Active = False
//        txtML1 = ""
//        txtML2 = "Nothing"
//      End If
    
//    Case "MLMANUAL" ' Mold level in manual control
//      Call comtab.GetField("L1Strand", CStr(strandid), "MoldLevelControlCode", vv)
//      qe.Active = False
//      If Not (IsNull(vv)) Then
//        If UCase$(CStr(vv)) = "MANUAL" Then
//            qe.Active = True
//        End If
//      Else  'it is null, don't know one way or the other
//      End If

//' nth++ (07.13.00) When we are getting the Mold Level Control in Manual "History" point
//' from Level 1, get its value and add check here.>>>>
//'

//    Case "LODELTA" ' Low delta T at mold. Check against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.MoldDeltaLowLimitBroad) And Not _
//               IsNullOrEmpty(vDeltaTFront) And Not _
//               IsNullOrEmpty(vDeltaTBack) Then
//          b1 = (vDeltaTFront < prc.MoldDeltaLowLimitBroad) Or _
//                      (vDeltaTBack < prc.MoldDeltaLowLimitBroad)
//        Else
//          b1 = False
//        End If
//        If Not IsNullOrEmpty(prc.MoldDeltaLowLimitNarrow) And Not _
//               IsNullOrEmpty(vDeltaTNorth) And Not _
//               IsNullOrEmpty(vDeltaTSouth) Then
//          b2 = (vDeltaTNorth < prc.MoldDeltaLowLimitNarrow) Or _
//                      (vDeltaTSouth < prc.MoldDeltaLowLimitNarrow)
//        Else
//          b2 = False
//        End If
//        qe.Active = b1 Or b2
//      Else
//        qe.Active = False
//      End If
      
//    Case "HIDELTA" ' High delta T at mold. Check against practice
//      If Not (prc Is Nothing) Then
//        If Not IsNullOrEmpty(prc.MoldDeltaHighLimitBroad) Then
//          b1 = (vDeltaTFront > prc.MoldDeltaHighLimitBroad) Or _
//                      (vDeltaTBack > prc.MoldDeltaLowLimitBroad)
                      
//        Else
//          b1 = False
//        End If
//        If Not IsNullOrEmpty(prc.MoldDeltaHighLimitNarrow) Then
//          b2 = (vDeltaTNorth > prc.MoldDeltaHighLimitNarrow) Or _
//                      (vDeltaTSouth > prc.MoldDeltaHighLimitNarrow)
//        Else
//          b2 = False
//        End If
//        qe.Active = b1 Or b2
//      Else
//        qe.Active = False
//      End If

//' Check for spray loop flows that are more than
//' LoopDescription.FlowHighDeviation away from the setpoints
//      Case "SL1DEV", "SL2DEV", "SL3DEV", "SL4DEV", "SL5DEV", _
//           "SL6DEV", "SL7DEV", "SL8DEV", "SL9DEV"
//        vN = Val(Mid$(qd.Name, 3, 1))
//        qe.Active = GetFlowDev(vN, strandid)
//      Case "SL10DEV", "SL11DEV", "SL12DEV", "SL13DEV", "SL14DEV", _
//           "SL15DEV", "SL16DEV"
//        vN = Val(Mid$(qd.Name, 3, 2))
//        qe.Active = GetFlowDev(vN, strandid)

    
//    Case "SL1MAN"
//    Case "SL2MAN"
//    Case "SL3MAN"
//    Case "SL4MAN"
//    Case "SL5MAN"
//    Case "SL6MAN"
//    Case "SL7MAN"
//    Case "SL8MAN"
//    Case "SL9MAN"
        
//''      Call comtab.GetField("L1Strand", CStr(StrandID), "Z1Mode", vv)
//'      qe.Active = (vv <> 1)
      
//    Case "SL10MAN"
//    Case "SL11MAN"
//    Case "SL12MAN"
//    Case "SL13MAN"
//    Case "SL14MAN"
//    Case "SL15MAN"
//    Case "SL16MAN"
    
//''      Call comtab.GetField("L1Strand", CStr(StrandID), "Z2Mode", vv)
//'      qe.Active = (vv <> 1)
    
  
//    Case "MWC", "WIDCHG"
//'      If comtab.GetField("L1Strand", CStr(StrandID), "MoldWidthInProgress", vv) Then
//'        qe.Active = vv
//'      End If
      
//    Case "OF"
//      If comtab.GetField("L1Strand", CStr(strandid), "MoldOscFrequency", vv) Then
//        qe.Active = vv > cp.ccHighMoldOscFrequency
//      End If
      
//    Case "LML"
//      If comtab.GetField("L1Strand", CStr(strandid), "MoldLevelAverage", vv) Then
//        qe.Active = vv < cp.ccLowMoldLevel
//      End If
    
//    Case "HML"
//      If comtab.GetField("L1Strand", CStr(strandid), "MoldLevelAverage", vv) Then
//        qe.Active = vv > cp.ccHighMoldLevel
//      End If
    
//    Case Else

//    End Select  ' qd.name for computed quality events
    
//GetNext:
//  Next qd ' for each quality definition
//  Exit Function
//If False Then
//ModuleError:
//  Call LogIt("SetQuality:" & Err.Description)
//  Exit Function
//  Resume
//End If

//End Function

//'-----------------------------------------------------------------------
//Private Function IsNullOrEmpty(ByVal Value) As Boolean
//  On Error Resume Next
//  IsNullOrEmpty = IsNull(Value) Or IsEmpty(Value)
//End Function

//'-----------------------------------------------------------------------
//' Set/Clear event for all strands
//'
//Private Sub SetQualityEvent(ByVal EventName, ByVal Value)
//  Dim ss&
//  Dim qe As ClassQualityEvent
//  Dim Key
  
//  On Error GoTo ModuleError
  
//  For ss& = 1 To cp.ccMaxStrands
//    Set qe = QEvents(ss&).FindEventUsingName(QDefinitions, EventName)
//    If Not (qe Is Nothing) Then
//      If qe.Enabled Then
//        qe.Active = Value
//      End If
//    End If
//  Next ss&
  
//  If Value Then
//    Call LogIt("SetQualityEvent:Set Event " & EventName)
//  Else
//    Call LogIt("SetQualityEvent:Cleared Event " & EventName)
//  End If
  
//If False Then
//ModuleError:
//  Call LogIt("SetQualityEvent:" & Err.Description)
//End If
  
//End Sub

//'-----------------------------------------------------------------------
//' Cleanup.
//'
//Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
  
//End Sub

//'-----------------------------------------------------------------------
//' Put an EventLog event into the EventLog table.
//'
//Private Sub PutEventLog(ByRef tokens() As String)
//  Dim sql$
//  Dim rs As ADODB.recordset
//  Dim kk&
  
//  On Error GoTo ModuleError
  
//  sql$ = "SELECT * FROM " & cp.GetTable("EventLog")
//  Set rs = mDb.GetWriteSet(cp.ccConnectString, sql$)
//  If Not (rs Is Nothing) Then
//    rs.AddNew
//    rs!Eventtime = Now
//    rs!Description = tokens(1)
//    kk& = 1
//    Do While (UBound(tokens) > kk&) And (kk& <= 3)
//      rs("Criterion" & CStr(kk& - 1)) = tokens(1 + kk&)
//      kk& = kk& + 1
//    Loop
//    rs.Update
//  End If
//  rs.Close
  
//If False Then
//ModuleError:
//  Call LogIt("PutEventLog:" & Err.Description)
//End If

//End Sub

//'------------------------------------------------------------------------------------
//Private Sub LogIt(ByVal msg$)
//  If Not (log Is Nothing) Then
//    Call log.Post("frmMain::" & msg$)
//  End If
//End Sub

//'-----------------------------------------------------------------------
//' Event received.
//' Log and process the event message, which is assumed to be
//' tab delimited.
//'
//Private Sub ieEvent_EventReceived(ByVal Message As String)
//  Dim tokens() As String
//  Dim MessageToLog As String
//  Dim Key$
//  Dim strand&
//  Dim tpl As ClassTuple
//  Dim ss&
//  Dim mask$
//  Dim vStatus
//  Dim vv, vvtemp
//  '' 012103 daw
//  Dim qd As ClassQualityDef
//  Dim vUnitWeight
//  Dim qs As ClassQStrand
  
//  On Error GoTo ModuleError
  
//  tokens = Split(Message, vbTab)
  
//'  vvtemp = comtab.GetField("L1Strand", "1", "Counter", vv)

//' Log only the messages we care about
//  MessageToLog = ""
  
//' Do the actual event handling
//  Select Case UCase$(tokens(0))
  
//  Case "DIE"
//    If UBound(tokens) <> 1 Then ' Must have 2 tokens
//      Call LogIt("DIE, bad format=[" & Message & "]")
//      Exit Sub
//    End If
  
//    Select Case UCase$(tokens(1))
//    Case "DIE"
//      Unload Me
    
//    Case Else
//      Call LogIt("EventReceived:Unknown DIE Action Type:" & tokens(1))
//    End Select

//'--- Case Change
//  Case "QUALITYEVENTS"
//    If UBound(tokens) <> 2 Then
//      Call LogIt("QualityEvents:Bad message=" & Message)
//      Exit Sub
//    End If
    
//    strand& = CLng(tokens(1))
//    mask$ = tokens(2)

//    If QEvents(strand&).SetUsingQualityMask(mask$) Then
//      QEvents(strand&).IsLoaded = True
//    End If

//' New section was created on a strand
//  Case "NEWSECTION"
//    If UBound(tokens) < 2 Then
//      Call LogIt("NewSection:Bad message=" & Message)
//      Exit Sub
//    End If
      
//    strand& = CLng(tokens(2))
//''    QStrands(CStr(Strand&)).section = CDbl(tokens(1))
    
//' Only bother we aren't idle
//    Call comtab.GetField("CasterStatus", 1, "CastMode", vStatus)
//    If vStatus <> "IDLE" Then
//      If QEvents(strand).IsLoaded Then
//        Call comtab.GetField("StrandStatus", 1, "UnitWeight", vUnitWeight)
//        WeightCastSinceClose = WeightCastSinceClose + vUnitWeight
//        WeightCastSinceOpen = WeightCastSinceOpen + vUnitWeight
//'        Call LogIt("-->WeightCastSinceClose = " & Format(WeightCastSinceClose, "#.00") & ", Section = " & tokens(1))
//        Call LogIt("Wgt Since Open = " & Format(WeightCastSinceOpen, "#") & ", Close = " & Format(WeightCastSinceClose, "#") & ", Section = " & tokens(1))
//        Call SetQuality(strand&)
//      End If
//    End If
  
//'------------------------------------------------------------------------------------
//  Case "HEAT"
//    MessageToLog = Message
    
//    If UBound(tokens) < 2 Then ' must have at least one parameter
//      Exit Sub
//    End If
//    Select Case UCase$(tokens(1)) ' these will mostly expect the heatid in tokens(2)
  
//' HEAT | LADLEOPEN | <heatID> | <heatName>
//    Case "LADLEOPEN" ' 2=heatid | 3=heatname
//      WeightCastSinceOpen = 0
//      If Not comtab.GetField("L1General", "1", "TundishWeight", TundishWeightAtOpen) Then
//        Call LogIt("EventReceived: HEAT LADLEOPEN - could not get TundishWeight")
//        Exit Sub
//      End If
      
//      If Not comtab.GetField("L1Strand", "1", "Counter", CounterAtOpen) Then ' added res 2/5/03
//        Call LogIt("EventReceived: HEAT LADLEOPEN - could not get CounterAtOpen")
//        Exit Sub
//      End If

//      Call LogIt("TundishWeightAtOpen = " & TundishWeightAtOpen)
//      If Not comtab.GetField("CasterStatus", "1", "CastInSequenceNumber", vv) Then
//        Call LogIt("EventReceived: HEAT LADLEOPEN - could not get CastInSequence")
//        Exit Sub
//      End If
//      If vv = 0 Then ' First heat of sequence
//        Call LogIt("First Heat of Sequence")
//      Else
//        Call LogIt("Continuation of Sequence")
//        Set qd = QDefinitions.FindDefUsingName("MIX")
//        If Not (qd Is Nothing) Then
//          MixWeight = TundishWeightAtOpen * qd.TopTundishFactor
//          Call LogIt("MIX: Factor=" & qd.TopTundishFactor)
//          Call LogIt("MIX: MixWeight=" & MixWeight)
//          Call SetQualityEvent("MIX", True)
//        End If
//      End If
      
//      Set qd = QDefinitions.FindDefUsingName("LDLLAN")
//      If Not (qd Is Nothing) Then
//        If vv = 0 Then ' First Heat of a Sequence
//            LanceWeight = 10000 ' arbitrary
//        Else
//            LanceWeight = TundishWeightAtOpen * qd.TopTundishFactor
//        End If
//        Call LogIt("LDLLAN: Factor=" & qd.TopTundishFactor)
//        Call LogIt("LDLLAN: LanceWeight=" & LanceWeight)
//      End If
      
//      ' Set timer to check for proper tundish weight rise (Lance detection)
//      tmrLadleLance.Enabled = True
//''      Call ComputeMixedSteel(OpenHeatName:=tokens(3))
      
//    Case "INTERFACE" ' heatname
//      Call ProcessInterface(HeatName:=tokens(2))
//      For ss& = 1 To cp.ccMaxStrands
//        Call SetQuality(ss&)
//      Next ss&
      
//    Case "LADLECLOSE" ' heatid | heatname
// ' Get the current tundish weight
//      If Not comtab.GetField("L1General", "1", "TundishWeight", TundishWeightAtClose) Then
//        Call LogIt("EventReceived: HEAT LADLECLOSE - could not get TundishWeight")
//        Exit Sub
//      End If
      
//      For ss& = 1 To cp.ccMaxStrands
//          Set qs = QStrands(CStr(ss&))
//          qs.CalculatedBoundary = True
//          qs.LanceTracked = True
//      Next ss&
      
//      WeightCastSinceClose = 0 ' reset
//      LanceWeight = 0
//      Call LogIt("TundishWeightAtClose = " & TundishWeightAtClose)
          
//    Case Else
//'      Call LogIt("Unknown HEAT Action Type:" & tokens(1))
//    End Select
      
//' These we care about...
//  Case "NEWSEQUENCE" ' sequenceid
//    TundishWeightAtClose = 0 ' 012103 daw
//    WeightCastSinceClose = 0
//    WeightCastSinceOpen = 0
//' Turn off all quality at end of sequence
//  Case "ENDSEQUENCE" ' sequenceid
//    Call LogIt("EventReceived:End of Sequence. Clearing Quality Events")
//    Call ProcessEndSequence
//    TundishWeightAtClose = 0
//    WeightCastSinceClose = 0
//    WeightCastSinceOpen = 0
//    LanceWeight = 0 ' 012103 daw
  
//  Case Else
  
//  End Select
    
//' Only log our messages.
//  If MessageToLog <> "" Then
//    Call LogIt("EventReceived:" & MessageToLog)
//  End If
  
//If False Then
//ModuleError:
//  Call LogIt("EventReceived:" & Err.Description)
//End If
    
//End Sub

//'-----------------------------------------------------------------------------------------------
//' Check clock weights
//'
//Private Sub CheckWeights()
//  Dim sql$
//  Dim tpl As ClassTuple
  
//  On Error GoTo ModuleError
  
//  Call cs.GetSnap
  
//  Set tpl = cs.fields.Find(UCase$("CastWeight"))
//  If tpl Is Nothing Then
//    Call LogIt("CheckWeights:Cannot find CastWeight clock.")
//    Exit Sub
//  End If
  
//' If our weight is over where mixing stops, then turn off quality
//  If Not IsEmpty(MssgStopWeight) Then
//    If tpl.Value1 > MssgStopWeight Then
//      MssgStopWeight = Empty
//      Call SetQualityEvent("MSSG", False)
//    End If
//  End If
  
//  If Not IsEmpty(MsdgStopWeight) Then
//    If tpl.Value1 > MsdgStopWeight Then
//      MsdgStopWeight = Empty
//      Call SetQualityEvent("MSDG", False)
//    End If
//  End If
  
//  If Not IsEmpty(MsrgStopWeight) Then
//    If tpl.Value1 > MsrgStopWeight Then
//      MsdgStopWeight = Empty
//      Call SetQualityEvent("MSRG", False)
//    End If
//  End If
  
//  lstWeights.Clear
//  With lstWeights
//    .AddItem "Cast Weight (tons)=" & Format$(tpl.Value1 / 2000#, "#.00")
//    .AddItem "MSSG Stop Weight (tons)=" & Format$(MssgStopWeight / 2000#, "#.00")
//    .AddItem "MSDG Stop Weight (tons)=" & Format$(MsdgStopWeight / 2000#, "#.00")
//    .AddItem "MSRG Stop Weight (tons)=" & Format$(MsdgStopWeight / 2000#, "#.00")
//  End With
  
//If False Then
//ModuleError:
//  Call LogIt("CheckWeights:" & Err.Description)
//End If

//End Sub

//'---------------------------------------------------------------------------------
//Private Sub ComputeMixedSteel(ByVal OpenHeatName)
//  Dim vState
//  Dim vCastingName, vOpenName
//  Dim vCastingID, vOpenID
//  Dim vCastingGrade, vOpenGrade
//  Dim vOpenMeetsCasting
//  Dim vCastingMeetsOpen
//  Dim vBoundary
  
//  Dim rs As ADODB.recordset
//  Dim sql$
  
//  Dim anlOpen As ClassAnalysis
//  Dim anlCasting As ClassAnalysis
//  Dim grdOpen As ClassGrade
//  Dim grdCasting As ClassGrade
  
//  Dim cs As ClassClockSnap
//  Dim tpl As ClassTuple
//  Dim qd As ClassQualityDef
  
//  Dim v
//  Dim vTundishWeight
  
//  On Error GoTo ModuleError
  
//  If Not comtab.GetField("CasterStatus", "1", "CastMode", vState) Then
//    Exit Sub
//  End If
  
//  If vState <> "CASTING" Then
//    Exit Sub
//  End If
    
//' Get the current tundish weight
//  If Not comtab.GetField("L1General", "1", "TundishWeight", vTundishWeight) Then
//    Exit Sub
//  End If
    
//  If Not comtab.GetField("CasterStatus", "1", "CastingHeatName", vCastingName) Then
//    Exit Sub
//  End If
    
//  vOpenName = OpenHeatName

//  Call LogIt("ComputeMixedSteel:Open=" & vOpenName & " Casting=" & vCastingName)
  
//' The open should differ from casting
//  If vOpenName = vCastingName Then
//    Call LogIt("ComputeMixedSteel:Casting and Open Heat were the same. Heat=" & vCastingName)
//    Exit Sub
//  End If
  
//' They are different, so get some info on the heats
//  If Not GetHeatInfo(vOpenName, vOpenID, grdOpen, anlOpen) Then
//    Exit Sub
//  End If
  
//  If Not GetHeatInfo(vCastingName, vCastingID, grdCasting, anlCasting) Then
//    Exit Sub
//  End If
  
//' Get a snapshot of the clocks
//  Set cs = New ClassClockSnap
//  Call cs.Initialize(cp.ccConnectString, log)
//  If Not cs.GetSnap Then
//    Call LogIt("ComputeMixedSteel:Could not snapshot the clocks.")
//    Exit Sub
//  End If
  
//' All of the info is collected. Now determined similarites
//  Set tpl = cs.fields.Find(UCase$("CastWeight"))  ' Get current cast weight clock
  
//  If Not AnalysisMeetsGrade(grdCasting, anlCasting) Then
//    Call LogIt("Compute:MixedSteelAnalysis did not meet grade.")
//  End If
  
//' See if the grades are different
//  If grdOpen.GradeName = grdCasting.GradeName Then
  
//'''    Call SetQualityEvent("MSSG", True)
//'''    MssgStopWeight = tpl.Value1 + vTundishWeight * 1#
    
//  Else
//    Call LogIt("C.M.S.:Different Grades: Tundish Wt=" & Format$(vTundishWeight, "#.0"))
    
//' The following is a precursor to changing the boundary
//    If AnalysisMeetsGrade(grdCasting, anlOpen) Then
//      Call LogIt("ComputeMixedSteel:Open heat meets Casting grade.")
//      vOpenMeetsCasting = True
//    Else
//      Call LogIt("ComputeMixedSteel:Open heat does not meet Casting grade.")
//      vOpenMeetsCasting = False
//    End If
    
//    If AnalysisMeetsGrade(grdOpen, anlCasting) Then
//      Call LogIt("ComputeMixedSteel:Casting heat meets Open grade.")
//      vCastingMeetsOpen = True
//    Else
//      Call LogIt("ComputeMixedSteel:Casting heat does not meet Open grade.")
//      vCastingMeetsOpen = False
//    End If
    
//' Now we know who meets what
//    If vOpenMeetsCasting Or vCastingMeetsOpen Then
      
//      Call SetQualityEvent("MSDG", True)
//      Set qd = QDefinitions.FindDefUsingName("MSDG")
//      If Not (qd Is Nothing) Then
//        MsdgStopWeight = tpl.Value1 + vTundishWeight * qd.TopTundishFactor
//        Call LogIt("C.M.S.:Different Grades: Factor=" & qd.TopTundishFactor)
//        Call LogIt("C.M.S.:Different Grades: Stop Weight=" & MsdgStopWeight)
//      End If
      
//' Now compute the boundary
//      vBoundary = Empty
      
//      If vOpenMeetsCasting And Not vCastingMeetsOpen Then
//        vBoundary = 0#  ' Cut it right now
//        Call LogIt("C.M.S.:Open met Casting Grade (but not vice versa) " _
//          & " Setting boundary to " & Format$(vBoundary, "#.00"))
//      ElseIf vCastingMeetsOpen And Not vOpenMeetsCasting Then
//        vBoundary = vTundishWeight
//        Call LogIt("C.M.S.:Casting met Open Grade (but not vice versa) " _
//          & " Setting boundary to " & Format$(vBoundary, "#.00"))
//      End If
      
//' Send Strand Tracking a boundary change message
//      If Not IsEmpty(vBoundary) Then
//        Call ieEvent.DeclareEvent("C.M.S.:HeatBoundary" & vbTab & Format(vBoundary, "#.00"))
//      Else
//        Call ieEvent.DeclareEvent("C.M.S.:No heat boundary change necessary.")
//      End If
      
//    Else
      
//      Call SetQualityEvent("MSRG", True)
//      Set qd = QDefinitions.FindDefUsingName("MSRG")
//      If Not (qd Is Nothing) Then
//        MsrgStopWeight = tpl.Value1 + vTundishWeight * qd.TopTundishFactor
//        Call LogIt("C.M.S.:Radical Grades: Factor=" & qd.TopTundishFactor)
//        Call LogIt("C.M.S.:Radical Grades: Stop Weight=" & MsrgStopWeight)
//      End If
    
//    End If
  
//  End If  ' Check if grades are the same
  
//If False Then
//ModuleError:
//  Call LogIt("ComputeMixedSteel:" & Err.Description)
//End If

//End Sub

//'---------------------------------------------------------------------------------
//' For a given heat, get grade and analysis information.
//'
//Private Function GetHeatInfo(ByVal HeatName, ByRef heatid, _
//  ByRef grd As ClassGrade, _
//  ByRef anl As ClassAnalysis)

//  Dim rs As ADODB.recordset
//  Dim rsAnl As ADODB.recordset
//  Dim sql$
  
//  On Error GoTo ModuleError
//  GetHeatInfo = False
  
//  If grd Is Nothing Then
//    Set grd = New ClassGrade
//    Call grd.Initialize(cp.ccConnectString, log)
//  End If
  
//  If anl Is Nothing Then
//    Set anl = New ClassAnalysis
//    Call anl.Initialize(cp.ccConnectString, ElementDefinitions:=elements)
//  End If
  
//  sql$ = "SELECT * FROM " & cp.GetTable("Heat") _
//    & " WHERE HeatName=" & mDb.Delimit(HeatName)
//  Set rs = mDb.GetReadSet(cp.ccConnectString, sql$)
//  If rs.EOF Then
//    Call LogIt("GetHeatInfo:Cannot find record for Heat=" & HeatName)
//    Exit Function
//  End If
  
//  If Not grd.Gets(GradeName:=rs!CasterGradeName) Then
//    Call LogIt("GetHeatInfo:Cannot get Grade=" & rs!CasterGradeName)
//    Exit Function
//  End If
  
//' Need a final analysis
//  sql$ = "SELECT * FROM " & cp.GetTable("Chemistry") _
//    & " WHERE HeatName=" & mDb.Delimit(HeatName) _
//    & " AND SampleType='F'"
//  Set rsAnl = mDb.GetReadSet(cp.ccConnectString, sql$)
//  If rsAnl.EOF Then
//    Call LogIt("GetHeatInfo:Cannot find final analysis for=" & HeatName)
//    Exit Function
//  End If
  
//  If Not anl.Gets(rsAnl, GetElements:=True) Then
//    Call LogIt("GetHeatInfo:Cannot get Analysis for=" & HeatName)
//    Exit Function
//  End If
  
//  rsAnl.Close
//  rs.Close
  
//  GetHeatInfo = True
  
//If False Then
//ModuleError:
//  Call LogIt("GetHeatInfo:Heat=" & HeatName & " Err=" & Err.Description)
//End If

//End Function


//'---------------------------------------------------------------------------------
//Private Function xx() As Boolean
//  Dim sql$
//  Dim rs As ADODB.recordset
  
//  On Error GoTo ModuleError
//  xx = False
  
  
//  xx = True
  
//If False Then
//ModuleError:
//  Call LogIt("xx:" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------------
//Private Function ProcessEndSequence() As Boolean
//  Dim ss&
//  Dim qe As ClassQualityEvent
  
//  On Error GoTo ModuleError
//  ProcessEndSequence = False
  
//  For ss& = 1 To cp.ccMaxStrands
//    For Each qe In QEvents(ss&).qevts
//      If qe.Active Then
//        qe.Active = False
//      End If
//    Next qe
  
//    Call SendDirtyQualityEvents(ss&)
//  Next ss&
  
//  ProcessEndSequence = True
  
//If False Then
//ModuleError:
//  Call LogIt("ProcessEndSequence:" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------------
//' Look in cache or database for the practice. If not found in cache, then
//' add it.
//'
//Private Function FindPractice(ByVal PracticeName) As ClassPractice
//  Dim sql$
//  Dim rs As ADODB.recordset
//  Dim prc As ClassPractice
  
//  On Error GoTo ModuleError
//  Set FindPractice = Nothing
  
//  If IsNull(PracticeName) Then
//    Exit Function
//  End If
  
//  Set prc = practices.Find(UCase$(PracticeName))
//  If prc Is Nothing Then
  
//    Set prc = New ClassPractice
//    Call prc.Initialize(cp)
//    If prc.Gets(PracticeName:=PracticeName) Then
//      Call practices.Add(prc, UCase$(PracticeName)) ' Put in cache
//    End If
  
//  End If
  
//  Set FindPractice = prc
  
//If False Then
//ModuleError:
//  Call LogIt("FindPractice:Practice=" & PracticeName & " Err=" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------------
//Private Function ShowQuality(ByVal strandid As Long) As Boolean
//  Dim sql$
//  Dim rs As ADODB.recordset
//  Dim quality As ClassQualityEvents
//  Dim qe As ClassQualityEvent
  
//  On Error GoTo ModuleError
  
//  Set quality = QEvents(strandid)
  
//  ShowQuality = False
  
//  With grdQuality
//    For Each qe In quality.qevts
//      Call .AddColumn("ID", Width:=10, CellType:="Text")
//      Call .AddColumn("Name", Width:=20, CellType:="Text")
//      Call .AddColumn("Value", Width:=10, CellType:="Text")
//      Call .AddColumn("Time", Width:=20, CellType:="Text")
//    Next qe
//  End With
  
  
//  ShowQuality = True
  
//If False Then
//ModuleError:
//  Call LogIt("ShowQuality:" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------------
//Private Function ProcessInterface(ByVal HeatName As String) As Boolean
//  Dim sql$
//  Dim rs As ADODB.recordset
//  Dim ss&
  
//  On Error GoTo ModuleError
//  ProcessInterface = False
  
//  For ss& = 1 To cp.ccMaxStrands
//    QStrands(CStr(ss&)).HeatBoundary = True
//  Next ss&
  
//  ProcessInterface = True
  
//If False Then
//ModuleError:
//  Call LogIt("ProcessInterface:" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------
//' Send a message when a quality event changes.
//' Format is:  Change<tab><QualityEvent><tab><strand-id><tab><QualityKey><tab>ACTIVE=TRUE
//'
//Public Sub SendDirtyQualityEvents(ByVal strandid As Long)
//  Dim qe As ClassQualityEvent
//  Dim s$
//  Dim mask$
//  Dim quality As ClassQualityEvents
  
//  On Error GoTo ModuleError
  
//  Set quality = QEvents(strandid)
  
//  mask$ = quality.BuildQualityChangeMask
  
//  If mask$ <> "" Then ' Indicates there were no changes
//    s$ = "Change" & vbTab & "QualityEvents" _
//    & vbTab & CStr(strandid) & vbTab & mask$
//    Call ieEvent.DeclareEvent(s$)
//  End If
  
//If False Then
//ModuleError:
//  Call LogIt("SendDirtyQualityEvents:" & Err.Description)
//End If

//End Sub

//'---------------------------------------------------------------------------------
//Private Function SetQuality(ByVal strandid As Long) As Boolean
//  Dim ss&
  
//  On Error GoTo ModuleError
//  SetQuality = False
  
//  Call SetQualityEvents(strandid)
//  Call SendDirtyQualityEvents(strandid)
  
//  SetQuality = True
  
//If False Then
//ModuleError:
//  Call LogIt("SetQuality:" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------------
//Private Function LoadPractice(ByVal heatid, _
//  ByVal TundishTypeCode, _
//  ByVal MoldSizeCode, _
//  ByVal GradeName) As Boolean
  
//  Dim sql$
//  Dim rs As ADODB.recordset
//  Dim PracticeName
  
//  On Error GoTo ModuleError
//  LoadPractice = False
  
//  Call LogIt("ComputePractice:Finding Practice for " _
//    & " TundishType=" & TundishTypeCode _
//    & " MoldSize=" & MoldSizeCode _
//    & " Grade=" & GradeName)
  
//  sql$ = "SELECT * FROM " & cp.GetTable("Practice") _
//    & " WHERE TundishTypeCode=" & mDb.Delimit(TundishTypeCode) _
//    & " AND MoldSizeCode=" & mDb.Delimit(MoldSizeCode) _
//    & " AND GradeList LIKE " & mDb.Delimit("%," & GradeName & ",%")
    
//  Set rs = mDb.GetReadSet(cp.ccConnectString, sql$)
//  If rs.EOF Then
//    Call LogIt("ComputePractice:Cannot locate practice.")
//    Exit Function
//  End If
  
//  PracticeName = rs!PracticeName
  
//  rs.Close
  
//' Now store the practice
//  sql$ = "SELECT * FROM " & cp.GetTable("Heat") _
//    & " WHERE HeatID=" & CStr(heatid)
//  Set rs = mDb.GetWriteSet(cp.ccConnectString, sql$)
//  If rs.EOF Then
//    Call LogIt("LoadPractice:Cannot find heatID=" & CStr(heatid))
//    Exit Function
//  End If
  
//  rs!PracticeName = PracticeName
//  rs.Update
//  rs.Close
  
//  LoadPractice = True
  
//If False Then
//ModuleError:
//  Call LogIt("LoadPractice:" & Err.Description)
//End If

//End Function

//'---------------------------------------------------------------------------------
//Private Sub mnuExit_Click()
//  Unload Me
//End Sub

//'-----------------------------------------------------------------------
//' Update the log
//'
//Private Sub Timer1_Timer()
//    Call log.UpdateList(txtLogs)
//End Sub

//' This timer is enabled when the ladle is opened
//' It checks for reasonable tundish weight rise (initially 500lbs)
//'  after a reasonable number of seconds (initially 15)

//Private Sub tmrLadleLance_Timer()
//    Dim vTundishWeight, vCounterNow, v, vDensity, vWidth, vTotalWeight, vTemp
//    If comtab.GetField("L1General", "1", "TundishWeight", vTundishWeight) Then
    
//        Call LogIt("tmrLadleLance: Lanced: Tundish at open = " & TundishWeightAtOpen & ", now = " & vTundishWeight)
//        v = comtab.GetField("L1Strand", "1", "Counter", vCounterNow)
//        If Not comtab.GetField("CasterStatus", "1", "SteelDensity", vDensity) Then
//            Call LogIt("Could not find density use 471.")
//            vDensity = 471#
//        Else
//            Call LogIt(" density used = " & vDensity)
//            If vDensity < 200 Then
//                Call LogIt(vDensity & " density too low use 471.")
//                vDensity = 471#
//            End If
                
//        End If
//        If Not comtab.GetField("L1Strand", "1", "BottomMoldWidth", vWidth) Then
//            Call LogIt("Could not find BottomMoldWidth use 45")
//            vWidth = 45#
//        End If
        
//        Call LogIt("counteratopen = " & CounterAtOpen & " counter now = " & vCounterNow & " density = " & vDensity & " Width = " & vWidth)
        
//        vTemp = (vCounterNow - CounterAtOpen) * vWidth / 12# * 7.5 / 12# * vDensity
//        vTotalWeight = vTundishWeight + vTemp
                
//        Call LogIt("vTundishWeight, vtemp = " & vTundishWeight & " " & vTemp _
//            & " counteratopen = " & CounterAtOpen & " counter now = " & vCounterNow _
//            & " density = " & vDensity & " Width = " & vWidth)

//        Call LogIt("Total weight of metal in tundish & cast since open = " & vTotalWeight)
      
//        If vTotalWeight > TundishWeightAtOpen + 400 Then    ' changed above line to this by res 013103
//            Call LogIt("tmrLadleLance: Not Lanced")
//        Else
//            Call SetQualityEvent("LDLLAN", True)
//            Call LogIt("tmrLadleLance: Lanced: LanceWeight = " & LanceWeight)
//        End If
//    Else
//        Call LogIt("tmrLadleLance: could not get Tundish Weight")
//    End If
//    tmrLadleLance.Enabled = False ' await next ladle open
//End Sub

//'-----------------------------------------------------------------------------------------------
//' Called every 5 seconds
//'
//Private Sub tmrPeriodic_Timer()
//  Static ticks&
//  Dim vStatus
//  Dim ss&
//  On Error Resume Next
  
//  ticks& = ticks& + 1
  
//  Call CheckBoundary
  
//' Every 5 secs. Look for dirty quality events
//  If (ticks& Mod 5) = 0 Then
//    Call CheckWeights
    
//    For ss& = 1 To cp.ccMaxStrands
//      Call SendDirtyQualityEvents(ss&)
//    Next ss&
//  End If
  
//End Sub

//'-----------------------------------------------------------------------------------------------
//Private Function CheckBoundary()
//  Dim ss&
//  Dim qe As ClassQualityEvent
//  Dim IsChange As Boolean
  
//  On Error GoTo ModuleError
  
//  For ss& = 1 To cp.ccMaxStrands
//    IsChange = False
    
//    Set qe = QEvents(ss&).FindEventUsingName(QDefinitions, "HB")
//    If qe Is Nothing Then
//      Exit Function
//    End If
        
//    If qe.Active Then
//      If Now >= qe.ResetValue Then
//        qe.Active = False
//        IsChange = True
//      End If
//    End If
  
//    Set qe = QEvents(ss&).FindEventUsingName(QDefinitions, "CHB")
//    If qe Is Nothing Then
//      Exit Function
//    End If
        
//    If qe.Active Then
//      If Now >= qe.ResetValue Then
//        qe.Active = False
//        IsChange = True
//      End If
//    End If
    
//' If changes, then send events right away
//    If IsChange Then
//      Call SendDirtyQualityEvents(ss&)
//    End If
    
//  Next ss&
  
//If False Then
//ModuleError:
//  Call LogIt("CheckBoundary:" & Err.Description)
//End If

//End Function

//'-----------------------------------------------------------------------------------------------
//Private Sub updnStrand_Change()
//  lblStrand = updnStrand.Value
  
//  Call ShowQuality(CLng(updnStrand.Value))
  
//End Sub

}
