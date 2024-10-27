namespace OrdersFilteringApp
{
	partial class OrdersFilteringApp
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			GetOrdersFromTextFileButton = new Button();
			OrdersListDataGrid = new DataGridView();
			DistrictComboBox = new ComboBox();
			FilterTimeButton = new Button();
			SaveOrdersToTextFileButton = new Button();
			GetOrdersFromDbFileButton = new Button();
			GetOrdersLabel = new Label();
			CancelFilteringButton = new Button();
			SelectedDistrictLabel = new Label();
			SaveOrdersToDbFileButton = new Button();
			SaveOrdersLabel = new Label();
			((System.ComponentModel.ISupportInitialize)OrdersListDataGrid).BeginInit();
			SuspendLayout();
			// 
			// GetOrdersFromTextFileButton
			// 
			GetOrdersFromTextFileButton.Location = new Point(614, 46);
			GetOrdersFromTextFileButton.Name = "GetOrdersFromTextFileButton";
			GetOrdersFromTextFileButton.Size = new Size(120, 25);
			GetOrdersFromTextFileButton.TabIndex = 0;
			GetOrdersFromTextFileButton.Text = "Текстовый файл";
			GetOrdersFromTextFileButton.UseVisualStyleBackColor = true;
			GetOrdersFromTextFileButton.Click += GetOrdersFromTextFileButton_Click;
			// 
			// OrdersListDataGrid
			// 
			dataGridViewCellStyle1.NullValue = null;
			OrdersListDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			OrdersListDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			OrdersListDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			OrdersListDataGrid.Location = new Point(12, 12);
			OrdersListDataGrid.Name = "OrdersListDataGrid";
			OrdersListDataGrid.Size = new Size(555, 300);
			OrdersListDataGrid.TabIndex = 1;
			// 
			// DistrictComboBox
			// 
			DistrictComboBox.FormattingEnabled = true;
			DistrictComboBox.Location = new Point(614, 135);
			DistrictComboBox.Name = "DistrictComboBox";
			DistrictComboBox.RightToLeft = RightToLeft.No;
			DistrictComboBox.Size = new Size(120, 23);
			DistrictComboBox.TabIndex = 2;
			// 
			// FilterTimeButton
			// 
			FilterTimeButton.Location = new Point(614, 164);
			FilterTimeButton.Name = "FilterTimeButton";
			FilterTimeButton.Size = new Size(120, 25);
			FilterTimeButton.TabIndex = 4;
			FilterTimeButton.Text = "Отфильтровать";
			FilterTimeButton.UseVisualStyleBackColor = true;
			FilterTimeButton.Click += FilterTimeButton_Click;
			// 
			// SaveOrdersToTextFileButton
			// 
			SaveOrdersToTextFileButton.Location = new Point(614, 256);
			SaveOrdersToTextFileButton.Name = "SaveOrdersToTextFileButton";
			SaveOrdersToTextFileButton.Size = new Size(120, 25);
			SaveOrdersToTextFileButton.TabIndex = 5;
			SaveOrdersToTextFileButton.Text = "Текстовый файл";
			SaveOrdersToTextFileButton.UseVisualStyleBackColor = true;
			SaveOrdersToTextFileButton.Click += SaveOrdersToTextFileButton_Click;
			// 
			// GetOrdersFromDbFileButton
			// 
			GetOrdersFromDbFileButton.Location = new Point(614, 77);
			GetOrdersFromDbFileButton.Name = "GetOrdersFromDbFileButton";
			GetOrdersFromDbFileButton.Size = new Size(120, 25);
			GetOrdersFromDbFileButton.TabIndex = 6;
			GetOrdersFromDbFileButton.Text = "Файл базы данных";
			GetOrdersFromDbFileButton.UseVisualStyleBackColor = true;
			GetOrdersFromDbFileButton.Click += GetOrdersFromDbFileButton_Click;
			// 
			// GetOrdersLabel
			// 
			GetOrdersLabel.Location = new Point(614, 12);
			GetOrdersLabel.Name = "GetOrdersLabel";
			GetOrdersLabel.Size = new Size(120, 30);
			GetOrdersLabel.TabIndex = 7;
			GetOrdersLabel.Text = "Получить заказы через:";
			GetOrdersLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// CancelFilteringButton
			// 
			CancelFilteringButton.Location = new Point(599, 195);
			CancelFilteringButton.Name = "CancelFilteringButton";
			CancelFilteringButton.Size = new Size(150, 25);
			CancelFilteringButton.TabIndex = 8;
			CancelFilteringButton.Text = "Отменить фильтрацию";
			CancelFilteringButton.UseVisualStyleBackColor = true;
			CancelFilteringButton.Click += CancelFilteringButton_Click;
			// 
			// SelectedDistrictLabel
			// 
			SelectedDistrictLabel.Location = new Point(614, 110);
			SelectedDistrictLabel.Name = "SelectedDistrictLabel";
			SelectedDistrictLabel.Size = new Size(120, 15);
			SelectedDistrictLabel.TabIndex = 9;
			SelectedDistrictLabel.Text = "Выбранный район:";
			SelectedDistrictLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// SaveOrdersToDbFileButton
			// 
			SaveOrdersToDbFileButton.Location = new Point(614, 287);
			SaveOrdersToDbFileButton.Name = "SaveOrdersToDbFileButton";
			SaveOrdersToDbFileButton.Size = new Size(120, 25);
			SaveOrdersToDbFileButton.TabIndex = 10;
			SaveOrdersToDbFileButton.Text = "Файл базы данных";
			SaveOrdersToDbFileButton.UseVisualStyleBackColor = true;
			SaveOrdersToDbFileButton.Click += SaveOrdersToDbFileButton_Click;
			// 
			// SaveOrdersLabel
			// 
			SaveOrdersLabel.Location = new Point(614, 223);
			SaveOrdersLabel.Name = "SaveOrdersLabel";
			SaveOrdersLabel.Size = new Size(120, 30);
			SaveOrdersLabel.TabIndex = 11;
			SaveOrdersLabel.Text = "Сохранить заказы как:";
			SaveOrdersLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// OrdersFilteringApp
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(770, 317);
			Controls.Add(SaveOrdersLabel);
			Controls.Add(SaveOrdersToDbFileButton);
			Controls.Add(SelectedDistrictLabel);
			Controls.Add(CancelFilteringButton);
			Controls.Add(GetOrdersLabel);
			Controls.Add(GetOrdersFromDbFileButton);
			Controls.Add(SaveOrdersToTextFileButton);
			Controls.Add(FilterTimeButton);
			Controls.Add(DistrictComboBox);
			Controls.Add(OrdersListDataGrid);
			Controls.Add(GetOrdersFromTextFileButton);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "OrdersFilteringApp";
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "OrdersFilteringApp";
			((System.ComponentModel.ISupportInitialize)OrdersListDataGrid).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button GetOrdersFromTextFileButton;
		private ComboBox DistrictComboBox;
		public DataGridView OrdersListDataGrid;
		private Button FilterTimeButton;
		private Button SaveOrdersToTextFileButton;
		private Button GetOrdersFromDbFileButton;
		private Label GetOrdersLabel;
		private Button CancelFilteringButton;
		private Label SelectedDistrictLabel;
		private Button SaveOrdersToDbFileButton;
		private Label SaveOrdersLabel;
	}
}
