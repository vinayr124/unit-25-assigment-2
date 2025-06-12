Public Class Form3
    Public Shared Teachers As New Dictionary(Of String, List(Of String))()
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckedListBox1.Items.Add("Unit 1: The Online World")
        CheckedListBox1.Items.Add("Unit 2: Technology Systems")
        CheckedListBox1.Items.Add("Unit 3: A Digital Portfolio")
        CheckedListBox1.Items.Add("Unit 4: Creating Digital Animation")
        CheckedListBox1.Items.Add("Unit 5: Creating Digital Audio")
        CheckedListBox1.Items.Add("Unit 6: Creating Digital Graphics")
        CheckedListBox1.Items.Add("Unit 7: Creating Digital Video")
        CheckedListBox1.Items.Add("Unit 8: Mobile Apps Development")
        CheckedListBox1.Items.Add("Unit 9: Spreadsheet Development")
        CheckedListBox1.Items.Add("Unit 10: Database Development")
        CheckedListBox1.Items.Add("Unit 11: Computer Networks")
        CheckedListBox1.Items.Add("Unit 12: Software Development")
        CheckedListBox1.Items.Add("Unit 13: Website Development")
        CheckedListBox1.Items.Add("Unit 14: Installing and Maintaining Computer Hardware")
        CheckedListBox1.Items.Add("Unit 15: Installing and Maintaining Computer Software")
        CheckedListBox1.Items.Add("Unit 16: Automated Computer Systems")
        CheckedListBox1.Items.Add("Unit 17: Multimedia Products Development")
        CheckedListBox1.Items.Add("Unit 18: Computational Thinking")
        CheckedListBox1.Items.Add("Unit 19: Computing in the Workplace")
        CheckedListBox1.Items.Add("Unit 20: Building a Personal Computer")
        CheckedListBox1.Items.Add("Unit 21: A Technology Business")
        CheckedListBox1.Items.Add("Unit 22: Computer Security in Practice")
        CheckedListBox1.Items.Add("Unit 23: Computer Systems Support in Practice")
        CheckedListBox1.Items.Add("Unit 24: Software Systems Development")
        CheckedListBox1.Items.Add("Unit 25: IT Work Experience")

        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim teacherName As String = TextBox1.Text.Trim()
        Dim teacherID As String = TextBox2.Text.Trim()

        If String.IsNullOrEmpty(teacherName) Or String.IsNullOrEmpty(teacherID) Then
            MessageBox.Show("Please enter both the teacher name and teacher ID.")
            Return
        End If

        Dim selectedUnits As New List(Of String)()
        For Each item As String In CheckedListBox1.CheckedItems
            selectedUnits.Add(item.ToString())
        Next

        If selectedUnits.Count = 0 Then
            MessageBox.Show("Please select at least one unit for the teacher.")
            Return
        End If

        If Teachers.ContainsKey(teacherID) Then
            MessageBox.Show("This teacher has already been added.")
            Return
        End If

        Teachers(teacherName) = selectedUnits

        MessageBox.Show("Teacher record created!" & vbCrLf &
                         "Teacher: " & teacherName & vbCrLf &
                         "Teacher ID: " & teacherID & vbCrLf &
                         "Units: " & String.Join(", ", selectedUnits))

        TextBox1.Clear()
        TextBox2.Clear()
        CheckedListBox1.ClearSelected()

        CheckedListBox1.Items.Clear()
        CheckedListBox1.Items.Add("Unit 1: The Online World")
        CheckedListBox1.Items.Add("Unit 2: Technology Systems")
        CheckedListBox1.Items.Add("Unit 3: A Digital Portfolio")
        CheckedListBox1.Items.Add("Unit 4: Creating Digital Animation")
        CheckedListBox1.Items.Add("Unit 5: Creating Digital Audio")
        CheckedListBox1.Items.Add("Unit 6: Creating Digital Graphics")
        CheckedListBox1.Items.Add("Unit 7: Creating Digital Video")
        CheckedListBox1.Items.Add("Unit 8: Mobile Apps Development")
        CheckedListBox1.Items.Add("Unit 9: Spreadsheet Development")
        CheckedListBox1.Items.Add("Unit 10: Database Development")
        CheckedListBox1.Items.Add("Unit 11: Computer Networks")
        CheckedListBox1.Items.Add("Unit 12: Software Development")
        CheckedListBox1.Items.Add("Unit 13: Website Development")
        CheckedListBox1.Items.Add("Unit 14: Installing and Maintaining Computer Hardware")
        CheckedListBox1.Items.Add("Unit 15: Installing and Maintaining Computer Software")
        CheckedListBox1.Items.Add("Unit 16: Automated Computer Systems")
        CheckedListBox1.Items.Add("Unit 17: Multimedia Products Development")
        CheckedListBox1.Items.Add("Unit 18: Computational Thinking")
        CheckedListBox1.Items.Add("Unit 19: Computing in the Workplace")
        CheckedListBox1.Items.Add("Unit 20: Building a Personal Computer")
        CheckedListBox1.Items.Add("Unit 21: A Technology Business")
        CheckedListBox1.Items.Add("Unit 22: Computer Security in Practice")
        CheckedListBox1.Items.Add("Unit 23: Computer Systems Support in Practice")
        CheckedListBox1.Items.Add("Unit 24: Software Systems Development")
        CheckedListBox1.Items.Add("Unit 25: IT Work Experience")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class