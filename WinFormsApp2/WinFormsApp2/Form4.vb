Public Class Form4
    Public Shared AttendanceRecords As New Dictionary(Of String, Dictionary(Of DateTime, Dictionary(Of String, String)))()

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        For Each teacher As String In Form3.Teachers.Keys
            ComboBox1.Items.Add(teacher)
        Next

        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Level 2")
        ComboBox2.Items.Add("Level 3")

        DataGridView1.Rows.Clear()

        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("StudentName", "Student Name")
            DataGridView1.Columns.Add("StudentID", "Student ID")
            DataGridView1.Columns.Add("Level", "Level")
            DataGridView1.Columns.Add("Units", "Units")

            Dim chkCol As New DataGridViewCheckBoxColumn()
            chkCol.Name = "Attendance"
            chkCol.HeaderText = "Present"
            chkCol.FalseValue = False
            chkCol.TrueValue = True
            chkCol.ValueType = GetType(Boolean)
            DataGridView1.Columns.Add(chkCol)
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
                DataGridView1.Rows.Add(studentName, studentID, studentLevel, studentUnits, False)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim currentDate As DateTime = DateTime.Now.Date

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then
                Continue For
            End If

            Dim studentID As String = row.Cells("StudentID").Value.ToString()

            Dim attendanceStatus As String
            If Convert.ToBoolean(row.Cells("Attendance").Value) Then
                attendanceStatus = "Present"
            Else
                attendanceStatus = "Absent"
            End If

            If Not AttendanceRecords.ContainsKey(studentID) Then
                AttendanceRecords(studentID) = New Dictionary(Of DateTime, Dictionary(Of String, String))()
            End If

            If Not AttendanceRecords(studentID).ContainsKey(currentDate) Then
                AttendanceRecords(studentID)(currentDate) = New Dictionary(Of String, String)()
            End If

            Dim units As List(Of String) = Form2.Students(studentID)("Units")
            For Each unit As String In units
                AttendanceRecords(studentID)(currentDate)(unit) = attendanceStatus
            Next
        Next

        MessageBox.Show("Attendance has been marked for today.")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class