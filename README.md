# Personal data encryption
___
![alt text](http://i67.tinypic.com/2lq0xx.jpg "Logo Title Text 1")
___
#### The encoding process of how the lines and the dots are made
##### Quadratic shape algorithm
```
Sub Drowsquare(X As Integer, Y As Integer)
        For i = X To X + 5
            For j = Y To Y + 5
                pic.SetPixel(i, j, Color.Red)
            Next
        Next
    End Sub
```
##### Rectangle shape algorithm
```
Sub DrowRectangle(X As Integer, Y As Integer)
        For i = X To X + 20
            For j = Y To Y + 5
                pic.SetPixel(i, j, Color.Red)
            Next
        Next
    End Sub
```
##### Then we will have a function named Create Code that will receive the ID and convert it into a code
```
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
```
##### In the project there were only two keys. There are two types of encryption depending on the key. If the key is equal to one, we encrypt the first pattern as follows
```
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
```
##### If the number equals 1, draw 3 rectangles and then two squares. If the number equals 2, draw a rectangle, then a square, then a rectangle, then a square, then a rectangle, and so on for the rest of the numbers in the first pattern. If the pattern changes, the shapes will change for the number
___
#### The dncoding process of how the lines and the dots are decoded
##### All we need to do it to determine where the code is, and that can be done by easily by giving the pattern a colour, in this case it is red. It can be done in two steps.
##### First the algorithim will change every other colour to black and leave only the red colour.
![alt text](http://i68.tinypic.com/2ccw0i.jpg "Logo Title Text 1")
##### And to easily check we use this code
```
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
```
##### Second the algorthim of capturing the corners of each rectangle and square
##### We have to read every pixel in the picture to determine if the if it's black or read, if the given data is 0 then it's black, if the given data is 1 then it's red
##### For example if our pixel is called P then all the other pixels around it will look something like this
|PUL|PU|PUR|
|PL|P(Red colour)|PR|
|PDL|PD|PDR|
##### So P is the pixel we're reading right now and PU is the one on the top of it, PD is the one down of it and so on
##### If we want to find the left top corner of a square our table should look like this
|PUL|PU|PUR|
|PL|P(Red colour)|PR(Red colour)|
|PDL|PD(Red colour)|PDR(Red colour)|
##### We depend on this table in our code to find the location of the corner 
|Tables| Are|Cool|
| ------------- |:-------------:| -----:|
|X-1,Y-1|X,Y-1|X+1,Y-1|
|X-1,Y|X,Y|X+1,Y|
|X-1,Y|X,Y+1|X+1,Y+1|
```
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
```
##### And the same goes for all other corners
##### After we find the shape of each pattern we can then translate it into a number and we can use this code to find the orignal ID in our database
```
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
```
