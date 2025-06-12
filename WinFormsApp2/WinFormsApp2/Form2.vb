Public Class Form2
    Public Shared Students As New Dictionary(Of String, Dictionary(Of String, List(Of String)))()
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Level 2")
        ComboBox1.Items.Add("Level 3")


        ComboBox1.Enabled = True

        CheckedListBox1.Items.Clear()

        For Each teacher As String In Form3.Teachers.Keys
            CheckedListBox1.Items.Add(teacher)
        Next

        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

        CheckedListBox2.Items.Clear()

        Dim selectedTeachers As New List(Of String)()
        For Each item As String In CheckedListBox1.CheckedItems
            selectedTeachers.Add(item.ToString())
        Next

        If selectedTeachers.Count > 0 Then
            For Each teacher As String In selectedTeachers
                If Form3.Teachers.ContainsKey(teacher) Then
                    For Each unit As String In Form3.Teachers(teacher)
                        If Not CheckedListBox2.Items.Contains(unit) Then
                            CheckedListBox2.Items.Add(unit)
                        End If
                    Next
                End If
            Next
        End If

        CheckedListBox2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studentName As String = TextBox1.Text.Trim()

        Dim studentID As String = TextBox2.Text.Trim()

        Dim level As String = ComboBox1.SelectedItem?.ToString()

        Dim selectedTeachers As New List(Of String)()
        For Each item As String In CheckedListBox1.CheckedItems
            selectedTeachers.Add(item.ToString())
        Next

        Dim selectedUnits As New List(Of String)()
        For Each item As String In CheckedListBox2.CheckedItems
            selectedUnits.Add(item.ToString())
        Next

        If String.IsNullOrEmpty(studentName) Then
            MessageBox.Show("Please enter the student name.")
            Return
        End If

        If String.IsNullOrEmpty(studentID) Then
            MessageBox.Show("Please enter the student ID.")
            Return
        End If

        If String.IsNullOrEmpty(level) Then
            MessageBox.Show("Please select the student level.")
            Return
        End If

        If selectedTeachers.Count = 0 Then
            MessageBox.Show("Please select at least one teacher.")
            Return
        End If

        If selectedUnits.Count = 0 Then
            MessageBox.Show("Please select at least one unit for the student.")
            Return
        End If

        Dim studentData As New Dictionary(Of String, List(Of String))()
        studentData("Name") = New List(Of String) From {studentName}
        studentData("Level") = New List(Of String) From {level}
        studentData("Teacher") = selectedTeachers
        studentData("Units") = selectedUnits

        Students(studentID) = studentData

        MessageBox.Show("Student record created!" & vbCrLf &
                         "Student: " & studentName & vbCrLf &
                         "Student ID: " & studentID & vbCrLf &
                         "Level: " & level & vbCrLf &
                         "Teacher(s): " & String.Join(", ", selectedTeachers) & vbCrLf &
                         "Units: " & String.Join(", ", selectedUnits))

        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = -1
        CheckedListBox1.ClearSelected()
        CheckedListBox2.ClearSelected()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

End Class