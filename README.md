# Personal data encryption
___
![alt text](http://i67.tinypic.com/2lq0xx.jpg "Logo Title Text 1")
___
#### The coding process of how the lines and the dots are made
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
