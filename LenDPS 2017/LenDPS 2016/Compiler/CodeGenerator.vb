Imports System
Imports System.IO
Imports System.Text
Imports Railway

Public Class CodeGenerator
    Private MaxTemp As Integer = 0

    Enum eEquationType
        NONE = 0
        BOOL = 1
        TIMER = 2
    End Enum

    Public Sub DataBounded()
        Dim i, j As Integer
        i = 0 : j = 0

        For k As Integer = 0 To UBound(dbEquation) - 1
            If dbEquation(k).Type = eEquationType.BOOL Then
                dbEquation(k).Result = Result_List(i)
                i += 1
            ElseIf dbEquation(k).Type = eEquationType.TIMER Then
                dbEquation(k).Result = TimeList(j).varresult
                j += 1
            End If
        Next
    End Sub

    Public Sub ModularIO(ByVal sFormat As String)
        ' *********************************
        ' -------- Memory Mapping ---------
        '**********************************
        '----------------------------------
        '         BOOLEAN TEMP VAR
        '----------------------------------
        '             VIM
        '----------------------------------
        '             VOM
        '----------------------------------
        '             VCom
        '----------------------------------
        '            NVCom
        '----------------------------------
        '          BOOLEAN VAR
        '----------------------------------       
        '         TEMP VAR TIMER
        '----------------------------------
        '         COUNT TIMER VAR
        '----------------------------------
        Dim start As Integer = 0
        Dim idxCount As Integer = 0
        For i As Integer = 1 To Len(sFormat)
            If Mid(sFormat, i, 1) = "I" Or Mid(sFormat, i, 1) = "O" Then
                idxCount += 1
            End If
        Next

        'fill dbIO as 
        '-------------- I/O OPCODE -------------------
        Dim OpCode As String
        For i As Integer = 0 To UBound(dbIO) - 16
            OpCode = Conversion.Hex(CInt(i + start) + 10)
            Select Case Len(OpCode)
                Case 1 : dbIO(i).opcode = "000" & OpCode
                Case 2 : dbIO(i).opcode = "00" & OpCode
                Case 3 : dbIO(i).opcode = "0" & OpCode
                Case 4 : dbIO(i).opcode = OpCode
            End Select
        Next
        '----------------------- LATCH OPCODE --------------------------
        start = (idxCount * 16) + 10
        For i As Integer = 0 To IdxParam - 1
            '-------------- I/O -----------------------
            For j As Integer = 0 To UBound(dbIO) - 16
                If Parameter(i).Name = dbIO(j).name Then
                    Parameter(i).OpCode = dbIO(j).opcode
                    Parameter(i).status = True
                    Exit For
                End If
            Next
            '-------------- LATCH ---------------------
            If Parameter(i).status = False Then
                OpCode = Conversion.Hex(CInt(start))
                Select Case Len(OpCode)
                    Case 1 : Parameter(i).OpCode = "000" & OpCode
                    Case 2 : Parameter(i).OpCode = "00" & OpCode
                    Case 3 : Parameter(i).OpCode = "0" & OpCode
                    Case 4 : Parameter(i).OpCode = OpCode
                End Select
                start += 1
                Parameter(i).status = True
            End If
        Next

        ' Timer Variable Memory Mapping
        For i As Integer = start To start + (IdxTime - 1)
            OpCode = Conversion.Hex(CInt(i))
            Select Case Len(OpCode)
                Case 1 : TimeList(i - start).tempAddress = "000" & OpCode
                Case 2 : TimeList(i - start).tempAddress = "00" & OpCode
                Case 3 : TimeList(i - start).tempAddress = "0" & OpCode
                Case 4 : TimeList(i - start).tempAddress = OpCode
            End Select
        Next

        start = start + (IdxTime)
        For i As Integer = start To start + (IdxTime - 1)
            OpCode = Conversion.Hex(CInt(i))
            Select Case Len(OpCode)
                Case 1 : TimeList(i - start).countAddress = "000" & OpCode
                Case 2 : TimeList(i - start).countAddress = "00" & OpCode
                Case 3 : TimeList(i - start).countAddress = "0" & OpCode
                Case 4 : TimeList(i - start).countAddress = OpCode
            End Select
        Next

        'For i As Integer = 0 To UBound(dbIO) - 16
        '    Debug.Print(i + 1 & " - " & dbIO(i).name & " - " & dbIO(i).opcode & " <> " & start)
        'Next
    End Sub

    'Public Sub GenerateAddressOfIO(ByVal sformat As String)
    '    ' *********************************
    '    ' -------- Memory Mapping ---------
    '    '**********************************
    '    '----------------------------------
    '    '         BOOLEAN TEMP VAR
    '    '----------------------------------
    '    '             VIM
    '    '----------------------------------
    '    '             VOM
    '    '----------------------------------
    '    '             VCom
    '    '----------------------------------
    '    '            NVCom
    '    '----------------------------------
    '    '          BOOLEAN VAR
    '    '----------------------------------       
    '    '         TEMP VAR TIMER
    '    '----------------------------------
    '    '         COUNT TIMER VAR
    '    '----------------------------------
    '    Dim start As Integer = 0
    '    Dim idxCount As Integer = 0
    '    For i As Integer = 1 To Len(sformat)
    '        If Mid(sformat, i, 1) = "I" Or Mid(sformat, i, 1) = "O" Then
    '            idxCount += 1
    '        End If
    '    Next

    '    'fill dbIO as 
    '    '-------------- I/O OPCODE -------------------
    '    Dim OpCode As String
    '    For i As Integer = 0 To UBound(dbIO) - 16
    '        OpCode = Conversion.Hex(CInt(i + start) + 10)
    '        Select Case Len(OpCode)
    '            Case 1 : dbIO(i).opcode = "000" & OpCode
    '            Case 2 : dbIO(i).opcode = "00" & OpCode
    '            Case 3 : dbIO(i).opcode = "0" & OpCode
    '            Case 4 : dbIO(i).opcode = OpCode
    '        End Select
    '    Next
    '    '---------------- VITAL COMMUNICATION OPCODE -------------------
    '    Dim idxVComm As Integer = 0
    '    For i As Integer = 0 To UBound(dbComVtl) - 1
    '        If dbComVtl(i) <> String.Empty Then
    '            idxVComm += 1
    '        End If
    '    Next

    '    '-------------- NON VITAL COMMUNICATION OPCODE -----------------
    '    Dim idxNVComm As Integer = 0
    '    For i As Integer = 0 To UBound(dbComNVtl) - 1
    '        If dbComNVtl(i) <> String.Empty Then
    '            idxNVComm += 1
    '        End If
    '    Next
    '    Debug.Print("VComm := " & idxVComm)
    '    Debug.Print("NVComm := " & idxNVComm)

    '    '----------------------- LATCH OPCODE --------------------------
    '    start = (idxCount * 16) + 10
    '    For i As Integer = 0 To IdxParam - 1
    '        '-------------- I/O -----------------------
    '        For j As Integer = 0 To UBound(dbIO) - 16
    '            If Parameter(i).Name = dbIO(j).name Then
    '                Parameter(i).OpCode = dbIO(j).opcode
    '                Parameter(i).status = True
    '                Exit For
    '            End If
    '        Next
    '        ' ''-------------- V-COM ---------------------
    '        ''For j As Integer = 0 To UBound(dbComVtl) - 1
    '        ''    If Parameter(i).Name = dbComVtl(j) Then

    '        ''    End If
    '        ''Next


    '        ' ''-------------- NV-COM --------------------
    '        ''For j As Integer = 0 To UBound(dbComNVtl) - 1
    '        ''    If Parameter(i).Name = dbComNVtl(j) Then

    '        ''    End If
    '        ''Next


    '        '-------------- LATCH ---------------------
    '        If Parameter(i).status = False Then
    '            OpCode = Conversion.Hex(CInt(start))
    '            Select Case Len(OpCode)
    '                Case 1 : Parameter(i).OpCode = "000" & OpCode
    '                Case 2 : Parameter(i).OpCode = "00" & OpCode
    '                Case 3 : Parameter(i).OpCode = "0" & OpCode
    '                Case 4 : Parameter(i).OpCode = OpCode
    '            End Select
    '            start += 1
    '            Parameter(i).status = True
    '        End If
    '    Next

    '    ' Timer Variable Memory Mapping
    '    For i As Integer = start To start + (IdxTime - 1)
    '        OpCode = Conversion.Hex(CInt(i))
    '        Select Case Len(OpCode)
    '            Case 1 : TimeList(i - start).tempAddress = "000" & OpCode
    '            Case 2 : TimeList(i - start).tempAddress = "00" & OpCode
    '            Case 3 : TimeList(i - start).tempAddress = "0" & OpCode
    '            Case 4 : TimeList(i - start).tempAddress = OpCode
    '        End Select
    '    Next

    '    start = start + (IdxTime)
    '    For i As Integer = start To start + (IdxTime - 1)
    '        OpCode = Conversion.Hex(CInt(i))
    '        Select Case Len(OpCode)
    '            Case 1 : TimeList(i - start).countAddress = "000" & OpCode
    '            Case 2 : TimeList(i - start).countAddress = "00" & OpCode
    '            Case 3 : TimeList(i - start).countAddress = "0" & OpCode
    '            Case 4 : TimeList(i - start).countAddress = OpCode
    '        End Select
    '    Next

    '    'For i As Integer = 0 To UBound(dbIO) - 16
    '    '    Debug.Print(i + 1 & " - " & dbIO(i).name & " - " & dbIO(i).opcode & " <> " & start)
    '    'Next
    'End Sub

    Public Sub GenerateVariable()
        ' *********************************
        ' -------- Memory Mapping ---------
        '**********************************
        '----------------------------------
        '         BOOLEAN TEMP VAR
        '----------------------------------
        '             VIM
        '----------------------------------
        '             VOM
        '----------------------------------
        '             VCom
        '----------------------------------
        '            NVCom
        '----------------------------------
        '          BOOLEAN VAR
        '----------------------------------       
        '         TEMP VAR TIMER
        '----------------------------------
        '         COUNT TIMER VAR
        '----------------------------------

        ' Boolean Variable Memory Mapping 
        Dim OpCode As String
        For i As Integer = 0 To IdxParam - 1
            OpCode = Conversion.Hex(CInt(i + 10))
            Select Case Len(OpCode)
                Case 1 : Parameter(i).OpCode = "000" & OpCode
                Case 2 : Parameter(i).OpCode = "00" & OpCode
                Case 3 : Parameter(i).OpCode = "0" & OpCode
                Case 4 : Parameter(i).OpCode = OpCode
            End Select
        Next
        Dim start As Integer = IdxParam
        ' Timer Variable Memory Mapping
        For i As Integer = start To start + (IdxTime - 1)
            OpCode = Conversion.Hex(CInt(i + 10))
            Select Case Len(OpCode)
                Case 1 : TimeList(i - start).tempAddress = "000" & OpCode
                Case 2 : TimeList(i - start).tempAddress = "00" & OpCode
                Case 3 : TimeList(i - start).tempAddress = "0" & OpCode
                Case 4 : TimeList(i - start).tempAddress = OpCode
            End Select
        Next

        start = start + (IdxTime)
        For i As Integer = start To start + (IdxTime - 1)
            OpCode = Conversion.Hex(CInt(i + 10))
            Select Case Len(OpCode)
                Case 1 : TimeList(i - start).countAddress = "000" & OpCode
                Case 2 : TimeList(i - start).countAddress = "00" & OpCode
                Case 3 : TimeList(i - start).countAddress = "0" & OpCode
                Case 4 : TimeList(i - start).countAddress = OpCode
            End Select
        Next
    End Sub

    Private Function GetOperator(ByVal source As String) As Boolean
        Dim iBool As Boolean = False
        For i As Integer = 0 To source.Length - 1
            Dim op As String = source.Substring(i, 1)
            If op = "+" Or op = "*" Then
                iBool = True : Exit For
            End If
        Next
        Return iBool
    End Function

    Private Function RemoveParenthesis(ByVal source As String) As String
        Dim str As String = ""
        For i As Integer = 0 To source.Length - 1
            If source.Substring(i, 1) <> "(" And source.Substring(i, 1) <> ")" Then
                str = str & source.Substring(i, 1)
            End If
        Next
        Return str
    End Function

    Private Function CheckParenthesis(ByVal source As String) As Boolean
        Dim bCheck As Boolean = False
        For i As Integer = 0 To source.Length - 1
            If source.Substring(i, 1) = "(" Or source.Substring(i, 1) = ")" Then
                bCheck = True : Exit For
            End If
        Next
        Return bCheck
    End Function

    Private Function FindIndexID(ByVal variable As String) As Integer
        Dim index As Integer = -1
        If Mid(variable, 1, 3) = ".N." Then
            variable = Mid(variable, 4, Len(variable) - 3)
        End If
        For i As Integer = 0 To IdxParam - 1
            If variable = Parameter(i).Name Then
                index = i
                Exit For
            End If
        Next
        Return index
    End Function

    Private Function FindInvert(ByVal variable As String) As Boolean
        Dim bInvert As Boolean = False
        If Mid(variable, 1, 3) = ".N." Then bInvert = True
        Return bInvert
    End Function

    Private Function FindTemp(ByVal variable As String) As String
        Dim mVariable As String = ""
        If Mid(variable, 1, 4) = "temp" Then
            Select Case Mid(variable, 5, 1)
                Case "0" : mVariable = "0000"
                Case "1" : mVariable = "0001"
                Case "2" : mVariable = "0002"
                Case "3" : mVariable = "0003"
                Case "4" : mVariable = "0004"
                Case "5" : mVariable = "0005"
                Case "6" : mVariable = "0006"
                Case "7" : mVariable = "0007"
                Case "8" : mVariable = "0008"
                Case "9" : mVariable = "0009"
            End Select
        Else
            mVariable = variable
        End If
        Return mVariable
    End Function

#Region "Hardware Configuration"
    Public Sub Create_Link_HDW(ByVal pathLink As String, ByVal sLink As String)
        Dim writeBinStream As FileStream
        Dim binFile As String = pathLink

        writeBinStream = New FileStream(binFile, FileMode.Create)
        Dim writeBinary As New BinaryWriter(writeBinStream, Encoding.GetEncoding("iso-8859-1"))

        For i As Integer = 1 To Len(sLink)
            If Mid(sLink, i, 1) = "I" Or Mid(sLink, i, 1) = "O" Then
                Dim c As Char = Mid(sLink, i, 1)
                writeBinary.Write(c)
                Dim int As Integer = CInt(Mid(sLink, i + 1, 4))

                Dim msb As Integer = int >> 8
                Dim lsb As Integer = int And 255
                writeBinary.Write(ChrW(msb))
                writeBinary.Write(ChrW(lsb))
                i += 4
            Else
                Dim adr As Integer = CInt(Mid(sLink, i, 2))
                Dim cadr As String = Hex(adr)
                writeBinary.Write(ChrW(Convert.ToInt32(cadr, 16)))
                i += 1
            End If
        Next
        writeBinary.Flush()
        writeBinary.Close()
    End Sub

    Public Sub Create_Modular_Hdw(ByVal amountOfCoupler As Integer, ByVal pathHdw As String, ByVal pathLink As String, ByVal pathApp As String, ByVal pathTERC As String)
        Dim writeBinStream As FileStream
        Dim binFile As String = pathHdw
        Dim linkFileInfo As New FileInfo(pathLink)
        Dim appFileInfo As New FileInfo(pathApp)
        Dim fileLinkSize As String
        Dim fileHdwSize As String

        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim sHdw(1) As String
        Dim startAdr(1) As String
        '----------------------------------------------------------------------------
        For i As Integer = 0 To UBound(Parameter) - 1
            If Parameter(i).Type = TokenList.T_VitalCom Then
                If j = 0 Then startAdr(0) = Parameter(i).OpCode
                j += 1
            ElseIf Parameter(i).Type = TokenList.T_NVitalCom Then
                If k = 0 Then startAdr(1) = Parameter(i).OpCode
                k += 1
            End If
        Next
        sHdw(0) = "V" & String.Format("{0:00000}", j) & "A" '& startAdr(0)
        sHdw(1) = "N" & String.Format("{0:00000}", k) & "A" '& startAdr(1)
        '----------------------------------------------------------------------------
        'Debug.Print(sHdw(0) & " Vcom")
        'Debug.Print(sHdw(1) & " NVcom")

        writeBinStream = New FileStream(binFile, FileMode.Create)
        Dim writeBinary As New BinaryWriter(writeBinStream, Encoding.GetEncoding("iso-8859-1"))

        ' 1. ID Station (#BJRS)
        writeBinary.Write(ChrW(35)) '#
        writeBinary.Write(ChrW(66)) 'B
        writeBinary.Write(ChrW(74)) 'J
        writeBinary.Write(ChrW(82)) 'R
        writeBinary.Write(ChrW(83)) 'S

        ' 2. File *.lnk Size (L.....)
        writeBinary.Write(ChrW(76)) 'L
        fileLinkSize = String.Format("{0:00000}", linkFileInfo.Length)
        'Debug.Print(fileLinkSize)
        For i As Integer = 1 To Len(fileLinkSize)
            Dim d As Char = Trim(Mid(fileLinkSize, i, 1))
            writeBinary.Write(d)
        Next

        ' 3. Amount Of sVCM (S.)
        writeBinary.Write(ChrW(83)) 'S
        writeBinary.Write(ChrW(amountOfCoupler - 1))

        ' 4. Amount Of Vital Communication (V.....A..)
        ' 5. Amount Of Non Vital Communication (N.....A..)
        Dim a, b As String
        For x As Integer = 0 To 1
            For y As Integer = 1 To Len(sHdw(x))
                Dim c As Char = Mid(sHdw(x), y, 1)
                writeBinary.Write(c)
            Next
            a = Mid(startAdr(x), 1, 2)
            b = Mid(startAdr(x), 3, 2)
            writeBinary.Write(ChrW(Convert.ToInt32(a, 16)))
            writeBinary.Write(ChrW(Convert.ToInt32(b, 16)))
        Next

        ' 6. File *.app size (@.......)
        '    BERC File Info
        writeBinary.Write(ChrW(64)) ' @
        fileHdwSize = String.Format("{0:0000000}", appFileInfo.Length)
        For i As Integer = 1 To Len(fileHdwSize)
            Dim d As Char = Trim(Mid(fileHdwSize, i, 1))
            writeBinary.Write(d)
        Next

        ' 7. File *.app size (P.......)
        '    TERC File Info
        writeBinary.Write(ChrW(80)) 'P
        If (File.Exists(pathTERC)) Then
            Dim file_TERC_Info As New FileInfo(pathTERC)
            Dim terc As Integer = file_TERC_Info.Length
            Dim terc_size As String = String.Format("{0:000000}", terc)

            For i As Integer = 1 To Len(terc_size)
                Dim d As Char = Trim(Mid(terc_size, i, 1))
                writeBinary.Write(d)
            Next
            writeBinary.Write(ChrW(80))
        Else
            For i As Integer = 1 To 6
                writeBinary.Write(ChrW(48))
            Next
            writeBinary.Write(ChrW(80))
        End If

        ' 8. Date of Generate Opcode
        'Date and Time Info
        Dim Time As DateTime = Today
        Dim this_day As String = String.Format("{0:00}", Time.Day)
        Dim this_month As String = String.Format("{0:00}", Time.Month)
        Dim this_year As String = String.Format("{0:00}", Time.Year)
        this_year = Mid(this_year, 3, 2)

        Dim cc(5) As Char
        cc(0) = Mid(this_day, 1, 1)
        cc(1) = Mid(this_day, 2, 1)
        cc(2) = Mid(this_month, 1, 1)
        cc(3) = Mid(this_month, 2, 1)
        cc(4) = Mid(this_year, 1, 1)
        cc(5) = Mid(this_year, 2, 1)

        For i As Integer = 0 To 5
            writeBinary.Write(cc(i))
        Next
        writeBinary.Write(ChrW(80)) 'P

        writeBinary.Flush()
        writeBinary.Close()
    End Sub

    Public Sub CreateHdw(ByVal pathHdw As String, ByVal pathApp As String, ByVal pathTERC As String)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim l As Integer = 0
        Dim m As Integer = 0
        Dim sHdw(3) As String
        Dim startAdr(3) As String

        For i As Integer = 0 To UBound(Parameter) - 1
            If Parameter(i).Type = TokenList.T_VitalInput Then
                If j = 0 Then startAdr(0) = Parameter(i).OpCode
                j += 1
            ElseIf Parameter(i).Type = TokenList.T_VitalOutput Then
                If k = 0 Then startAdr(1) = Parameter(i).OpCode
                k += 1
            ElseIf Parameter(i).Type = TokenList.T_VitalCom Then
                If l = 0 Then startAdr(2) = Parameter(i).OpCode
                l += 1
            ElseIf Parameter(i).Type = TokenList.T_NVitalCom Then
                If m = 0 Then startAdr(3) = Parameter(i).OpCode
                m += 1
            End If
        Next
        sHdw(0) = "I" & String.Format("{0:00000}", j) & "A" '& startAdr(0)
        sHdw(1) = "O" & String.Format("{0:00000}", k) & "A" '& startAdr(1)
        sHdw(2) = "V" & String.Format("{0:00000}", l) & "A" '& startAdr(2)
        sHdw(3) = "N" & String.Format("{0:00000}", m) & "A" '& startAdr(3)

        '--------------------------------------------------------------------------------------
        Dim writeBinStream As FileStream
        Dim binFile As String = pathHdw
        Dim fileInfo As New FileInfo(pathApp)
        Dim fi As Integer = 0
        Dim fiSize As String

        writeBinStream = New FileStream(binFile, FileMode.Create)
        Dim writeBinary As New BinaryWriter(writeBinStream, Encoding.GetEncoding("iso-8859-1"))

        writeBinary.Write(ChrW(35))
        writeBinary.Write(ChrW(66))
        writeBinary.Write(ChrW(74))
        writeBinary.Write(ChrW(82))
        writeBinary.Write(ChrW(83))
        Dim a, b As String
        For x As Integer = 0 To 3
            For y As Integer = 1 To Len(sHdw(x))
                Dim c As Char = Mid(sHdw(x), y, 1)
                writeBinary.Write(c)
            Next
            a = Mid(startAdr(x), 1, 2)
            b = Mid(startAdr(x), 3, 2)
            writeBinary.Write(ChrW(Convert.ToInt32(a, 16)))
            writeBinary.Write(ChrW(Convert.ToInt32(b, 16)))
        Next
        writeBinary.Write(ChrW(64))
        fi = fileInfo.Length
        fiSize = String.Format("{0:0000000}", fi)
        For i As Integer = 1 To Len(fiSize)
            Dim d As Char = Trim(Mid(fiSize, i, 1))
            writeBinary.Write(d)
        Next
        writeBinary.Write(ChrW(80))

        'TERC File Info
        If (File.Exists(pathTERC)) Then
            Dim file_TERC_Info As New FileInfo(pathTERC)
            Dim terc As Integer = file_TERC_Info.Length
            Dim terc_size As String = String.Format("{0:000000}", terc)

            For i As Integer = 1 To Len(terc_size)
                Dim d As Char = Trim(Mid(terc_size, i, 1))
                writeBinary.Write(d)
            Next
            writeBinary.Write(ChrW(80))
        Else
            For i As Integer = 1 To 6
                writeBinary.Write(ChrW(48))
            Next
            writeBinary.Write(ChrW(80))
        End If

        'Date and Time Info
        Dim Time As DateTime = Today
        Dim this_day As String = String.Format("{0:00}", Time.Day)
        Dim this_month As String = String.Format("{0:00}", Time.Month)
        Dim this_year As String = String.Format("{0:00}", Time.Year)
        this_year = Mid(this_year, 3, 2)

        Dim cc(5) As Char
        cc(0) = Mid(this_day, 1, 1)
        cc(1) = Mid(this_day, 2, 1)
        cc(2) = Mid(this_month, 1, 1)
        cc(3) = Mid(this_month, 2, 1)
        cc(4) = Mid(this_year, 1, 1)
        cc(5) = Mid(this_year, 2, 1)

        For i As Integer = 0 To 5
            writeBinary.Write(cc(i))
        Next
        writeBinary.Write(ChrW(80))

        writeBinary.Flush()
        writeBinary.Close()
    End Sub
#End Region

#Region "ASCII Format"

    Private Function HexToASCII(ByVal Hex As String) As Char
        Dim asciivalue = System.Convert.ToChar(System.Convert.ToUInt32(Hex, 16))
        Return asciivalue
    End Function

    Public Sub WriteBinFile(ByVal pathSource As String, ByVal pathBERC As String, ByVal pathTERC As String)
        ' 1. TERC
        ' 2. BERC
        If File.Exists(pathTERC) Then
            Dim wBinStream As FileStream
            Dim tercFile As New BinaryReader(File.Open(pathTERC, FileMode.Open), Encoding.GetEncoding("iso-8859-1"))
            Dim pos_terc As ULong = 0
            Dim lenght_terc As ULong = tercFile.BaseStream.Length


            wBinStream = New FileStream(pathSource, FileMode.Create)
            Dim wBin As New BinaryWriter(wBinStream, Encoding.GetEncoding("iso-8859-1"))

            While pos_terc < lenght_terc
                Dim c As Char = tercFile.ReadChar
                pos_terc += 1
                wBin.Write(c)
            End While
            tercFile.Close()

            If File.Exists(pathBERC) Then
                Dim bercFile As New BinaryReader(File.Open(pathBERC, FileMode.Open), Encoding.GetEncoding("iso-8859-1"))
                Dim pos_berc As ULong = 0
                Dim lenght_berc As ULong = bercFile.BaseStream.Length

                While pos_berc < lenght_berc
                    Dim c As Char = bercFile.ReadChar
                    pos_berc += 1
                    wBin.Write(c)
                End While
                bercFile.Close()
            Else
                MessageBox.Show("BERC.bin file doesn't exist")
            End If
            wBinStream.Close()
        Else
            MessageBox.Show("TERC.bin file doesn't exist")
        End If

    End Sub

    Public Sub ReadAndCreateHex_TERC(ByVal hexPath As String)
        If File.Exists(hexPath) Then
            Dim hexSource As New StreamReader(hexPath)
            Dim writeBinStream As FileStream
            Dim iLine As String
            Dim dataLine(0) As String
            Dim i As ULong
            Dim binFile As String = hexPath & ".bin" 'App_Path() & "TERC.cbi"

            writeBinStream = New FileStream(binFile, FileMode.Create)
            Dim writeBinary As New BinaryWriter(writeBinStream, Encoding.GetEncoding("iso-8859-1"))

            If File.Exists(hexPath) Then
                i = 0
                Do
                    iLine = hexSource.ReadLine
                    dataLine(i) = iLine
                    If Len(dataLine(i)) = 9 Then
                        Dim DataHex(5) As String
                        '---------- OPERATOR ---------------------------- (1)
                        If (Mid(dataLine(i), 1, 1)) = "Z" Then
                            DataHex(0) = "5A"
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            '-------------------------------------------- (2)
                            DataHex(1) = Mid(dataLine(i), 2, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            '-------------------------------------------- (3)
                            DataHex(2) = Mid(dataLine(i), 4, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(2), 16)))
                            '-------------------------------------------- (4)
                            DataHex(3) = Mid(dataLine(i), 6, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(3), 16)))
                            '-------------------------------------------- (5)
                            DataHex(4) = Mid(dataLine(i), 8, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                        Else
                            MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii (E)")
                            'Exit Do
                        End If

                    ElseIf Len(dataLine(i)) = 15 Then
                        Dim DataHex(9) As String
                        If Mid(dataLine(i), 1, 1) = "T" Or Mid(dataLine(i), 1, 1) = "K" Then
                            '------ OPERATOR ---------------------------- (1)
                            If Mid(dataLine(i), 1, 1) = "T" Then
                                DataHex(0) = "54"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            ElseIf Mid(dataLine(i), 1, 1) = "K" Then
                                DataHex(0) = "4B"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            End If
                            '------- NEGASI OR NOT ---------------------- (2)
                            If Mid(dataLine(i), 2, 1) = "." Then
                                DataHex(1) = "2E"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            ElseIf Mid(dataLine(i), 2, 1) = "_" Then
                                DataHex(1) = "5F"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            End If
                            '-------------------------------------------- (3)
                            DataHex(2) = Mid(dataLine(i), 3, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(2), 16)))
                            '-------------------------------------------- (4)
                            DataHex(3) = Mid(dataLine(i), 5, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(3), 16)))
                            '------- NEGASI OR NOT ---------------------- (5)
                            If Mid(dataLine(i), 7, 1) = "." Then
                                DataHex(4) = "2E"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            ElseIf Mid(dataLine(i), 7, 1) = "_" Then
                                DataHex(4) = "5F"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            End If
                            '-------------------------------------------- (6) 
                            DataHex(5) = Mid(dataLine(i), 8, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(5), 16)))
                            '-------------------------------------------- (7)
                            DataHex(6) = Mid(dataLine(i), 10, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(6), 16)))
                            '-------------------------------------------- (8)
                            DataHex(7) = Mid(dataLine(i), 12, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(7), 16)))
                            '-------------------------------------------- (9)
                            DataHex(8) = Mid(dataLine(i), 14, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(8), 16)))
                        Else
                            MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii (K / T)")
                            Exit Do
                        End If
                    ElseIf Len(dataLine(i)) = 10 Then   ' E
                        Dim DataHex(6) As String
                        '---------- OPERATOR ---------------------------- (1)
                        If Mid(dataLine(i), 1, 1) = "E" Then
                            DataHex(0) = "45"
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            '------- NEGASI OR NOT ---------------------- (2)
                            If Mid(dataLine(i), 2, 1) = "." Then
                                DataHex(1) = "2E"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            ElseIf Mid(dataLine(i), 2, 1) = "_" Then
                                DataHex(1) = "5F"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            End If
                            '-------------------------------------------- (3)
                            DataHex(2) = Mid(dataLine(i), 3, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(2), 16)))
                            '-------------------------------------------- (4)
                            DataHex(3) = Mid(dataLine(i), 5, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(3), 16)))
                            '-------------------------------------------- (5)
                            DataHex(4) = Mid(dataLine(i), 7, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            '-------------------------------------------- (6)
                            DataHex(5) = Mid(dataLine(i), 9, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(5), 16)))
                        End If
                    Else
                        'MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii")
                        Exit Do
                    End If
                    i += 1
                    ReDim Preserve dataLine(i)
                Loop Until iLine Is Nothing
                writeBinary.Flush()
                writeBinary.Close()
                hexSource.Close()
            Else
                MessageBox.Show("TERC file doesn't exist")
            End If
        Else
            Debug.Print("TERC file doesn't exist")
            Exit Sub
        End If
    End Sub

    Public Sub ReadAndCreateHex_BERC(ByVal hexPath As String)
        If File.Exists(hexPath) Then
            Dim hexSource As New StreamReader(hexPath)
            Dim writeBinStream As FileStream
            Dim iLine As String
            Dim dataLine(0) As String
            Dim i As ULong
            Dim binFile As String = hexPath & ".bin" 'App_Path() & "BERC.cbi"

            writeBinStream = New FileStream(binFile, FileMode.Create)
            Dim writeBinary As New BinaryWriter(writeBinStream, Encoding.GetEncoding("iso-8859-1"))

            'Dim ii, jj, kk, ll, mm, nn As Long
            If File.Exists(hexPath) Then
                'i = 0
                'ii = 0
                'jj = 0
                'kk = 0
                'll = 0
                'mm = 0
                'nn = 0
                Do
                    iLine = hexSource.ReadLine
                    dataLine(i) = iLine
                    If Len(dataLine(i)) = 10 Then
                        'ii += 1
                        Dim DataHex(6) As String
                        '---------- OPERATOR ---------------------------- (1)
                        If (Mid(dataLine(i), 1, 1)) = "E" Then
                            DataHex(0) = "45"
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            '------- NEGASI OR NOT ---------------------- (2)
                            If Mid(dataLine(i), 2, 1) = "." Then
                                DataHex(1) = "2E"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            ElseIf Mid(dataLine(i), 2, 1) = "_" Then
                                DataHex(1) = "5F"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            End If
                            '-------------------------------------------- (3)
                            DataHex(2) = Mid(dataLine(i), 3, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(2), 16)))
                            '-------------------------------------------- (4)
                            DataHex(3) = Mid(dataLine(i), 5, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(3), 16)))
                            '-------------------------------------------- (5)
                            DataHex(4) = Mid(dataLine(i), 7, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            '-------------------------------------------- (6)
                            DataHex(5) = Mid(dataLine(i), 9, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(5), 16)))
                        Else
                            MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii (E)")
                            'Exit Do
                        End If

                    ElseIf Len(dataLine(i)) = 11 Then
                        'jj += 1
                        Dim DataHex(6) As String
                        '---------- OPERATOR ---------------------------- (1)
                        If (Mid(dataLine(i), 1, 1)) = "W" Then
                            DataHex(0) = "57"
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            '-------------------------------------------- (2)
                            DataHex(1) = Mid(dataLine(i), 2, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            '-------------------------------------------- (3)
                            DataHex(2) = Mid(dataLine(i), 4, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(2), 16)))
                            '-------------------------------------------- (4)
                            DataHex(3) = Mid(dataLine(i), 6, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(3), 16)))
                            '-------------------------------------------- (5)
                            DataHex(4) = Mid(dataLine(i), 8, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            '-------------------------------------------- (2)
                            DataHex(5) = Mid(dataLine(i), 10, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(5), 16)))
                        Else
                            MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii (W)")
                            Exit Do
                        End If

                    ElseIf Len(dataLine(i)) = 15 Then
                        'kk += 1
                        Dim DataHex(9) As String
                        If Mid(dataLine(i), 1, 1) = "T" Or Mid(dataLine(i), 1, 1) = "K" Then
                            '------ OPERATOR ---------------------------- (1)
                            If Mid(dataLine(i), 1, 1) = "T" Then
                                DataHex(0) = "54"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            ElseIf Mid(dataLine(i), 1, 1) = "K" Then
                                DataHex(0) = "4B"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(0), 16)))
                            End If
                            '------- NEGASI OR NOT ---------------------- (2)
                            If Mid(dataLine(i), 2, 1) = "." Then
                                DataHex(1) = "2E"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            ElseIf Mid(dataLine(i), 2, 1) = "_" Then
                                DataHex(1) = "5F"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(1), 16)))
                            End If
                            '-------------------------------------------- (3)
                            DataHex(2) = Mid(dataLine(i), 3, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(2), 16)))
                            '-------------------------------------------- (4)
                            DataHex(3) = Mid(dataLine(i), 5, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(3), 16)))
                            '------- NEGASI OR NOT ---------------------- (5)
                            If Mid(dataLine(i), 7, 1) = "." Then
                                DataHex(4) = "2E"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            ElseIf Mid(dataLine(i), 7, 1) = "_" Then
                                DataHex(4) = "5F"
                                writeBinary.Write(ChrW(Convert.ToInt32(DataHex(4), 16)))
                            End If
                            '-------------------------------------------- (6) 
                            DataHex(5) = Mid(dataLine(i), 8, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(5), 16)))
                            '-------------------------------------------- (7)
                            DataHex(6) = Mid(dataLine(i), 10, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(6), 16)))
                            '-------------------------------------------- (8)
                            DataHex(7) = Mid(dataLine(i), 12, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(7), 16)))
                            '-------------------------------------------- (9)
                            DataHex(8) = Mid(dataLine(i), 14, 2)
                            writeBinary.Write(ChrW(Convert.ToInt32(DataHex(8), 16)))
                        Else
                            MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii (K / T)")
                            Exit Do
                        End If
                    Else
                        'MessageBox.Show("Line ( " & i.ToString & " ) can't to convert to ascii")
                        'Debug.Print(i.ToString & " - " & dataLine(i))
                        Exit Do
                    End If
                    'Debug.Print(i.ToString & " - " & iLine & " << Line")
                    'Debug.Print(ii.ToString & " = ii")
                    'Debug.Print(jj.ToString & " = jj")
                    'Debug.Print(jj.ToString & " = jj")
                    i += 1
                    ReDim Preserve dataLine(i)
                Loop Until iLine Is Nothing
                writeBinary.Flush()
                writeBinary.Close()
                hexSource.Close()
            Else
                MessageBox.Show("BERC file doesn't exist")
            End If
        Else
            Debug.Print("BERC file doesn't exist")
            Exit Sub
        End If


    End Sub

#End Region

#Region "HEX Format"


    Private Function MakeOpcodeEqual(ByVal result As String, ByVal var1 As String, ByVal type As eEquationType) As String
        Dim Opcode As String = 0
        Dim mResult As String = ""
        Dim mVar1 As String = ""
        Dim idx As Integer = 0

        Select Case type
            Case eEquationType.BOOL
                idx = FindIndexID(result)
                If idx <> -1 Then
                    If FindInvert(result) Then mResult = "." & Parameter(idx).OpCode Else mResult = Parameter(idx).OpCode
                Else
                    mResult = FindTemp(result)
                End If

            Case eEquationType.TIMER
                idx = FindIndexID(result)
                If idx <> -1 Then
                    For i As Integer = 0 To IdxTime - 1
                        If result = TimeList(i).varresult Then
                            mResult = TimeList(i).tempAddress
                        End If
                    Next
                    'If FindInvert(result) Then mResult = "!" & Parameter(idx).OpCode Else mResult = Parameter(idx).OpCode
                Else
                    mResult = FindTemp(result)
                End If
        End Select

        idx = FindIndexID(var1)
        If idx <> -1 Then
            If FindInvert(var1) Then mVar1 = "." & Parameter(idx).OpCode Else mVar1 = "_" & Parameter(idx).OpCode
        Else
            mVar1 = "_" & FindTemp(var1)
        End If

        Opcode = "E" & mVar1 & mResult
        Return Opcode
    End Function

    Private Function MakeOpcodeRabbit(ByVal result As String, ByVal var1 As String, ByVal var2 As String, ByVal operand As String, ByVal type As eEquationType) As String
        Dim Opcode As String = 0
        Dim mResult As String = ""
        Dim mVar1 As String = ""
        Dim mVar2 As String = ""
        Dim mOperand As String = ""
        Dim idx As Integer = 0

        Select Case type
            Case eEquationType.BOOL
                idx = FindIndexID(result)
                If idx <> -1 Then
                    If FindInvert(result) Then mResult = "." & Parameter(idx).OpCode Else mResult = Parameter(idx).OpCode
                Else
                    mResult = FindTemp(result)
                End If

            Case eEquationType.TIMER
                idx = FindIndexID(result)
                If idx <> -1 Then
                    For i As Integer = 0 To IdxTime - 1
                        If result = TimeList(i).varresult Then
                            mResult = TimeList(i).tempAddress
                        End If
                    Next
                    'If FindInvert(result) Then mResult = "!" & Parameter(idx).OpCode Else mResult = Parameter(idx).OpCode
                Else
                    mResult = FindTemp(result)
                End If
        End Select

        idx = FindIndexID(var1)
        If idx <> -1 Then
            If FindInvert(var1) Then mVar1 = "." & Parameter(idx).OpCode Else mVar1 = "_" & Parameter(idx).OpCode
        Else
            mVar1 = "_" & FindTemp(var1)
        End If

        idx = FindIndexID(var2)
        If idx <> -1 Then
            If FindInvert(var2) Then mVar2 = "." & Parameter(idx).OpCode Else mVar2 = "_" & Parameter(idx).OpCode
        Else
            mVar2 = "_" & FindTemp(var2)
        End If

        Select Case Trim(operand)
            Case "+" : mOperand = "T" ' " || "
            Case "*" : mOperand = "K" ' " && "
            Case Else : mOperand = operand
        End Select
        'Opcode = mResult & " = " & mVar1 & mOperand & mVar2 & ";" & vbCrLf
        Opcode = mOperand & mVar1 & mVar2 & mResult
        Return Opcode
    End Function

    Private Function MakeOpcode(ByVal result As String, ByVal var1 As String, ByVal var2 As String, ByVal operand As String) As String
        Dim Opcode As String = ""
        Dim mResult As String = ""
        Dim mVar1 As String = ""
        Dim mVar2 As String = ""
        Dim mOperand As String = ""
        Dim idx As Integer = 0

        idx = FindIndexID(result)
        If idx <> -1 Then
            If FindInvert(result) Then mResult = "." & Parameter(idx).OpCode Else mResult = Parameter(idx).OpCode
        Else
            mResult = "_" & FindTemp(result)
        End If

        idx = FindIndexID(var1)
        If idx <> -1 Then
            If FindInvert(var1) Then mVar1 = "." & Parameter(idx).OpCode Else mVar1 = "_" & Parameter(idx).OpCode
        Else
            mVar1 = "_" & FindTemp(var1)
        End If

        idx = FindIndexID(var2)
        If idx <> -1 Then
            If FindInvert(var2) Then mVar2 = "." & Parameter(idx).OpCode Else mVar2 = "_" & Parameter(idx).OpCode
        Else
            mVar2 = "_" & FindTemp(var2)
        End If

        Select Case Trim(operand)
            Case "+" : mOperand = "||"
            Case "*" : mOperand = "&&"
            Case Else : mOperand = operand
        End Select

        Opcode = mResult & "=" & mVar1 & mOperand & mVar2 & ";" '& vbCrLf
        Return Opcode
    End Function

    Private Function MakeGeneralTimerOpcode(ByVal result As String) As String
        Dim OpCode As String = ""
        Dim mResult As String = ""
        Dim CountTimer As String = ""
        Dim TimeDelay As String = ""
        Dim idx As Integer = 0

        idx = FindIndexID(result)
        If idx <> -1 Then
            If FindInvert(result) Then mResult = "." & Parameter(idx).OpCode Else mResult = Parameter(idx).OpCode
        Else
            mResult = FindTemp(result)
        End If

        For i As Integer = 0 To IdxTime - 1
            If result = TimeList(i).varresult Then
                CountTimer = TimeList(i).countAddress
                TimeDelay = TimeList(i).overflow.ToString
                If Len(TimeDelay) = 1 Then
                    TimeDelay = "0" & TimeDelay
                ElseIf Len(TimeDelay) = 2 Then
                    TimeDelay = TimeDelay
                End If
            End If
        Next
        OpCode = "W" & CountTimer & TimeDelay & mResult
        Return OpCode
    End Function

    Private Function MakeTimerOpcode(ByVal tempTime As String) As String
        Dim opcode As String = ""
        Dim mTempTime As String = ""
        Dim countTime As String = ""
        For i As Integer = 0 To IdxTime - 1
            If tempTime = TimeList(i).varresult Then
                mTempTime = TimeList(i).tempAddress
                countTime = TimeList(i).countAddress
            End If
        Next
        'opcode = vbCrLf & "Z" & mTempTime & countTime
        opcode = "Z" & mTempTime & countTime
        Return opcode
    End Function
#End Region

    Public Sub ParseEquation(ByVal result As String, ByVal source As String, ByVal type As eEquationType, ByVal pathBERC As String, ByVal pathTERC As String)
        Dim bLeft As Boolean = False
        Dim bRight As Boolean = False
        Dim str As String = ""

        IdxBranch = 0 : ReDim Branch(IdxBranch)
        Dim iTemp As ULong = 0 : ReDim Temp(iTemp)
        Dim mNode As New ExpressionNode(source)

        If UBound(Branch) > 2 Then
            For i As ULong = 0 To IdxBranch - 1
                If Branch(i).Left <> "" And Branch(i).Operand <> "" And Branch(i).Right <> "" Then
                    If CheckParenthesis(Branch(i).Left) Then Branch(i).Left = RemoveParenthesis(Branch(i).Left)
                    If CheckParenthesis(Branch(i).Right) Then Branch(i).Right = RemoveParenthesis(Branch(i).Right)
                    Temp(iTemp) = Branch(i)
                    iTemp += 1 : ReDim Preserve Temp(iTemp)
                End If
            Next

            Dim Equation(0) As String
            Dim iEquation As ULong = 0
            Dim TempEquation(0) As String
            Dim iTempEquation As ULong = 0

            ReDim TempEquation(iTempEquation)
            ReDim Equation(iEquation)
            MaxTemp = 0
            Equation(0) = Temp(0).Left & Temp(0).Operand & Temp(0).Right
            If iTemp = 1 Then
                TempEquation(0) = result & " = " & Temp(0).Left & Temp(0).Operand & Temp(0).Right
                If type = eEquationType.BOOL Then
                    str = MakeOpcodeRabbit(result, Temp(0).Left, Temp(0).Right, Temp(0).Operand, type) ' & vbCrLf
                    saveFile(pathBERC, str)
                ElseIf type = eEquationType.TIMER Then
                    str = MakeGeneralTimerOpcode(result) '& vbCrLf
                    saveFile(pathBERC, str)
                    str = MakeOpcodeRabbit(result, Temp(0).Left, Temp(0).Right, Temp(0).Operand, type) & vbCrLf
                    str &= MakeTimerOpcode(result) '& vbCrLf
                    saveFile(pathTERC, str)
                End If
            Else
                TempEquation(0) = "temp" & CStr(iTempEquation) & " = " & Temp(0).Left & Temp(0).Operand & Temp(0).Right
                If type = eEquationType.BOOL Then
                    str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(0).Left, Temp(0).Right, Temp(0).Operand, type)
                    saveFile(pathBERC, str)
                ElseIf type = eEquationType.TIMER Then
                    str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(0).Left, Temp(0).Right, Temp(0).Operand, type)
                    saveFile(pathTERC, str)
                End If
            End If
            'Me.fctbEquation.Text &= TempEquation(0) & ";" & vbCrLf
            If MaxTemp > iTempEquation Then MaxTemp = MaxTemp Else MaxTemp = iTempEquation
            For i As ULong = 1 To iTemp - 1
                bLeft = GetOperator(Temp(i).Left)
                bRight = GetOperator(Temp(i).Right)
                If bLeft = False And bRight = False Then
                    iEquation += 1 : ReDim Preserve Equation(iEquation)
                    iTempEquation += 1 : ReDim Preserve TempEquation(iTempEquation)
                    Equation(iEquation) = Temp(i).Left & Temp(i).Operand & Temp(i).Right
                    If i = iTemp - 1 Then
                        TempEquation(iTempEquation) = result & " = " & Temp(i).Left & Temp(i).Operand & Temp(i).Right
                        If type = eEquationType.BOOL Then
                            str = MakeOpcodeRabbit(result, Temp(i).Left, Temp(i).Right, Temp(i).Operand, type) '& vbCrLf
                            saveFile(pathBERC, str)
                        ElseIf type = eEquationType.TIMER Then
                            str = MakeGeneralTimerOpcode(result) '& vbCrLf
                            saveFile(pathBERC, str)
                            str = MakeOpcodeRabbit(result, Temp(i).Left, Temp(i).Right, Temp(i).Operand, type) & vbCrLf
                            str &= MakeTimerOpcode(result) ' & vbCrLf
                            saveFile(pathTERC, str)
                        End If
                    Else
                        TempEquation(iTempEquation) = "temp" & CStr(iTempEquation) & " = " & Temp(i).Left & Temp(i).Operand & Temp(i).Right
                        If type = eEquationType.BOOL Then
                            str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(i).Left, Temp(i).Right, Temp(i).Operand, type)
                            saveFile(pathBERC, str)
                        ElseIf type = eEquationType.TIMER Then
                            str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(i).Left, Temp(i).Right, Temp(i).Operand, type)
                            saveFile(pathTERC, str)
                        End If
                    End If
                    'Me.fctbEquation.Text &= TempEquation(iTempEquation) & ";" & vbCrLf
                    If MaxTemp > iTempEquation Then MaxTemp = MaxTemp Else MaxTemp = iTempEquation
                ElseIf bLeft And bRight = False Then
                    For j As ULong = 0 To iEquation
                        If Equation(j) = Temp(i).Left Then
                            If i = iTemp - 1 Then
                                TempEquation(iTempEquation) = result & " = " & Temp(i).Right & Temp(i).Operand & "temp" & CStr(iTempEquation)
                                If type = eEquationType.BOOL Then
                                    str = MakeOpcodeRabbit(result, Temp(i).Right, "temp" & CStr(iTempEquation), Temp(i).Operand, type) '& vbCrLf
                                    saveFile(pathBERC, str)
                                ElseIf type = eEquationType.TIMER Then
                                    str = MakeGeneralTimerOpcode(result) '& vbCrLf
                                    saveFile(pathBERC, str)
                                    str = MakeOpcodeRabbit(result, Temp(i).Right, "temp" & CStr(iTempEquation), Temp(i).Operand, type) & vbCrLf
                                    str &= MakeTimerOpcode(result) '& vbCrLf
                                    saveFile(pathTERC, str)
                                End If
                            Else
                                TempEquation(iTempEquation) = "temp" & CStr(iTempEquation) & " = " & Temp(i).Right & Temp(i).Operand & "temp" & CStr(iTempEquation)
                                If type = eEquationType.BOOL Then
                                    str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(i).Right, "temp" & CStr(iTempEquation), Temp(i).Operand, type)
                                    saveFile(pathBERC, str)
                                ElseIf type = eEquationType.TIMER Then
                                    str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(i).Right, "temp" & CStr(iTempEquation), Temp(i).Operand, type)
                                    saveFile(pathTERC, str)
                                End If
                            End If
                            'Me.fctbEquation.Text &= TempEquation(iTempEquation) & ";" & vbCrLf
                        End If
                    Next
                    Equation(iEquation) = Temp(i).Left & Temp(i).Operand & Temp(i).Right
                    If MaxTemp > iTempEquation Then MaxTemp = MaxTemp Else MaxTemp = iTempEquation
                ElseIf bLeft = False And bRight Then
                    For j As ULong = 0 To iEquation
                        If Equation(j) = Temp(i).Right Then
                            If i = iTemp - 1 Then
                                TempEquation(iTempEquation) = result & " = " & Temp(i).Left & Temp(i).Operand & "temp" & CStr(iTempEquation)
                                If type = eEquationType.BOOL Then
                                    str = MakeOpcodeRabbit(result, Temp(i).Left, "temp" & CStr(iTempEquation), Temp(i).Operand, type) '& vbCrLf
                                    saveFile(pathBERC, str)
                                ElseIf type = eEquationType.TIMER Then
                                    str = MakeGeneralTimerOpcode(result) '& vbCrLf
                                    saveFile(pathBERC, str)
                                    str = MakeOpcodeRabbit(result, Temp(i).Left, "temp" & CStr(iTempEquation), Temp(i).Operand, type) & vbCrLf
                                    str &= MakeTimerOpcode(result) '& vbCrLf
                                    saveFile(pathTERC, str)
                                End If
                            Else
                                TempEquation(iTempEquation) = "temp" & CStr(iTempEquation) & " = " & Temp(i).Left & Temp(i).Operand & "temp" & CStr(iTempEquation)
                                If type = eEquationType.BOOL Then
                                    str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(i).Left, "temp" & CStr(iTempEquation), Temp(i).Operand, type)
                                    saveFile(pathBERC, str)
                                ElseIf type = eEquationType.TIMER Then
                                    str = MakeOpcodeRabbit("temp" & CStr(iTempEquation), Temp(i).Left, "temp" & CStr(iTempEquation), Temp(i).Operand, type)
                                    saveFile(pathTERC, str)
                                End If
                            End If
                            'Me.fctbEquation.Text &= TempEquation(iTempEquation) & ";" & vbCrLf
                        End If
                    Next
                    Equation(iEquation) = Temp(i).Left & Temp(i).Operand & Temp(i).Right
                    If MaxTemp > iTempEquation Then MaxTemp = MaxTemp Else MaxTemp = iTempEquation
                ElseIf bLeft And bRight Then
                    Dim lft As Boolean = False
                    Dim rht As Boolean = False
                    Dim idxLft As ULong = 0
                    Dim idxRht As ULong = 0
                    Dim index As ULong = 0
                    For j As ULong = 0 To iEquation
                        If Equation(j) = Temp(i).Left Then idxLft = j : lft = True : Exit For
                    Next
                    For j As ULong = 0 To iEquation
                        If Equation(j) = Temp(i).Right Then idxRht = j : rht = True : Exit For
                    Next
                    If rht And lft Then
                        If idxLft > idxRht Then index = idxRht Else index = idxLft
                        Equation(index) = Temp(i).Left & Temp(i).Operand & Temp(i).Right
                        If i = iTemp - 1 Then
                            TempEquation(index) = result & " = " & "temp" & CStr(idxRht) & Temp(i).Operand & "temp" & CStr(idxLft)
                            If type = eEquationType.BOOL Then
                                str = MakeOpcodeRabbit(result, "temp" & CStr(idxRht), "temp" & CStr(idxLft), Temp(i).Operand, type) '& vbCrLf
                                saveFile(pathBERC, str)
                            ElseIf type = eEquationType.TIMER Then
                                str = MakeGeneralTimerOpcode(result) '& vbCrLf
                                saveFile(pathBERC, str)
                                str = MakeOpcodeRabbit(result, "temp" & CStr(idxRht), "temp" & CStr(idxLft), Temp(i).Operand, type) & vbCrLf
                                str &= MakeTimerOpcode(result) '& vbCrLf
                                saveFile(pathTERC, str)
                            End If
                        Else
                            TempEquation(index) = "temp" & CStr(index) & " = " & "temp" & CStr(idxRht) & Temp(i).Operand & "temp" & CStr(idxLft)
                            If type = eEquationType.BOOL Then
                                str = MakeOpcodeRabbit("temp" & CStr(index), "temp" & CStr(idxRht), "temp" & CStr(idxLft), Temp(i).Operand, type)
                                saveFile(pathBERC, str)
                            ElseIf type = eEquationType.TIMER Then
                                str = MakeOpcodeRabbit("temp" & CStr(index), "temp" & CStr(idxRht), "temp" & CStr(idxLft), Temp(i).Operand, type)
                                saveFile(pathTERC, str)
                            End If
                        End If
                        'Me.fctbEquation.Text &= TempEquation(index) & ";" & vbCrLf
                        If MaxTemp > iTempEquation Then MaxTemp = MaxTemp Else MaxTemp = iTempEquation
                        iEquation -= 1 : ReDim Preserve Equation(iEquation)
                        iTempEquation -= 1 : ReDim Preserve TempEquation(iTempEquation)
                    End If
                End If
            Next
        Else
            ' FOR SINGLE EQUATION LIKE -> BOOL A = B 
            Dim var1 As String = RemoveParenthesis(source)
            If type = eEquationType.BOOL Then
                str = MakeOpcodeEqual(result, var1, type) '& vbCrLf
                saveFile(pathBERC, str)
            ElseIf type = eEquationType.TIMER Then
                str = MakeGeneralTimerOpcode(result) '& vbCrLf
                saveFile(pathBERC, str)
                str = MakeOpcodeEqual(result, var1, type) & vbCrLf
                str &= MakeTimerOpcode(result)
                saveFile(pathTERC, str)
            End If
        End If


    End Sub

    Private Sub saveFile(ByVal path As String, ByVal data As String)
        Dim sw As StreamWriter
        If File.Exists(path) Then
            sw = File.AppendText(path)
            sw.WriteLine(data)
        Else
            sw = File.CreateText(path)
            sw.WriteLine(data)
        End If
        sw.Flush()
        sw.Close()
    End Sub

End Class
