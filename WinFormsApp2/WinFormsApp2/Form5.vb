Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        For Each teacher As String In Form3.Teachers.Keys
            ComboBox1.Items.Add(teacher)
        Next

        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Level 2")
        ComboBox2.Items.Add("Level 3")

        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("StudentName", "Student Name")
            DataGridView1.Columns.Add("StudentID", "Student ID")
            DataGridView1.Columns.Add("Level", "Level")
            DataGridView1.Columns.Add("Units", "Units")

            DataGridView1.Columns.Add("Attendance", "Attendance")
        End If

        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedTeacher As String = ComboBox1.SelectedItem?.ToString()
        Dim selectedLevel As String = ComboBox2.SelectedItem?.ToString()

        If String.IsNullOrEmpty(selectedTeacher) Then
            MessageBox.Show("Please select a teacher.")
            Return
        End If

        If String.IsNullOrEmpty(selectedLevel) Then
            MessageBox.Show("Please select a level.")
            Return
        End If

        DataGridView1.Rows.Clear()

        For Each studentID As String In Form2.Students.Keys
            Dim studentData = Form2.Students(studentID)
            Dim studentName As String = studentData("Name")(0)
            Dim studentLevel As String = studentData("Level")(0)
            Dim studentTeachers As List(Of String) = studentData("Teacher")
            Dim studentUnits As String = String.Join(", ", studentData("Units"))

            If studentLevel = selectedLevel AndAlso studentTeachers.Contains(selectedTeacher) Then
                Dim attendanceStatus As Integer = 0
                If Form4.AttendanceRecords.ContainsKey(studentID) Then
                    Dim currentDate As DateTime = DateTime.Now.Date
                    If Form4.AttendanceRecords(studentID).ContainsKey(currentDate) Then
                        For Each unit As String In studentData("Units")
                            If Form4.AttendanceRecords(studentID)(currentDate).ContainsKey(unit) Then
                                If Form4.AttendanceRecords(studentID)(currentDate)(unit) = "Present" Then
                                    attendanceStatus = 1
                                End If
                                Exit For
                            End If
                        Next
                    End If
                End If

                DataGridView1.Rows.Add(studentName, studentID, studentLevel, studentUnits, attendanceStatus)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class