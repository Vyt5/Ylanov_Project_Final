
namespace My_Tickets
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.events = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.price = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.place = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.priceS = new System.Windows.Forms.TextBox();
            this.addressS = new System.Windows.Forms.TextBox();
            this.placeS = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.TextBox();
            this.dateS = new System.Windows.Forms.TextBox();
            this.insert_data = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // events
            // 
            this.events.Location = new System.Drawing.Point(12, 48);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(119, 20);
            this.events.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.price);
            this.panel1.Controls.Add(this.address);
            this.panel1.Controls.Add(this.place);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.priceS);
            this.panel1.Controls.Add(this.addressS);
            this.panel1.Controls.Add(this.placeS);
            this.panel1.Controls.Add(this.time);
            this.panel1.Controls.Add(this.dateS);
            this.panel1.Controls.Add(this.events);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 97);
            this.panel1.TabIndex = 1;
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(532, 32);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(33, 13);
            this.price.TabIndex = 11;
            this.price.Text = "Цена";
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(411, 32);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(38, 13);
            this.address.TabIndex = 10;
            this.address.Text = "Адрес";
            // 
            // place
            // 
            this.place.AutoSize = true;
            this.place.Location = new System.Drawing.Point(282, 32);
            this.place.Name = "place";
            this.place.Size = new System.Drawing.Size(39, 13);
            this.place.TabIndex = 9;
            this.place.Text = "Место";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Время";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Мероприятие";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // priceS
            // 
            this.priceS.Location = new System.Drawing.Point(535, 48);
            this.priceS.Name = "priceS";
            this.priceS.Size = new System.Drawing.Size(50, 20);
            this.priceS.TabIndex = 5;
            // 
            // addressS
            // 
            this.addressS.Location = new System.Drawing.Point(411, 47);
            this.addressS.Name = "addressS";
            this.addressS.Size = new System.Drawing.Size(118, 20);
            this.addressS.TabIndex = 4;
            // 
            // placeS
            // 
            this.placeS.Location = new System.Drawing.Point(282, 47);
            this.placeS.Name = "placeS";
            this.placeS.Size = new System.Drawing.Size(123, 20);
            this.placeS.TabIndex = 3;
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(223, 48);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(53, 20);
            this.time.TabIndex = 2;
            this.time.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dateS
            // 
            this.dateS.Location = new System.Drawing.Point(137, 47);
            this.dateS.Name = "dateS";
            this.dateS.Size = new System.Drawing.Size(80, 20);
            this.dateS.TabIndex = 1;
            this.dateS.TextChanged += new System.EventHandler(this.dateS_TextChanged);
            // 
            // insert_data
            // 
            this.insert_data.Location = new System.Drawing.Point(258, 95);
            this.insert_data.Name = "insert_data";
            this.insert_data.Size = new System.Drawing.Size(75, 23);
            this.insert_data.TabIndex = 12;
            this.insert_data.Text = "Добавить";
            this.insert_data.UseVisualStyleBackColor = true;
            this.insert_data.Click += new System.EventHandler(this.insert_data_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 130);
            this.Controls.Add(this.insert_data);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox events;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox addressS;
        private System.Windows.Forms.TextBox placeS;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.TextBox dateS;
        private System.Windows.Forms.TextBox priceS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label place;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button insert_data;
    }
}