Public Class binSearch

    Dim arr(1000000) As Double
    ' "arr" is the array that stores all the number values in sorted order

    Dim sz As Integer = 0
    ' "sz" is an integer variable that stores the size of array "arr"

    Dim x As Double
    ' "x" is a variable to store the value that has to be searched

    Dim val As Double
    ' "val" stores the input value that will be added to the array

    Dim posLow(100), posMid(100), posHigh(100) As Integer
    ' "posLow" is an array to store the position of "L" at each iteration of Binary Search

    Dim cnt As Integer = 0
    ' "cnt" the number iterations the "do while" loop ran to find "x"

    Dim temp As Integer = 0
    ' "temp" is temporary variable for sometimes use

    Dim brr(1000000) As String
    ' "brr" is the array that stores all the strings in sorted order

    Dim crr() As String
    ' "crr" array is used to read the input from file

    Dim type As Integer = -1
    ' Stores the type of input, if input is a real number then type=1, else in the case of string type=2

    Dim xString As String = ""
    ' "xString" is temporary string variable for sometimes use

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        ' "Double.TryParse(newVal.Text, val)" will return TRUE if the string newVal.Text is also a valid 
        ' representation of a double number and FALSE otherwise, in the case of TRUE it will also store 
        ' the double number corresponding to that string into double variable "val"

        If (Double.TryParse(newVal.Text, val) = True) And (type <> 2) Then
            ' If input is a real number

            type = 1

            If sz = 0 Then
                ' Trivial condition checked
                arr(sz) = val
                sz += 1         ' array size increases by 1

            ElseIf arr(sz - 1) <= val Then
                ' Array must be sorted, hence checking the sorting condition
                arr(sz) = val
                sz += 1         ' array size increases by 1

            Else
                ' User is informed about invalid input
                MessageBox.Show("Entered element disrupts the Sorted nature of array.", "INVALID INPUT")

            End If

        Else

            If (type = 1) Then
                ' User is informed about invalid input
                MessageBox.Show("Enter a Integer or a Real Number.", "INVALID INPUT")
            Else
                If (Double.TryParse(newVal.Text, val) = True) Then
                    ' User is informed about invalid input
                    MessageBox.Show("Enter a String.", "INVALID INPUT")
                Else
                    If sz = 0 Then
                        ' Trivial condition checked
                        brr(sz) = newVal.Text
                        type = 2
                        sz += 1         ' array size increases by 1

                    ElseIf String.Compare(brr(sz - 1), newVal.Text) <= 0 Then
                        ' Array must be sorted, hence checking the sorting condition
                        brr(sz) = newVal.Text
                        type = 2
                        sz += 1         ' array size increases by 1

                    Else
                        ' User is informed about invalid input
                        MessageBox.Show("Entered element disrupts the Sorted nature of array.", "INVALID INPUT")

                    End If
                End If
            End If

        End If

        arrSize.Text = sz.ToString()    'Printing the new array size

        ' Information about previous states is no longer required after the addition of a new element to array
        newVal.Text = ""
        xFind.Text = ""
        result.Text = ""
        arrStatus.Text = ""
        For i As Integer = 0 To (cnt - 1)
            posLow(i) = 0
            posMid(i) = 0
            posHigh(i) = 0
        Next
        cnt = 0
        temp = 0
        LowHighPos.Text = ""

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        ' Clear Button makes every integer or double variable as zero and strings as empty string 
        For i As Integer = 0 To (sz - 1)
            arr(i) = 0
            brr(i) = ""
        Next
        sz = 0
        newVal.Text = ""
        arrSize.Text = ""
        xFind.Text = ""
        result.Text = ""
        arrStatus.Text = ""
        For i As Integer = 0 To (cnt - 1)
            posLow(i) = 0
            posMid(i) = 0
            posHigh(i) = 0
        Next
        cnt = 0
        temp = 0
        type = -1
        LowHighPos.Text = ""
        lblFile.Text = "No File Selected"

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If xFind.Text = "" Then
            ' User is informed about invalid input
            MessageBox.Show("Enter the Element to be searched.", "ERROR")

        ElseIf Double.TryParse(xFind.Text, val) = False Then
            If (type = 1) Then
                ' User is informed about invalid input
                MessageBox.Show("Enter a String.", "INVALID INPUT")
            Else
                ' Standard Binary Search Algorithm
                xString = xFind.Text
                Dim low As Integer = 0, high As Integer = sz - 1
                Dim mid As Integer

                ' Forgetting the information about the previous states 
                For i As Integer = 0 To (cnt - 1)
                    posLow(i) = 0
                    posMid(i) = 0
                    posHigh(i) = 0
                Next
                cnt = 0
                temp = 0
                LowHighPos.Text = ""
                result.Text = "NOT FOUND"

                Do While (low < high)

                    mid = Fix((low + high) / 2)

                    ' Storing the value of low, mid and high during each iteration of Bianry Search
                    posLow(cnt) = low
                    posMid(cnt) = mid
                    posHigh(cnt) = high
                    cnt += 1

                    If String.Compare(brr(mid), xString) = 0 Then
                        ' If xString matches with middle element, then we make low > high, so that the loop breaks
                        low = mid + 1
                        high = mid - 1

                    ElseIf String.Compare(brr(mid), xString) > 0 Then
                        'If xString < brr(mid) element, then xString can only lie in left half subarray after the mid element.
                        high = mid - 1

                    Else
                        'If xString > brr(mid) element, then xString can only lie in right half subarray after the mid element.
                        low = mid + 1

                    End If

                Loop

                ' last iteration
                mid = Fix((low + high) / 2)
                If String.Compare(brr(mid), xString) = 0 Then

                    posLow(cnt) = mid
                    posMid(cnt) = mid
                    posHigh(cnt) = mid
                    cnt += 1
                    result.Text = "FOUND"

                End If
            End If

        ElseIf sz = 0 Then
            ' User is informed about invalid input
            MessageBox.Show("Array is empty right now.", "ERROR")

        Else
            ' Standard Binary Search Algorithm
            x = val
            Dim low As Integer = 0, high As Integer = sz - 1
            Dim mid As Integer

            ' Forgetting the information about the previous states 
            For i As Integer = 0 To (cnt - 1)
                posLow(i) = 0
                posMid(i) = 0
                posHigh(i) = 0
            Next
            cnt = 0
            temp = 0
            LowHighPos.Text = ""
            result.Text = "NOT FOUND"

            Do While (low < high)

                mid = Fix((low + high) / 2)

                ' Storing the value of low, mid and high during each iteration of Bianry Search
                posLow(cnt) = low
                posMid(cnt) = mid
                posHigh(cnt) = high
                cnt += 1

                If arr(mid) = x Then
                    ' If x matches with middle element, then we make low > high, so that the loop breaks
                    low = mid + 1
                    high = mid - 1

                ElseIf arr(mid) > x Then
                    'If x < arr(mid) element, then x can only lie in left half subarray after the mid element.
                    high = mid - 1

                Else
                    'If x > arr(mid) element, then x can only lie in right half subarray after the mid element.
                    low = mid + 1

                End If

            Loop

            ' last iteration
            mid = Fix((low + high) / 2)
            If arr(mid) = x Then

                posLow(cnt) = mid
                posMid(cnt) = mid
                posHigh(cnt) = mid
                cnt += 1
                result.Text = "FOUND"

            End If

            End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        ' Complete array output
        arrStatus.Text = ""
        If type <> 2 Then
            For i As Integer = 0 To (sz - 1)
                arrStatus.Text += arr(i).ToString()
                arrStatus.Text += vbTab
            Next
        Else
            For i As Integer = 0 To (sz - 1)
                arrStatus.Text += brr(i)
                arrStatus.Text += vbTab
            Next
        End If

        LowHighPos.Text = ""

        If sz = 0 Then
            ' User is informed about invalid operation
            MessageBox.Show("Array is empty.", "ERROR")

        ElseIf sz = 1 Then

        ElseIf cnt = 0 Then
            ' User is informed about invalid operation
            MessageBox.Show("First Search an element.", "ERROR")

        Else
            ' Printing L, M, H 
            For i As Integer = 0 To (sz - 1)
                ' temp = current iteration of binary search
                If posLow(temp) = i Then
                    LowHighPos.Text += "L"
                End If
                If posMid(temp) = i Then
                    LowHighPos.Text += "M"
                End If
                If posHigh(temp) = i Then
                    LowHighPos.Text += "H"
                End If
                LowHighPos.Text += vbTab
            Next

            ' "cnt" is the total number of iterations of binary search
            If temp < cnt - 1 Then
                temp += 1
            End If

        End If

    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        ' Calling for CLEAR BUTTON
        btnClear_Click(sender, e)

        OpenFileDialog1.Title = "SELECT TEXT FILE"
        OpenFileDialog1.ShowDialog()
        ' Storing the name of input file in lblFile.Text
        lblFile.Text = OpenFileDialog1.FileName

        If lblFile.Text.Substring(lblFile.Text.Length - 4, 4) = ".txt" Then
            ' Checking if the file is a text file or not

            crr = IO.File.ReadAllLines(lblFile.Text)
            ' "crr" now stores all data of input file, with each line of input file as a separate string in "crr" 

            ' Checking the type of inputs given
            sz = UBound(crr) + 1
            If sz <> 0 Then
                If Double.TryParse(crr(0), val) = True Then
                    type = 1
                Else
                    type = 2
                End If
            End If
            sz = 0

            Dim wrong As Integer = 0
            ' If wrong =1, then the inputs are invalid

            For i As Integer = 0 To UBound(crr)
                ' Running a loop from staring to the end of the array "crr"

                ' If the inputs are invalid, break the FOR loop
                If wrong = 1 Then
                    Exit For
                End If

                ' This is same as ADD BUTTON
                If type <> 2 Then
                    If Double.TryParse(crr(i), val) = True Then

                        If sz = 0 Then
                            arr(sz) = val
                            sz += 1
                        ElseIf arr(sz - 1) <= val Then
                            arr(sz) = val
                            sz += 1
                        Else
                            MessageBox.Show("Enter sorted array.", "INVALID INPUT")
                            wrong = 1
                        End If
                    Else
                        MessageBox.Show("Enter Integers or Real Numbers only.", "INVALID INPUT")
                        wrong = 1
                    End If
                Else
                    If Double.TryParse(crr(i), val) = False Then

                        If sz = 0 Then
                            brr(sz) = crr(i)
                            sz += 1
                        ElseIf String.Compare(brr(sz - 1), crr(i)) <= 0 Then
                            brr(sz) = crr(i)
                            sz += 1
                        Else
                            MessageBox.Show("Enter sorted array.", "INVALID INPUT")
                            wrong = 1
                        End If
                    Else
                        MessageBox.Show("Enter strings only.", "INVALID INPUT")
                        wrong = 1
                    End If
                End If
            Next

            ' Updating the size of "arr"
            arrSize.Text = sz.ToString()

            If wrong = 1 Then
                ' Since, wrong =1, so the there is some invalid input, so we call CLEAR BUTTON to bring the application back to intial states
                btnClear_Click(sender, e)

            End If

        Else
            ' User is informed about invalid format of file, and the application is brought to its intial staes
            MessageBox.Show("Select a Text file.", "ERROR")
            btnClear_Click(sender, e)
        End If

    End Sub

End Class
