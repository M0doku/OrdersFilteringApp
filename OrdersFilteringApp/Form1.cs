using System.Diagnostics;
using System.IO;
using Serilog;
using Microsoft.EntityFrameworkCore;
using static OrdersFilteringApp.OrdersFilteringApp;

namespace OrdersFilteringApp
{
	public partial class OrdersFilteringApp : Form
	{
		List<Order> ordersList = new List<Order>();
		List<Order> filteredOrdersList = new List<Order>();
		static string DbPath = AppDomain.CurrentDomain.BaseDirectory + "_deliveryOrders.db";
		public OrdersFilteringApp()
		{
			InitializeComponent();
			string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmm");
			if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Logs/"))
			{
				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Logs/");
			}
			Log.Logger = new LoggerConfiguration()
				.WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}/Logs/_deliveryLog_{timestamp}.txt")
				.CreateLogger();
			Log.Information("Program started");
		}


		private void GetOrdersFromTextFile()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "txt files (*.txt)|*.txt";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				using (StreamReader sr = new StreamReader(ofd.FileName))
				{
					Order order = new Order();
					string line;
					if (sr.Peek == null)
					{
						MessageBox.Show("В файле нет данных");
						Log.Information("No data in the file.");
					}
					else
					{
						ordersList.Clear();
					}
					while ((line = sr.ReadLine()!) != null)
					{
						try
						{
							var values = line.Split(' ');
							int id = Int32.Parse(values[0]);
							double weight = double.Parse(values[1]);
							DateTime dt = DateTime.ParseExact(values[3] + ' ' + values[4], "yyyy-MM-dd HH:mm:ss",
										   System.Globalization.CultureInfo.InvariantCulture);
							ordersList.Add(order = new Order(id, weight, values[2], dt));
							Log.Information($"Order added: ID: {order.ID}, Weight: {order.Weight}, District: {order.District}, Time: {order.Time}");
						}
						catch (Exception ex)
						{
							MessageBox.Show($"Некорректные данные были пропущены.");
							Log.Error("Error is happened: " + ex.Message);
						}
					}
					GetDistricts();
					OrdersListDataGrid.DataSource = null;
				}
			}
		}

		private void GetOrdersFromDbFile()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "db files (*.db)|*.db";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				File.Copy(ofd.FileName, DbPath, true);
				using (ApplicationContext db = new ApplicationContext())
				{
					try
					{
						ordersList = db.Orders.ToList();
						OrdersListDataGrid.DataSource = ordersList;
						OrdersListDataGrid.Columns["Time"].DefaultCellStyle.Format = "G";				
						foreach (var order in db.Orders)
						{
							Log.Information($"Order added: ID: {order.ID}, Weight: {order.Weight}, District: {order.District}, Time: {order.Time}");
						}
						GetDistricts();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Выберите файл в корректном формате.");
						Log.Error("Error is happened: " + ex.Message);
					}
				}
			}

		}

		private void FilteringOrders()
		{
			string selectedDistrict = string.Empty;
			if (DistrictComboBox.SelectedValue?.ToString() != null)
			{
				selectedDistrict = DistrictComboBox.SelectedValue.ToString();
				var firstOrder = ordersList.Where(x => x.District == selectedDistrict).OrderBy(x => x.Time).First();
				Debug.WriteLine($"ID: {firstOrder.ID}, Weight: {firstOrder.Weight}, District: {firstOrder.District}, Time: {firstOrder.Time}");
				filteredOrdersList = ordersList.Where(x => x.District == selectedDistrict).Where(x => x.Time >= firstOrder.Time && x.Time <= firstOrder.Time.AddMinutes(30)).OrderBy(x => x.Time).ToList();
				OrdersListDataGrid.DataSource = filteredOrdersList;
				Log.Information($"Orders filtered by district: {selectedDistrict}");
			}
			else
			{
				MessageBox.Show("Выберите район для фильтрации.");
				Log.Information("No data to filter.");
			}
		}

		private void SaveOrdersToTextFile()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "txt files (*.txt)|*.txt";
			sfd.FileName = "_deliveryOrder";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter sw = new StreamWriter(sfd.FileName))
				{
					if (filteredOrdersList.Count() > 0)
					{
						foreach (var order in filteredOrdersList)
						{
							sw.WriteLine($"{order.ID} {order.Weight} {order.District} {order.Time}");
							Log.Information($"Order saved: ID: {order.ID} Weight: {order.Weight} District: {order.District} Time: {order.Time}");
						}
					}
					else
					{
						foreach (var order in ordersList)
						{
							sw.WriteLine($"{order.ID} {order.Weight} {order.District} {order.Time}");
							Log.Information($"Order saved: ID: {order.ID} Weight: {order.Weight} District: {order.District} Time: {order.Time}");
						}
					}
					Log.Information($"Orders saved to file {sfd.FileName}");
				}
			}
		}

		private void SaveOrdersToDbFile()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "db files (*.db)|*.db";
			sfd.FileName = "_deliveryOrder";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (ApplicationContext db = new ApplicationContext())
				{
					db.Database.ExecuteSqlRaw("DELETE FROM Orders");
					if (filteredOrdersList.Count > 0)
					{
						foreach (var order in filteredOrdersList)
						{
							db.Orders.Add(order);
							Log.Information($"Order saved: ID: {order.ID} Weight: {order.Weight} District: {order.District} Time: {order.Time}");
						}
					}
					else
					{
						foreach (var order in ordersList)
						{
							db.Orders.Add(order);
							Log.Information($"Order saved: ID: {order.ID} Weight: {order.Weight} District: {order.District} Time: {order.Time}");
						}

					}
					db.SaveChanges();
				}
				File.Copy(DbPath, sfd.FileName, true);
				Log.Information($"Orders saved to file {sfd.FileName}");
			}
		}

		private void GetOrdersFromTextFileButton_Click(object sender, EventArgs e)
		{
			GetOrdersFromTextFile();
			OrdersListDataGrid.DataSource = ordersList;
			OrdersListDataGrid.Columns["Time"].DefaultCellStyle.Format = "G";
		}
		public class Order
		{
			public int ID { get; set; }
			public double Weight { get; set; }
			public string District { get; set; }
			public DateTime Time { get; set; }
			public Order(int ID, double Weight, string District, DateTime Time)
			{
				this.ID = ID;
				this.Weight = Weight;
				this.District = District;
				this.Time = Time;
			}
			public Order() { }
		}

		public partial class ApplicationContext : DbContext
		{
			public DbSet<Order> Orders { get; set; } = null!;
			public ApplicationContext() => Database.EnsureCreated();
			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				optionsBuilder.UseSqlite($"Data Source={DbPath}");
			}

		}

		private void GetDistricts()
		{
			var districts = ordersList.Select(x => x.District);
			var uniqueDistricts = districts.Distinct().ToList();
			DistrictComboBox.DataSource = uniqueDistricts;
			foreach (var district in uniqueDistricts)
			{
				Log.Information($"District loaded: {district}");
			}
		}

		private void FilterTimeButton_Click(object sender, EventArgs e)
		{
			FilteringOrders();
		}

		private void SaveOrdersToTextFileButton_Click(object sender, EventArgs e)
		{
			SaveOrdersToTextFile();
		}

		private void GetOrdersFromDbFileButton_Click(object sender, EventArgs e)
		{
			GetOrdersFromDbFile();
		}

		private void CancelFilteringButton_Click(object sender, EventArgs e)
		{
			OrdersListDataGrid.DataSource = ordersList;
			Log.Information("Orders restored.");
		}

		private void SaveOrdersToDbFileButton_Click(object sender, EventArgs e)
		{
			SaveOrdersToDbFile();
		}

	}
}
