﻿Imports System.Data.OleDb
Imports System.Drawing
Imports System.Data
Imports System.Runtime.InteropServices
Imports Microsoft.Win32

Class MainWindow
    Dim conn As New OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=CodeProjectDatabase.accdb")
    Dim cmd As New OleDbCommand("", conn)
    Dim pic As Bitmap
    Dim Name As String, Hight As Integer, PhoneNumber As String, Email As String, Gender As String, Birthdate As Date, bytImage() As Byte, ProfileImage As Bitmap, Scanerror As Boolean = True

    Class code
        Public CodeShape(5) As shape
    End Class

    Class shape
        Public X, X1, Y, Y1 As Integer
        Public w, h As Integer
        Public Function IsSquare() As Char
            w = X1 - X : h = Y1 - Y
            If w = h Then
                IsSquare = "1"
            Else
                IsSquare = "0"
            End If
        End Function
    End Class

    Sub ScanCode()
        Try
            Dim img As Bitmap = pic
            Dim w As Integer = img.Width : Dim h As Integer = img.Height
            Dim Red, Green, Blue, leftP, rightP, upP, downP, pixel, rupP, lupP, rdownP, ldownP, c, d As Integer
            c = 0 : d = 0 ' 

            Dim sh(250) As shape

            For i = 0 To 250
                sh(i) = New shape
            Next

            For j = 1 To h - 2
                For i = 1 To w - 2
                    Red = img.GetPixel(i, j).R : Blue = img.GetPixel(i, j).B : Green = img.GetPixel(i, j).G

                    If Red > 200 And Green < 50 And Blue < 50 Then
                        img.SetPixel(i, j, Color.FromArgb(Red, Green, Blue))
                    Else
                        img.SetPixel(i, j, Color.FromArgb(0, 0, 0))
                    End If
                Next
            Next

            For j = 1 To h - 2
                For i = 1 To w - 2

                    pixel = img.GetPixel(i, j).R

                    If pixel <> 0 Then

                        leftP = img.GetPixel(i - 1, j).R
                        rightP = img.GetPixel(i + 1, j).R
                        upP = img.GetPixel(i, j - 1).R
                        downP = img.GetPixel(i, j + 1).R
                        rupP = img.GetPixel(i + 1, j - 1).R
                        lupP = img.GetPixel(i - 1, j - 1).R
                        rdownP = img.GetPixel(i + 1, j + 1).R
                        ldownP = img.GetPixel(i - 1, j + 1).R

                        If leftP = 0 And upP = 0 And lupP = 0 And rupP = 0 Then
                            sh(c).X = i
                            sh(c).Y = j
                            c += 1

                        End If


                        If rightP = 0 And downP = 0 And rdownP = 0 And ldownP = 0 Then
                            sh(d).X1 = i
                            sh(d).Y1 = j
                            d += 1
                        End If


                    End If
                Next
            Next

            Dim leng As Integer = c / 5

            Dim TheCode(leng) As code
            Dim CodeToStr(leng) As String
            Dim n As Integer = 0
            For i = 0 To leng - 1
                TheCode(i) = New code
                For j = 0 To 4
                    TheCode(i).CodeShape(j) = sh(n)
                    CodeToStr(i) += TheCode(i).CodeShape(j).IsSquare()
                    n += 1
                Next
            Next

            Dim TheDecodedResult As String = ""
            Dim type As Integer = DecodePattern(CodeToStr(2))
            If type = 1 Then
                For i = 0 To leng - 1
                    TheDecodedResult += DecodeType1(CodeToStr(i))
                Next
            End If
            If type = 2 Then
                For i = 0 To leng - 1
                    TheDecodedResult += DecodeType2(CodeToStr(i))
                Next
            End If
            FillDGV("SELECT * FROM PersonalInfo WHERE ID =" & TheDecodedResult)
            Scanerror = False
        Catch ex As Exception

            MsgBox("The scan was not successful because of the following
           1. You may not have a card to scan (card must be opened first)
           2. The code may not be clear or fake
           3. No such card is registered in the database ")


        End Try



    End Sub

    Function DecodePattern(CodeToStr As String) As String
        Select Case CodeToStr
            Case "10011"
                DecodePattern = "1"
            Case "01110"
                DecodePattern = "2"
        End Select
        Return DecodePattern
    End Function
    Function DecodeType2(CodeToStr As String) As String
        Select Case CodeToStr
            Case "10100"
                DecodeType2 = "1"
            Case "00111"
                DecodeType2 = "2"
            Case "11001"
                DecodeType2 = "3"
            Case "11110"
                DecodeType2 = "4"
            Case "01011"
                DecodeType2 = "5"
            Case "00001"
                DecodeType2 = "6"
            Case "10110"
                DecodeType2 = "7"
            Case "10101"
                DecodeType2 = "8"
            Case "11111"
                DecodeType2 = "9"
            Case "01101"
                DecodeType2 = "0"
        End Select
    End Function
    Function DecodeType1(CodeToStr As String) As String
        Select Case CodeToStr
            Case "00011"
                DecodeType1 = "1"
            Case "01010"
                DecodeType1 = "2"
            Case "10111"
                DecodeType1 = "3"
            Case "10010"
                DecodeType1 = "4"
            Case "11100"
                DecodeType1 = "5"
            Case "00110"
                DecodeType1 = "6"
            Case "11010"
                DecodeType1 = "7"
            Case "00101"
                DecodeType1 = "8"
            Case "11101"
                DecodeType1 = "9"
            Case "00010"
                DecodeType1 = "0"
        End Select
    End Function

    Sub Drowsquare(X As Integer, Y As Integer)
        For i = X To X + 5
            For j = Y To Y + 5
                pic.SetPixel(i, j, Color.Red)
            Next
        Next
    End Sub

    Sub DrowRectangle(X As Integer, Y As Integer)
        For i = X To X + 20
            For j = Y To Y + 5
                pic.SetPixel(i, j, Color.Red)
            Next
        Next
    End Sub

    Sub CreatCode(RandomID As Integer)
        'pic = New Bitmap(1000, 1500)

        Dim RandomPattern As New Random
        Dim Pattren As Integer = RandomPattern.Next(1, 3)
        'PictureBox1.Image = My.Resources.Untitled_22
        pic = My.Resources.Untitled_22

        Dim X, Y, oldX, i As Integer : Y = 105 : oldX = 95 : i = 1
        Dim str As String = RandomID
        If str <> "" Then str = str.Insert(2, Pattren)

        For Each c As Char In str

            X = oldX
            If i = 3 Then
                Select Case Pattren
                    Case "1"
                        Drowsquare(X, Y)
                        X += 11
                        DrowRectangle(X, Y)
                        X += 27
                        DrowRectangle(X, Y)
                        X += 27
                        Drowsquare(X, Y)
                        X += 11
                        Drowsquare(X, Y)
                    Case "2"
                        DrowRectangle(X, Y)
                        X += 27
                        Drowsquare(X, Y)
                        X += 11
                        Drowsquare(X, Y)
                        X += 11
                        Drowsquare(X, Y)
                        X += 11
                        DrowRectangle(X, Y)
                End Select
            Else
                If Pattren = 1 Then
                    Select Case c
                        Case "1"
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)

                        Case "2"
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                        Case "3"
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                        Case "4"
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                        Case "5"
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                        Case "6"
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                        Case "7"
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                        Case "8"
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                        Case "9"
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                        Case "0"
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                    End Select
                End If
                If Pattren = 2 Then
                    Select Case c
                        Case "1"
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)

                        Case "2"
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                        Case "3"
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                        Case "4"
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                        Case "5"
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                        Case "6"
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                        Case "7"
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                        Case "8"
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                        Case "9"
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                        Case "0"
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                            X += 11
                            Drowsquare(X, Y)
                            X += 11
                            DrowRectangle(X, Y)
                            X += 27
                            Drowsquare(X, Y)
                    End Select
                End If
            End If
            i += 1
            Y += 10
            If Y < 160 Then oldX += 5
            If Y >= 165 Then oldX -= 5
        Next
        pic.Save("Cards\" + Name + " Card.png", Imaging.ImageFormat.Png)
        PictureBox1.Source = convert_Image_To_ImageSource(pic)
    End Sub



    Public Function convert_Image_To_ImageSource(ByVal image As Image, Optional w As Integer = 0, Optional h As Integer = 32) As System.Windows.Media.ImageSource
        Try
            Dim bmp As Bitmap
            '  
            '  
            If h > 0 And w > 0 Then
                bmp = New Bitmap(image, w, h)
            Else
                bmp = New Bitmap(image, image.Width, image.Height)
            End If

            Return Me.convert_Image_To_ImageSource(Me.get_picture_buffer(bmp))
        Catch ex As Exception
            MsgBox("error")
            Return Nothing
        End Try
    End Function



    Public Function convert_Image_To_ImageSource(ByVal Bytes() As Byte) As System.Windows.Media.ImageSource
        Try
            Dim ImageStream As New IO.MemoryStream
            '  
            If Bytes Is Nothing Then
                Return Nothing
            End If
            '  
            If Bytes.Length = 0 Then
                Return Nothing
            End If
            '  
            If Bytes.GetUpperBound(0) > 0 Then
                ImageStream = New IO.MemoryStream(Bytes)
                Dim Converter As New System.Windows.Media.ImageSourceConverter
                Return Converter.ConvertFrom(ImageStream)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox("error")
            Return Nothing
        End Try
    End Function

    Public Function get_picture_buffer(ByVal img As Image, Optional ByVal imgWidth As Integer = 0, Optional ByVal imgHeight As Integer = 0) As Byte()
        Try
            Dim streamPicture As New System.IO.MemoryStream
            Dim bmp As System.Drawing.Bitmap

            If (img Is Nothing) Then
                Return Nothing
            End If

            If (imgWidth <= 0) Then
                imgWidth = img.Width
            End If
            '  
            '  
            If (imgHeight <= 0) Then
                imgHeight = img.Height
            End If
            bmp = New System.Drawing.Bitmap(img, imgWidth, imgHeight)
            bmp.Save(streamPicture, System.Drawing.Imaging.ImageFormat.Png)
            '  

            Return streamPicture.GetBuffer
        Catch ex As Exception
            MsgBox("error")
        End Try

    End Function

    Private Sub rectangle9_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles rectangle9.MouseLeftButtonDown
        Me.Close()
    End Sub

    Private Sub rectangle6_Copy_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectangle6_Copy.MouseDown
        ScanCode()
        If Scanerror = False Then
            Try
                Dim dr As DataRowView
                dr = Dt.Items(0)
                Namelabel.Content = dr.Row.Item(1)
                BirhdayLabel.Content = dr.Row.Item(5)
                GenderLabel.Content = dr.Row.Item(4)
                PhoneNumberLabel.Content = dr.Row.Item(2)
                EmailLabel.Content = dr.Row.Item(3)
                GetPictureFromDGV()
                Profileimg.Source = convert_Image_To_ImageSource(ProfileImage)
            Catch ex As Exception
                MsgBox("The scan was not successful because of the following
           1. You may not have a card to scan (card must be opened first)
           2. The code may not be clear or fake
           3. No such card is registered in the database ")
            End Try

        End If

    End Sub

    Private Sub rectangle11_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectangle11.MouseDown
        Try
            Dim myDialog As New OpenFileDialog()
            myDialog.Filter = "All Files|*.*|Image Files|*.jpg;*.gif;*.png;*.bmp"
            myDialog.ShowDialog()
            ProfileImage = New Bitmap(myDialog.FileName)
        Catch ex As Exception
            MsgBox("You didn't set an image")
            ProfileImage = My.Resources._5604653_200x130
        End Try

    End Sub

    Private Sub radioButton_Checked(sender As Object, e As RoutedEventArgs) Handles radioButton.Checked
        Gender = radioButton.Content
    End Sub

    Private Sub radioButton1_Checked(sender As Object, e As RoutedEventArgs) Handles radioButton1.Checked
        Gender = radioButton1.Content
    End Sub

    Function GetTable(SelectCommand As String) As DataTable
        Try
            Dim tbl As New DataTable
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.CommandText = SelectCommand
            tbl.Load(cmd.ExecuteReader())
            Return tbl
        Catch ex As Exception
            MsgBox(ex.Message)
            Return New DataTable
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Function

    Sub FillDGV(Optional SelectFill As String = "")
        If SelectFill = "" Then SelectFill = "SELECT * FROM PersonalInfo"
        Dt.DataContext = GetTable(SelectFill)

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        pic = My.Resources.Untitled_22
        ProfileImage = My.Resources._5604653_200x130
        PictureBox1.Source = convert_Image_To_ImageSource(pic)
        FillDGV()
    End Sub


    Private Sub rectangle33_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles rectangle33.MouseDown
        Dim r As Random = New Random
        Dim RandomID As Integer = r.Next(10000000, 999999999)
        AddDataToDatabase(RandomID)
        CreatCode(RandomID)
    End Sub

    Private Sub rectangle7_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles rectangle7.MouseLeftButtonDown
        Dim myDialog As New OpenFileDialog()
        myDialog.Filter = "All Files|*.*|Image Files|*.jpg;*.gif;*.png;*.bmp"
        myDialog.ShowDialog()
        PictureBox1.Source = New BitmapImage(New Uri(myDialog.FileName, UriKind.Absolute))
        pic = New Bitmap(myDialog.FileName)
    End Sub



    Private Sub AddDataToDatabase(ID As Integer)

        Try

            Name = textBox.Text
            Birthdate = Convert.ToDateTime(textBox_Copy.Text)
            PhoneNumber = textBox_Copy1.Text
            Email = textBox_Copy2.Text

            Dim ms As New System.IO.MemoryStream
            Dim bmpImage As Bitmap = New Bitmap(ProfileImage)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            bytImage = ms.ToArray()
            ms.Close()

            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO PersonalInfo (ID,FullName,PhoneNumber,Email,Gender,Birthdate,pic) 
            VALUES (" & ID & ", '" & Name & "','" & PhoneNumber & "' , '" & Email & "' , '" & Gender & "' , '" & Birthdate & "' , @image) "
            cmd.Parameters.AddWithValue("@image", bytImage)
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            MsgBox("Something went wrong during the data entry process. Please re-validate the fields again
don't forget to fill all fields")
        End Try


        FillDGV()
    End Sub

    Sub GetPictureFromDGV()
        Try
            Dim dr As DataRowView
            dr = Dt.Items(0)
            Dim lb() As Byte = dr.Row.Item(6)
            Dim lstr As New System.IO.MemoryStream(lb)
            ProfileImage = Image.FromStream(lstr)
            lstr.Close()
        Catch ex As Exception

        End Try

    End Sub

End Class
