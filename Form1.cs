using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace StudentRegistrationForm
{
    public partial class Form1 : Form
    {
        private readonly TextBox txtName = new TextBox();
        private readonly TextBox txtEmail = new TextBox();

        private readonly RadioButton male = new RadioButton();
        private readonly RadioButton female = new RadioButton();

        private readonly ComboBox course = new ComboBox();

        private readonly CheckBox cricket = new CheckBox();
        private readonly CheckBox music = new CheckBox();
        private readonly CheckBox reading = new CheckBox();

        private readonly DateTimePicker dob = new DateTimePicker();

        private readonly ListBox result = new ListBox();

        public Form1()
        {
           

            Text = "Student Registration Form";
            Size = new Size(520, 650);
            StartPosition = FormStartPosition.CenterScreen;

            AddLabel("Student Name:", 20, 20);
            txtName.SetBounds(150, 20, 220, 25);
            Controls.Add(txtName);

            AddLabel("Email:", 20, 60);
            txtEmail.SetBounds(150, 60, 220, 25);
            Controls.Add(txtEmail);

            AddLabel("Gender:", 20, 100);

            male.Text = "Male";
            male.SetBounds(150, 100, 80, 25);
            Controls.Add(male);

            female.Text = "Female";
            female.SetBounds(240, 100, 90, 25);
            Controls.Add(female);

            AddLabel("Course:", 20, 140);

            course.SetBounds(150, 140, 220, 25);
            course.DropDownStyle = ComboBoxStyle.DropDownList;
            course.Items.AddRange(new object[]
            {
                "BCA", "B.Tech", "MCA", "Diploma"
            });
            Controls.Add(course);

            AddLabel("Hobbies:", 20, 180);

            cricket.Text = "Cricket";
            cricket.SetBounds(150, 180, 80, 25);
            Controls.Add(cricket);

            music.Text = "Music";
            music.SetBounds(240, 180, 80, 25);
            Controls.Add(music);

            reading.Text = "Reading";
            reading.SetBounds(330, 180, 90, 25);
            Controls.Add(reading);

            AddLabel("Date of Birth:", 20, 220);

            dob.SetBounds(150, 220, 220, 25);
            dob.MaxDate = DateTime.Today;
            Controls.Add(dob);

            Button submit = new Button();
            submit.Text = "Submit";
            submit.SetBounds(150, 270, 120, 35);
            submit.Click += Submit_Click;
            Controls.Add(submit);

            AddLabel("Student Details:", 20, 330);

            result.SetBounds(150, 330, 300, 200);
            Controls.Add(result);
        }

        private void AddLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.SetBounds(x, y, 120, 25);
            Controls.Add(lbl);
        }

        private void Submit_Click(object? sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (name == "" || email == "" ||
                (!male.Checked && !female.Checked) ||
                course.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields!");
                return;
            }

            try
            {
                MailAddress address = new MailAddress(email);

                if (address.Address != email)
                {
                    MessageBox.Show("Enter a valid Email!");
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a valid Email!");
                return;
            }

            string gender = male.Checked ? "Male" : "Female";

            List<string> hobbies = new List<string>();

            if (cricket.Checked) hobbies.Add("Cricket");
            if (music.Checked) hobbies.Add("Music");
            if (reading.Checked) hobbies.Add("Reading");

            string hobby = hobbies.Count > 0
                ? string.Join(", ", hobbies)
                : "None";

            result.Items.Clear();

            result.Items.Add("Name: " + name);
            result.Items.Add("Email: " + email);
            result.Items.Add("Gender: " + gender);
            result.Items.Add("Course: " + course.Text);
            result.Items.Add("Hobbies: " + hobby);
            result.Items.Add("DOB: " + dob.Value.ToShortDateString());

            MessageBox.Show("Registration Successful!");
        }
    }
}
