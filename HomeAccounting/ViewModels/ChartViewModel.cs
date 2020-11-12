using HomeAccounting.Models;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.ViewModels
{
    class ChartViewModel
    {
        private DataManager dataManager;

        public ChartViewModel()
        {
            dataManager = new DataManager();

            var incomeOperations = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Income").OrderBy(o => o.Date);
            var expenseOperations = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Expense").OrderBy(o => o.Date);

            // Create the plot model
            var tmp = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };


            var incomes = new LineSeries { Title = "Income", MarkerType = MarkerType.Circle };

            foreach(var o in incomeOperations)
            {
                incomes.Points.Add(new DataPoint(DateTimeAxis.ToDouble(o.Date), Convert.ToDouble(o.Sum)));
            }
    
            var expenses = new LineSeries { Title = "Expense", MarkerType = MarkerType.Circle };

            foreach (var o in expenseOperations)
            {
                expenses.Points.Add(new DataPoint(DateTimeAxis.ToDouble(o.Date), Convert.ToDouble(o.Sum)));
            }


            // Add the series to the plot model
            tmp.Series.Add(incomes);
            tmp.Series.Add(expenses);

            // Axes are created automatically if they are not defined

            // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
            this.Model = tmp;
        }

        /// <summary>
        /// Gets the plot model.
        /// </summary>
        public PlotModel Model { get; private set; }
    }
}
