using HomeAccounting.Models;
using MaterialDesignColors.Recommended;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HomeAccounting.ViewModels
{
    class ChartViewModel
    {
        private DataManager dataManager;

        /// <summary> Gets the plot model. </summary>
        public PlotModel Model { get; private set; }

        public ChartViewModel()
        {
            dataManager = new DataManager();

            var incomeOperations = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Income").OrderBy(o => o.Date);
            var expenseOperations = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Expense").OrderBy(o => o.Date);

            // Create the plot model
            var tmp = new PlotModel();
            tmp.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM/yy" });
            tmp.Axes.Add(new LogarithmicAxis { Position = AxisPosition.Left, StringFormat = "### ### ###" });


            var incomes = new LineSeries { Title = "Income", MarkerType = MarkerType.Circle };

            foreach (var o in incomeOperations)
            {
                incomes.Points.Add(new DataPoint(DateTimeAxis.ToDouble(o.Date), Convert.ToDouble(o.Sum)));
            }
    
            var expenses = new LineSeries { Title = "Expense", MarkerType = MarkerType.Circle };

            foreach (var o in expenseOperations)
            {
                expenses.Points.Add(new DataPoint(DateTimeAxis.ToDouble(o.Date), Convert.ToDouble(o.Sum)));
            }


            tmp.Series.Add(incomes);
            tmp.Series.Add(expenses);

            this.Model = tmp;
        }

    }
}
