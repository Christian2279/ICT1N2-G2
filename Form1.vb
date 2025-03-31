Imports System.Data.SqlClient
Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim StudentId As String = TextBox1.Text
        Dim StudentName As String = TextBox2.Text
        Dim RollNo As String = TextBox3.Text
        Dim Status As String = TextBox4.Text

        Dim Query As String = "insert into newtab values(@studentid,@studentname,@rollno,@status)"
        Using con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marilyn\Documents\Studentdb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cnn As SqlCommand = New SqlCommand(Query, con)
                cnn.Parameters.AddWithValue("@StudentId", StudentId)
                cnn.Parameters.AddWithValue("@StudentName", StudentName)
                cnn.Parameters.AddWithValue("@RollNo", RollNo)
                cnn.Parameters.AddWithValue("@Status", Status)

                con.Open()
                cnn.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record Saved Successfully")

            End Using

        End Using


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query As String = "select * from newtab"
        Using con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marilyn\Documents\Studentdb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cnn As SqlCommand = New SqlCommand(query, con)

                Using da As New SqlDataAdapter(cnn)

                    Using table As New DataTable()


                        da.Fill(table)
                        DataGridView1.DataSource = table




                    End Using



                End Using


            End Using


        End Using




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim StudentId As Integer = TextBox1.Text
        Dim StudentName As String = TextBox2.Text
        Dim RollNo As String = TextBox3.Text
        Dim Status As String = TextBox4.Text

        Dim Query As String = "update newtab set studentname=@studentname,rollno=@rollno,status=@status where studentid=@studentid"
        Using con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marilyn\Documents\Studentdb.mdf;Integrated Security=True;Connect Timeout=30")
            con.Open()
            Using cnn As SqlCommand = New SqlCommand(Query, con)
                cnn.Parameters.AddWithValue("@StudentId", StudentId)
                cnn.Parameters.AddWithValue("@StudentName", StudentName)
                cnn.Parameters.AddWithValue("@RollNo", RollNo)
                cnn.Parameters.AddWithValue("@Status", Status)
                cnn.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record Saved Successfully")
            End Using

        End Using





    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "select * from newtab"
        Using con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marilyn\Documents\Studentdb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cnn As SqlCommand = New SqlCommand(query, con)

                Using da As New SqlDataAdapter(cnn)

                    Using table As New DataTable()


                        da.Fill(table)
                        DataGridView1.DataSource = table


                    End Using



                End Using


            End Using


        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim StudentId As Integer = TextBox1.Text
        Dim query As String = "delete newtab where studentid=@studentid"
        Using con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marilyn\Documents\Studentdb.mdf;Integrated Security=True;Connect Timeout=30")
            con.Open()
            Using cnn As SqlCommand = New SqlCommand(query, con)
                cnn.Parameters.AddWithValue("@StudentId", StudentId)
                cnn.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record deleted Successfully")

            End Using

        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class
